using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {

    public DelegateOnSelect m_delOnSelect;
    public ItemInfo m_Iteminfo;
    public Image m_imgItem;


    public void Init(ItemInfo info, DelegateOnSelect del)
    {
        m_Iteminfo = info;
        m_delOnSelect = del;
    }

    public void OnSelect()
    {
        m_delOnSelect(m_Iteminfo);
    }
}
