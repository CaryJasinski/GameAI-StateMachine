using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour, PlatformState {

	public State s;
	public int TimerStart, TimerEnd;
	public bool startTimer = false;

	void Start () {
		s = State.lowered;
		TimerStart = 0;
		TimerEnd = 300;
	
	}

	void Update () {
		if(startTimer){
			TimerStart++;
			if(TimerStart >= TimerEnd){
				s = State.raised;
				startTimer = false;
				TimerStart = 0;
			}
		}

		if(s != State.lowered){
			ChangeState();
		}
	}
	public State CheckState(){
		return s;

	}
	public bool ChangeState(){
		//Add enter code and exit code
		if( s != State.raising || s != State.lowering || s != State.waiting){
			if(s == State.lowered){
				StartCoroutine(RaiseCylinder());
				//Initilization code should go before or after
				//There should also be code for exiting a state
				return true;
			}
			else if(s == State.raised){
				StartCoroutine(LowerCylinder());
				return true;
			}
		}

		if(s == State.waiting){
			waitingState();
			return true;
		}
		return false;
	}

	public void waitingState(){
		startTimer = true;
	}

	IEnumerator RaiseCylinder(){
		float yPOS = 0.5f * Time.deltaTime;
		s = State.raising;
		while(this.transform.position.y < this.transform.localScale.y){
			this.transform.Translate(new Vector3 (0, yPOS, 0)); 
			yield return new WaitForFixedUpdate();
		}
		s = State.waiting;
	}
	IEnumerator LowerCylinder(){
		float yPOS = 0.5f * Time.deltaTime;
		s = State.lowering;
		while(this.transform.position.y > -this.transform.localScale.y){
			this.transform.Translate(new Vector3 (0, -yPOS, 0)); 
			yield return new WaitForFixedUpdate();
		}
		s = State.lowered;
	}

//	void ChangeState(){
//		if(this.transform.position.y == -this.transform.localScale.y) 
//			StartCoroutine (RaiseCylinder ());
//		else
//			StartCoroutine (LowerCylinder ());
//	}
}
