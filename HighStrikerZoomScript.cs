using UnityEngine;
using System.Collections;

public class HighStrikerZoomScript : MonoBehaviour {

	public float zoomto;
	public GameObject camobj;
	public CamControl camcam;

	// Use this for initialization
	void Awake () {
		camobj = GameObject.FindGameObjectWithTag ("MainCamera");
		camcam = camobj.GetComponent<CamControl> ();
	}

	void OnTriggerEnter (Collider other) {
		camcam.orthozoom = zoomto;
	}
}
