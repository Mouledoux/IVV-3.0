using UnityEngine;
using System.Collections;

public class ToggleVR : MonoBehaviour
{
    GvrViewer m_gvr;

    void Start()
    {
        m_gvr = GetComponent<GvrViewer>();
    }

    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //        m_gvr.VRModeEnabled = !m_gvr.VRModeEnabled;
    //}

    public void Toggle()
    {
        m_gvr.VRModeEnabled = !m_gvr.VRModeEnabled;
    }
}
