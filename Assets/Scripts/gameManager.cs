using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public PlayerController player;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            // if(pause==true){
            //     Time.timeScale = 1;
            //     pause = false;
            // }else{
            //     Time.timeScale = 0;
            //     pause = true;
            // }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                pause = true;
                player.myText.text = "Paused";
                player.myText2.gameObject.SetActive(true);
            }
        }
        else if (pause && Input.anyKeyDown)
        {
            pause = false;
            player.myText.text = "";
            player.myText2.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
