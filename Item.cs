using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour {

	public LevelInformationScript script;
	public AudioClip thissound;
	public AudioSource audio;
	public GameObject afterdeathsound;
	public bool mustgetlast = false;
	public PlayerForce pfscript;
	public GameObject dtext;

	void Awake () {
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
		pfscript = GameObject.Find ("Plastic Ball").GetComponent<PlayerForce> ();
		dtext = GameObject.Find ("DeathText");
	}
	
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player" && pfscript.enabled == true) {
			GameObject kaboom = Instantiate (afterdeathsound, transform.position, transform.rotation) as GameObject;
			kaboom.GetComponent<AudioSource>().clip = thissound;
			kaboom.audio.PlayOneShot(kaboom.audio.clip);
			Destroy(this.gameObject);
			if(mustgetlast == true && script.Goal > 1){
				pfscript.enabled = false;
				dtext.GetComponent<Text> ().text = "Hit the bumpers first!";
			}
			script.Goal-=1;
		}
	}
}
