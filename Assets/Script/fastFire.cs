using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fastFire : MonoBehaviour {
public GameObject scoreholder;
void Start () {
		 scoreholder=GameObject.FindGameObjectWithTag("scoreholder");
	}
	 public void restart()
    {
       // canv.SetActive(false);
    	Debug.Log("dsq");
    	 Destroy(scoreholder);
        SceneManager.LoadScene(0);
        
    }
}
