using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class EventInfo
{
    public enum SelectType
    {
        eTextSelect,
        eItemConsume,
        eItemGain
    }

    //public enum 

    public int               m_nIndex;          // 이벤트 식별자
    public SelectType        m_typeSelect;      // 이벤트 타입
    // 발동 타입 추가 필요
    // 발동 턴 추가 필요
    public Text              m_textContent;     // 내용
}

public class ItemInfo
{
    public string Name;             // 아이템명
    public int SingleUse;           // 일회성 
    public string Description;      // 아이템 설명
}

public class Gamedata : Singleton<Gamedata> {

    public static List<ItemInfo> m_listItem    = new List<ItemInfo>();
    public static List<string> m_listInventory   = new List<string>();


    // JsonFile
    public TextAsset m_jsonItemList;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        LoadFromJsonFile();
    }

    private void LoadFromJsonFile()
    {

        // Item List
        m_listItem = JsonMapper.ToObject<List<ItemInfo>>(m_jsonItemList.text);


    }
}
