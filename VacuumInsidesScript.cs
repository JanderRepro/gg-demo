using UnityEngine;
using System.Collections;

public class VacuumInsidesScript : MonoBehaviour {

	public bool occupied = false;
	public GameObject victim;
	public float maxmass;
	public AudioClip sucknoise;
	public AudioSource audio;

	// Use this for initialization
	void Update () {
		if (victim != null) {
			victim.transform.position = Vector3.Lerp (victim.transform.position, transform.position, 1f * Time.deltaTime);
			victim.transform.localScale *= 0.9f;
			if(victim.transform.localScale.x < 0.1f){
				Destroy (victim);
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
			if(rb.mass < maxmass){
				audio.PlayOneShot(sucknoise, 1f);
				if(other.collider != null){
					other.collider.isTrigger = true;
				}
				rb.isKinematic = true;
				other.transform.position = Vector3.Lerp (other.transform.position, transform.position, 40f * Time.deltaTime);
				victim = other.gameObject;
			}
		}
	}
}