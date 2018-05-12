using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMesh{

	NavNode[,] grid;
	Vector2 mesh_size;
	float node_size;

	//creates an empty NavMesh
	public NavMesh(Vector2 mesh_size, float node_size){

		int nodes_x = Mathf.RoundToInt (mesh_size.x / node_size);
		int nodes_y = Mathf.RoundToInt (mesh_size.y / node_size);

		this.grid = new NavNode[nodes_x, nodes_y];
		this.mesh_size = mesh_size;
		this.node_size = node_size;

		for (int x = 0; x < nodes_x; x++) {
			for (int y = 0; y < nodes_y; y++) {

				//assuming centred at (0,0) world space
				float new_x =  - (nodes_x / 2)*node_size + (x * node_size);
				float new_y =  - (nodes_y / 2)*node_size + (y * node_size);

				Vector2 node_pos = new Vector2 (new_x, new_y);
				grid [x, y] = new NavNode (node_pos);
			}
		}
	}

	//returns the NavNode at 'world_pos'
	public NavNode GetNode(int x, int y){
		return grid [x, y];
	}

	public NavNode GetNodeAtWorldPos(){
		return null;
	}

	public NavNode[] GetPath(Vector2 start, Vector2 end){
		//calc the grid pos of 'start' and 'end'
		//return a path of NavNodes from start to end
		return null;
	}

	//returns the dimentions of the grid
	public Vector2 GetGridDimentions(){
		return new Vector2 (grid.GetLength(0), grid.GetLength(1));
	}


}
