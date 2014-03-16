using UnityEngine;
using System.Collections;

public class WolfLookForFood : State<Wolf> {

	private static WolfLookForFood instance;
	private int wanderTime;
	private bool wanderDirectionChosen;
	private Vector3 movement;


	private WolfLookForFood(){}

	public static WolfLookForFood Instance(){
		instance = new WolfLookForFood();

		return instance;
	}

	public override void Enter(Wolf t){
		Debug.Log ("I am looking for food! Woo!");
		wanderDirectionChosen = false;
		wanderTime = 0;
		
	}
	
	public override void Execute(Wolf t){

		wanderTime++;
		if(!wanderDirectionChosen){
			Vector2 dirVec = Random.insideUnitCircle;
			movement = new Vector3(dirVec.x,
			                       0,
			                       dirVec.y);
			
			movement.Normalize();
			t.movement = movement;
			wanderDirectionChosen = true;
			Debug.Log(t.movement);
			t.faceForward();
		}

		if(wanderTime > 180){
			wanderTime = 0;
			wanderDirectionChosen = false;

		}

		if(t.nose.Collided!=null)
			t.thisWolf.ChangeState(WolfStalking.Instance());
		
		t.rigidbody.AddForce(movement * 7);
		
	}
	
	
	public override void Exit(Wolf t){
		
		
	}
}


