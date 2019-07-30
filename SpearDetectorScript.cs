using UnityEngine;
using System.Collections;

public class SpearDetectorScript : MonoBehaviour {

	public GameObject thespear;
	public Vector3 moveto;
	public Vector3 startpoint;
	public Vector3 skewer;
	public float stabspeed;
	public float retractspeed;
	private float speed;



	// Use this for initialization
	void Start () {
		startpoint = thespear.transform.position;
		if (skewer == Vector3.zero) {
			skewer = startpoint;
			skewer.y += 11f;
		}
		moveto = startpoint;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		thespear.transform.position = Vector3.Lerp (thespear.transform.position, moveto, speed);
		if (Vector3.Distance (thespear.transform.position, skewer) < 0.1f) {
			speed = retractspeed;
			moveto = startpoint;
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			speed = stabspeed;
			moveto = skewer;
		}
	}
}
