using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOnTraps : MonoBehaviour {

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.transform.parent.tag.Contains("Trap")){
			Debug.Log("got hit");
			FindObjectOfType<ChangeHealthBar>().ChangeHBar(-1);
		}
	}
}
