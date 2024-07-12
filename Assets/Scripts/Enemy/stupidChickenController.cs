using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stupidChickenController : EnemyController
{
    public ParticleSystem RunDust;

    public AudioClip runSound;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected void FixedUpdate()
    {
        CheckPlayer();
        Movement();
        FlipEnemies();
    }

    public void createRunDust()
    {
        RunDust.Play();
    }

    public void RunSound()
    {
        PlaySound(runSound);
    }
}
