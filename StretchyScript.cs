using UnityEngine;
using System.Collections;

public class StretchyScript : MonoBehaviour {

	public Vector3 stritch;
	public Vector3 stratch;
	public Vector3 stretchto;
	public float speed;

	// Use this for initialization
	void Start () {
		stretchto = stritch;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localScale = Vector3.Lerp (transform.localScale, stretchto, speed);
		if(Vector3.Distance (transform.localScale, stritch) < 0.5f){
			stretchto = stratch;
		}
		if(Vector3.Distance (transform.localScale, stratch) < 0.5f){
			stretchto = stritch;
		}
	}
}
