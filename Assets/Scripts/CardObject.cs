using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {

    public DelegateOnSelect m_delOnSelect;
    public ItemInfo m_Iteminfo;
    public Image m_imgItem;
    public Text m_textTitle;
    public Text m_textDesc;

    public void Init(ItemInfo info, DelegateOnSelect del)
    {
        m_Iteminfo = info;
        m_delOnSelect = del;

        if (Gamedata.m_dicItem[info.Name] == null)
        {
            Debug.LogError("<color=red> Resource Loading Error!! - ItemSlot:Gamedata.m_dicItem </color>");
        }
        else
        {
            m_imgItem.sprite = Gamedata.m_dicItem[info.Name];
        }
        m_textTitle.text = info.Name;
        m_textDesc.text = info.Description;
    }

    public void OnSelect()
    {
        m_delOnSelect(m_Iteminfo);
    }
}
