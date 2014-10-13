using UnityEngine;
using System.Collections;

public class rotateAround : MonoBehaviour {

	
	public float speed;
	public Transform origin;
	private float angle;
	private float radius;

	void Start () {
		radius = Vector2.Distance(this.transform.position, origin.position);
	//	angle = Vector2.Angle (origin.position, this.transform.position);

		Vector3 planetPos = origin.transform.position;
		Vector3 playerPos = this.transform.position;
		
		planetPos.x = planetPos.x - playerPos.x;
		planetPos.y = planetPos.y - playerPos.y;

		angle = (Mathf.Atan2 (planetPos.y, planetPos.x) * Mathf.Rad2Deg)-180;
	}

	void FixedUpdate () {
		angle += speed;


		float x = (Mathf.Cos (angle * Mathf.Deg2Rad) * radius) + origin.position.x;
		float y = (Mathf.Sin (angle * Mathf.Deg2Rad) * radius) + origin.position.y;
		                           	
		rigidbody2D.MovePosition (new Vector2 (x, y));
	}
}
