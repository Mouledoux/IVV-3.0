using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private GameObject m_ProgressBar;

    public UnityEngine.Events.UnityEvent OnLoad;

    private float m_MinPos
    {
        get { return -m_ProgressBar.GetComponent<RectTransform>().rect.width; }
    }

    private GameObject m_Cam;

	// Use this for initialization
	void Start ()
    {
        m_Cam = Camera.main.gameObject;
        m_ProgressBar.transform.localPosition = new Vector3(m_MinPos + 1, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_ProgressBar.transform.localPosition.x >= 1)
        {
            m_ProgressBar.transform.localPosition = new Vector3(m_MinPos + 1, 0, 0);
            OnLoad.Invoke();
        }
        else if (Physics.Raycast(m_Cam.transform.position, m_Cam.transform.forward, 99))
        {
            print(true);
            m_ProgressBar.transform.localPosition += new Vector3(Time.deltaTime, 0, 0);
        }
        else if (m_ProgressBar.transform.localPosition.x > m_MinPos + 1)
        {
            m_ProgressBar.transform.localPosition -= new Vector3(Time.deltaTime, 0, 0);
        }
	}
}
