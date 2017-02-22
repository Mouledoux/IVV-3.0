using UnityEngine;

/// <summary>
/// Makes object look at the main Camera
/// </summary>
 
public class LookAtCamera : MonoBehaviour
{
    Transform m_view;

    private void Start()
    {
        m_view = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(m_view);
    }
}
