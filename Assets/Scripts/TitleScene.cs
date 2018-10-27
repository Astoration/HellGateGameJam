using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour {

    public Image m_imgBlack;
    private bool m_bEnableInput = false;
    private const float m_fWaitTime = 3.0f;

    private void Start()
    {
        StartCoroutine(FadeIn(m_fWaitTime));
        StartCoroutine(StartWating());
    }

    private IEnumerator StartWating()
    {
        yield return new WaitForSeconds(m_fWaitTime);

        m_bEnableInput = true;
    }

    public void OnClick()
    {
        if(m_bEnableInput)
            StartCoroutine(ChangeScene("IntroScene"));
    }

    public IEnumerator FadeIn(float fadeTime)
    {
        Color color = m_imgBlack.color;
        float fTime = 1.0f;

        color.a = Mathf.Lerp(0.0f, 1.0f, fTime);
        m_imgBlack.gameObject.SetActive(true);

        while (0.0f < color.a)
        {
            fTime -= Time.deltaTime / fadeTime;

            color.a = Mathf.Lerp(0.0f, 1.0f, fTime);
            m_imgBlack.color = color;

            yield return null;
        }
    }

    public IEnumerator FadeOut(float fadeTime)
    {
        Color color = m_imgBlack.color;
        float fTime = 0.0f;

        color.a = Mathf.Lerp(0.0f, 1.0f, fTime);
        m_imgBlack.gameObject.SetActive(true);

        while (color.a < 1.0f)
        {

            fTime += Time.deltaTime / fadeTime;

            color.a = Mathf.Lerp(0.0f, 1.0f, fTime);
            m_imgBlack.color = color;

            yield return null;
        }
    }

    public IEnumerator ChangeScene(string strScene)
    {
        StartCoroutine(FadeOut(2.0f));

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(strScene);
    }
}
