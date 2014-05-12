using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {
	public GameObject Player;
	public Vector3 PlayerPosition;
	public Vector3 TargetPosition;
	public int cameraOffsetY = 10;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	void Start () {
		if(Player == null)
			FindPlayer ();
	}

	void Update () {
		if(Player == null)
			FindPlayer ();
		else
			LockCamera ();
	}

	void FindPlayer () {
		Player = GameObject.FindGameObjectWithTag("Player");
		//PlayerPosition = Player.transform.position;
	}

	void LockCamera () {
		PlayerPosition = Player.transform.position;
		TargetPosition = new Vector3(PlayerPosition.x, PlayerPosition.y + cameraOffsetY, PlayerPosition.z);
		this.transform.position = Vector3.SmoothDamp(this.transform.position, TargetPosition, ref velocity, smoothTime);
	}
}
