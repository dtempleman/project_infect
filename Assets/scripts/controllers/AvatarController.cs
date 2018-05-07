using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour {
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
}
