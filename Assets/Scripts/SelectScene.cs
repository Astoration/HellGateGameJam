using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScene : Singleton<SelectScene> {

    public CardObject[] m_objCard;
    public float        m_fFadeTime;
    private int m_nInitCount = 0;

    private void Awake()
    {
        m_objCard = new CardObject[3];
    }

    void Start () {
        StartCoroutine(GameUtility.Instance.FadeIn(2.0f));
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
    }

    private void InitCards()
    {
        // json 불러오고 불러온 정보를 이용하여 데이터 세팅


        foreach (var card in m_objCard)
        {
            int rand = Random.Range(0, 1);
            if (0 == rand)
            {
                //card.Init(Gamedata.GameItem.eHot6);
                card.Init(Gamedata.m_listGameItem[Random.Range(0, Gamedata.m_listGameItem.Count)]);
            }
            else
            {
                card.Init(Gamedata.m_listDuplicationItem[Random.Range(0, Gamedata.m_listDuplicationItem.Count)]);
            }
        }
        m_nInitCount++;

    }

}
