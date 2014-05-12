using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public Vector3 cameraOffset = new Vector3(-5, 15, -5);


	void Start () {
		LockCameraToPlayer();
	}

	void Update () {
		LockCameraToPlayer();
	}
	void LockCameraToPlayer()
	{
		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player");

		transform.position = player.transform.position + cameraOffset;

		transform.LookAt(player.transform);
	}
}
