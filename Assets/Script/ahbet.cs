using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ahbet : MonoBehaviour {

	

   
    public float enemySpeed = 3;
    
    public testtime script;
    void Awake()

    {
        
        if (this.enabled == false)
        {
            this.enabled = true;
        }   //rest.transform.position = transform.position;
        if (this.GetComponent<BoxCollider2D>().enabled == false)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
         script =  GameObject.FindGameObjectWithTag("GM").GetComponent<testtime>();   
        
          if(script.score> 30){ 
            
            enemySpeed=3.1f;
            

        }
    }
   
    // Update is called once per frame
    void Update () {
          if(script.score> 30){ 
            
            enemySpeed=3.1f;
            

        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
            //healthtext.text = "";
           
        }
        //healthtext.text = ""+health;
       
        
        
            transform.position += Vector3.up * (-enemySpeed) * Time.deltaTime;
        
      
    }
   
    



}