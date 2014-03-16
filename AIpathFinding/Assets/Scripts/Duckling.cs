using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Duckling : MonoBehaviour {

	public Transform Leader;
	private float fuzzyForce, fuzzySpeed, fDistance;
	//private List<Collider> lstFlockers;
	Collider[] arrFlockers;
	Duckling duckling;
	Vector3 vecChange;
	private bool inARow;

	public int iThisIterator;
	// Use this for initialization
	void Awake () {
		//lstFlockers.Add(this.transform);
		iThisIterator = -1;
		fuzzyForce = 10 + Random.Range(-1.5f,2f);
		fuzzySpeed = 0 + Random.Range(1f, 1.5f);
		fDistance = 3f;
		inARow = false;
	}

	void FixedUpdate(){
		getNeighbors();
		Seperation();
		Cohesion();
		Allignment();
		FollowLeader();
	}

	void getNeighbors(){

		arrFlockers = Physics.OverlapSphere(this.transform.position, 2);

	}
	void Allignment(){

		Vector3 average = Vector3.zero;
		int numbersOfDucks = 0;
		for(int i = 0; i < arrFlockers.Length; ++i){
			
			if(arrFlockers[i].gameObject.name == "Flock"){
				average+=arrFlockers[i].transform.position;
				numbersOfDucks++;
			}
		}
			average.Normalize();
		this.rigidbody.AddForce(average / numbersOfDucks);
	}


		



	void Cohesion(){
		for(int i = 0; i < arrFlockers.Length; ++i){
			
			if(arrFlockers[i].gameObject.name == "Flock" && distance(arrFlockers[i].transform) > 2f ){

			
			//else if(distance(lstFlockers[i].transform) > 3f){
				
				
				
				vecChange = -(this.transform.position - arrFlockers[i].transform.position);

				vecChange.Normalize();

				this.rigidbody.AddForce((vecChange * distance(arrFlockers[i].transform)) * fuzzyForce);
			}
		}


	}



	void Seperation(){
		for(int i = 0; i < arrFlockers.Length; ++i){
			
			if(arrFlockers[i].gameObject.name == "Flock" && distance(arrFlockers[i].transform) < 1f ){
				
				
				vecChange = (this.transform.position - arrFlockers[i].transform.position);

				vecChange.Normalize();
			
				this.rigidbody.AddForce((vecChange * distance(arrFlockers[i].transform)) * fuzzyForce);
			}
		}

	}

	void FollowLeader(){
		if(this.distance(Leader) > fDistance + 1)
		{
			if(Vector3.Dot(Leader.position, this.transform.position) < 0)
				;
			else
				this.rigidbody.AddForce((Leader.position - this.transform.position ) * this.distance(Leader) * (fuzzySpeed/2) );
		}
		else if (this.distance(Leader) < fDistance - 1)
		{
			if(Vector3.Dot(Leader.position, this.transform.position) < 0)
				;
			else
				this.rigidbody.AddForce(-(Leader.position - this.transform.position ) * this.distance(Leader)  * 3);
		}

	}

	float distance(Transform t){

		return Vector3.Distance(this.transform.position, t.position);

	}

//	void OnCollisionEnter(Collision c){
//
//		if(c.gameObject.name == "Flock")
//		{
//			vecChange = -(c.transform.position - this.transform.position) * Time.deltaTime * 10f;
//			//vecChange = new Vector3(vecChange.x, 0f, vecChange.z);
//			transform.position += vecChange;
//
//		}
//	}
}
