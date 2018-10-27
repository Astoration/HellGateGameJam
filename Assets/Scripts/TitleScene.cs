using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleScene : MonoBehaviour {

    private bool m_bEnableInput = false;
    private const float m_fWaitTime = 3.0f;

    private void Start()
    {
        StartCoroutine(GameUtility.Instance.FadeIn(m_fWaitTime));
        StartCoroutine(StartWating());
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(GameUtility.Instance.FadeOut(2.0f));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(GameUtility.Instance.FadeIn(2.0f));
        }
    }

    private IEnumerator StartWating()
    {
        yield return new WaitForSeconds(m_fWaitTime);

        m_bEnableInput = true;
    }

    public void OnClick()
    {
        if(m_bEnableInput)
            StartCoroutine(GameUtility.Instance.ChangeScene("IntroScene"));
    }
}
