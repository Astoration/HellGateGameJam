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

    public Image        m_imgBlack;
    public CardObject[] m_objCard;
    public float        m_fFadeTime         = 0.0f;         // 화면 페이드 타임
    public Text         m_textRemain;
    public int          m_nTotalCardCount   = 0;            // 플레이어가 가져올 카드 수
    public int          m_nNowCardCount     = 0;            // 현재 가져온 카드 수
   
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
                Debug.Log("<color=red> " + i.Name + ", " + i.Description + "</color>");
            }

            Debug.Log("----------------- Inventory -------------------");
            foreach (var i in Gamedata.m_listInventory)
            {
                Debug.Log("<color=red> " + i.Name + ", " + i.Description + "</color>");
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            PopupInventory.Instantiate();
            
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            PopupSchedule.Instantiate();
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetRecursionAlpha(m_objCard[0].gameObject, 1.0f);
        }
    }

    private void InitCards()
    {
        m_textRemain.text = "남은 카드 수 : " + (m_nTotalCardCount - m_nNowCardCount);

        foreach (var card in m_objCard)
        {
            int rand = Random.Range(0, m_listItem.Count);
            ItemInfo item = m_listItem[rand];
          
            card.Init(item, OnSelectCard);
        }
    }

    private void OnSelectCard(ItemInfo info)
    {
        m_nNowCardCount++;
        Gamedata.m_listInventory.Add(info);
        
        // 1회성 아이템 처리
        if (0 != info.Consumable) {
            m_listItem.Remove(info);
        }

        if(0 == m_nTotalCardCount - m_nNowCardCount)
        {
            StartCoroutine(ChangeScene("MainScene"));
        }

        InitCards();
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

    public IEnumerator FadeOutCard(float fadeTime)
    {
       // m_objCard[0].
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
