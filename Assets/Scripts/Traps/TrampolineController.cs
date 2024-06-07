using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    private static TrampolineController instance;

    public static TrampolineController Instance { get => instance; }

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        instance = this;
    }

    public void SetTriggerAnimation()
    {
        animator.SetBool("Jumping", true);
        Invoke(nameof(SetTriggerIdleAnimation), 1f);
    }

    public void SetTriggerIdleAnimation()
    {
        animator.SetBool("Jumping", false);
    }
}
