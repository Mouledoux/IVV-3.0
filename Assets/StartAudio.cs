using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    [SerializeField] AudioSource m_audio;
    [SerializeField] AudioClip m_clip;
	
    // Use this for initialization
	void Start ()
    {
        m_audio = GetComponent<AudioSource>();	
	}
	
	public void StartUpAudio()
    {
        if (m_audio.isPlaying)
            return;

        m_audio.clip = m_clip;
        m_audio.loop = true;
        m_audio.Play();
    }
}
