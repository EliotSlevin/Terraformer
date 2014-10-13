using UnityEngine;
using System.Collections;

public class limitSpeed : MonoBehaviour {


	
	public float maxVelocity  = 10.0f; //set in the inspector
	
	void Update()
	{
		Vector2 velocity = rigidbody2D.velocity;
		if (velocity == Vector2.zero) return;
		
		float magnitude = velocity.magnitude;
		if (magnitude > maxVelocity)
		{
			velocity *= (maxVelocity / magnitude);
			rigidbody2D.velocity = velocity;
		}
	}
}
