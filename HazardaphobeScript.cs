using UnityEngine;
using System.Collections;

public class HazardaphobeScript : MonoBehaviour {

	public bool canscore;
	public AudioClip thissound;
	public GameObject afterdeathsound;

	void Start(){

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "hazard") {
			if(thissound != null){
				GameObject kaboom = Instantiate (afterdeathsound, transform.position, transform.rotation) as GameObject;
				kaboom.GetComponent<AudioSource>().clip = thissound;
				kaboom.audio.PlayOneShot(thissound);
			}
			Destroy (this.gameObject);
			if(canscore){
				GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ().Goal--;
			}
		}
	}
}
