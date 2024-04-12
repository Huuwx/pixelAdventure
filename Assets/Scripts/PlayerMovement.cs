using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
