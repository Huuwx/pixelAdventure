using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;

    public static SoundController Instance { get => instance; }


    [SerializeField] private List<AudioClip> sources = new List<AudioClip>();

    public List<AudioClip> Sources { get =>  sources; }

    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        if(SoundController.instance != null) { Debug.LogError("Only 1 SoundController allow to exist!"); }
        SoundController.instance = this;
        audiosource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        audiosource.Stop();
        audiosource.clip = clip;
        audiosource.Play();
    }
}
