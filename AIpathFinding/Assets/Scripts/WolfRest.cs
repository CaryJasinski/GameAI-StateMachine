using UnityEngine;
using System.Collections;

public class WolfRest : State<Wolf> {

	private static WolfRest instance;

	private WolfRest(){}
	public static WolfRest Instance(){
		instance = new WolfRest();
		
		return instance;
		
	}

	public override void Enter(Wolf t){
		Debug.Log ("I am resting! Woo!");
		
	}
	
	public override void Execute(Wolf t){
		t.hunger++;

		if(t.hunger >= t.hungerThreashold)
			t.thisWolf.ChangeState(WolfLookForFood.Instance());
		
	}
	
	
	public override void Exit(Wolf t){
		
		
	}
}
