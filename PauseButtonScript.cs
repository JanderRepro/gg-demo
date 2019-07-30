using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButtonScript : ButtonScript {

	public GameObject rewind;
	public GameObject exit;
	public GameObject zoom;
	public GameObject startpanel;
	public Image icon;
	public Sprite pauseicon;
	public Sprite playicon;

	void Awake(){
		startpanel = GameObject.Find ("Scene Start Panel");
	}

	void Start(){
		this.gameObject.SetActive (false);
	}

	public override void OnClick () {
		base.OnClick ();
		if (Time.timeScale == 0) { //Game is paused
			Time.timeScale = 1f; //...so we unpause
			rewind.SetActive(false);
			exit.SetActive(false);
			zoom.SetActive(false);
			icon.sprite = pauseicon;
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
			startpanel.SetActive (false);
		}
		else { //Game is not paused
			rewind.SetActive(true); //...so we pause
			exit.SetActive(true);
			zoom.SetActive(true);
			icon.sprite = playicon;
			Time.timeScale = 0f;
			Screen.sleepTimeout = 3;
			startpanel.SetActive (true);
		}
	}
}
