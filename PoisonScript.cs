using UnityEngine;
using System.Collections;

public class PoisonScript : MonoBehaviour {

	public Vector3 lastemission;
	public GameObject cloud;
	public GameObject detector;
	public PoisonDetectScript detectscript;
	public float distance;
	public AudioClip emit;
	AudioSource audio;

	// Use this for initialization
	public virtual void Awake () {
		audio = GetComponent<AudioSource> ();
		detectscript = detector.GetComponent<PoisonDetectScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distance = Vector3.Distance (transform.position, lastemission);
		if (detectscript.gasses == 0 || distance > 1.5) {
			spit ();
		}
	}

	public virtual void spit(){
		lastemission = transform.position;
		GameObject fumes = Instantiate(cloud, transform.position, transform.rotation) as GameObject;
		audio.PlayOneShot (emit, 1f);
	}
}
