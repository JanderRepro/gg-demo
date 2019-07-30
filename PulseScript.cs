using UnityEngine;
using System.Collections;

public class PulseScript : MonoBehaviour {

	public Vector3 basesize;
	public float altsize = 2f;
	public Vector3 changeto;
	public float speed = 0.15f;

	// Use this for initialization
	void Start () {
		basesize = transform.localScale;
		changeto = basesize * altsize;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.Lerp (transform.localScale, changeto, speed);
		if (Vector3.Distance (transform.localScale, basesize) < 0.5f) {
			changeto = basesize * altsize;
		}
		if (Vector3.Distance (transform.localScale, basesize * altsize) < 0.5f) {
			changeto = basesize;
		}
	}
}
