using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {

    public Image        m_imgItem;
    public ItemInfo     m_ItemInfo;
    private MouseOverable m_mouseOverable;

    private void Awake()
    {
        m_mouseOverable = GetComponent<MouseOverable>();
    }

    public void Init (ItemInfo info)
    {
        m_ItemInfo = info;
        m_mouseOverable.title = info.Name;
        m_mouseOverable.description = info.Description;

        if (Gamedata.m_dicItem[info.Name] == null)
        {
            Debug.LogError("<color=red> Resource Loading Error!! - ItemSlot:Gamedata.m_dicItem </color>");
        }
        else
        {
            m_imgItem.sprite = Gamedata.m_dicItem[info.Name];
        }
	}
	
	
}
