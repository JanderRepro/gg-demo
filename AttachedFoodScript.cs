using UnityEngine;
using System.Collections;

public class AttachedFoodScript : MonoBehaviour {

	public Transform strapped;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = strapped.position;
	}
}
