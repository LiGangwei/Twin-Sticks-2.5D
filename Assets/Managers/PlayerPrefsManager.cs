using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
	const string LEVEL_UNLOCKED = "level_unlocked";

	// Saves max level reached assuming int level is the scene index in build instead of level number in game context
	public static void UnlockLevel(int level) {
		if(level <= SceneManager.sceneCountInBuildSettings - 1 && level > 0) {
			PlayerPrefs.SetInt(LEVEL_UNLOCKED, level);
		} else {
			Debug.LogError("Level out of bounds!");
		}
	}

	public static int FurthestLevelReached() {
		return PlayerPrefs.GetInt(LEVEL_UNLOCKED);
	}


//  This was how Ben did it in Glitch Garden, it stores each unlocked level as a new int key, using the int value as a kind of bool instead(1 for true and 0 for false)
//  I guess this has the benefit of being able to storing individual unlocked levels instead of furthest level reached

//	public static void UnlockLevel(int level) {
//		if((level <= Application.levelCount - 1) && (level >= 0)) {
//			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //1 for true
//		} else {
//			Debug.LogError("Level out of bounds");
//		}
//	}
//
//	public static bool IsLevelUnlocked(int level) {
//		if((level <= Application.levelCount - 1) && (level >= 0)) {
//			//			if(PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1) {
//			if(PlayerPrefs.HasKey(LEVEL_KEY + level.ToString())) {
//				return true;
//			} else {
//				return false;
//			}
//		} else {
//			Debug.LogError("Level out of bounds");
//			return false;
//		}
//	}
}
