using UnityEngine;
using System.Collections;

public class FulcrumFollowScript : MonoBehaviour {

	public Transform fulsource;
	public Vector3 gohere;

	// Use this for initialization
	void Awake () {
		gohere = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gohere.x = fulsource.position.x;
		transform.position = gohere;
	}
}
