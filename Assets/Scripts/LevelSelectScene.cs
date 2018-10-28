using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScene : MonoBehaviour {

    public Image m_imgBlack;
    public Text m_textTitle;

    void Start()
    {
        StartCoroutine(FadeIn(2.0f));
    }

    public void SelectLevel1()
    {
        ProcessManager.Instance.difficult = 700;
        m_textTitle.text = "쉬엄쉬엄 하다 가자구";

        StartCoroutine(FadeOut(2.0f, 1.0f));
    }

    public void SelectLevel2()
    {
        ProcessManager.Instance.difficult = 1100;
        m_textTitle.text = "역시 세상은 중간이야.";

        StartCoroutine(FadeOut(2.0f, 1.0f));
    }

    public void SelectLevel3()
    {
        ProcessManager.Instance.difficult = 1500;
        m_textTitle.text = "헬게이트가 열린다. 가즈아아아아!!!";

        StartCoroutine(FadeOut(2.0f, 1.0f));
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

        m_imgBlack.gameObject.SetActive(false);
    }

    public IEnumerator FadeOut(float fadeTime, float waitTime = 0.0f)
    {
        yield return new WaitForSeconds(waitTime);

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

        SceneManager.LoadScene("MainScene");
    }

    public IEnumerator ChangeScene(string strScene)
    {
        StartCoroutine(FadeOut(2.0f));

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(strScene);
    }
}
