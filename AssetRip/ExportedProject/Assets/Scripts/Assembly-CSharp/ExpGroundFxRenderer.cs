using UnityEngine;

public class ExpGroundFxRenderer : MonoBehaviour
{
	[SerializeField]
	public Camera cam;

	[SerializeField]
	public GameObject rendRoot;

	[SerializeField]
	public Renderer[] rend;

	[SerializeField]
	public float size;

	[SerializeField]
	public float duration;

	[SerializeField]
	public int res;

	[SerializeField]
	public int antialiasingSamples;

	public Texture2D tex;

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public Texture2D RenderGroundTexture()
	{
		return null;
	}
}
