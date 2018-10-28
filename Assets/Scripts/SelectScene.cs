using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;
using UnityEngine.SceneManagement;

public delegate void DelegateOnSelect(ItemInfo info);

public class SelectScene : Singleton<SelectScene> {

 //   public UnityEvent onClick;
    private List<ItemInfo> m_listItem       = new List<ItemInfo>();
    private List<ItemInfo> m_listDelete     = new List<ItemInfo>();

    public Image        m_imgBlack;
    public CardObject[] m_objCard;
    public float        m_fFadeTime         = 0.0f;         // 화면 페이드 타임
    public Text         m_textRemain;
    public int          m_nTotalCardCount   = 0;            // 플레이어가 가져올 카드 수
    public int          m_nNowCardCount     = 0;            // 현재 가져온 카드 수

    private bool        m_bIsClick = false;


    void Start () {
        StartCoroutine(FadeIn(m_fFadeTime));

        m_listItem = Gamedata.m_listItem;
        InitCards();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("----------------- m_listItem -------------------");
            foreach (var i in Gamedata.m_listItem)
            {
                Debug.Log("<color=red> " + i.Name + ", " + i.UniqueItem + "</color>");
            }

            Debug.Log("----------------- Inventory -------------------");
            foreach (var i in Gamedata.m_listInventory)
            {
                Debug.Log("<color=red> " + i.Name + ", " + i.UniqueItem + "</color>");
            }
        }
    }

    private void InitCards()
    {
        m_bIsClick = false;
        m_textRemain.text = "남은 카드 수 : " + (m_nTotalCardCount - m_nNowCardCount);

        if (m_nTotalCardCount - m_nNowCardCount == 0)
            return;

        foreach (var card in m_objCard){
            // 초기화
            card.gameObject.SetActive(true);
            SetRecursionAlpha(card.gameObject, 1.0f);

            int rand = Random.Range(0, m_listItem.Count);
            ItemInfo item = m_listItem[rand];
          
            card.Init(item, OnSelectCard);
        }
    }

    private void OnSelectCard(ItemInfo info)
    {
        if (false == m_bIsClick){
            m_bIsClick = true;
            m_nNowCardCount++;
            Gamedata.m_listInventory.Add(info);

            // 1회성 아이템 처리
            if (0 != info.UniqueItem)
            {
                // 유니크 아이템 습득시 다른 유니크 아이템 삭제
                foreach(var i in m_listItem)
                {
                    if(i.UniqueItem == 1)
                    {
                        // 지금 머리 안돌아가니까 일단 생각나는대로 짜자.
                        m_listDelete.Add(i);
                        //m_listItem.Remove(i);
                    }
                }
                foreach (var i in m_listDelete )
                {
                    m_listItem.Remove(i);
                }
            }

            m_textRemain.text = "남은 카드 수 : " + (m_nTotalCardCount - m_nNowCardCount);
            if (0 == m_nTotalCardCount - m_nNowCardCount)
            {
                StartCoroutine(StartIEnum2(3.0f));
            }

            StartFadeOutCard(info);
        }
    }

    private void StartFadeOutCard(ItemInfo info)
    {
        if(m_objCard[0].m_Iteminfo == info)
        {
            StartCoroutine(FadeOutObject(m_objCard[0].gameObject, 0.75f, 1.0f));
            StartCoroutine(FadeOutObject(m_objCard[1].gameObject, 1.0f));
        }
        else if (m_objCard[1].m_Iteminfo == info)
        {
            StartCoroutine(FadeOutObject(m_objCard[0].gameObject, 1.0f));
            StartCoroutine(FadeOutObject(m_objCard[1].gameObject, 0.75f, 1.0f));
        }

        StartCoroutine(StartIEnum(2.5f));
    }

    private void SetRecursionAlpha(GameObject obj, float alpha)
    {
        if(obj.GetComponent<Image>() != null)
        {
            Color color = obj.GetComponent<Image>().color;
            obj.GetComponent<Image>().color = new Color(color.r, color.g, color.b, alpha);
        }

        if (obj.GetComponent<Text>() != null)
        {
            Color color = obj.GetComponent<Text>().color;
            obj.GetComponent<Text>().color = new Color(color.r, color.g, color.b, alpha);
        }

        for (int i = 0; i < obj.transform.childCount; ++i)
        {
            SetRecursionAlpha(obj.transform.GetChild(i).gameObject, alpha);
        }
    }

    private IEnumerator StartIEnum(float time)
    {
        // 이제 변수명 짓는게 귀찮다 그냥 짓자. 왈왈
        yield return new WaitForSeconds(time);

        InitCards();
    }

    private IEnumerator StartIEnum2(float time)
    {
        // 이제 변수명 짓는게 귀찮다 그냥 짓자. 왈왈
        yield return new WaitForSeconds(time);

        StartCoroutine(ChangeScene("LevelSelectScene"));
    }

    public IEnumerator FadeOutObject(GameObject obj, float fadeTime, float waitTime = 0.0f)
    {
        yield return new WaitForSeconds(waitTime);

        float fTime = 1.0f;
        float alpha = 1.0f;
        SetRecursionAlpha(obj, Mathf.Lerp(0.0f, 1.0f, fTime));
       
        while(0.0f < alpha)
        {
            fTime -= Time.deltaTime / fadeTime;

            alpha = Mathf.Lerp(0.0f, 1.0f, fTime);
            SetRecursionAlpha(obj, alpha);
            
            yield return null;
        }

        obj.SetActive(false);
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
