using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    private static HomeController instance;

    public static HomeController Instance { get => instance; }

    string SceneName;
    public GameObject panel;
    public GameObject panelDoneGame;
    public GameObject panelChangeCharacter;
    public Button SettingBtn;



    // Start is called before the first frame update
    void Start()
    {
        //panel.SetActive(false);
    }


    public void GameOver()
    {
        Time.timeScale = 0;
        panelDoneGame.SetActive(true);
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void SoundSettingScene()
    {
        SceneManager.LoadScene("SoundSetting");
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

    public void NinJaFrogBtn()
    {
        Debug.Log("0");
        ValueNeverDestroy.Instance.indexCharacter = 0;
    }

    public void MaskDudeBtn()
    {
        Debug.Log("1");
        ValueNeverDestroy.Instance.indexCharacter = 1;
    }
}
