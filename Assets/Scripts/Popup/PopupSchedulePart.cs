using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSchedulePart : MonoBehaviour {

    public enum DevelopmentPart
    {
        eDirector,
        eProgrammer,
        eArt
    }

    public enum Act
    {
        eWork,
        eHot6,
        eRamen,
        eSleep,
        eSearch,
        eGame,
        None
    }

    public DevelopmentPart  m_typePart;
    public Act              m_selectAct;

    public Transform        m_tmPanel;
    public Image            m_imgSelect;
    public System.Action<DevelopmentPart, Act> m_delSelect;

    public static int hotsixCount = 0;
    public static int foodCount = 0;

    public bool preHotsix = false;
    public bool preFood = false;

    public void Init(System.Action<DevelopmentPart, Act> del)
    {
        m_delSelect = del;
        foodCount = 0;
        hotsixCount = 0;

    }

    private void SelectIcon(Act act)
    {
        m_imgSelect.gameObject.SetActive(true);
        m_imgSelect.transform.SetParent(m_tmPanel.GetChild((int)act));
        m_imgSelect.transform.localPosition = Vector3.zero;
    }

    public void OnWork()
    {
        m_selectAct = Act.eWork;
        SelectIcon(m_selectAct);
        if (preFood)
        {
            preFood = false;
            foodCount -= 1;
        }
        if (preHotsix)
        {
            preHotsix = false;
            hotsixCount -= 1;
        }
        m_delSelect(m_typePart, m_selectAct);
    }

    public void OnHot6()
    {
        if (HasItem("핫식스") <= hotsixCount) return;
        if(!preHotsix)
            hotsixCount += 1;
        preHotsix = true;
        if(preFood){
            preFood = false;
            foodCount -= 1;
        }
        m_selectAct = Act.eHot6;
        SelectIcon(m_selectAct);
        m_delSelect(m_typePart, m_selectAct);
    }

    public void OnRamen()
    {
        if (HasItem("컵라면") <= foodCount) return;
        if (!preFood)
            foodCount += 1;
        preFood = true;
        if (preHotsix)
        {
            preHotsix = false;
            hotsixCount -= 1;
        }
        m_selectAct = Act.eRamen;
        SelectIcon(m_selectAct);
        m_delSelect(m_typePart, m_selectAct);
    }

    public void OnSleep()
    {
        m_selectAct = Act.eSleep;
        SelectIcon(m_selectAct);
        if (preFood)
        {
            preFood = false;
            foodCount -= 1;
        }
        if (preHotsix)
        {
            preHotsix = false;
            hotsixCount -= 1;
        }
        m_delSelect(m_typePart, m_selectAct);
    }

    public void OnSearch()
    {
        m_selectAct = Act.eSearch;
        SelectIcon(m_selectAct);
        if (preFood)
        {
            preFood = false;
            foodCount -= 1;
        }
        if (preHotsix)
        {
            preHotsix = false;
            hotsixCount -= 1;
        }
        m_delSelect(m_typePart, m_selectAct);
    }

    public void OnGame()
    {
        m_selectAct = Act.eGame;
        SelectIcon(m_selectAct);
        if (preFood)
        {
            preFood = false;
            foodCount -= 1;
        }
        if (preHotsix)
        {
            preHotsix = false;
            hotsixCount -= 1;
        }
        m_delSelect(m_typePart, m_selectAct);
    }

    public int HasItem(string name)
    {
        int count = 0;
        for (var i = 0; i < Gamedata.m_listInventory.Count; i++)
        {
            var item = Gamedata.m_listInventory[i];
            if (item.Name == name)
            {
                count += 1;
            }
        }
        return count;
    }
}
