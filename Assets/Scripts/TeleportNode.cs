using UnityEngine.Events;
using UnityEngine;

public class TeleportNode : RaySelectionVolume
{
    public UnityEvent OnLeave;

    [SerializeField] private GameObject m_cameraRig;

    private TeleportNodeManager m_nodeManager;

    private void Start()
    {
        m_nodeManager = FindObjectOfType<TeleportNodeManager>();
        loadedAction.AddListener(Teleport);
    }

    public void Teleport()
    {
        Vector3 temp = transform.position;
        temp.y = m_cameraRig.transform.position.y;
        m_cameraRig.transform.position = temp;
    }

    public void LoadedAction()
    {
        loadedAction.Invoke();
    }

}
