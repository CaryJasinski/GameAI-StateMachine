using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Application.LoadLevel("GameOver");
		}
	}
}
