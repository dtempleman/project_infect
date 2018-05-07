using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour {
	public float time = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (time < 0) {
			Destroy (this.gameObject);
		} else {
			time -= Time.deltaTime;
		}
	}
}
