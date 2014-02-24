using UnityEngine;
using System.Collections;

public class DeleteObject : MonoBehaviour {

	private int m_startTime;
	[HideInInspector]public int intDeathTimer = 180;
	public bool Kill = false;
	
	void Start () 
	{
		m_startTime = 0; 
	}
	void Update () 
	{
		if(Kill)
			Destroy(this.gameObject);
		if(this.gameObject.name == "Bullet") {
			SelfDestruct();
		}
	}
	void OnCollisionEnter (Collision other) 
	{
		if (this.tag == "Bullet" && other.gameObject.tag == "Player")
		{
			Destroy (other.gameObject);
			Destroy(this.gameObject);
		}
		else if(other.gameObject.tag != "Player")
			Destroy(this.gameObject);
	}
	void SelfDestruct () 
	{
		if (m_startTime >= intDeathTimer)
			Destroy(this.gameObject);
		m_startTime++;
	}
}
