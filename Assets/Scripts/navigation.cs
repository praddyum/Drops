using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class navigation : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void credits()
    {
        SceneManager.LoadScene(4);
    }

    public void plantlist()
    {
        SceneManager.LoadScene(1);
    }

    public void realtime()
    {
        SceneManager.LoadScene(2);
    }

    public void ar()
    {
        SceneManager.LoadScene(3);
    }

    public void website()
    {
        Application.OpenURL("https://praddy2009.github.io/portfolio/");
    }


    public void linkedin()
    {
        Application.OpenURL("https://in.linkedin.com/in/praddyum");
    }

}
