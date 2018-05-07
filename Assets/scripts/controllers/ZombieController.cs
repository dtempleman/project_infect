using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
	public GameObject attack;

	bool attacking = false;
	float attackTimer = 3f;
	float waitTime;
	float timer = 0f;
	GameObject target;
	Vector3 idle_target;
	public bool alert = false;
	Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		attackTimer -= Time.deltaTime;
		waitTime -= Time.deltaTime;
		if (alert) {
			if (!attacking || attackTimer > 0) {
				follow (target);
			} else {
				_rigidbody.velocity = new Vector3 (0, 0, 0);
				GameObject a = Instantiate (attack);
				Vector3 dir = (target.transform.position - this.transform.position);
				a.transform.position = this.transform.position + dir *.75f;
				attackTimer = 3f;
				waitTime = 1;
				attacking = false;
			}
		} else {
			idle ();
		}
	}

	void follow(GameObject target){
		if(Vector3.Distance(target.transform.position, this.transform.position) > 6f){
			alert = false;
			//Debug.Log ("you got away");
		}else if(Vector3.Distance(target.transform.position, this.transform.position) < 1f){
			attacking = true;
		}else if(waitTime<0){
			Move (target.transform.position);

		}
		//Debug.Log("moving");
	}

	void idle(){
		if (timer <= 0f) {
			float x_rand = Random.Range (-5, 5)/10f;
			float y_rand = Random.Range (-5, 5)/10f;
			idle_target = new Vector3(x_rand + this.transform.position.x, y_rand + this.transform.position.y, 0);
			timer = Random.Range (3, 5);
			//Debug.Log ("new idle pos "+ idle_target);
		}if (Mathf.Abs(this.transform.position.x - idle_target.x) < .01f && Mathf.Abs(this.transform.position.y - idle_target.y) < .1f){
			_rigidbody.velocity = new Vector3 (0, 0, 0);
			timer -= Time.deltaTime;
		}else {
			Move (idle_target);
		}
	}

	void Move(Vector3 target){
		float speed = .75f;
		Vector3 newVel = (target - transform.position).normalized*speed;
		_rigidbody.velocity = newVel;
	}
		
	public void Alert(GameObject target){
		this.target = target;
		alert = true;
		timer = 0f;
		//Debug.Log ("alerted");
	}
		
}
