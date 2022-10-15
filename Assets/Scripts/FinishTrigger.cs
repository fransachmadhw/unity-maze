using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(level);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        int level = player.AngkaScene;
        if (collider.name == "Player")
        {
            level += 1;
            // Debug.Log("masuk " + collider.name);
            if (level < 4)
            {
                SceneManager.LoadScene("Level" + level);
            }
            else
            {
                StartCoroutine(player.Menang());
            }
        }
    }
}
