using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody rb;
    private player a;
  public   float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        a = GameObject.Find("player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a.game == true)
        {

            rb.AddForce((a.transform.position - transform.position).normalized * speed);
            if (transform.position.y < -2)
            {
                Destroy(gameObject);
            }
        }
    }
    
}
