using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

	public Vector3 point1;
	public Vector3 point2;
	public Vector3 destination;
	public float speed;
	public LevelInformationScript script;
	public AudioClip thissound;
	public GameObject afterdeathsound;

	// Use this for initialization
	void Start () {
		destination = point1;
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, destination, speed);
		if (Vector3.Distance (transform.position, point1) < 0.5f) {
			destination = point2;
		}
		if (Vector3.Distance (transform.position, point2) < 0.5f) {
			destination = point1;
		}
		if (script.Goal == 0) {
			GameObject kaboom = Instantiate (afterdeathsound, transform.position, transform.rotation) as GameObject;
			kaboom.GetComponent<AudioSource>().clip = thissound;
			kaboom.audio.PlayOneShot(thissound);
			Destroy (this.gameObject);
		}
	}


}
