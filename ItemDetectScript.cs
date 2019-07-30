using UnityEngine;
using System.Collections;

public class ItemDetectScript : MonoBehaviour {

	public LevelInformationScript script;
	public string targettag = "trigger";
	public bool hasitem = false;
	public bool nullifymass;
	public AudioSource audio;
	public AudioClip triggersound;
	
	void Awake () {
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}
	
	void OnTriggerEnter (Collider other){
		if (other.tag == targettag) {
			script.Goal-=1;
			hasitem = true;
			if(triggersound != null){
				audio.PlayOneShot (triggersound);
			}
			if(nullifymass == true){
				other.GetComponent<Rigidbody>().mass = 0f;
			}
		}
	}
}
