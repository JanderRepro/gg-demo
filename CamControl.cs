using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {

	public GameObject player;
	public GameObject userinterface;
	public Vector3 offset;
	public Vector3 UIoffset;
	public Vector3 UIpausefix; //this should only not be zero if pausing pushes the UI out of place
	public float fullzoom;
	public ZoomButtonScript zoomscript;
	public float speed = 0.05f;
	public Camera cam;
	public float orthozoom = 10;
	public float UIscale;

	// Use this for initialization
	void Awake () {
		offset = new Vector3 (0f, -1f, -100f);
		UIoffset = new Vector3 (0f, 0f, 6f);
		cam = this.gameObject.GetComponent<Camera> ();
		fullzoom = cam.orthographicSize;
		player = GameObject.FindWithTag("Player");
		zoomscript = GameObject.Find ("Zoom Button").GetComponent<ZoomButtonScript> ();
		userinterface = GameObject.Find ("UI Canvas 1");
		UIscale = 0.004140786f * cam.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		//Makes camera follow player. Leave this commented out until discernable landmarks are made.
		//transform.position = player.transform.position + offset;
		if (UIpausefix != Vector3.zero && zoomscript.zoomed == true) {
			UIoffset = UIpausefix;
		} else
			UIoffset = new Vector3 (0f, 0f, 6f);
		transform.position = Vector3.Slerp (transform.position, player.transform.position + offset, speed);
		userinterface.transform.position = transform.position + UIoffset;
		cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, orthozoom, speed * Time.deltaTime * 10);
		UIscale = 0.004140786f * cam.orthographicSize;
		userinterface.transform.localScale = new Vector3 (UIscale, UIscale, UIscale);
	}
}
