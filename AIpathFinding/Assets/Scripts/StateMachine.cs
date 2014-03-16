using UnityEngine;
using System.Collections;

public class StateMachine<T>{

	private T owner;
	private State<T> currentState{get; set;}
	private State<T> previousState{get; set;}
	private State<T> globalState{get; set;}

	public StateMachine(T t){
		owner = t;
		currentState = null;
		previousState = null;
		globalState = null;

	}

	public void SetCurrentState(State<T> s){
		currentState = s;
	}
	public void SetPreviousState(State<T> s){
		previousState = s;
	}
	public void SetGlobalState(State<T> s){
		globalState = s;
	}

	public void UpdateState(){

		if(globalState != null)
			globalState.Execute(owner);

		if(currentState != null)
			currentState.Execute(owner);

	}


	public void ChangeState(State<T> t){

		previousState = currentState;

		if(currentState != null)
			currentState.Exit(owner);

		currentState = t;

		currentState.Enter(owner);

	}

	public void RevertToPreviousState(){

		ChangeState(previousState);
	}
}
