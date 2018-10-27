using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScene : Singleton<SelectScene> {

    // 이미 본 아이템들
    public List<Gamedata.GameItem> m_listShowingGameItem = new List<Gamedata.GameItem>();   

    public CardObject[] m_objCard;
    public float        m_fFadeTime;
    private int m_nInitCount = 0;
    
    void Start () {
        StartCoroutine(GameUtility.Instance.FadeIn(2.0f));

        InitCards();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(GameUtility.Instance.FadeIn(2.0f));
        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(GameUtility.Instance.FadeOut(2.0f));
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            PopupEvent.Instantiate();
        }
        
    }

    private void InitCards()
    {
        // json 불러오고 불러온 정보를 이용하여 데이터 세팅


        foreach (var card in m_objCard)
        {
            int rand = Random.Range(0, 1);
            if (0 == rand)
            {
                // 이미 본 리스트와 중복 체크, 추가 필요
                int select = Random.Range(0, Gamedata.m_listGameItem.Count);
                card.Init(Gamedata.m_listGameItem[select]);
                m_listShowingGameItem.Add((Gamedata.GameItem)select);
            }
            else
            {
                card.Init(Gamedata.m_listDuplicationItem[Random.Range(0, Gamedata.m_listDuplicationItem.Count)]);
            }
        }
        m_nInitCount++;

    }

}
