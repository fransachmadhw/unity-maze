using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject bola;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(button: 0))
        {
            Instantiate(original: bola, position: transform.position, rotation: Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Lantai")
        {
            Destroy(bola, 2);
        }
    }
}
