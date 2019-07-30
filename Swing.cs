using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {

	public float rotaterate;
	public Vector3 pivot;
	public bool flipflip;
	public Vector3 target;
	public int counter = 0;
	public bool stop = true;

	// Use this for initialization
	void Awake () {
		rigidbody.centerOfMass = pivot;
	}

	public Vector3 Pivot {
		set {
			pivot = value;
			rigidbody.centerOfMass = pivot;
		}
		get {
			return pivot;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.AddTorque (Vector3.forward * rotaterate * Time.deltaTime);
		counter++;
		if (rigidbody.angularVelocity.magnitude < 7f) {
			rigidbody.AddTorque (Vector3.forward * rotaterate * Time.deltaTime);

		}
	}

	public void Realign (float x, float y, float z){
		var point = new Vector3 (x, y, z);
		pivot = point;
		rigidbody.centerOfMass = point;
	}
}
