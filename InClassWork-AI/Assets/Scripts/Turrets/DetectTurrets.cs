using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectTurrets : MonoBehaviour {

	//public static List<GameObject> stateMachines = new List<GameObject>();
	
	public SphereCollider DetectionRadius;
	public List<GameObject> TurretsInRadius = new List<GameObject>();
	public bool PlayerInRange = false, DecideToShoot = false;

	void Start () {
		//stateMachines.Add(this.gameObject);

	

		//TurretsInRadius.Add(this.gameObject);

	}

	void Update () {
		TurretsInRadius = CheckDetectionRadius();

		foreach(GameObject turret in TurretsInRadius){
			if(turret.transform.GetComponent<DetectTurrets>().PlayerInRange)
				DecideToShoot = true;


		}
		if(DecideToShoot)
			this.gameObject.SendMessage("StartShooting");
		else
			this.gameObject.SendMessage("StopShooting");

		DecideToShoot = false;

	}
	public List<GameObject> CheckDetectionRadius () {
		List<GameObject> detectedGameObjects = new List<GameObject>();
		foreach(Collider col in Physics.OverlapSphere(DetectionRadius.transform.position, DetectionRadius.radius/2))
		{
			if (col.gameObject.tag == "Turret" && !detectedGameObjects.Contains(col.gameObject))
			{
				detectedGameObjects.Add(col.gameObject);
			}

		}
		return detectedGameObjects;
	}
	public void OnTriggerEnter (Collider other) {
		if(other.tag == "Player"){
			PlayerInRange = true;
		} 
	}
	public void OnTriggerExit (Collider other) {
		if(other.tag == "Player") {
			PlayerInRange = false;
		}
  }
}
