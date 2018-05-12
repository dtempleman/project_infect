using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
	public GameObject ping;
	public int mag = 1;
	public float duration = 2;

	//examples of sound:
	//walking will not cause any sound
	//running will cause a ping(1)
	//gunshots will cause a ping(10)
	//blunt weapons will cause a ping(3)

	//when this is call it will "ping" a sound at the position (pos) with a magnitude of (lvl) 
	//alerting all enemies within range
	void Ping(Vector2 pos, int lvl, float dur){
		//create a sound object of size lvl.
		GameObject p = Instantiate (ping);
		p.transform.position = pos;
		p.GetComponent<PingController> ().magnitude = mag;
		p.GetComponent<PingController> ().duration = dur;
		Debug.Log ("ping " + pos + ". mag=" + mag + ". dur=" + dur);
	}


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = 0;
			Ping (pos, mag, duration);
		}
	}



}
