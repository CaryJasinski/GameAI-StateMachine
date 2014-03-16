using UnityEngine;
using System.Collections;

public class WolfScent : MonoBehaviour {

	public Collider Collided = null;
	
	void OnTriggerEnter(Collider c){
		
		if(c.gameObject.name == "Flock")
			Collided = c;
		
	}
	void OnTriggerStay(Collider c){
		if(c.gameObject.name == "Flock")
			Collided = c;
		
	}
}
