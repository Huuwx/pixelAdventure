using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public GameObject panel;
    public Button SettingBtn;

    // Start is called before the first frame update
    void Start()
    {
        //panel.SetActive(false);
    }


    public void StartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void Setting()
    {
        panel.SetActive(true);
        SettingBtn.enabled = false;
    }

    public void Resume()
    {
        panel.SetActive(false);
        SettingBtn.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void Exit()
    {
        SceneManager.LoadScene("Home");
    }
}
