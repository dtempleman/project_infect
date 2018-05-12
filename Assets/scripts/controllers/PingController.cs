using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingController : MonoBehaviour {

	public int magnitude = 1;
	float progress = 0;
	public float duration = 2;
	float time;
	// Use this for initialization
	void Start () {
		time = duration;
		this.transform.localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = Vector3.Lerp (new Vector2 (0, 0), new Vector2 (magnitude, magnitude), progress);
		progress += Time.deltaTime / duration;
		if(time < 0){
			Destroy (this.gameObject);
		}
		time -= Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<ZombieController> ().Alert (this.transform.position); //this needs to be a pos not a GO

		}

	}
}
