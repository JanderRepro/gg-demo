using UnityEngine;
using System.Collections;

public class RandomRotateScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		rigidbody.angularVelocity = Random.insideUnitSphere * 5;
	}
}
