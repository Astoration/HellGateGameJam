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

[Serializable]
public class ItemInfo
{
    public string Name;             // 아이템명
    public string Image;            // 이미지명
    public int UniqueItem;          // 일회성 
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

    private void LoadItems()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Item/Item");

        foreach (Sprite sprite in sprites){

            if(sprite.name == "Item_0")
                m_dicItem.Add("핫식스", sprite);

            else if (sprite.name == "Item_1")
                m_dicItem.Add("야구 방망이", sprite);

            else if (sprite.name == "Item_2")
                m_dicItem.Add("위장약", sprite);

            else if (sprite.name == "Item_3")
                m_dicItem.Add("사촌 누나의 연락처", sprite);

            else if (sprite.name == "Item_4")
                m_dicItem.Add("타블렛 펜심", sprite);

            else if (sprite.name == "Item_5")
                m_dicItem.Add("토끼 머리띠", sprite);

            else if (sprite.name == "Item_6")
                m_dicItem.Add("컵라면", sprite);

            else if (sprite.name == "Item_8")
                m_dicItem.Add("담배", sprite);

            else if (sprite.name == "Item_10")
                m_dicItem.Add("치킨", sprite);

            else if (sprite.name == "Item_11")
                m_dicItem.Add("무선 키보드", sprite);
        }
    }

    private void LoadResource()
    {
        LoadItems();
       
    }

    private void LoadFromJsonFile()
    {

        // Item List
        m_listItem = JsonMapper.ToObject<List<ItemInfo>>(m_jsonItemList.text);


    }
}
