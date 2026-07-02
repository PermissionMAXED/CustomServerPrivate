using BapCustomServer;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace BapCustomServer.Tests;

// F080 client identity resolution: ClientIdentityResolver.Resolve picks accountId/username/discriminator
// from headers > query > sid cookie > fallback, in that precedence order, and normalizes the result.
public class ClientIdentityResolverTests
{
    private static HttpContext Ctx(Action<HttpContext> configure)
    {
        var ctx = new DefaultHttpContext();
        configure(ctx);
        return ctx;
    }

    [Fact] // empty request -> falls back to the provided fallback identity
    public void NoSignals_UsesFallback()
    {
        var id = ClientIdentityResolver.Resolve(new DefaultHttpContext(), "custom-7", "Player7", 1007);
        Assert.Equal("custom-7", id.AccountId);
        Assert.Equal("Player7", id.Username);
        Assert.Equal(1007, id.Discriminator);
    }

    [Fact] // X-BAP-* headers win over everything and are trimmed/parsed
    public void Headers_TakePrecedence()
    {
        var ctx = Ctx(c =>
        {
            c.Request.Headers["X-BAP-AccountId"] = "  acct-hdr  ";
            c.Request.Headers["X-BAP-Username"] = " NameHdr ";
            c.Request.Headers["X-BAP-Discriminator"] = "42";
            c.Request.QueryString = new QueryString("?accountId=acct-q&username=NameQ&discriminator=99");
        });

        var id = ClientIdentityResolver.Resolve(ctx, "fb", "fbName", 1);

        Assert.Equal("acct-hdr", id.AccountId); // header beats query, trimmed
        Assert.Equal("NameHdr", id.Username);
        Assert.Equal(42, id.Discriminator);
    }

    [Fact] // query string is used when no header is present
    public void Query_UsedWhenNoHeader()
    {
        var ctx = Ctx(c => c.Request.QueryString = new QueryString("?accountId=acct-q&username=NameQ&discriminator=55"));

        var id = ClientIdentityResolver.Resolve(ctx, "fb", "fbName", 1);

        Assert.Equal("acct-q", id.AccountId);
        Assert.Equal("NameQ", id.Username);
        Assert.Equal(55, id.Discriminator);
    }

    [Fact] // the sid cookie (bapcustom- prefix) supplies the accountId below header/query
    public void SidCookie_SuppliesAccountId()
    {
        var ctx = Ctx(c => c.Request.Headers["Cookie"] = "sid=bapcustom-cookieacct");

        var id = ClientIdentityResolver.Resolve(ctx, "fb", "fbName", 1);

        Assert.Equal("cookieacct", id.AccountId); // prefix stripped
    }

    [Fact] // a sid cookie without the bapcustom- prefix is ignored -> fallback wins
    public void SidCookie_WrongPrefix_Ignored()
    {
        var ctx = Ctx(c => c.Request.Headers["Cookie"] = "sid=steam-12345");

        var id = ClientIdentityResolver.Resolve(ctx, "fb", "fbName", 1);

        Assert.Equal("fb", id.AccountId);
    }

    [Fact] // a non-numeric discriminator is ignored and the fallback discriminator is kept
    public void NonNumericDiscriminator_KeepsFallback()
    {
        var ctx = Ctx(c => c.Request.Headers["X-BAP-Discriminator"] = "not-a-number");

        var id = ClientIdentityResolver.Resolve(ctx, "fb", "fbName", 1234);

        Assert.Equal(1234, id.Discriminator);
    }
}
