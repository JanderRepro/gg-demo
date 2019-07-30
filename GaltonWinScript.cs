using UnityEngine;
using System.Collections;

public class GaltonWinScript : MonoBehaviour {

	public LevelInformationScript script;
	
	void Awake () {
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}
	
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player" || other.tag == "trigger") {
			Destroy(this.gameObject);
			script.Goal-=1;
		}
	}
}
