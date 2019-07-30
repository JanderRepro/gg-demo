using UnityEngine;
using System.Collections;

public class TilingScript : MonoBehaviour {

	public Material matty;
	public Vector2 tiling;
	public bool toscale = true;

	// Use this for initialization
	void Awake () {
		matty = renderer.material;
		if (toscale == true) {
			tiling.x = transform.localScale.x;
			tiling.y = transform.localScale.y;
		}
		matty.SetTextureScale ("_MainTex", tiling);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
