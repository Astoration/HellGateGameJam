using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;
public delegate void DelegateOnSelect(ItemInfo info);

public class SelectScene : Singleton<SelectScene> {

 //   public UnityEvent onClick;
    private List<ItemInfo> m_listItem       = new List<ItemInfo>();

    public CardObject[] m_objCard;
    public float        m_fFadeTime         = 0.0f;         // 화면 페이드 타임
    public float        m_fSelectTimeLimit    = 0.0f;       // 카트 뽑기 제한시간

    public int          m_nTotalCardCount   = 0;            // 플레이어가 가져올 카드 수
    public int          m_nNowCardCount     = 0;            // 현재 가져온 카드 수
   
    void Start () {
        StartCoroutine(GameUtility.Instance.FadeIn(2.0f));

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
            PopupEvent.Instantiate();
        }
    }

    private void InitCards()
    {
        foreach (var card in m_objCard)
        {
            int rand = Random.Range(0, m_listItem.Count);
            ItemInfo item = m_listItem[rand];
          
            card.Init(item, OnSelectCard);
        }

        StartCoroutine(StartCardSelect());
    }

    private IEnumerator StartCardSelect()
    {
        yield return new WaitForSeconds(m_fSelectTimeLimit);

        int rand = Random.Range(0, m_listItem.Count);
        OnSelectCard(m_listItem[rand]);

        if(m_nNowCardCount < m_nTotalCardCount)
            StartCoroutine(StartCardSelect());
    }

    private void OnSelectCard(ItemInfo info)
    {
        m_nNowCardCount++;

        // 인벤토리에 해당 아이템 추가
        Gamedata.m_listInventory.Add(info);

        // 1회성 아이템 처리
        if (0 != info.Consumable) {
            m_listItem.Remove(info);
        }
    }

}
