using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScene : Singleton<SelectScene> {

    public List<string> m_listShowingGameItem    = new List<string>();      // 이미 본 아이템들
  
    public CardObject[] m_objCard;
    public float        m_fFadeTime;

    //public float        m_
   
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
            Debug.Log("1111");

            StartCoroutine(GameUtility.Timer(2.0f, delegate
            {
                Debug.Log("gdgdgd");
            }));
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
            int rand = Random.Range(0, 1);
            if (0 == rand)
            {
                // 이미 본 리스트와 중복 체크, 추가 필요
              //  int select = Random.Range(0, Gamedata.m_listGameItem.Count);
             //   card.Init(Gamedata.m_listGameItem[select]);
              //  m_listShowingGameItem.Add((ItemInfo.type)select);
            }
            else
            {
              //  card.Init(Gamedata.m_listDuplicationItem[Random.Range(0, Gamedata.m_listDuplicationItem.Count)]);
            }
        }
      
    }

}
