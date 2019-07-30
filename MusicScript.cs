using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	public LevelInformationScript liscript;
	public AudioClip defaultclip;
	public AudioSource audio;
	public float transitionprogress;
	public float currenttracklength;
	public float difference;
	public int changeto;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (this.gameObject); //Stops title screen from duplicating BGM
		}
	}

	// Use this for initialization
	void OnLevelWasLoaded () {
		transitionprogress = audio.timeSamples;
		currenttracklength = audio.clip.length;
		liscript = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
		if (liscript.levelmusic != null) {
			if(liscript.levelmusic != audio.clip){//switch tracks
				audio.Stop ();
				difference = liscript.levelmusic.length / currenttracklength * transitionprogress;
				changeto = (int)difference;
				audio.clip = liscript.levelmusic;
				audio.timeSamples = changeto;
				audio.Play();
				//Debug.Log (audio.clip.length);
			}
		}
		else if(audio.clip != defaultclip){//Switch to Polka Waltz
			audio.Stop ();
			difference = defaultclip.length / currenttracklength * transitionprogress;
			changeto = (int)difference;
			audio.clip = defaultclip;
			audio.timeSamples = changeto;
			audio.Play();
			//Debug.Log (audio.clip.length);
		}
	}
}