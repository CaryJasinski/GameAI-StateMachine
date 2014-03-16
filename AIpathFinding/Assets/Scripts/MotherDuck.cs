using UnityEngine;
using System.Collections;

public class MotherDuck : MonoBehaviour {

	public StateMachine<MotherDuck> thisDuck;// = new StateMachine<MotherDuck>(MotherDuck);
	public int fuzzyFatigue;

	public int Fatigue;
	public Vector3 movement;
	//Vector2 dirVec;
	//private int angle;
	//Quaternion newDirToRotate;
	//public float length, yVec;

	//public bool isMoving, hasRotated, enumFinished, inState, test;

	// Use this for initialization
	void Awake () {
		Fatigue = 0;
		fuzzyFatigue = Random.Range(60,120);
		//inState = false;
		//test = false;
		thisDuck = new StateMachine<MotherDuck>(this);
		thisDuck.ChangeState(MotherDuckWandering.Instance());
		//thisDuck.UpdateState();
		movement = Vector3.zero;
		//prevMovement = Vector3.zero;

		//isMoving = true; 
		//hasRotated = false;


		//enumFinished = false;
	

	
	}
	void FixedUpdate(){

	
		thisDuck.UpdateState();




	}
	
	// Update is called once per frame
//	void Update () {
//		if(!enumFinished)
//			StartCoroutine(MovementTransition());
//
//		if(!isMoving){
//			decideNewDir();
//			hasRotated = true;
//
//
//
//		}
//	}

	public void faceForward(){
		if(movement != Vector3.zero)
			transform.rotation = Quaternion.LookRotation(movement);

	}
//	void decideNewDir(){
//		yVec = this.transform.position.y;
//		dirVec = Random.insideUnitCircle;
//		movement= new Vector3(dirVec.x,
//		                      0,
//		                      dirVec.y);
//
//		movement.Normalize();
//
//
//	}

//	public void _Timer(int t){
//
//		StartCoroutine(Start());
//
//	}
//
//	IEnumerator Start() {
//
//		yield return StartCoroutine(Timer(30));
//
//	}
//	
//	IEnumerator Timer(int t){
//
//		inState = true;
//		for(int i = 0; i< t; ++i)
//			yield return new WaitForFixedUpdate();
//		inState = false;
//		
//	}

//	IEnumerator MovementTransition(){
//		enumFinished = true;
//		int randomFuz = Random.Range(30, 56);
//		for(int i = 0; i< 60 + randomFuz; ++i)
//			yield return new WaitForFixedUpdate();
//
//		if(isMoving){
//			isMoving = false;
//			hasRotated = false;
//		}
//		else
//			isMoving = true;
//
//		enumFinished = false;
//	}

//	void directionChange(ref Vector3 movVec){
//		switch(direction){
//		case Direction.forward:
//			movVec = Vector3.left;
//			direction = Direction.left;
//			break;
//		case Direction.left:
//			movVec = Vector3.back;
//			direction = Direction.backward;
//			break;
//		case Direction.backward:
//			movVec = Vector3.right;
//			direction = Direction.right;
//			break;
//		case Direction.right:
//			movVec = Vector3.forward;
//			direction = Direction.forward;
//			break;
//
//		}
//
//	}
//
//	void perpVec(ref Vector3 movVec, Vector3 hitVec){
//
//
//		float x = 0f;
//		float y = 0f;
//		float z = 0f;
//
//		x = movVec.z * hitVec.x;
//		z = movVec.x * hitVec.z;
//		y = 0f;
//
//		if(x != 0)
//			x = x/x;
//		if(z !=0)
//			z = z/z;
//
//		movVec = new Vector3(-x,y,-z);
//
//
//	}
//
//
//	float inc(float x){
//		x--;
//
//		if(x < -1)
//			x=1;
//
//		return x;
//
//	}
}
//
//public enum Direction{forward,backward,left,right};
