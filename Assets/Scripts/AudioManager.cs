using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;
    [SerializeField] public AudioSource WheelchairSFXSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip complete;
    public AudioClip death;
    public AudioClip damage;
    public AudioClip throwing;
    public AudioClip door;
    public AudioClip box;
    public AudioClip wheelchair;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else  Destroy(gameObject);
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayWheelchairSFX()
    {
        if (WheelchairSFXSource.clip != wheelchair || !WheelchairSFXSource.isPlaying)
        {
            WheelchairSFXSource.clip = wheelchair;
            WheelchairSFXSource.loop = true;
            WheelchairSFXSource.Play();
        }
    }

    public void StopWheelchairSFX()
    {
        if (WheelchairSFXSource.isPlaying)
        {
            WheelchairSFXSource.Stop();
        }
    }
}
