using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour {
	int HP = 100;

	Rigidbody2D _rigidbody;
	Body body;
	float baseSpeed = 1f;

	// Use this for initialization
	void Start () {
		body = new Body ("Daniel");	
		_rigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		//checkTargets (3f);
	}

	void Move(){
		float speed = GetSpeed ();
		float X_move = Input.GetAxis ("Horizontal");
		float Y_move = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (X_move, Y_move) + new Vector2(this.transform.position.x, this.transform.position.y);

		_rigidbody.velocity = new Vector2 (X_move, Y_move) * speed;

		//this.transform.position = movement*speed;
		//this.transform.position.Normalize ();
	
	}

	float GetSpeed(){
		return baseSpeed;
	}
	/*
	void checkTargets(float dist){
		//if there are targets within the dist
		//alert them.
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		for (int i = 0; i < enemies.Length; i++) {
			
			if (enemies [i].GetComponent<ZombieController> ().isAlerted() == false) {
				if (Vector3.Distance (enemies [i].transform.position, this.transform.position) < dist) {
					Debug.Log ("alerting");
					enemies [i].GetComponent<ZombieController> ().Alert (this.gameObject);
				}
			}
		}

	}
	*/
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Hitbox") {
			HP--;
			Debug.Log ("you have been hit, HP = " + HP);
		}

	}



}
