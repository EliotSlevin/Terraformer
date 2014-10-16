using UnityEngine;
using System.Collections;

public class ChatGui : MonoBehaviour {
	void Start (){
		global.ChatBoxIsUp = false;
	}

	public GUISkin mySkin;
	public GUIStyle topPercent;


	void OnGUI () {	


		// Chat Box
		GUI.skin = mySkin;
		Rect chatLocation;
		Rect chatBackground;
		Rect topBar;
		

		if (global.ChatBoxIsUp) {
			chatLocation = new Rect (Screen.width - 310, Screen.height - 400, 300, 400);		
			chatBackground = new Rect (Screen.width - 310, Screen.height - 410, 300, 410);		
			topBar = new Rect (Screen.width - 310, Screen.height - 450, 300, 450);		
		} else {
			chatLocation = new Rect (Screen.width - 310, Screen.height, 300, 400);	
			chatBackground = new Rect (Screen.width - 310, Screen.height, 300, 410);		
			topBar = new Rect (Screen.width - 310, Screen.height - 40, 300, 40);		
		}
		GUI.Box (topBar, "");
		GUI.Box (chatBackground, "");

		global.ChatBoxIsUp  = GUI.Toggle (topBar, global.ChatBoxIsUp, "EMPLOYEE 21105 MESSAGES");

		GUILayout.BeginArea (chatLocation);
		int loopMax;
		if (global.ChatBoxMessages.Count < 10) {
				 loopMax = global.ChatBoxMessages.Count;
		} else {
			 loopMax = 10;
		}

		for (int i = 0; i < loopMax; i++ ){
				string messageText = (string) global.ChatBoxMessages[i];
				GUILayout.Label (messageText);
		}
		GUILayout.EndArea ();


		// Seed Count
		Rect counterLocation = new Rect(Screen.width/2-100, 0,200,40);
		GUI.Box (counterLocation, "");
		GUI.Label (counterLocation, "Section 91 Health : " + global.terraFormedCount + "%", topPercent);
	}
}