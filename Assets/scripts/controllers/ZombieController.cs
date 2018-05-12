using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
	public enum STATE {Idle, Alerted, Hunting};

	float move_speed;
	float rotate_speed;
	bool rotating;
	bool moving;

	STATE current_state;

	//Vector2 forward;

	Vector2 target;
	Vector3 home;
	GameObject pray;

	float timer = 0f;

	Rigidbody2D _rigidbody;


	// Use this for initialization
	void Start () {
		home = this.transform.position;
		current_state = STATE.Idle;
		move_speed = .75f;
		rotate_speed = 30f;

		timer = 0;


		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Look ();

		if (current_state == STATE.Idle) {
			int max_roam = 3;
			if (!moving) {
				target = new Vector2 (home.x + Random.Range (0, max_roam), home.y + Random.Range (0, max_roam));
				moving = true;
			} else {
				Move (target);
			}

		} else if (current_state == STATE.Alerted) {
			// go to alert
			// once at alert idle
			Investigate ();
		} else if (current_state == STATE.Hunting) {
			follow (pray);
		} else {
			Debug.Log ("Illegal State.");
			current_state = STATE.Idle;
		}

		timer -= Time.deltaTime;
	}

	//will check its field of view for any targets
	void Look(){
		// create field of view
		// if target within FOV
		// current_state = STATE.Hunting;
		// target = target;

		Debug.DrawLine (this.transform.position, (this.transform.position + this.transform.up), Color.red);

	}

	void follow(GameObject target){
		if(Vector3.Distance(target.transform.position, this.transform.position) > 6f){
			//alerted = false;
			//Debug.Log ("you got away");
		}else if(Vector3.Distance(target.transform.position, this.transform.position) < 1f){
			//attacking = true;
		//}else if(waitTime<0){
			Move (target.transform.position);

		}
		//Debug.Log("moving");
	}

	void Move(Vector3 target){
		if(Mathf.Abs(this.transform.position.x - home.x) < .01f && Mathf.Abs(this.transform.position.y - home.y) < .01f){
			moving = false;
		}else if(true){
			transform.Translate (Vector2.up * move_speed * Time.deltaTime);
		}else{

		}


		//Vector3 newVel = (target - transform.position).normalized*move_speed;
		//_rigidbody.velocity = newVel;

		//if facing target
			// move forward
		//else
			//rotate to target


	}
		
	public void Alert(Vector2 target){
		target = target;
		current_state = STATE.Alerted;
		Debug.Log ("allerted to: " + target);
	}
		
	public bool isAlerted(){
		return false;
	}

	void Investigate(){
		if (Mathf.Abs(this.transform.position.x - home.x) < .5f && Mathf.Abs(this.transform.position.y - home.y) < .5f){
			_rigidbody.velocity = new Vector3 (0, 0, 0);
			timer -= Time.deltaTime;
			current_state = STATE.Idle;
		}else {
			Move (home);
		}
	}
}
