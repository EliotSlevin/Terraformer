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
			global.lastSeedLocation = this.transform;

			if (!(coll.transform.childCount > 2)){ 
				global.terraFormedCount++;
				//coll.transform.renderer.material.SetFloat("_EffectAmount", 0.5f);
				//coll.transform.renderer.material = fullColour;
				StartCoroutine(Fade(coll.transform.renderer));
			}
		}
	}

	IEnumerator Fade(Renderer itemToFade) {
		for (float f = 1f; f >= 0; f -= 0.01f) {

			itemToFade.material.SetFloat("_EffectAmount", f);
			if (f == 0) itemToFade.material = fullColour;
			yield return null;
		}
	}
}
