using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour {

    public enum EndingType
    {
        eBadDirector,
        eBadProgrammer,
        eBadArtist,
        eBadAll,
        eSuccess
    }

    public Image m_imgBlack;
    private int m_nNowCount;
    private string badDirector = @" 개발력이 모두 떨어진 기획자...
대작병이 도진 기획자는 결국 스트레스 과민성 장염이 심해져 응급차에 실려가고 만다.";
    
    private string badProgrammer = @" 개발력이 떨어진 개발자들...
그 둘은 너무나 큰 고생을 했다.고생은 사랑의 시작이라고 했던가, 둘은 게임잼을 뒤로하고 사랑의 야반도주를 시작한다.";

    private string bad_Artist = @" 반복되는 블루스크린은 사람의 폭력성을 시험하기에 좋은 환경이었다.
태블릿 샷건을 시전한 아티스트는 헤어진 여자친구를 붙잡기 위해 떠나간다.";

    private string bad_All = @"  희망을 안고 게임잼에 참석한 개발자들. 48시간이 지나고 나서야 그들을 깨달았다. 
그들이 연 문은 지옥문이라는 걸...

원하는 걸 구현하기에 턱없이 부족한 시간과 예측하지 못한 변수 앞에 완성은 신기루처럼 사라져버렸다.";

    private string success = @"  분명 헬게이트의 문은 열렸다.거듭된 이견과 오해가 있었고, 잠도 제대로 잘 수 없었지만 그들은 게임을 완성시켰다.
최고의 게임은 아니다. 전에 없던 새로운 게임도 아니다.
평범한 하지만 그래서 더 의미가 있는 게임이었다.

그들은 그렇게 헬게이트 게임잼을 완성시켰다.";

    public string showText;
    public Text m_textShow;

    public const float m_fWaitTime = 2.0f;
    public float m_fTickTime;
    public float m_fLineTime;
    public float speed = 1.0f;

    void Start()
    {
     //   StartCoroutine(FadeIn(m_fWaitTime));
      //  StartCoroutine(TypingAnimation());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 4.0f;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            speed = 1.0f;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Init(EndingType.eSuccess);
            StartCoroutine(FadeIn(m_fWaitTime));
            StartCoroutine(TypingAnimation());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Init(EndingType.eBadAll);
            StartCoroutine(FadeIn(m_fWaitTime));
            StartCoroutine(TypingAnimation());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Init(EndingType.eBadArtist);
            StartCoroutine(FadeIn(m_fWaitTime));
            StartCoroutine(TypingAnimation());
        }
    }

    void Init(EndingType type)
    {
        switch(type) {
            case EndingType.eBadDirector:
                showText = badDirector;
                break;

            case EndingType.eBadProgrammer:
                showText = badProgrammer;
                break;

            case EndingType.eBadArtist:
                showText = bad_Artist;
                break;

            case EndingType.eBadAll:
                showText = bad_All;
                break;

            case EndingType.eSuccess:
                showText = success;
                break;
        }
   
    }

    private IEnumerator TypingAnimation()
    {
        yield return new WaitForSeconds(m_fWaitTime);

        while (m_nNowCount < showText.Length)
        {
            m_textShow.text += showText[m_nNowCount++];
            yield return new WaitForSeconds(m_fTickTime / speed);
        }

        yield return new WaitForSeconds(2.0f);

        StartCoroutine(FadeOut(2.0f));
        yield return null;

        StartCoroutine(ChangeScene("TitleScene"));
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
