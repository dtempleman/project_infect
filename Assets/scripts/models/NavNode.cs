using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavNode{

	Vector2 position;
	bool walkable;

	public NavNode(Vector2 pos, bool walkable = true){
		this.walkable = walkable;
		this.position = pos;
	}

	public void SetWalkable(bool walkable){
		this.walkable = walkable;
	}

	public bool IsWalkable(){
		return walkable;
	}

	public Vector2 GetPosiotion(){
		return position;
	}
}
