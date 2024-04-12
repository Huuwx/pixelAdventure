using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void StartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
