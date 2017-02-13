using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float m_Timer = 0;

    public float m_Delay;
    public UnityEngine.Events.UnityEvent OnTime;
	
    void OnEnable()
    {
        ResetTimer();
    }

	void Update ()
    {
        m_Timer += Time.deltaTime;

        if(m_Timer >= m_Delay)
        {
            OnTime.Invoke();
            ResetTimer();
            enabled = false;
        }
	}

    public void ResetTimer()
    {
        m_Timer = 0;
    }
}
