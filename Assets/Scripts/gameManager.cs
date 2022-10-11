using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pause == false)
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
            }
        }
        else if (pause == true && Input.anyKeyDown)
        {
            Time.timeScale = 1;
            pause = false;

        }
    }
}
