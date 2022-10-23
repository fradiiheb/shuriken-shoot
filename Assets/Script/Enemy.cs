using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float health = 3;
    public Text healthtext;
    public GameObject enemy;
    public GameObject player;
    public int max=10;
    public float enemySpeed = 3;
    public GameObject sc;
    public testtime script;
     AudioSource audio;
     bool dead=false;
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
            
            //enemySpeed=3.01f;
            max= 20;

        }
    }
    void Start()
       
    {
        audio = GameObject.FindGameObjectWithTag("scoreholder").GetComponent<AudioSource> ();
    health = Random.Range(1, max);
        
    }
    // Update is called once per frame
    void Update () {
          if(script.score> 30){ 
            
            //enemySpeed=3.1f;
            

        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
            //healthtext.text = "";
           
        }
        //healthtext.text = ""+health;
        sc.GetComponent<TextMesh>().text = "" + health;
        
        
            transform.position += Vector3.up * (-enemySpeed) * Time.deltaTime;
        
        if (health <= 0) {
            if(dead==false){
            audio.Play();
            dead=true;
            }
            Destroy(gameObject);
           
          
        }
        float x=max/3;
        float y=x*2;
        if(health > y){ 
            gameObject.GetComponent<Renderer>().material.color=Color.green;
        }else if((health  <= y)&&(health>x)){ 
            gameObject.GetComponent<Renderer>().material.color=Color.yellow;
        }else
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        //sc.transform.localPosition = Camera.main.ViewportToWorldPoint(this.transform.position);
       
    }
   
    



}
