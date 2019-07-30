using UnityEngine;
using System.Collections;

public class FinishLineScript : MonoBehaviour {
	public GameObject finbut;
	void OnTriggerEnter(Collider other){
		finbut.SetActive (true);
	}
}
