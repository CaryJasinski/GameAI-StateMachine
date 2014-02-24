using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public GameObject Player;
	public Vector3 SpawnPosition = Vector3.zero;
	
	void Start () {
		SpawnPosition = this.transform.position;
		if(GameObject.FindGameObjectWithTag("Player") == null){
			Instantiate(Player, SpawnPosition, Quaternion.identity);
			GameObject.FindGameObjectWithTag("Player").name = "Player";
		}
	}

	void Update () {
		if(GameObject.FindGameObjectWithTag("Player") == null){
			Instantiate(Player, SpawnPosition, Quaternion.identity);
			GameObject.FindGameObjectWithTag("Player").name = "Player";
		}
	}
}
