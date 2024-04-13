using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    string SceneName;
    public GameObject panel;
    public Button SettingBtn;

    // Start is called before the first frame update
    void Start()
    {
        //panel.SetActive(false);
    }


    public void StartBtn()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void Setting()
    {
        panel.SetActive(true);
        SettingBtn.enabled = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        panel.SetActive(false);
        SettingBtn.enabled = true;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1;

    }

    public void BackHomeScene()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }

    public void BtnLV1()
    {
        SceneName = "SampleScene";
        SceneManager.LoadScene(SceneName);
    }

    public void ChangeCharacterScene()
    {
        SceneName = "ChangeCharacterScene";
        SceneManager.LoadScene(SceneName);
    }
}
