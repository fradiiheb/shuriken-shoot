using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreholder : MonoBehaviour {
public testtime script;
 public  float scores;
	// Use this for initialization
	void Start () {
		 script =  GameObject.FindGameObjectWithTag("GM").GetComponent<testtime>();   
	}
	
	// Update is called once per frame
	void Update () {
		scores=script.score;
	}
}
