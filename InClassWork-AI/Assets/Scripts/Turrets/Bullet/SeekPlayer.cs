using UnityEngine;
using System.Collections;

public class SeekPlayer : MonoBehaviour {

	public Transform target;
	private float fltStartingYAxis;
	public float fltBulletSpeed = 4;
	private Vector3 vectorToChange;

	void Start () 
	{
		fltStartingYAxis = this.transform.position.y;
		vectorToChange = this.transform.position;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () 
	{
		this.transform.LookAt(target.position, transform.up);
		
		vectorToChange += fltBulletSpeed * Time.deltaTime * transform.forward;
		vectorToChange.y = fltStartingYAxis;
		this.transform.position = vectorToChange;
	}
}
