using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixRealitySimulation : MonoBehaviour
{
    [SerializeField] LayerMask m_defualtmask;
    [SerializeField] LayerMask m_MixedRealitymask;

    private Camera m_camera;

    // Use this for initialization
    void Start ()
    {
        m_camera = GetComponent<Camera>();	
	}

    [ContextMenu("On")]
    public void IntoMixedReality()
    {
        m_camera.cullingMask = m_MixedRealitymask;
    }

    [ContextMenu("Off")]
    public void OutMixedReality()
    {
        m_camera.cullingMask = m_defualtmask;
    }
}
