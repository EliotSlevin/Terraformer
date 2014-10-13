using UnityEngine;
using System.Collections;

public class Attractor : MonoBehaviour {

	public float gravity = -12;
	public float radius = 4.2f;

	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {

			PlayerController.inPlanet = true;



			Vector2 angle = (coll.transform.position - transform.position).normalized;
			coll.attachedRigidbody.AddForce(angle * (gravity*angle.magnitude));


			Vector3 planetPos = this.transform.position;
			Vector3 playerPos = coll.transform.position;

			planetPos.x = planetPos.x - playerPos.x;
			planetPos.y = planetPos.y - playerPos.y;


			float rotateAngle = (Mathf.Atan2 (planetPos.y, planetPos.x) * Mathf.Rad2Deg) + 90;
			//coll.transform.rotation = Quaternion.Euler (new Vector3(0,0, rotateAngle));
			coll.rigidbody2D.MoveRotation(rotateAngle);
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		PlayerController.inPlanet = false;
	}
}
