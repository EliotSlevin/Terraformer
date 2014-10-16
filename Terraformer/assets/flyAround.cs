using UnityEngine;
using System.Collections;

public class flyAround : MonoBehaviour {

	private float angle = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float y = Mathf.Sin (angle)*2;
		Vector3 move = new Vector3 (transform.position.x, y, 0);
		transform.position = move;
		angle += 0.01f;
	}
}
