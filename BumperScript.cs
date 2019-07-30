using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

	public float force = 10f;
	public float boostduration;
	public float boostlength = 10f;
	public Transform originalObject;
	public Transform reflectedObject;
	public GameObject theball;
	public GameObject thegerbil;
	public Vector3 gerbilcenter;
	public PlayerForce ballscript;
	public bool isgoal = true;
	public LevelInformationScript liscript;
	public int numberofhits = 0;
	public AudioSource audio;
	public AudioClip boing;

	void Awake(){
		theball = GameObject.Find ("Plastic Ball");
		thegerbil = GameObject.Find ("Gerbil");
		ballscript = theball.GetComponent<PlayerForce> ();
		liscript = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
		gerbilcenter = new Vector3 (-0.27f, 0f, 3f);
	}

	void FixedUpdate(){
		if (boostduration > 0) {
			theball.rigidbody.AddForce (transform.forward * force * Time.deltaTime);
		}
		if (boostduration == 0) {
			ballscript.maxvelocity = 10;
			ballscript.canreverse = true;
		}
		if (boostduration > -50) {
			thegerbil.transform.localPosition = gerbilcenter;
		}
		boostduration--;
		if (isgoal == false) {
			renderer.material.color = Color.Lerp (renderer.material.color, Color.black, Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			numberofhits++;
			if(isgoal == true && liscript.Goal > 1){
				liscript.Goal-=1;
				isgoal = false;
			}
			audio.PlayOneShot(boing);
			ballscript.maxvelocity = 100;
			ballscript.canreverse = false;
			boostduration = boostlength;
		}
	}
}
