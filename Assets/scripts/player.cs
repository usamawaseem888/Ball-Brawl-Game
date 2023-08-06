using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private AudioSource au_dio;
    public AudioClip crash, strike,ppow;
    public static int mark = 0,life=3;
    public float speed = 5f;
    private Rigidbody rb;
    private rotate r;
    private GameObject b;
    GameObject c;
    public bool game = true;
   public  bool powerup = false;
    // Start is called before the first frame update
    void Start()
    {
        au_dio=GetComponent<AudioSource>();
        rb=GetComponent<Rigidbody>();
        r = GameObject.Find("focal point").GetComponent<rotate>();
        b = GameObject.Find("focal point");
       c = GameObject.Find("pow");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (game == true)
        {


            float inn = Input.GetAxis("Vertical");
            float horiz = Input.GetAxis("Horizontal");
            player_Postion();
            //rb.AddForce(r.transform.forward * speed * inn);
            rb.AddForce(b.transform.forward * speed * inn);
            rb.AddForce(Vector3.right * horiz * speed);
            c.transform.position = rb.transform.position;
            c.SetActive(powerup);
            Debug.Log(mark);
            if (life < 0)
            {
                game = false;
            }
        }
    }
    void player_Postion()
    {
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
            game = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerup"))
        {
            Destroy(other.gameObject);
            powerup = true;
            au_dio.PlayOneShot(ppow, 1f);
        }
        StartCoroutine(po());
        if (other.gameObject.CompareTag("scoree"))
        {
            mark++;
            Destroy(other.gameObject);
            au_dio.PlayOneShot(ppow, 1f);
        }
    }

    IEnumerator po()
    {
        yield return new WaitForSeconds(speed);
        powerup=false;
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && powerup)
        {
            Vector3 away=collision.transform.position-transform.position;
            Debug.Log("collided with enemy");
            mark += 3;
           // Destroy(collision.gameObject);
           collision.rigidbody.AddForce(away*15,ForceMode.Impulse);
            powerup = false;
            au_dio.PlayOneShot(strike, 1f);

        }
        else if(collision.gameObject.CompareTag("enemy"))
        {
            life--;
            au_dio.PlayOneShot(crash, 1f);
        }
    }
}
