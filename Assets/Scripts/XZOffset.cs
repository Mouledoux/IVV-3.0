using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XZOffset : MonoBehaviour
{
    public Transform m_Target;
	
    void Start()
    {
        m_Target = m_Target == null ? Camera.main.transform : m_Target;
    }

	void Update ()
    {
        Vector3 newPos = Vector3.zero;
        newPos.x = m_Target.transform.position.x;
        newPos.z = m_Target.transform.position.z;
  
        newPos += m_Target.transform.forward * 1.1f;

        newPos.y = 0;

        transform.position = newPos;

        Vector3 newRot = Vector3.zero;
        newRot = m_Target.transform.localEulerAngles;
        newRot.x = newRot.z = 0;

        transform.localEulerAngles = newRot;
	}
}
