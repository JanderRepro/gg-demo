using UnityEngine;
using System.Collections;

public class PlayerForce : MonoBehaviour {
	
	public Transform Camera;
	private Transform Player;
	public float force = 150f;
	public Vector3 direction;
	public Vector3 curveloc;
	public float distance;
	public float maxvelocity = 10f;
	public AudioClip thunknoise;
	public AudioSource audio;
	public bool canreverse = true;

	public delegate void DeathAction();
	public static event DeathAction OnDeath;
	
	public float Force {
		get{
			if (distance > 1) {
				return force * 5;
			} else return force;
		}
		set{
			force = value;
		}
	}
	
	void Start() {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		Camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		Camera.rotation = Player.rotation;
		Player.rotation = Camera.rotation;
		direction = new Vector3 (0, 0, 0);
	}
	
	void FixedUpdate () {
		//acceleration input
		direction = new Vector3 (0, 0, 0);
		direction.x = Input.acceleration.x * 2f;
		direction.y = Input.acceleration.y * 2f;

		//if the game is being run on a Mac or PC, take keyboard input instead
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) {
			float leftright = Input.GetAxis ("Horizontal");
			float updown = Input.GetAxis ("Vertical");
			direction.x = leftright * 2f;
			direction.y = updown;
		}

		//refine acceleration sensitivity
		if (Mathf.Abs (direction.x) > 1f) {
			direction.x = direction.x / Mathf.Abs (direction.x);
		}
		if (Mathf.Abs (direction.y) > 1f) {
			direction.y = direction.y / Mathf.Abs (direction.y);
		}
		
		rigidbody.AddForce (direction * force * Time.deltaTime);
		curveloc = rigidbody.velocity.normalized;
		distance = Vector3.Distance (direction, curveloc);

		//cap velocity
		if(rigidbody.velocity.magnitude > maxvelocity){
			rigidbody.velocity = rigidbody.velocity.normalized * maxvelocity;
		}

		//invert velocity
		Vector3 switcheroo = rigidbody.velocity;
		if (Mathf.Sign (direction.x) != Mathf.Sign (rigidbody.velocity.x)) {
			switcheroo.x = -rigidbody.velocity.x;
		}
		if (Mathf.Sign (direction.y) != Mathf.Sign (rigidbody.velocity.y)) {
			switcheroo.y = -rigidbody.velocity.y;
		}

		if (canreverse == true) {
			rigidbody.velocity = Vector3.Lerp (rigidbody.velocity, switcheroo, 0.05f);
		}
	}

	void OnDisable(){
		if (OnDeath != null) {
			OnDeath ();
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag != "gerbilpart" && other.gameObject.tag != "gerbil") {
			Debug.Log (other.gameObject.name);
			audio.PlayOneShot (thunknoise, rigidbody.velocity.magnitude / 5f);
		}
	}
}
