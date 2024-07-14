using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public IEnumerator SceneLoad()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("Current");
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("Next");
    }

    public void setActiveImg()
    {
        gameObject.SetActive(false);
    }
}
