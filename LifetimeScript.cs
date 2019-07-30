using UnityEngine;
using System.Collections;

public class LifetimeScript : MonoBehaviour {

	public float lifespan;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifespan);
	}
}
