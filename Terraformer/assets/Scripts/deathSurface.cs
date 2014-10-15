using UnityEngine;
using System.Collections;

public class deathSurface : MonoBehaviour {
	float startTime;
	bool isDead = false;
	public GUIStyle deathStyle;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "sun") {
			isDead = true;
			coll.transform.renderer.material.color = new Color(255,0,0);
			startTime = Time.realtimeSinceStartup;
			Time.timeScale = 0.04f;
		}
	}

	void OnGUI () {
		if (isDead) {
			GUI.Label (new Rect((Screen.width/2)-150, (Screen.height/2)-100,300,200), "MISSION FAILURE: DEATH", deathStyle);
		}
	}

	void Update() {
		if (isDead) {
		GetComponent<SpriteRenderer> ().color = Color.red;
			if (Time.realtimeSinceStartup > (startTime + 2)) {
					this.transform.position = global.lastSeedLocation.position;
					Time.timeScale = 1;
					isDead = false;
			}
		} else {
			GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}
}
