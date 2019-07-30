using UnityEngine;
using System.Collections;

public class HighStrikerScript : TriggerScript {

	public Swing swingscript;
	public GameObject fulcrum;
	public Vector3 destination;
	public float movement;
	public AudioSource audio;
	public AudioClip gears;

	void Awake(){
	}

	void Update(){
		fulcrum.transform.localPosition = Vector3.Lerp (fulcrum.transform.localPosition, swingscript.pivot / 2f, 0.05f);
	}

	public override void trigger(){
		if (swingscript.pivot.x > -0.5) {
			audio.PlayOneShot(gears);
			swingscript.Realign(swingscript.pivot.x - 0.5f, 0f, 0f);
			movement -= 25 / 2;
		}
	}
}
