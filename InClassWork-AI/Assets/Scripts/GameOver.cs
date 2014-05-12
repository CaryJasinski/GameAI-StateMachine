using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		GUI.color = Color.red;
		GUI.TextField(new Rect(Screen.width/2 - 50, Screen.height/2 - 50, 100, 50), "Game Over");
		if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 + 25, 100, 50), "Play Again?"))
		{
			Application.LoadLevel("NavGraphDemo");
		}
	}
}
