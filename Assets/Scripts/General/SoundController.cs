using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;

    public static SoundController Instance { get => instance; }


    [SerializeField] private List<AudioClip> sources = new List<AudioClip>();
    [SerializeField] private List<AudioClip> soundeffects = new List<AudioClip>();

    public List<AudioClip> Sources { get =>  sources; }
    public List<AudioClip> Soundeffects { get => soundeffects; }

    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        //if(SoundController.instance != null) { Debug.LogError("Only 1 SoundController allow to exist!"); }
        //SoundController.instance = this;

        // Đảm bảo rằng chỉ có một thể hiện của SoundController
        if (instance == null)
        {
            // Đối tượng hiện tại sẽ là thể hiện duy nhất
            instance = this;

            // Không hủy đối tượng này khi chuyển scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Nếu đã tồn tại một thể hiện khác, hủy đối tượng hiện tại
            Destroy(gameObject);
        }

        audiosource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        audiosource.Stop();
        audiosource.clip = clip;
        audiosource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }
}
