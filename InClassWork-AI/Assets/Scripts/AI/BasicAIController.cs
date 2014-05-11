using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicAIController : MonoBehaviour {
	
	public NavMeshAgent agent;
	public float findWaypointRadius = 30.0f;
	public float findPlayerRadius = 15.0f;
	
	public List<Transform> previousWaypoints;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//travel to the closest waypoint if it is not one of the last two that were traveled to

		//The AI will find it's way point using an overlap shpere 
		//It will then determine which waypoint is closest and travel to that first

		//AI walks along it's path, waypoint to waypoint
		//If the player is found AI will target player player until the player is out of range
		//When the player position is lost travel to the nearest waypoint 
		// if no waypoint is in range travel back to the start4
		if(!previousWaypoints.Contains(GetNearestWaypoint())) 
			previousWaypoints.Add(GetNearestWaypoint());

		agent.SetDestination(previousWaypoints[0].position);
	}

	Transform GetNearestWaypoint()
	{
		float nearestDistanceSqr = Mathf.Infinity;
		Collider[] overlapObjects = Physics.OverlapSphere(transform.position, findWaypointRadius);
		Transform nearestObject = null;
		
		foreach(Collider obj in overlapObjects)
		{
			if(obj.CompareTag("Waypoint"))
			{
				Vector3 objPos = obj.transform.position;
				float distanceSqr = (objPos - transform.position).sqrMagnitude;
				
				if(distanceSqr < nearestDistanceSqr)
				{
					nearestObject = obj.transform;
					nearestDistanceSqr = distanceSqr;
				}
			}
		}
		
		return nearestObject;
	}
}
