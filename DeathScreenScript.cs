using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathScreenScript : MonoBehaviour {

	public bool dead = false;
	public GameObject button;
	public float speed;
	public float alpha = 0f;
	public Image background;
	public Color fade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dead == true) {
			//renderer.material.color = new Vector4(255, 0, 0, Mathf.Lerp (0f, 200f, speed));
			//background.color = new Vector4(255, 0, 0, Mathf.Lerp (0f, 200f, speed));
			background.color = Color.Lerp (background.color, fade, speed);
			if(Input.anyKey){
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public void Kill(){
		dead = true;
		button.GetComponent<Text> ().enabled = true;
	}

	void OnEnable(){PlayerForce.OnDeath += Kill;
	}

	void OnDisable(){
		PlayerForce.OnDeath -= Kill;
	}
}
