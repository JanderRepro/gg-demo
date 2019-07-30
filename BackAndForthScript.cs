using UnityEngine;
using System.Collections;

public class BackAndForthScript : MonoBehaviour {

	public Vector3 point1;
	public Vector3 point2;
	public Vector3 destination;
	public float speed;
	
	// Use this for initialization
	void Start () {
		destination = point1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, destination, speed);
		if (Vector3.Distance (transform.position, point1) < 0.5f) {
			destination = point2;
		}
		if (Vector3.Distance (transform.position, point2) < 0.5f) {
			destination = point1;
		}
	}
	
	
}
