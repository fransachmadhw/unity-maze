using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public PlayerController player;
    public Vector3 reset;
    public GameObject bola;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetPlayer()
    {
        bola.transform.position = reset;
        player.myText.text = "";
        player.ResetButton.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        player.isMoving = true;
        // Destroy(player.gameObject.piece, 1);
    }
}
