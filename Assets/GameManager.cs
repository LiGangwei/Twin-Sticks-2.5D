using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {
	public bool isPlayingBack = false;

	void Update() {
		if(CrossPlatformInputManager.GetButton("Fire1")) {
			isPlayingBack = true;
		} else {
			isPlayingBack = false;
		}
	}
}
