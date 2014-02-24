using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerPlatforms : MonoBehaviour {
	public GameObject Plat1;
	public GameObject Plat2;
	public GameObject Plat3;
	public List<GameObject> Platforms;
	public bool triggered = false;
	Platform platform;
	State s;

	void Start () {
		Platforms.Add (Plat1);
		Platforms.Add (Plat2);
		Platforms.Add (Plat3);
	}

	void Update () {

	}

	void Cylinder(){
		foreach (GameObject c in Platforms) {
			platform = (Platform)c.gameObject.GetComponent<Platform>();
			Debug.Log(platform.CheckState());
			platform.ChangeState();
		}
	}
	void OnTriggerEnter (Collider c) {
		if (c.tag == "Player") {
			Cylinder ();		
		}
	}
}
