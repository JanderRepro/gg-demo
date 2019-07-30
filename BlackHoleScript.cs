using UnityEngine;
using System.Collections;

public class BlackHoleScript : MonoBehaviour {

	public bool occupied = false;
	public GameObject victim;
	public Vector3 victimvelocity;
	public Vector3 exitpoint;
	public Vector3 gerbilpoint;
	public bool random = true;
	public float cycle;
	public AudioClip sucknoise;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		gerbilpoint = exitpoint;
		gerbilpoint.z = 3;
	}
	
	void FixedUpdate () {
		if (victim != null) {
			victim.transform.position = transform.position;
			cycle--;
			victim.rigidbody.AddTorque(Vector3.forward * 1000 * Time.deltaTime);
			if(cycle < 1){
				victim.transform.position = exitpoint;
				victim = null;
			}
		}
	}

	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		Sucking(other.transform.root.gameObject);
	}
	
	public void Sucking (GameObject other){
		if (other != this.transform.root.gameObject && victim == null) {
			var rb = other.gameObject.GetComponent<Rigidbody>();
			audio.PlayOneShot(sucknoise, 1f);
			if(other.collider != null){
				//other.collider.isTrigger = true;
				//rb.isKinematic = true;
				other.transform.position = Vector3.Lerp (other.transform.position, transform.position, 40f * Time.deltaTime);
				victim = other.gameObject;
				cycle = 30;
				victimvelocity = victim.rigidbody.velocity;
			}
		}
	}
}
