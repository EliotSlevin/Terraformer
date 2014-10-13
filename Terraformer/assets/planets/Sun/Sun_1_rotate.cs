using UnityEngine;
using System.Collections;

public class Sun_1_rotate : MonoBehaviour {

	public float speed = 2;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime * speed);
	}
}
