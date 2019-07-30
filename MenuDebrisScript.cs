using UnityEngine;
using System.Collections;

public class MenuDebrisScript : MonoBehaviour {

	public float force = 150f;
	public Vector3 direction;
	public Vector3 curveloc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		direction = new Vector3 (0, 0, 0);
		direction.x = Input.acceleration.x;
		direction.y = Input.acceleration.y;
		
		//float leftright = Input.GetAxis ("Horizontal");
		//float updown = Input.GetAxis ("Vertical");
		//direction.x = leftright;
		//direction.y = updown;
		
		rigidbody.AddForce (direction * force * Time.deltaTime);
		curveloc = rigidbody.velocity.normalized;
	}
}
