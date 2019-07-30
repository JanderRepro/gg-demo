using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {

	public float countdown;
	public bool pin = true;
	public GameObject shard;
	public GameObject explosion;
	public GameObject explosiongraphic;
	public GameObject sparks;
	public GameObject pinobject;
	public Rigidbody grnrb;
	public Rigidbody pinrb;
	public Transform detonator;
	public GameObject gsprite;
	public string trigger;
	public bool sensitive = true;
	public ColorScript coloring;
	public AudioClip hissing;
	public AudioSource audio;
	public GameObject nextinline;
	public bool respawn = false;
	public GrenadeScript nextscript;
	public Vector3 originalposition;
	public Quaternion originalrotation;

	void Start(){
		nextscript = nextinline.GetComponent<GrenadeScript>();
		originalposition = transform.position;
		originalrotation = transform.rotation;
		audio = GetComponent<AudioSource> ();
		if (sensitive == true) {
			gsprite.GetComponent<SpriteRenderer>().color = Color.red;
		} else if (trigger == "Player") {
			//keep default green
		} else gsprite.GetComponent<SpriteRenderer>().color = Color.yellow;
	}

	// Use this for initialization
	void Update () {
		if (pinobject == null && pin == true) {
			arm ();
		}
		if (pin == false) {
			countdown -= Time.deltaTime;
			if(countdown < 0f){
				Debug.Log ("Kaboom");
				explode ();
			}
		}
	}
	
	void OnCollisionEnter(Collision other){
		if (other.transform.IsChildOf (transform)) {
		} else if (other.gameObject.tag == trigger || sensitive == true) {
			arm ();
		}
	}

	public void arm(){
		if (pinrb != null) {
			pinrb.isKinematic = false;
			pinrb.GetComponent<Collider> ().isTrigger = false;
			audio.PlayOneShot (hissing, 0.75f);
		}
		grnrb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		transform.DetachChildren ();
		detonator.transform.SetParent(this.transform);
		sparks.transform.SetParent(this.transform);
		gsprite.transform.SetParent (this.transform);
		sparks.SetActive(true);
		if (pin == true) {
			countdown = 5f;
			pin = false;
		}
	}

	public void explode(){
		for (int i = 0; i < 8; i++) {
			GameObject shrapnel = Instantiate(shard, detonator.position, detonator.rotation) as GameObject;
			detonator.Rotate(Vector3.zero, 45f);
		}
		GameObject kaboom = Instantiate (explosion, detonator.position, detonator.rotation) as GameObject;
		GameObject seekaboom = Instantiate (explosiongraphic, detonator.position, detonator.rotation) as GameObject;
		kaboom.GetComponent<AudioSource> ().volume = 0.5f;
		if (respawn == true) {
			//GameObject clone = Instantiate (nextinline, originalposition, originalrotation) as GameObject;
			GameObject clone = (GameObject)Instantiate(Resources.Load ("Grenade"), originalposition, originalrotation);
			GrenadeScript nextscript = clone.gameObject.GetComponent<GrenadeScript>();
			nextscript.sensitive = sensitive;
			nextscript.respawn = respawn;
			Resources.UnloadUnusedAssets();
		}
		Destroy (this.gameObject);
	}
}
