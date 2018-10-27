using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;

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
    public int Consumable;          // 일회성 
    public string Description;      // 아이템 설명
}

public class Gamedata : Singleton<Gamedata> {
    public static List<ItemInfo> m_listItem         = new List<ItemInfo>();
    public static List<ItemInfo> m_listInventory    = new List<ItemInfo>();
    public static Dictionary<string, Sprite> m_dicItem = new Dictionary<string, Sprite>();

    // JsonFile
    public TextAsset m_jsonItemList;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        LoadFromJsonFile();
        LoadResource();
    }

    private void LoadResource()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Item/Item");

        foreach (Sprite sprite in sprites)
        {
            m_dicItem.Add(sprite.name, sprite);
        }
    }

    private void LoadFromJsonFile()
    {

        // Item List
        m_listItem = JsonMapper.ToObject<List<ItemInfo>>(m_jsonItemList.text);


    }
}
