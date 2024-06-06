using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsController : MonoBehaviour
{
    public float speed;
    public float direct;
    public bool MoveX;
    public bool MoveY;

    public GameObject PointGroundcheck;
    public Vector2 sizePointGroundcheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SawMove();
        if(MoveX || MoveY)
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
            if(colliderR.tag == "Ground")
            {
                Debug.Log("cham dat");
                if (MoveX)
                {
                    MoveX = false;
                    Invoke(nameof(ChangeX), 1.5f);
                }
                else if(MoveY)
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
        direct *= -1;
    }

    public void ChangeY()
    {
        MoveY = true;
        direct *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(PointGroundcheck.transform.position, new Vector3(sizePointGroundcheck.x, sizePointGroundcheck.y, 1f));
    }
}
