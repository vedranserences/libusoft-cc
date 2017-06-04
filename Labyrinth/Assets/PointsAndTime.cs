using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsAndTime : MonoBehaviour {

	public static float finalTime;
	public static float finalScore;

	private Scene currentScene;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		finalTime = Time.timeSinceLevelLoad;
		if(currentScene.name.Contains("Easy")){
			finalScore = 1000 - finalTime;
		} else if (currentScene.name.Contains("Medium")) {
			finalScore = 1000 - finalTime/2;
		} else if (currentScene.name.Contains("Hard")) {
			finalScore = 1000 - finalTime/3;
		}
		
	}
}
