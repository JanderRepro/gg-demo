using UnityEngine;
using System.Collections;

public class SpaceJunkControlScript : MonoBehaviour {

	public Rigidbody rb;
	public SpaceSpawnScript script;

	// Use this for initialization
	void Start () {
		rb = rigidbody;
		rb.useGravity = false;
		script = GameObject.Find ("EventSystem").GetComponent<SpaceSpawnScript> ();
	}
	
	// Update is called once per frame
	void OnDisable () {
		script.junkcount--;
	}
}
