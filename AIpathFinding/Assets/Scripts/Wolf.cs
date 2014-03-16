using UnityEngine;
using System.Collections;

public class Wolf : MonoBehaviour {
	public int hunger, hungerThreashold;
	public WolfScent nose;
	public WolfSight eyes;
	public StateMachine<Wolf> thisWolf;
	public Vector3 movement;
	void Awake () {
		hunger = 0;
		hungerThreashold =30;
		nose = (WolfScent)GetComponentInChildren<WolfScent>();
		eyes = (WolfSight)GetComponentInChildren<WolfSight>();
		thisWolf = new StateMachine<Wolf>(this);
		thisWolf.ChangeState(WolfRest.Instance());
	}
	void FixedUpdate(){

		thisWolf.UpdateState();

	}

	public void ActivateScent(){
		GameObject[] arr = transform

	}

	public void faceForward(){
		if(movement != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(movement);
		
	}
	// Update is called once per frame

}
