using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	public int speed;
	public Material fullColour;
	// Use this for initialization
	void Start () {
		print ("force added?");
		rigidbody2D.AddForce (transform.up * -speed);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "planet") {
			this.transform.parent = coll.transform;
			this.rigidbody2D.isKinematic = true;

			if (!(coll.transform.childCount > 2)) global.terraFormedCount++;
			coll.transform.renderer.material = fullColour;
		}
	}
}
