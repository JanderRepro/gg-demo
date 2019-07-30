using UnityEngine;
using System.Collections;

public class BuoyancyScript : MonoBehaviour {

	public float upwardforce = 12.72f;
	public bool inwater = false;
	public Vector3 pushdir;
	public Quaternion floatdir = Quaternion.identity;

	void OnTriggerEnter(Collider other){
		if (other.tag == "liquid") {
			inwater = true;
			rigidbody.drag = 3f;
			rigidbody.angularDrag = 1f;
			rigidbody.velocity = rigidbody.velocity / 6f;
			//pushdir = other.transform.rotation.eulerAngles;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "liquid") {
			inwater = false;
			rigidbody.drag = 0f;
		}
	}

	// Use this for initialization
	void Awake () {
		floatdir.eulerAngles = new Vector3 (0, 0, 90);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (inwater == true) {
			Vector3 force = pushdir * upwardforce;
			this.rigidbody.AddForce (force, ForceMode.Acceleration);
			if(transform.rotation.z < 80f){
				rigidbody.AddTorque (Vector3.forward * upwardforce * 5f * Time.deltaTime);
			}
			if(transform.rotation.z > 100f){
				rigidbody.AddTorque (Vector3.back * upwardforce * 5f * Time.deltaTime);
			}
			if(transform.rotation.z > 80f && transform.rotation.z < 100f){
				rigidbody.angularVelocity = Vector3.zero;
			}
		}
	}
}
