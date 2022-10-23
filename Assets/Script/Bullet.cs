using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletSpeed = 8;
    public testtime script;
    public static int bulletpower = 1;
AudioSource audio;
    void Start()

    {
         audio = GameObject.FindGameObjectWithTag("GM").GetComponent<AudioSource> ();
     script = GameObject.FindGameObjectWithTag("GM").GetComponent<testtime>();

    }
    // Update is called once per frame
    void Update () {

        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.x > max.x || transform.position.x < min.x
            || transform.position.y > max.y || transform.position.y < min.y)
            Destroy(gameObject);


    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy")) {
        collision.collider.GetComponent<Enemy>().health-=bulletpower;
        audio.Play ();
            script.score++;

            Destroy(gameObject);
        
       }
    }

}
