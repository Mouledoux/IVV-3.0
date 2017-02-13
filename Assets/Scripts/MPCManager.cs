using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCManager : MonoBehaviour
{
    public MediaPlayerCtrl MPC;

    public UnityEngine.Events.UnityEvent OnPlay;
    public UnityEngine.Events.UnityEvent OnEnd;

    void Update ()
    {
        if (MPC.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.END)
            Stop();

        if (Input.GetKeyDown(KeyCode.F7))
            PlayPause();
    }

    public void Play()
    {
        StartCoroutine(PlayVideo());
    }

    public void PlayPause()
    {
        if (MPC.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
            MPC.Pause();
        else
            Play();
    }

    public void Stop()
    {
        MPC.Stop();
        OnEnd.Invoke();
    }

    public IEnumerator PlayVideo()
    {
        while (MPC.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
        {
            MPC.Play();
            yield return null;
        }

        OnPlay.Invoke();
    }
}