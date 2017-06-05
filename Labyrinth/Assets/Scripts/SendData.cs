using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TaskOnClick()
  {
      try
      {  
          string ourPostData = "{ \"username\": \"" + SaveUsername.username + "\", \"points\": " + ScoreShower.scoreText.text + ", \"time\": " + TimeShower.timeText.text + "}";
		  Debug.Log(ourPostData);
          Dictionary<string,string> headers = new Dictionary<string, string>();
          headers.Add("Content-Type", "application/json");
          //byte[] b = System.Text.Encoding.UTF8.GetBytes();
          byte[] pData = System.Text.Encoding.ASCII.GetBytes(ourPostData.ToCharArray());
          ///POST by IIS hosting...
          WWW api = new WWW("http://192.168.0.18:4200/game", pData, headers);
          ///GET by IIS hosting...
          ///WWW api = new WWW("http://192.168.1.120/si_aoi/api/total?dynamix={\"plan\":\"TESTA02\"");
      }
      catch (UnityException ex) { Debug.Log(ex.Message); }
  }
}
