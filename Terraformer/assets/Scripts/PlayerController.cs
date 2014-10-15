using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public static bool inPlanet;
	public GameObject seed;

	public float speed = 12;
	public float jumpHeight = 10;
	public float jetPackSpeed = 10;
	public float spaceRotateSpeed = 20;

	public float startWalkBoost = 5;
	public float endWalkDampening = 7;
	public AudioSource jetPackSound;
	public AudioSource walkLoopSound;
	public AudioClip seedDropSound;
	public AudioSource audioSeedDropSound;

	public SpriteRenderer standingSprite;
	public Animator walkingAnimation;
	public Sprite standing;
	private int countTest = 0;


	void Update () {

		walkingAnimation.enabled = false;
		standingSprite.sprite = standing;
		

// MESSAGE TESTING MUST REMOVE //
		if (Input.GetKeyDown (KeyCode.P)) {
			countTest ++;
			global.AddChatMessage("<b>Manager</b>\nTry using space to jump. You can jump over to nearby planets, but there's a good chance you'll get stuck in space. Use <i>left</i> and <i>right</i> to rotate around in space, and <i>up</i> to use your jetpack." + countTest.ToString());
		}





//		Left Right Movement
		if(Input.GetKey (KeyCode.LeftArrow)){
			if (inPlanet){
				walkingAnimation.enabled = true;
				walkingAnimation.SetInteger("direction", 1);
				rigidbody2D.AddForce (-transform.right * speed) ;
			} else{
				rigidbody2D.AddTorque (spaceRotateSpeed);
			}
		}

		if (Input.GetKey (KeyCode.RightArrow)){
			if (inPlanet){
				walkingAnimation.enabled = true;
				walkingAnimation.SetInteger("direction", 2);
				rigidbody2D.AddForce (transform.right * speed);
			} else{
				rigidbody2D.AddTorque (-spaceRotateSpeed);
			}
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			moveRight(startWalkBoost);	
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			moveLeft(startWalkBoost);	
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			moveRight(endWalkDampening);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			moveLeft(endWalkDampening);
		}


//		Jumping
		if (Input.GetKey (KeyCode.UpArrow)) {
						rigidbody2D.AddForce (transform.up * jetPackSpeed);	
			jetPackSound.enabled = true;
			jetPackSound.loop = true;
				} else {
			jetPackSound.enabled = false;
			jetPackSound.loop = false;		
		}

		if (Input.GetKeyDown (KeyCode.Space) & inPlanet) {
			rigidbody2D.AddForce (transform.up * jumpHeight);
		}


// 		Walking Audio Loop
		if ((Input.GetKey (KeyCode.RightArrow)) || (Input.GetKey (KeyCode.LeftArrow))) {
						if (inPlanet) {
								walkLoopSound.enabled = true;
								walkLoopSound.loop = true;
						}
				} else {
								walkLoopSound.enabled = false;
								walkLoopSound.loop = false;		
						}
				
//		Seed Drop Sound
		//if (Input.GetButtonDown ("use") && inRange) {
		//	audio.PlayOneShot(seedDropSound);

		//		}
// 		Placing Seeds
		if (Input.GetKeyDown (KeyCode.DownArrow) & inPlanet) {
			Vector2 temp = this.transform.position;
			Instantiate(seed, temp, this.transform.rotation);
			audioSeedDropSound.PlayOneShot (seedDropSound);
		}
	}

	void moveLeft(float multiAmount){
		if (inPlanet){
			rigidbody2D.AddForce (-transform.right * (speed*multiAmount)) ;
		} 	
	}

	void moveRight(float multiAmount){
		if (inPlanet){
			rigidbody2D.AddForce (transform.right * (speed*multiAmount)) ;
		} 	
	}
}

	
