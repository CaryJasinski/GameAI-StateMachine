using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;

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

		transform.position = new Vector3(player.transform.position.x - 5,
		                                 player.transform.position.y + 15, 
		                                 player.transform.position.z - 5);

		transform.LookAt(player.transform);
	}
}
