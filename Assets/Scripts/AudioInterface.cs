using UnityEngine;

public class AudioInterface : MonoBehaviour
{
    AudioSource m_audio;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }
    public void SetTrack(AudioClip clip)
    {
        m_audio.clip = clip;
        m_audio.Play();
    }
}
