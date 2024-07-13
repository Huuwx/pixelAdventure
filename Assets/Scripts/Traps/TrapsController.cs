using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsController : MonoBehaviour
{
    private static TrapsController instance;

    public static TrapsController Instance { get => instance; }

    public float speed;
    public float direct;
    public bool MoveX;
    public bool MoveY;
    public bool changed = true;
    private Animator animator;

    public GameObject PointGroundcheck;
    public Vector2 sizePointGroundcheck;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SawMove();
        if ((MoveX && changed) || (MoveY && changed))
        {
            ChangeMove();
        }
    }

    public void SawMove()
    {
        Vector2 pos = transform.position;
        if (MoveX)
        {
            pos.x = pos.x + speed * direct * Time.deltaTime;
        }
        if (MoveY)
        {
            pos.y = pos.y + speed * direct * Time.deltaTime;
        }

        transform.position = pos;
    }

    public void ChangeMove()
    {
        Collider2D[] collidersR = Physics2D.OverlapBoxAll(PointGroundcheck.transform.position, sizePointGroundcheck, 0);
        foreach (var colliderR in collidersR)
        {
            if (colliderR.tag == "Ground" || colliderR.tag == "Wall")
            {
                if (MoveX)
                {
                    MoveX = false;
                    Invoke(nameof(ChangeX), 1.5f);
                }
                else if (MoveY)
                {
                    MoveY = false;
                    Invoke(nameof(ChangeY), 1.5f);
                }
            }
        }
    }

    public void ChangeX()
    {
        MoveX = true;
        changed = false;
        direct *= -1;
        Invoke(nameof(SetChanged), 2f);
    }

    public void ChangeY()
    {
        MoveY = true;
        changed = false;
        direct *= -1;
        Invoke(nameof(SetChanged), 2f);
    }

    public void SetChanged()
    {
        changed = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(PointGroundcheck.transform.position, new Vector3(sizePointGroundcheck.x, sizePointGroundcheck.y, 1f));
    }

    
}
