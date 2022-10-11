using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int AngkaScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
