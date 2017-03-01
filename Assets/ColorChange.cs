using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    private IEnumerator Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        //float [] color = { 0, 0, 0 };
        float r = 0;
        float g = 0;
        float b = 0;

        while (true)
        {


            r += Time.deltaTime;
            g += Time.deltaTime * 1.5f;
            b += Time.deltaTime * 2f;

            r %= 1;
            g %= 1;
            b %= 1;

            sr.color = new Color(r, g, b, 1);

            yield return new WaitForSeconds(.05f);
        }

    }
    
}
