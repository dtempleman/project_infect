using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshController : MonoBehaviour {

	NavMesh mesh;

	public Vector2 mesh_size;
	public float node_size;

	public LayerMask obsticle_mask;

	// Use this for initialization
	void Start () {
		//Generate ();
	}
	void Awake(){
		Generate ();
	}
	// Update is called once per frame
	void Update () {

	}

	public void Generate(){
		mesh = new NavMesh (mesh_size, node_size);
		SetWalkable ();
	}

	void SetWalkable(){
		Vector2 grid_dim = mesh.GetGridDimentions ();
		int i = 0;
		for (int x = 0; x < grid_dim.x; x++) {
			for (int y = 0; y < grid_dim.y; y++) {
				NavNode n = mesh.GetNode (x, y); 
				n.SetWalkable (!Physics2D.OverlapCircle(n.GetPosiotion(), node_size/2, obsticle_mask));
			}
		}
	}

	void OnDrawGizmosSelected(){
		int nodes_x = Mathf.RoundToInt (mesh_size.x / node_size);
		int nodes_y = Mathf.RoundToInt (mesh_size.x / node_size);

		for (int x = 0; x < nodes_x; x++) {
			for (int y = 0; y < nodes_y; y++) {
				Gizmos.color = (mesh.GetNode (x, y).IsWalkable ()) ? Color.white : Color.red;
				Gizmos.DrawSphere (mesh.GetNode(x,y).GetPosiotion(), node_size/2);

			}
		}
	}
}
