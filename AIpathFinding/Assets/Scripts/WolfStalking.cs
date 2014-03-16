using UnityEngine;
using System.Collections;

public class WolfStalking : State<Wolf> {

	private static WolfStalking instance;
	private static Collider target;
	private bool TargetFound;
	private Vector3 movement;
	
	
	private WolfStalking(){}
	
	public static WolfStalking Instance(){
		instance = new WolfStalking();
		
		return instance;
	}
	
	public override void Enter(Wolf t){
		TargetFound = false;
		Debug.Log("I am stalking! woo!");
		
	}
	
	public override void Execute(Wolf t){
		
		
		if(!TargetFound){
			target = t.nose.Collided;
			TargetFound = true;
			target.renderer.material.color = Color.red;
		}
		
		movement = (target.transform.position + (target.transform.forward * 40)) - t.transform.position;
		movement = MonoBehaviourInheritor.zeroY(movement);
		t.movement = movement;//target.transform.position - t.transform.position;
		movement.Normalize();
		t.faceForward();
		t.rigidbody.AddForce(movement * 7);
		
	}
	
	
	public override void Exit(Wolf t){
		
		
	}
}
