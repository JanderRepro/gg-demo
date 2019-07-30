using UnityEngine;
using System.Collections;

public class VortexScript : MonoBehaviour {
	
	public float pull;
	public float tug;
	public float rotation = 5;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(-Vector3.forward * Time.deltaTime * rotation);
	}
	
	void OnTriggerStay (Collider other) {
		if (other.tag != "trigger" && other.tag != "gerbil") {
			Vector3 diff = transform.position - other.transform.position;
			other.rigidbody.AddForce(diff / diff.magnitude * pull);
			other.rigidbody.AddTorque(Vector3.up * tug);
		}
	}
}
