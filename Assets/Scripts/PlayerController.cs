using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rigid;
    public Vector3 reset;
    public int AngkaScene;
    public Text myText;
    public Button ResetButton;
    public bool isMoving = true;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(Mulai());
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            if(Input.GetAxis("Horizontal")>0)
            {
                rigid.AddForce(Vector3.right * 60f);
                //  sampleText.text = "Kanan";
                //  StartCoroutine(ExampleCoroutine());
            }
            if(Input.GetAxis("Horizontal")<0)
            {
                rigid.AddForce(-Vector3.right * 60f);
                //  sampleText.text = "Kiri";
                //  StartCoroutine(ExampleCoroutine());
            }
            if(Input.GetAxis("Vertical")>0)
            {
                rigid.AddForce(Vector3.forward * 60f);
                //  sampleText.text = "Maju";
                //  StartCoroutine(ExampleCoroutine());
            }
            if(Input.GetAxis("Vertical")<0)
            {
                rigid.AddForce(-Vector3.forward * 60f);
                //  sampleText.text = "Mundur";
            }
        }
    }

    IEnumerator Mulai()
    {
        if(AngkaScene == 1)
        {
            myText.text = "Level 1\nCapai garis finish tanpa nabrak!";
            yield return new WaitForSeconds(5);
            myText.text = "";
        }
        else if(AngkaScene == 2)
        {
            myText.text = "Level 2\nCapai garis finish tanpa nabrak!";
            yield return new WaitForSeconds(5);
            myText.text = "";
        }
        else if(AngkaScene == 3)
        {
            myText.text = "Level 3\nCapai garis finish tanpa nabrak!";
            yield return new WaitForSeconds(5);
            myText.text = "";
        }
    }

    // IEnumerator Kalah()
    // {
    //     myText.text = "Hati-hati dong!";
    //     yield return new WaitForSeconds(2);
    //     myText.text = "";
    // }

    IEnumerator Menang()
    {
        for (int i = 10; i > 0; i--)
        {
            myText.text = "Buset, seriusan menang?\n" + i;
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("Level1");
    }

    void FixedUpdate()
    {}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            ResetButton.gameObject.SetActive(true);
            isMoving = false;
            myText.text = "Hati-hati dong!";
            // StartCoroutine(Kalah());
        }
        if(collision.gameObject.tag == "Finish")
        {
            AngkaScene += 1;
            if (AngkaScene == 4)
            {
                // Debug.Log("Menang");
                StartCoroutine(Menang());
            }
            else
            {
                SceneManager.LoadScene("Level" + AngkaScene);
            }
        }
    }
}
