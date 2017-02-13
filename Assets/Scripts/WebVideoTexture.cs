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
        tex = new WebGLMovieTexture(m_VideoURL);
        tex.loop = m_Loop;

        m_Screen.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
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

        tex.Play();
        OnPlay.Invoke();
    }

    void Update()
    {
        tex.Update();

        if (tex.time >= tex.duration)
        {
            cState = State.END;
            OnEnd.Invoke();
        }
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
        tex.Pause();
        tex.Seek(0f);
        cState = State.STOP;
    }
}
