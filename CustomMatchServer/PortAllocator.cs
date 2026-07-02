using System.Net;
using System.Net.Sockets;

namespace BapCustomServer;

public sealed class PortAllocator
{
    private readonly object _gate = new();
    private readonly HashSet<int> _reserved = [];

    // Optional guard for Wine UDP teardown. Keep this at zero for fixed-port AMP
    // deployments; the allocator already probes the OS before reusing a port.
    private readonly Dictionary<int, DateTime> _cooldown = [];

    /// <summary>
    /// How long a released port stays parked in the cooldown queue before it
    /// can be handed out again. Defaults to no artificial cooldown.
    /// </summary>
    public TimeSpan CooldownDuration { get; set; } = TimeSpan.Zero;

    public int ReserveFrom(int startPort, int range)
    {
        return ReserveFrom(startPort, range, requireUdpFree: false);
    }

    public int ReserveUdpFrom(int startPort, int range)
    {
        return ReserveFrom(startPort, range, requireUdpFree: true);
    }

    private int ReserveFrom(int startPort, int range, bool requireUdpFree)
    {
        lock (_gate)
        {
            PurgeExpiredCooldownsLocked();

            for (int port = startPort; port < startPort + range; port++)
            {
                if (_reserved.Contains(port))
                {
                    continue;
                }

                if (CooldownDuration > TimeSpan.Zero && _cooldown.ContainsKey(port))
                {
                    // Still cooling down; skip even if the OS would currently
                    // accept the bind, to give wine time to fully release the
                    // previous UDP socket.
                    continue;
                }

                if (IsTcpFree(port) && (!requireUdpFree || IsUdpFree(port)))
                {
                    _reserved.Add(port);
                    return port;
                }
            }
        }

        throw new InvalidOperationException($"No free port found in range {startPort}-{startPort + range - 1}.");
    }

    public void Release(params int[] ports)
    {
        ReleaseCore(addCooldown: true, ports);
    }

    public void ReleaseImmediately(params int[] ports)
    {
        ReleaseCore(addCooldown: false, ports);
    }

    private void ReleaseCore(bool addCooldown, params int[] ports)
    {
        DateTime now = DateTime.UtcNow;
        lock (_gate)
        {
            foreach (int port in ports)
            {
                if (port <= 0)
                {
                    continue;
                }

                _reserved.Remove(port);
                if (addCooldown && CooldownDuration > TimeSpan.Zero)
                {
                    // Park the port in the cooldown queue instead of immediately
                    // making it available again. PurgeExpiredCooldownsLocked() on
                    // the next ReserveFrom() will evict it once CooldownDuration
                    // has elapsed.
                    _cooldown[port] = now;
                }
                else
                {
                    _cooldown.Remove(port);
                }
            }
        }
    }

    /// <summary>
    /// Test/diagnostic helper: returns true if the given port is currently
    /// parked in the cooldown queue.
    /// </summary>
    public bool IsInCooldown(int port)
    {
        lock (_gate)
        {
            PurgeExpiredCooldownsLocked();
            return _cooldown.ContainsKey(port);
        }
    }

    private void PurgeExpiredCooldownsLocked()
    {
        if (_cooldown.Count == 0 || CooldownDuration <= TimeSpan.Zero)
        {
            _cooldown.Clear();
            return;
        }

        DateTime cutoff = DateTime.UtcNow - CooldownDuration;
        List<int>? expired = null;
        foreach (KeyValuePair<int, DateTime> entry in _cooldown)
        {
            if (entry.Value <= cutoff)
            {
                expired ??= new List<int>();
                expired.Add(entry.Key);
            }
        }

        if (expired is null)
        {
            return;
        }

        foreach (int port in expired)
        {
            _cooldown.Remove(port);
        }
    }

    private static bool IsTcpFree(int port)
    {
        try
        {
            using var tcp = new TcpListener(IPAddress.Loopback, port);
            tcp.Start();
            tcp.Stop();
            return true;
        }
        catch (SocketException)
        {
            return false;
        }
    }

    private static bool IsUdpFree(int port)
    {
        try
        {
            using var udp = new UdpClient(AddressFamily.InterNetwork);
            udp.Client.Bind(new IPEndPoint(IPAddress.Loopback, port));
            return true;
        }
        catch (SocketException)
        {
            return false;
        }
    }
}
