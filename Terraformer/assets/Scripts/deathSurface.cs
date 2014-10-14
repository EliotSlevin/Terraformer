using UnityEngine;
using System.Collections;

public class deathSurface : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "sun") {
			this.transform.position = global.lastSeedLocation.position;
		}
	}
}
