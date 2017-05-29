using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {
	GameObject ball;
	private Vector3 armRotation;

	// Use this for initialization
	void Start () {
		if(!(ball = GameObject.FindGameObjectWithTag("Player"))) {
			Debug.LogError("Ball not found!");
		}
		armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ball.transform.position;

		armRotation.y += CrossPlatformInputManager.GetAxis("RHorizontal");
		armRotation.x += CrossPlatformInputManager.GetAxis("RVertical");

		transform.rotation = Quaternion.Euler(armRotation);
	}
}
