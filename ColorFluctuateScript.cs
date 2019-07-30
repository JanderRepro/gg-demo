using UnityEngine;
using System.Collections;

public class ColorFluctuateScript : MonoBehaviour {

	public Color basecolor;
	public Color altcolor;
	public Color changeto;
	public float speed;

	// Use this for initialization
	void Start () {
		basecolor = renderer.material.color;
		changeto = altcolor;
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.color = Color.Lerp (renderer.material.color, changeto, speed);
		if (Vector4.Distance(renderer.material.color, basecolor) < 0.05f) {
			changeto = altcolor;
		}
		if (Vector4.Distance(renderer.material.color, altcolor) < 0.05f) {
			changeto = basecolor;
		}
		Debug.Log (Vector4.Distance(renderer.material.color, changeto));
	}
}
