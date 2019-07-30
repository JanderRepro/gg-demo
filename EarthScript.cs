using UnityEngine;
using System.Collections;

public class EarthScript : MonoBehaviour {

	public float rotated = 0;
	public GameObject targetobj;
	public GameObject earth;
	public TrailRenderer rainbow;
	public LevelInformationScript script;

	void Awake() {
		rainbow = targetobj.GetComponent<TrailRenderer> ();
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}

	// Use this for initialization
	void Start () {
		rainbow.enabled = false;
	}
	
	// Update is called once per frame
	void OnTriggerExit(Collider other){
		if (other.tag == "trigger") {
			if(earth.transform.rotation.z < 0f || earth.transform.rotation.z > 300f){//Earth is rotating in reverse
				rainbow.enabled = true;
			}
			if(script.Goal == 1f){
				script.Goal = 0f;
				rotated++;
				if(rotated == 2){
					PlayerPrefs.SetInt ("insurance"+Application.loadedLevelName, 1);
				}
			}
			else{
				script.Goal = 6f;
			}
		}
	}
}
