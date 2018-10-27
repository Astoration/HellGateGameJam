using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupInventory : MonoBehaviour {

    private static Canvas m_canvas;
    public GameObject m_objItemSlots;
    private ItemSlot[] m_arrSlot;

    private void Awake()
    {
        m_canvas = FindObjectOfType<Canvas>();

        m_arrSlot = new ItemSlot[m_objItemSlots.transform.childCount];
        
        for(int i = 0; i < m_objItemSlots.transform.childCount; ++i)
        {
            m_arrSlot[i] = m_objItemSlots.transform.GetChild(i).GetComponent<ItemSlot>();
        }
    }

    public static PopupInventory Instantiate()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Popup/PopupInventory"));

        if (obj == null || obj.GetComponent<PopupInventory>() == null)
        {
            Debug.LogError("<color=red> Resource Loading Error!! - PopupInventory </color>");
            return null;
        }

        PopupInventory popup = obj.GetComponent<PopupInventory>();
        obj.transform.SetParent(m_canvas.transform);
        popup.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        return popup;
    }

    public void Init()
    {
        int count = 0;
        foreach(var info in Gamedata.m_listInventory)
        {
            m_arrSlot[count++].Init(info);
            //i.Name
        }
    }

    public void OnClose()
    {
        Destroy(this.gameObject);
    }
}
