using UnityEngine;
using System.Collections;


public class MotherDuckWandering : State<MotherDuck> {

	private static MotherDuckWandering instance;

	private bool wanderDirectionChosen;
	 
	private Vector3 movement;

	private MotherDuckWandering(){}
	public static MotherDuckWandering Instance(){
		instance = new MotherDuckWandering();

		return instance;

	}

	public override void Enter(MotherDuck t){
		Debug.Log("Time for wandering");

		wanderDirectionChosen = false;
		
	}
	
	public override void Execute(MotherDuck t){

		++t.Fatigue;
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

		t.rigidbody.AddForce(movement * 7);

		if(t.Fatigue >= 180 + t.fuzzyFatigue)
			t.thisDuck.ChangeState(MotherDuckRest.Instance());


	}
	
	
	public override void Exit(MotherDuck t){

		Debug.Log("This is no time for Wandering");
		t.movement = Vector3.zero;
		wanderDirectionChosen = true;
		
	}


}
