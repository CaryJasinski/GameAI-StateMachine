using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public NavMeshAgent agent;
	public Vector3 destination;
	public int SprintSpeed = 10;
	public int intSprintDuration = 150;
	public int intRechargeDelay = 30;

	private int m_sprintPower;
	private int m_rechargeDelay;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		m_sprintPower = intSprintDuration;
		m_rechargeDelay = intRechargeDelay; 
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

		if(m_sprintPower > 0 && Input.GetKey(KeyCode.LeftShift))
		{
			agent.speed = SprintSpeed;
			m_sprintPower--;
		}
		else
		{
			if( m_sprintPower < intSprintDuration)
			{
				m_rechargeDelay--;
				if(m_rechargeDelay <= 0)
				{
					m_sprintPower++;
				}
			}
			if(intSprintDuration == m_sprintPower)
				m_rechargeDelay = intRechargeDelay;
			agent.speed = 8;
		}
	}
	void OnGUI()
	{
		GUI.TextArea(new Rect(10,10, 125, 25), "Sprint Power: " + m_sprintPower);
	}
}
