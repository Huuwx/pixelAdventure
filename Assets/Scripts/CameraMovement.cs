using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPos;
    public Vector2 minPos;

    // Start is called before the first frame update
    void Start()
    {
        //CheckTarget();
    }

    void CheckTarget()
    {
        if (PlayerController.NinjaFrog == true)
        {
            target = CharacterSelection.Instance.Character[0].transform;
        }
        else if (PlayerController.VirtualGuy == true)
        {
            target = CharacterSelection.Instance.Character[1].transform;
        }
        else
        {
            target = CharacterSelection.Instance.Character[2].transform;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Vector3.Distance(target.position, transform.position) > float.Epsilon)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
