using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	
	public AudioSource audio;
	public AudioClip clicksound;
	
	// Use this for initialization
	public virtual void Awake () {
		audio = transform.root.GetComponent<AudioSource> ();
	}

	public virtual void OnClick(){
		audio.PlayOneShot (clicksound);
	}
}
