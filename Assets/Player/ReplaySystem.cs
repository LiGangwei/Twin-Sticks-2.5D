using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {
	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
	private Rigidbody rigidbody;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		if(!(rigidbody = GetComponent<Rigidbody>())) {
			Debug.LogError("Rigidbody not found!");
		}
		if(!(gameManager = FindObjectOfType<GameManager>())) {
			Debug.LogError("GameManager not found!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.isPlayingBack) {
			Playback();
		} else {
			Record();
		}
		print(keyFrames[0].position);
	}

	void Playback() {
		rigidbody.isKinematic = true;
		int index = Time.frameCount % bufferFrames;
		transform.position = keyFrames[index].position;
		transform.rotation = keyFrames[index].rotation;
	}

	void Record() {
		// Why here? Why not just once before recording?
		rigidbody.isKinematic = false;
		int index = Time.frameCount % bufferFrames;
		keyFrames[index] = new MyKeyFrame(transform.position, transform.rotation, Time.time);
	}
}

/// <summary>
/// Struct for recording a frame in a game.
/// </summary>
public struct MyKeyFrame {
	public Vector3 position;
	public Quaternion rotation;
	public float time;

	public MyKeyFrame(Vector3 newPosition, Quaternion newRotation, float newTime) {
		position = newPosition;
		rotation = newRotation;
		time = newTime;
	}
}
