using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class testtime : MonoBehaviour {
    public List<Transform> rest;
    public GameObject enemy;
    public GameObject player;
    public Text scoretext;
    public  float score=0f;
    public GameObject canv;
    public move sc;
     public GameObject scx;
 public int numElements;
      public List <GameObject> optionx;
    void Start()
    {
         numElements = optionx.Capacity;
        StartCoroutine(Example());
        awed();
         sc =  GameObject.FindGameObjectWithTag("Player").GetComponent<move>();   
       
    }
    void awed()
    {
        
         StartCoroutine(Option());

    }
    void ebda()
    {
        StartCoroutine(Example());
         

    }
    void Update()
    {
        scx.GetComponent<TextMesh>().text = "" + score;;
        scoretext.text = "Score: " + score;
        if(score> 30){ 
            //sc.sPeedfire=0.15f;
        }
    }
    IEnumerator Option()
    {
        
      
        yield return new WaitForSeconds(13);

       //Instantiate(enemy, rest[0].transform.position, Quaternion.identity);
       Instantiate(optionx[Random.Range(0, numElements)], rest[Random.Range(0, 6)].position, Quaternion.identity);
       
       awed();
    }
    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(5);
       
        Instantiate(enemy, rest[0].transform.position, Quaternion.identity);
        Instantiate(enemy, rest[1].transform.position, Quaternion.identity);
        Instantiate(enemy, rest[2].transform.position, Quaternion.identity);
        Instantiate(enemy, rest[3].transform.position, Quaternion.identity);
        Instantiate(enemy, rest[4].transform.position, Quaternion.identity);//to hide
        Instantiate(enemy, rest[5].transform.position, Quaternion.identity);
        Instantiate(enemy, rest[6].transform.position, Quaternion.identity);//to hide


        if (player != null)
        {
            ebda();
        }
        else
        {
          //   canv.SetActive(true);
           SceneManager.LoadScene(1);


        }
    }


}
