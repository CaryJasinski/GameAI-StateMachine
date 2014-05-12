using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicAIController : MonoBehaviour {

	public NavMeshAgent agent;

	public int totalWaypoints;
	public List<Transform> Waypoints;
	public Transform CurrentWaypoint;
	public List<Transform> PreviousWaypoints;

	public float findWaypointRadius = 30.0f;
	public float findPlayerRadius = 15.0f;

	public bool chasingPlayer = false; 

	void Start () {

		GameObject[] goWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		foreach(GameObject waypoint in goWaypoints)
			Waypoints.Add(waypoint.transform);
		totalWaypoints = Waypoints.Count;

		agent = GetComponent<NavMeshAgent>();
		AssignDesination("random"); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		ScanForPlayer();
		if(!chasingPlayer)
		{
			if(PreviousWaypoints.Count < totalWaypoints - 1)
			{
				if(agent.remainingDistance < 0.01f)
				{
					AssignDesination("random");
					PreviousWaypoints.Add(CurrentWaypoint);
				}
			}
			else
			{
				ResetPath();
			}
		}
	}
	void ResetPath()
	{
		foreach( Transform waypoint in PreviousWaypoints)
			Waypoints.Add(waypoint);
		PreviousWaypoints.Clear();
	}
	void AssignDesination(string assignmentType)
	{
		switch(assignmentType)
		{
		case "random":
			AssignRandomWaypoint();
			break;
		case "nearest":
			AssignNearestWaypoint();
			break;
		}
	}

	void ScanForPlayer()
	{
		Collider[] overlapObjects = Physics.OverlapSphere(transform.position, findPlayerRadius);
		
		foreach(Collider obj in overlapObjects)
		{
			if(obj.CompareTag("Player"))
			{
				Vector3 PlayerPos = obj.transform.position;
				agent.SetDestination(PlayerPos);
				chasingPlayer = true;
			}
			else
			{
				chasingPlayer = false;
			}
		}
	}

	void AssignRandomWaypoint()
	{
		int randWaypoint = Random.Range(0, Waypoints.Count);
		agent.SetDestination(Waypoints[randWaypoint].position);
		CurrentWaypoint = Waypoints[randWaypoint];
		Waypoints.RemoveAt(randWaypoint);
	}
	
	void AssignNearestWaypoint()
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

		CurrentWaypoint = nearestObject;
		agent.SetDestination(nearestObject.position);
	}
}
