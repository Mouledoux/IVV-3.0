using System.Collections;
using UnityEngine;

public class WebVideoTexture : MonoBehaviour
{
    public WebGLMovieTexture tex;

    public string m_VideoURL;
    public GameObject m_Screen;

    public bool m_AutoPlay;
    public bool m_Loop;

    public UnityEngine.Events.UnityEvent OnPlay;
    public UnityEngine.Events.UnityEvent OnEnd;

    public enum State
    {
        INIT,
        PLAYING,
        PAUSED,
        END,
        STOP,
        READY,
        ERR,
    }

    [HideInInspector]
    public State cState = State.INIT;

    IEnumerator Start()
    {
        tex = null;
        tex = new WebGLMovieTexture(m_VideoURL);
        tex.loop = m_Loop;

        //m_Screen.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
        m_Screen.GetComponent<MeshRenderer>().material.mainTexture = tex;
        while(!tex.isReady)
        {
            yield return null;
        }

        cState = State.READY;

        if (!m_AutoPlay)
        {
            yield break;
        }

        Play();
    }

    private void OnEnable()
    {
        StartCoroutine(Start());
    }

    void Update()
    {
        tex.Update();

        if (tex.time >= tex.duration)
        {
            cState = State.END;
            OnEnd.Invoke();
            tex.Seek(0.01f);
        }
    }

    IEnumerator _Play()
    {
        yield return new WaitUntil(() => tex.isReady);

        tex.Play();
        OnPlay.Invoke();
    }

    public void Play()
    {
        //tex = new WebGLMovieTexture(m_VideoURL);
        StartCoroutine(_Play());
    }

    public void PlayPause()
    {
        if(cState == State.PLAYING)
        {
            tex.Pause();
            cState = State.PAUSED;
        }
        else
        {
            tex.Play();
            cState = State.PLAYING;
        }
    }

    public void Stop()
    {
        tex.Seek(0f);
        tex.Pause();
        cState = State.STOP;
        
    }
}
