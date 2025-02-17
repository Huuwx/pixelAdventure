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

    public AudioClip startSound;
    public AudioClip clickSound;
    public AudioClip chooseCharacterSound;
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
        ClickSound();
        SceneName = "LevelMenu";
        SceneController.Instance.LoadScene(SceneName);
    }

    public void SoundSettingScene()
    {
        ClickSound();
        SceneName = "SoundSetting";
        SceneController.Instance.LoadScene(SceneName);
    }

    public void ExitBtn()
    {
        ClickSound();
        Application.Quit();
    }

    public void Setting()
    {
        ClickSound();
        panel.SetActive(true);
        SettingBtn.enabled = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        ClickSound();
        panel.SetActive(false);
        SettingBtn.enabled = true;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneName = SceneManager.GetActiveScene().name;
        ClickSound();
        SceneController.Instance.LoadScene(SceneName);
        Time.timeScale = 1;
    }

    public void BackHomeScene()
    {
        SceneName = "Home";
        ClickSound();
        SceneController.Instance.LoadScene(SceneName);
        Time.timeScale = 1;
    }

    public void BtnLV1()
    {
        SceneName = "SampleScene";
        StartSound();
        SceneController.Instance.LoadScene(SceneName);
    }

    public void AchievementScene()
    {
        SceneName = "AchievementScene";
        ClickSound();
        SceneController.Instance.LoadScene(SceneName);
    }

    public void ChangeCharacterScene()
    {
        SceneName = "ChangeCharacterScene";
        ClickSound();
        SceneController.Instance.LoadScene(SceneName);
    }

    public void NinJaFrogBtn()
    {
        Debug.Log("0");
        ChooseCharacterSound();
        PlayerPrefsData.Instance.SaveIndexCharacter(0);
    }

    public void MaskDudeBtn()
    {
        Debug.Log("1");
        ChooseCharacterSound();
        PlayerPrefsData.Instance.SaveIndexCharacter(1);
    }

    public void StartSound()
    {
        SoundController.Instance.PlaySound(startSound);
    }
    public void ClickSound()
    {
        SoundController.Instance.PlaySound(clickSound);
    }
    public void ChooseCharacterSound()
    {
        SoundController.Instance.PlaySound(chooseCharacterSound);
    }
}
