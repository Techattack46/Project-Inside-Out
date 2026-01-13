using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] levelMusic;
    [SerializeField] private AudioSource sourcePrefab;
    public AudioSource levelMusicSource;
    
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LevelMusicIndex(int index)
    {
        levelMusicSource.clip = levelMusic[index];
        levelMusicSource.Play();
    }

    public void PlayClip(AudioClip clip)
    {
        AudioSource source = Instantiate(sourcePrefab);

        source.clip = clip;
        source.volume = 1f;

        source.Play();

        DontDestroyOnLoad(source);

        Destroy(source.gameObject, clip.length);
    }
}
