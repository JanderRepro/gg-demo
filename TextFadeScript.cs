using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFadeScript : MonoBehaviour {

	public Color changeto;
	public float duration; //how long the text should stay opaque
	public float speed;
	public Text words;
	public Image panel;

	// Use this for initialization
	void Awake () {
		changeto = words.color;
		words.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		words.color = Color.Lerp (words.color, changeto, speed);
		if (words.color == changeto) {
			duration--;
			if(duration <= 0){
				changeto = Color.clear;
			}
		}
		if (duration <= 0) {
			panel.color = Color.Lerp (panel.color, Color.clear, speed * 2);
			if(panel.color == Color.clear){
				Destroy (panel.gameObject);
			}
		}
	}
}
