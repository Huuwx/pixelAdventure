using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance { get; private set; }


    [SerializeField] private List<AudioClip> sources = new List<AudioClip>();

    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource= GetComponent<AudioSource>();
    }

    public List<AudioClip> getSources()
    {
        return sources;
    }

    public void PlayMusic(int index)
    {
        audiosource.Stop();
        audiosource.PlayOneShot(sources[index]);
    }
}
