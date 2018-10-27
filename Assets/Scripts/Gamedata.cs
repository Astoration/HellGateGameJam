using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamedata : Singleton<Gamedata> {

    public static List<GameItem> m_listGameItem = new List<GameItem>();                 // 중복 선택 불가 아이템
    public static List<GameItem> m_listDuplicationItem = new List<GameItem>();          // 중복 선택 가능 아이템

    public static List<GameItem> m_listInventory = new List<GameItem>();                // 인벤토리
    
    public enum GameItem
    {
        eNone,
        eHot6,
        eDigestiveMedicine,
        eRabbitEar,
        eChicken,
        eBaseballBat,
        eCigarette,
        eContact,
        eKeyboard

    };

    private void Awake()
    {
        // Test용 데이터 추가
        m_listGameItem.Add(GameItem.eRabbitEar);
        m_listGameItem.Add(GameItem.eDigestiveMedicine);
        m_listGameItem.Add(GameItem.eBaseballBat);
        m_listGameItem.Add(GameItem.eCigarette);
        m_listGameItem.Add(GameItem.eContact);
        m_listGameItem.Add(GameItem.eKeyboard);



        m_listDuplicationItem.Add(GameItem.eHot6);
        m_listDuplicationItem.Add(GameItem.eChicken);
        
    }
}
