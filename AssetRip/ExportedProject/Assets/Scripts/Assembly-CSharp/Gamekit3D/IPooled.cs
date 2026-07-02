using UnityEngine;

namespace Gamekit3D
{
	public interface IPooled<T> where T : MonoBehaviour, IPooled<T>
	{
		int poolID { get; set; }

		ObjectPooler<T> pool { get; set; }
	}
}
