using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnVidEnd : MonoBehaviour
{
    [SerializeField] List<GameObject> m_ToggleForVid= new List<GameObject>();
    private MediaPlayerCtrl m_mpc;

    private void Start()
    {
        m_mpc = GetComponent<MediaPlayerCtrl>();
        
        m_mpc.OnEnd += EndVid;
    }

    private void StartVid()
    {
        foreach(GameObject g in m_ToggleForVid)
        {
            g.SetActive(!g.active);
        }

    }

    public void EndVid()
    {
        foreach (GameObject g in m_ToggleForVid)
        {
            g.SetActive(!g.active);
        }
    }
}
