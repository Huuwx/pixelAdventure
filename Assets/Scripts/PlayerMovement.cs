using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement instance;

    public static PlayerMovement Instance { get => instance; }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerMovement.instance != null) { Debug.LogError("Only 1 SoundController allow to exist!"); }
        PlayerMovement.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 pos = transform.position;
        pos.x = pos.x + 1.0f * horizontal * Time.deltaTime;
        transform.position = pos;
    }
}
