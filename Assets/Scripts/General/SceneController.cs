using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private static SceneController instance;

    public static SceneController Instance { get => instance; }

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        animator = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        StartCoroutine(SceneLoad(sceneName));
    }

    IEnumerator SceneLoad(string sceneName)
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
        animator.SetTrigger("Start");
    }

    public void SetActiveLC()
    {
        gameObject.SetActive (false);
    }
}
