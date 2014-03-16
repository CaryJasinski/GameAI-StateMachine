using UnityEngine;
using System.Collections;

public class MotherDuckRest : State<MotherDuck> {

	private MotherDuckRest(){}

	private static MotherDuckRest instance;

	public static MotherDuckRest Instance(){
		instance = new MotherDuckRest();

		return instance;

	}

	public override void Enter(MotherDuck t){

		Debug.Log("I'm tired");
	

	}
	
	public override void Execute(MotherDuck t){


		t.movement = Vector3.zero;

		--t.Fatigue;



		if(t.Fatigue == 0)
			t.thisDuck.ChangeState(MotherDuckWandering.Instance());
		
	}
	
	
	public override void Exit(MotherDuck t){
		
		Debug.Log("No more rest for me!");

	}


}
