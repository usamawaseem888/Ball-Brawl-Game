using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed =15f;
    private player p;
    //GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        p=GameObject.Find("player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p.game == true)
        {
            float horiz = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.down * horiz * speed * Time.deltaTime);
        }
    }
}
