using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public float movespeed = 1f;
    float yPoss;
    
    public List <GameObject> bullet;
    public Transform Barrel;
   public float sPeedfire;
    private bool sPeedfirex=false;
    private bool power=false;
   public GameObject textoption;
  public GameObject deathanim;
   AudioSource audio;
  // public Text textop;
// Vector2 wx;
// Use this for initialization
void Start () {
    audio = GetComponent<AudioSource> ();
        yPoss = transform.position.y;
       
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, yPoss);
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("Fire", 0, sPeedfire);

        }
        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Fire");
        }

         Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0.975f, 0.25f));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0.025f, 0.05f));

        Vector3 pos = transform.position;
 
        pos.x = Mathf.Clamp(pos.x, -3.92f, 3.97f);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            print("GameOver");
            Destroy(collision.collider.gameObject);
          deathanim.GetComponent<Animation>().Play();
            Destroy(gameObject);

        }
        if (collision.collider.CompareTag("fastf"))
        {
            sPeedfirex=true;
             sPeedfire=0.15f;
             Destroy(collision.gameObject);
             StartCoroutine(speed());
              textoption.SetActive(true);
            StartCoroutine(desactive());
             textoption.GetComponent<TextMesh>().text="SpeedUp";

        }
        if (collision.collider.CompareTag("powerup"))
        {
            power=true;
             Bullet.bulletpower=3;
             Destroy(collision.gameObject);
             StartCoroutine(powerxd());
             textoption.SetActive(true);
            StartCoroutine(desactive());
             textoption.GetComponent<TextMesh>().text="PowerUp";


        }
    }
     IEnumerator desactive()
    {
        
        yield return new WaitForSeconds(1);
        textoption.SetActive(false);
    }

    IEnumerator powerxd()
    {
        
        yield return new WaitForSeconds(20);
        Bullet.bulletpower=1;
        power=false;
         textoption.SetActive(true);
          textoption.GetComponent<TextMesh>().text="PowerFinish";
           yield return new WaitForSeconds(1);
            textoption.SetActive(false);
      
    }

    IEnumerator speed()
    {
        
        yield return new WaitForSeconds(20);
        sPeedfire=0.3f;
        sPeedfirex=false;
         textoption.GetComponent<TextMesh>().text="SpeedFinish";
           yield return new WaitForSeconds(1);
            textoption.SetActive(false);

    }
    void Fire()
    {
        audio.Play ();
        if(sPeedfirex==true)
        Instantiate(bullet[1], Barrel.position, Quaternion.identity);
        else if(power==true)
        Instantiate(bullet[2], Barrel.position, Quaternion.identity);
        else
         Instantiate(bullet[0], Barrel.position, Quaternion.identity);
    }
}
