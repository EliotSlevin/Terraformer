using UnityEngine;
using System.Collections;

public static class global{
	public static int terraFormedCount = 0;
	public static int numberOfPlanets = 100;
	public static bool ChatBoxIsUp;
	public static ArrayList ChatBoxMessages = new ArrayList();
	public static Transform lastSeedLocation;

	public static void AddChatMessage (string text){
		ChatBoxMessages.Insert (0, text);
		ChatBoxIsUp = true;
	}





}
