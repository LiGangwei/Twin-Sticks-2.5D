using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraPan : MonoBehaviour {
	GameObject ball;

	// Use this for initialization
	void Start () {
		if(!(ball = GameObject.FindGameObjectWithTag("Player"))) {
			Debug.LogError("Ball not found!");
		}
	}

	void LateUpdate() {
		transform.LookAt(ball.transform);
	}
}
