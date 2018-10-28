using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupSchedule : MonoBehaviour {

    private static Canvas   m_canvas;

    public PopupSchedulePart[] m_arrPart;

    public GameObject result;

    public PopupSchedulePart.Act programmerAct = PopupSchedulePart.Act.None;
    public PopupSchedulePart.Act directorAct = PopupSchedulePart.Act.None;
    public PopupSchedulePart.Act artAct = PopupSchedulePart.Act.None;

    private void Awake()
    {
        m_canvas = FindObjectOfType<Canvas>();
    }

    private void Start()
    {
        foreach (var i in m_arrPart)
        {
            i.Init(OnSelect);
        }
    }

    public static PopupSchedule Instantiate()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Popup/PopupSchedule"));

        if (obj == null || obj.GetComponent<PopupSchedule>() == null)
        {
            Debug.LogError("<color=red> Resource Loading Error!! - PopupSchedule </color>");
            return null;
        }

        PopupSchedule popup = obj.GetComponent<PopupSchedule>();
        obj.transform.SetParent(m_canvas.transform);
        popup.GetComponent<RectTransform>().localPosition = Vector3.zero;
        popup.GetComponent<RectTransform>().localScale = Vector3.one;
        popup.name = "PopupSchedule";
        return popup;
    }

    private void OnSelect(PopupSchedulePart.DevelopmentPart part, PopupSchedulePart.Act act)
    {
        // 각 행동에 다른 처리 필요
        Debug.Log(part + ",    " + act);

        switch(part){
            case PopupSchedulePart.DevelopmentPart.eProgrammer:
                programmerAct = act;
                break;
            case PopupSchedulePart.DevelopmentPart.eDirector:
                directorAct = act;
                break;
            case PopupSchedulePart.DevelopmentPart.eArt:
                artAct = act;
                break;
        }

    }

    public void OnConfirm()
    {
        result.SetActive(true);
        result.GetComponentInChildren<Text>().text = "";
        ProcessManager.Instance.turn += 1;
        var resultString = "";
        resultString += DoAct(PopupSchedulePart.DevelopmentPart.eProgrammer, programmerAct);
        resultString += DoAct(PopupSchedulePart.DevelopmentPart.eArt, artAct);
        resultString += DoAct(PopupSchedulePart.DevelopmentPart.eDirector, directorAct);
        result.GetComponentInChildren<Text>().text = resultString;
    }

    public string DoAct(PopupSchedulePart.DevelopmentPart part,PopupSchedulePart.Act act){
        switch(act){
            case PopupSchedulePart.Act.eWork:
                if(part == PopupSchedulePart.DevelopmentPart.eProgrammer){
                    ProcessManager.Instance.programmerProgress += MemberManager.Instance.members[PositionType.Programmer].Condition;
                    return MemberManager.Instance.members[PositionType.Programmer].Update(true);

                }
                else if(part == PopupSchedulePart.DevelopmentPart.eArt){
                    ProcessManager.Instance.artProgress += MemberManager.Instance.members[PositionType.Art].Condition;
                    return MemberManager.Instance.members[PositionType.Art].Update(true);
                }
                else
                {
                    ProcessManager.Instance.directorProgress += MemberManager.Instance.members[PositionType.Director].Condition;
                    return MemberManager.Instance.members[PositionType.Director].Update(true);
                }
            case PopupSchedulePart.Act.eHot6:
                if (part == PopupSchedulePart.DevelopmentPart.eProgrammer)
                {
                    UseItem("핫식스");
                    MemberManager.Instance.members[PositionType.Programmer].Sleepy += 100;
                    return MemberManager.Instance.members[PositionType.Programmer].Update();

                }
                else if (part == PopupSchedulePart.DevelopmentPart.eArt)
                {
                    UseItem("핫식스");
                    MemberManager.Instance.members[PositionType.Art].Sleepy += 100;
                    return MemberManager.Instance.members[PositionType.Art].Update();
                }
                else
                {
                    UseItem("핫식스");
                    MemberManager.Instance.members[PositionType.Director].Sleepy += 100;
                    return MemberManager.Instance.members[PositionType.Director].Update();
                }
            case PopupSchedulePart.Act.eRamen:
                if (part == PopupSchedulePart.DevelopmentPart.eProgrammer)
                {
                    UseItem("컵라면");
                    MemberManager.Instance.members[PositionType.Programmer].Hunger += 100;
                    return MemberManager.Instance.members[PositionType.Programmer].Update();

                }
                else if (part == PopupSchedulePart.DevelopmentPart.eArt)
                {
                    UseItem("컵라면");
                    MemberManager.Instance.members[PositionType.Art].Hunger += 100;
                    return MemberManager.Instance.members[PositionType.Art].Update();
                }
                else
                {
                    UseItem("컵라면");
                    MemberManager.Instance.members[PositionType.Director].Hunger += 100;
                    return MemberManager.Instance.members[PositionType.Director].Update();
                }
            case PopupSchedulePart.Act.eSleep:
                if (part == PopupSchedulePart.DevelopmentPart.eProgrammer)
                {
                    MemberManager.Instance.members[PositionType.Programmer].sleepTurn = 2;
                    return MemberManager.Instance.members[PositionType.Programmer].Update();

                }
                else if (part == PopupSchedulePart.DevelopmentPart.eArt)
                {
                    MemberManager.Instance.members[PositionType.Art].sleepTurn = 2;
                    return MemberManager.Instance.members[PositionType.Art].Update();
                }
                else
                {
                    MemberManager.Instance.members[PositionType.Director].sleepTurn = 2;
                    return MemberManager.Instance.members[PositionType.Director].Update();
                }
            case PopupSchedulePart.Act.eSearch:
                if (part == PopupSchedulePart.DevelopmentPart.eProgrammer)
                {
                    MemberManager.Instance.members[PositionType.Programmer].adventureTurn = 2;
                    return MemberManager.Instance.members[PositionType.Programmer].Update();

                }
                else if (part == PopupSchedulePart.DevelopmentPart.eArt)
                {
                    MemberManager.Instance.members[PositionType.Art].adventureTurn = 2;
                    return MemberManager.Instance.members[PositionType.Art].Update();
                }
                else
                {
                    MemberManager.Instance.members[PositionType.Director].adventureTurn = 2;
                    return MemberManager.Instance.members[PositionType.Director].Update();
                }
            case PopupSchedulePart.Act.eGame:
                if (part == PopupSchedulePart.DevelopmentPart.eProgrammer)
                {
                    MemberManager.Instance.members[PositionType.Programmer].playTurn = 2;
                    return MemberManager.Instance.members[PositionType.Programmer].Update();

                }
                else if (part == PopupSchedulePart.DevelopmentPart.eArt)
                {
                    MemberManager.Instance.members[PositionType.Art].playTurn = 2;
                    return MemberManager.Instance.members[PositionType.Art].Update();
                }
                else
                {
                    MemberManager.Instance.members[PositionType.Director].playTurn = 2;
                    return MemberManager.Instance.members[PositionType.Director].Update();
                }
        }
        return "";
    }


    public void OnClose(){
        if(ProcessManager.Instance.directorProgress <= 0){
            PlayerPrefs.SetInt("endingType", 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EndingScene");
        }else if (ProcessManager.Instance.programmerProgress <= 0)
        {
            PlayerPrefs.SetInt("endingType", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EndingScene");
        }else if (ProcessManager.Instance.artProgress <= 0)
        {
            PlayerPrefs.SetInt("endingType", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EndingScene");
        }
        if (24<=ProcessManager.Instance.turn){
            var progress = ProcessManager.Instance.programmerProgress & ProcessManager.Instance.artProgress & ProcessManager.Instance.directorProgress;
            if(ProcessManager.Instance.difficult<=progress){
                PlayerPrefs.SetInt("endingType", 4);
                PlayerPrefs.Save();
            }else{
                PlayerPrefs.SetInt("endingType", 3);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene("EndingScene");
        }
        ProcessManager.Instance.InvokeEvent();
        Destroy(gameObject);
    }

    public void UseItem(string name)
    {
        for (var i = 0; i < Gamedata.m_listInventory.Count; i++)
        {
            var item = Gamedata.m_listInventory[i];
            if (item.Name == name)
            {
                Gamedata.m_listInventory.Remove(item);
                break;
            }
        }
    }
}
