using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public AudioMixerGroup soundMixer;
    public static AudioManager instance;

    private int musicIndex = 0;

    private void Awake() {
        if (instance) {
            Debug.LogWarning("There is more than one instance of AudioManager !");
            return;
        }
        instance = this;
    }
    
    void Start()
    {
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying) {
            PlayNextSong();
        }
    }

    void PlayNextSong() {
        musicIndex = musicIndex++ % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip _clip, Vector3 _position) {
        GameObject temp = new GameObject("tempAudio");
        temp.transform.position = _position;
        AudioSource audioSource = temp.AddComponent<AudioSource>();
        audioSource.clip = _clip;
        audioSource.outputAudioMixerGroup = soundMixer;
        audioSource.Play();
        Destroy(temp, _clip.length);
        return audioSource;
    }
}
