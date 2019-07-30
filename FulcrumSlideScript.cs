using UnityEngine;
using System.Collections;

public class FulcrumSlideScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * 5f * Time.deltaTime);
	}
}
