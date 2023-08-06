using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class spawn : MonoBehaviour
{
    private int spawnTime;
    private player p;
    public GameObject b;
    public GameObject power,scoree;
   
    int wave=1;
    // Start is called before the first frame update
    void Start()
    {
        p=GameObject.Find("player").GetComponent<player> ();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p.game == true)
        {
            spawnTime = FindObjectsOfType<enemy>().Length;
            if (spawnTime == 0)
            {
                wave++;
                spp();
            }
            if (GameObject.FindGameObjectsWithTag("powerup").Length == 0)
            {
                StartCoroutine(powers());
                spawn_power(power);
            }

            StartCoroutine(ps());
        }
        
    }
    IEnumerator ps()
    {
        yield return new WaitForSeconds(8);
       
        if (GameObject.FindGameObjectsWithTag("scoree").Length == 0)
        {
            
            spawn_power(scoree);

        }
    }
    IEnumerator powers()
    {
        yield return new WaitForSeconds(15);
    }
    void spawn_power(GameObject b)
    {
        Vector3 v = new Vector3(Random.Range(-9, 9), power.transform.position.y, Random.Range(-9, 9));
        StartCoroutine(ps());
        Instantiate(b, v, b.transform.rotation);
        


    }
    void spp()
    {
        Vector3 spawnn;
        for (int i = 0; i < wave; i++)
        {
            spawnn = spawnLocaion();
            Instantiate(b, spawnn, b.transform.rotation);
        }
    }
    private Vector3 spawnLocaion()
    {
        float xx = Random.Range(-9, 9);
        float zz = Random.Range(-9, 9);
        Vector3 vv = new Vector3(zz, 0, xx);
        return vv;
    }
}
