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

	//Messaging
	private int messageCount = 0;
	private float startTime;


	void Start(){
		GameObject[] planets;
		planets = GameObject.FindGameObjectsWithTag("planet");
		foreach (GameObject planet in planets) {
			planet.transform.renderer.material.SetFloat("_EffectAmount", 1f);
		}
	}


	void Update () {

		walkingAnimation.enabled = false;
		standingSprite.sprite = standing;
		
		
		// Chat Messages
		if (global.terraFormedCount == 0 && messageCount == 0 && Time.time > (startTime + 5)) {
			global.AddChatMessage("<b>Manager(private)</b>\nWelcome Employee 21105 to section 91. You have already been debriefed but I would like to repeat that you are here to terraform this section of space " +
			                      "for the indigenous colony that has contracted our help.\nYour suit allows you to use the LEFT and RIGHT arrows to move around planets and rotate while in space. Furthermore the SPACEBAR allows you " +
			                      "to jump between planets and the UP arrow will engage your Jet pack. Most " +
			                      "importantly while you are on planets press the DOWN arrow to plant seeds of life. Click the top of this window to close");
			messageCount++;
		} 
		if (global.terraFormedCount == 5 && messageCount == 1) {
			global.AddChatMessage("<b>Manager</b>\nToday is employee number 21852’s birthday");
			messageCount++;
		} 
		if (global.terraFormedCount == 10 && messageCount == 2) {
			global.AddChatMessage("<b>Employee 21100 (private)</b>\nCongratulations on getting area 91! The pay is really good. I hope after you" +
			                      "have terraformed the area we get stationed together. I really miss your crazy streak.");
			messageCount++;
		} 
		if (global.terraFormedCount == 15 && messageCount == 3) {
			global.AddChatMessage("<b>Unknown number (private)</b>\nTasukete kudasai! tasukete kudasai!");
			messageCount++;
		} 
		if (global.terraFormedCount == 20 && messageCount == 4) {
			global.AddChatMessage("<b>Employee number 21100 (private)</b>\nI think I’m going to quit the corporation and set up a home in area 89 it has nice a strong education system. " +
			                      "Alice is pregnant and I want to be there for her and the child. Wish me luck.");
			messageCount++;
		} 		
		if (global.terraFormedCount == 25 && messageCount == 5) {
			global.AddChatMessage("<b>Manager</b>\nEmployee number 21100 first child has just been born. A big congratulations to him.");
			messageCount++;
		} 
		if (global.terraFormedCount == 30 && messageCount == 6) {
			global.AddChatMessage("<b>Manager</b>\nThe Japanese republic has become too unstable and we will no longer be offering our services " +
			                      "until their economic situation becomes more stable.");
			messageCount++;
		} 
		if (global.terraFormedCount == 35 && messageCount == 7) {
			global.AddChatMessage("<b>Unknown (private)</b>\nHas the radiation been getting to your skin? Your suit just not cutting it for the more important things in life? Introducing Radi-Ecence " +
			                      "cream the fast and effective relief from the aging that radiation causes to your skin. New and improved formula!  ");
			messageCount++;
		} 
		if (global.terraFormedCount == 40 && messageCount == 8) {
			global.AddChatMessage("<b>Manager </b>\nSpace pirates have invaded area 89. Area’s 85 to 95 please report any sighing’s directly to head quarters. " +
			                      "Those areas mentioned are now in blue alert.");
			messageCount++;
		} 
		if (global.terraFormedCount == 45 && messageCount == 9) {
			global.AddChatMessage("<b>Unknown number (private)</b>\nIt’s … it’s consuming everything! Please come help me they weren’t fully tested. The seeds of life, " +
			                      "they are unstable. Don’t trust the corporation…don’t…");
			messageCount++;
		} 
		if (global.terraFormedCount == 50 && messageCount == 10) {
			global.AddChatMessage("<b>Manager</b>\nDue to unforeseen circumstances employee number 21103 has passed away. A moment of silence for our co worker");
			messageCount++;
		} 
		if (global.terraFormedCount == 55 && messageCount == 11) {
			global.AddChatMessage("<b>Manager</b>\nEmployee number 21104; please transfer to area 90 for black hole mining");
			messageCount++;
		} 
		if (global.terraFormedCount == 60 && messageCount == 12) {
			global.AddChatMessage("<b>Manager</b>\nToday is employee number 21105’s birthday");
			global.AddChatMessage("<b>Manager (private)</b> Happy birthday employee 21105");
			messageCount++;
		} 
		if (global.terraFormedCount == 65 && messageCount == 13) {
			global.AddChatMessage("<b>Employee 21100 (private)</b>\nJ̧̎̋͒ͥaͪ̈ç̔̑̽kͦͥ́ͣͥ̚ ͥͩ͋̑r̷͆͌͌͆u̧͛͆Ṅ̶ĎSͦͦ͊̌ͣ́̚A̶ ̌$!̄̈̓ͫ̅ ͂͆̃̅̌ͣ@̸ͥͬ̊ͯ ͤ͋̄͂̍͌̀̚E̴ͥ̊̀ͭ͗@̸̀̀̐̑̀ͬ̚Q ͫ̇̀̌ͣ͜M͌́̅ͭ̔̈̋L҉AK͊͑ͪ̉̆̑̏D̾ͬ9́̐͋͢ ͗̊#͂)̨͛ͧ̇̐@̓͐!ͭͬ͛̀");
			messageCount++;
		} 
		if (global.terraFormedCount == 70 && messageCount == 14) {
			global.AddChatMessage("<b>Manager (private)</b>\nWe are having technical issues with the com tower in your area you may have received some strange " +
			                      "communications please ignore them.");
			messageCount++;
		} 
		if (global.terraFormedCount == 75 && messageCount == 15) {
			global.AddChatMessage("<b>Unknown number (private)</b>\nDear Sir or Madam\nArea 89 has a large supply of seeds of energy on the market. If you transfer 20, " +
			                      "000 credits to my account I will acquire one for you and hold it until the end of your expedition if you transfer 20, 000 credits to me I will take 5% as a holding " +
			                      "fee and retain the seeds of energy for you. Please reply urgently with you credit transfer account details.\nBest regards - Kabuto yakushi");
			messageCount++;
		} 
		if (global.terraFormedCount == 80 && messageCount == 16) {
			global.AddChatMessage("<b>Manager</b>\nAreas 85 to 95 are now at red alert please report any disturbances directly to headquarters");
			messageCount++;
		} 
		if (global.terraFormedCount == 85 && messageCount == 17) {
			global.AddChatMessage("<b>Manager</b>\nPolitical tension are high in area 90 and area 85 therefore we will no longer be offering our services to those areas. Employee number’s 21850 and 21858 please transfer " +
			                      "to area 92\nEmployees near those areas please be extra careful");
			messageCount++;
		} 
		if (global.terraFormedCount == 90 && messageCount == 18) {
			global.AddChatMessage("<b>Manager (private)</b>\nGood job you have almost completed terraforming area 91. Further instructions will be presented to you when the system is at 100% health");
			messageCount++;
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
				


		//		}
// 		Placing Seeds
		if (Input.GetKeyDown (KeyCode.DownArrow) & inPlanet) {
			Vector2 temp = this.transform.position;
			Instantiate(seed, temp, this.transform.rotation);
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

	
