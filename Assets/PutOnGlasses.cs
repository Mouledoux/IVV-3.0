using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PutOnGlasses : MonoBehaviour
{
    [SerializeField] private UnityEvent m_glassOn;
    [SerializeField] private string m_animationName;

    private float m_waitTime;
    private Animation m_anim;
    
    private void Start()
    {
        m_anim = GetComponent<Animation>();
        m_waitTime = m_anim[m_animationName].length;
    }

    [ContextMenu("Backward")]
    public void AnimateBackwards()
    {
        m_anim[m_animationName].speed = -1;
        m_anim[m_animationName].time = m_anim[m_animationName].length;
        m_anim.Play(m_animationName);
    }

    [ContextMenu("Forward")]
    public void AnimateForward()
    {
        m_anim[m_animationName].speed = 1;
        m_anim.Play(m_animationName);

        StartCoroutine(AnimWait());
    }

    IEnumerator AnimWait( )
    {
        float t = 0;
        while(t < m_waitTime)
        {
            t += Time.deltaTime;
            yield return null;
        }

        m_glassOn.Invoke();
    }
}
