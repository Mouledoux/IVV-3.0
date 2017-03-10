using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void OpenURLLink()
    {
        Application.ExternalEval("window.open('https://www.tantrumlab.com/');");
    }
}
