/* Creator: Eric Z Mouledoux
 * Contact: EricMouledoux@gmail.com
 * 
 * Usage:
 * 
 * Notes:
 * 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SpotTheDifference : MonoBehaviour
{
    private GameObject m_Camera;
    private List<GameObject> m_Spotted = new List<GameObject>();
    private RaycastHit m_RayHit;

    public GameObject m_ConfirmationMark;
    public float m_SpotTimeDelay;


    public UnityEngine.Events.UnityEvent OnStart;
    public UnityEngine.Events.UnityEvent OnSpot;

    private bool m_IsSpotting
    {
        get
        {
            if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out m_RayHit))
                return (m_RayHit.transform.parent == transform);

            else
                return false;
        }
    }


	IEnumerator Start()
    {
        m_Camera = Camera.main.gameObject;
        OnStart.Invoke();

        // Update Loop
        while (true)
        {
            if (m_IsSpotting)
            {
                GameObject spotted = m_RayHit.transform.gameObject;
                yield return new WaitForSeconds(m_SpotTimeDelay);

                if (m_IsSpotting)
                    if (spotted == m_RayHit.transform.gameObject)
                        if (!m_Spotted.Contains(spotted))
                        {
                            ClickToFind(spotted);
                        }
            }

            yield return null;
        }
	}

    public void ClickToFind(GameObject aDif)
    {
        m_Spotted.Add(aDif);
        SpawnConfirmation(aDif.transform);
        OnSpot.Invoke();
    }

    public void SpawnConfirmation(Transform aTrans)
    {
        if (m_ConfirmationMark == null)
            return;

        GameObject cm = Instantiate(m_ConfirmationMark, aTrans);
        cm.transform.localPosition = Vector3.zero;
        cm.transform.localEulerAngles = Vector3.zero;
        //cm.transform.LookAt(m_Camera.transform);
    }

    public void Restart()
    {
        foreach (GameObject s in m_Spotted)
        {
            for (int i = 0; i < s.transform.childCount; i++)
            {
                Destroy(s.transform.GetChild(i).gameObject);
            }
        }

        m_Spotted = new List<GameObject>();
    }

    public void PrintScore(UnityEngine.UI.Text t)
    {
        t.text = "Congradulation on finding " + (m_Spotted.Count == transform.childCount ? "all " : "")
            + m_Spotted.Count.ToString() + " of the differences. Great job!";
    }

    public void EmailScore(string email)
    {
        string subject = "IVV Score";
        string body =
            "Congradulation on finding " + (m_Spotted.Count == transform.childCount ? "all " : "")
            + m_Spotted.Count.ToString() + " of the differences. Great job!";

        SendMail("Admin@TantrumLab.com", email, subject, body, "Tantrumlab01");
    }

    public void EmailScore(UnityEngine.UI.InputField email)
    {
        string subject = "IVV Score";
        string body =
            "Congradulation on finding " + (m_Spotted.Count == transform.childCount ? "all " : "")
            + m_Spotted.Count.ToString() + " of the differences. Great job!";

        SendMail("Admin@TantrumLab.com", email.text, subject, body, "Tantrumlab01");
    }

    void SendMail(string aFrom, string aTo, string aSubject, string aBody, string aPassword)
    {
        if (!aTo.Contains("@") && !aTo.ToLower().Contains(".com"))
            return;

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(aFrom);
        mail.To.Add(aTo);
        mail.Subject = aSubject;
        mail.Body = aBody;

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential(aFrom, aPassword) as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
    }
}
