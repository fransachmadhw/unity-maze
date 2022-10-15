using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rigid;
    private Animation idle;
    public Vector3 reset;
    public int AngkaScene;
    public Text myText;
    public Text myText2;
    public bool isMoving = true;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public Button ResetButton;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    public Material materialBola;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        idle = gameObject.GetComponent<Animation>();

        StartCoroutine(Mulai());

        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                rigid.AddForce(Vector3.right * 60f);
                //  sampleText.text = "Kanan";
                //  StartCoroutine(ExampleCoroutine());
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                rigid.AddForce(-Vector3.right * 60f);
                //  sampleText.text = "Kiri";
                //  StartCoroutine(ExampleCoroutine());
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                rigid.AddForce(Vector3.forward * 60f);
                //  sampleText.text = "Maju";
                //  StartCoroutine(ExampleCoroutine());
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                rigid.AddForce(-Vector3.forward * 60f);
                //  sampleText.text = "Mundur";
            }
        }
        if (rigid.velocity.x < 1 && rigid.velocity.x > -1 && rigid.velocity.y < 1 && rigid.velocity.y > -1 && rigid.velocity.z < 1 && rigid.velocity.z > -1)
        {
            idle.Play();
        }
        else
        {
            idle.Stop();
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        // Debug.Log(rigid.velocity);
    }

    IEnumerator Mulai()
    {
        if (AngkaScene == 1)
        {
            myText.text = "Level 1\nCapai garis finish tanpa nabrak!";
            yield return new WaitForSeconds(5);
            myText.text = "";
        }
        else if (AngkaScene == 2)
        {
            myText.text = "Level 2\nCapai garis finish tanpa nabrak!";
            yield return new WaitForSeconds(5);
            myText.text = "";
        }
        else if (AngkaScene == 3)
        {
            myText.text = "Level 3\nCapai garis finish tanpa nabrak!";
            yield return new WaitForSeconds(5);
            myText.text = "";
        }
    }

    IEnumerator Kalah()
    {
        myText.text = "Hati-hati dong!";
        yield return new WaitForSeconds(2);
        myText.text = "";
    }

    public IEnumerator Menang()
    {
        isMoving = false;
        for (int i = 5; i > 0; i--)
        {
            myText.text = "Buset, seriusan menang?\n" + i;
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("Credit");
    }

    void FixedUpdate()
    { }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            ResetButton.gameObject.SetActive(true);
            isMoving = false;
            myText.text = "Hati-hati dong!";
            //player.transform.position = reset;
            // StartCoroutine(Kalah());
            explode();
        }
        // if (collision.gameObject.tag == "Finish")
        // {
        //     AngkaScene += 1;
        //     if (AngkaScene == 4)
        //     {
        //         // Debug.Log("Menang");
        //         StartCoroutine(Menang());
        //     }
        // }
    }
    public void explode()
    {
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }
    public void createPiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        piece.GetComponent<Renderer>().material = materialBola;

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        Destroy(piece, 3);
    }
}
