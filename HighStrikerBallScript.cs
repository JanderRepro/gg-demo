using UnityEngine;
using System.Collections;

public class HighStrikerBallScript : MonoBehaviour {

	public LevelInformationScript script;
	public AudioSource audio;
	public AudioClip ding;

	// Use this for initialization
	void Awake () {
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}
	
	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "trigger") {
			script.Goal -= 1;
			audio.PlayOneShot(ding);
		}
	}
}
