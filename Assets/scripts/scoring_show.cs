using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoring_show : MonoBehaviour
{
    public TextMeshProUGUI sco,lif;
    public TextMeshProUGUI Game;
    private player a;
    // Start is called before the first frame update
    void Start()
    {
        sco.text = player.mark.ToString();
        lif.text = player.life.ToString();
        a=GameObject.Find("player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        sco.text = "score: " + player.mark.ToString();
        lif.text = "Life: " + player.life.ToString();
        if (a.game == false ) 
        {
            Endgame();
        }
    }
    void Endgame()
    {
       
        Game.text = "Game Over";
        player.life = 0;

       
    }
}
