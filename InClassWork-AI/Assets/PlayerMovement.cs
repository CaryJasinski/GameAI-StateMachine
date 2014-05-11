using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public NavMeshAgent agent;
	public Vector3 destination;
	
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update () 
	{
		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
				agent.SetDestination(hit.point);
		}
	}

}
