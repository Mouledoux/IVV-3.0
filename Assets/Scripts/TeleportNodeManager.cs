using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportNodeManager : MonoBehaviour
{
    private TeleportNode m_cNode; 

    public void ArriveAtNode(TeleportNode a_node) // calls the arrive Event for the node passed in, and the leave for all other nodes
    {
        if(m_cNode != null)
            m_cNode.OnLeave.Invoke();

        m_cNode = a_node;
    }
}
