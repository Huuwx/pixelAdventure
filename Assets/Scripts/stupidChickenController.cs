using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stupidChickenController : EnemyController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Movement();
        FlipEnemies();
    }
}
