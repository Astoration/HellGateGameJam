using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardObject : MonoBehaviour {

    public Gamedata.GameItem m_typeItem;


    public void Init(Gamedata.GameItem type)
    {
        m_typeItem = type;

    }

    public void OnSelect()
    {
        // 인벤토리에 해당 아이템 추가
        Gamedata.m_listInventory.Add(m_typeItem);
    }
}
