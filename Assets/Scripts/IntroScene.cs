using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour {

    private int m_nNowCount;
    private string m_strSynopsis = @"    20xx 년 x월 x일 안양에서 게임잼이 열렸다.
게임잼에 참여하기 위해 과민성 대장을 가진 골초 기획자, 전날 여자친구에게 차인 아티스트, 4차원 취향을 가진 개발자가 모인다...

과연 헬게이트는 열릴 것인가?";
    public Text m_textShow;

    public const float m_fWaitTime = 1.0f;
    public float m_fTickTime;
    public float m_fLineTime;

	void Start () {
        StartCoroutine(GameUtility.Instance.FadeIn(m_fWaitTime));
        StartCoroutine(TypingAnimation());
	}
	
	private IEnumerator TypingAnimation()
    {
        yield return new WaitForSeconds(m_fWaitTime);

        while (m_nNowCount < m_strSynopsis.Length)
        {
            m_textShow.text += m_strSynopsis[m_nNowCount++];
            yield return new WaitForSeconds(m_fTickTime);
        }

        yield return new WaitForSeconds(2.0f);

        StartCoroutine(GameUtility.Instance.FadeOut(2.0f));
        yield return null;

        StartCoroutine(GameUtility.Instance.ChangeScene("SelectScene"));
    }
}
