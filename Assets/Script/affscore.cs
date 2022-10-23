using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class affscore : MonoBehaviour {
public Text scoretext;
public scoreholder script;
 
	// Use this for initialization
	void Start () {
		 script =  GameObject.FindGameObjectWithTag("scoreholder").GetComponent<scoreholder>();   
		 scoretext=GameObject.FindGameObjectWithTag("show").GetComponent<Text>(); 
	}
	
	// Update is called once per frame
	void Update () {
		scoretext.text="Score="+script.scores;
	}
}
