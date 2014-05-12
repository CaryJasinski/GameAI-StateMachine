using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public int GameTimer = 60;

	// Use this for initialization
	void Start () {
		GameTimer *= 60;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		GameTimer--;
		if(GameTimer <= 0)
			Application.LoadLevel("Victory");
	}
	void OnGUI()
	{
		GUI.TextArea(new Rect(Screen.width/2 - 60, 25, 125, 25), "Time to Victory: " + (GameTimer/60));
	}
}
