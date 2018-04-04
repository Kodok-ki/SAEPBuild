using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBehaviour : MonoBehaviour {

    GameObject m_cryst;
    float m_startAlpha;
    float m_endAlpha;

	public void Start () {
        m_cryst = gameObject; //Manually attach script to indivdual crystals
        m_startAlpha = 1f; //Start by fading out
        m_endAlpha = 0f;
        StartCoroutine("Fade");
    }

    void Update() {}

    IEnumerator Fade(){
        Color col = m_cryst.GetComponent<SpriteRenderer>().color;
        float t;
        for(t = 0f;t < 1.1f; t += 0.05f){ //Where the fading happens
            col.a = Mathf.SmoothStep(m_startAlpha, m_endAlpha, t);
            m_cryst.GetComponent<SpriteRenderer>().color = col;
            yield return new WaitForSeconds(0.1f);
        }
        if(t >= 1f){ //Switches fade "direction"
            StopCoroutine("Fade");
            float temp = m_startAlpha;
            m_startAlpha = m_endAlpha;
            m_endAlpha = temp;
            StartCoroutine("Fade");
        }

    }
}
