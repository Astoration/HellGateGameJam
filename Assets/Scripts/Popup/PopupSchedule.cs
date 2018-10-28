using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                    return MemberManager.Instance.members[PositionType.Programmer].Update();

                }
                else if(part == PopupSchedulePart.DevelopmentPart.eArt){
                    ProcessManager.Instance.artProgress += MemberManager.Instance.members[PositionType.Art].Condition;
                    return MemberManager.Instance.members[PositionType.Art].Update();
                }
                else
                {
                    ProcessManager.Instance.directorProgress += MemberManager.Instance.members[PositionType.Director].Condition;
                    var condition = MemberManager.Instance.members[PositionType.Director].Condition;
                    return MemberManager.Instance.members[PositionType.Director].Update();
                }
                break;
        }
        return "";
    }


    public void OnClose(){
        ProcessManager.Instance.InvokeEvent();
        Destroy(gameObject);
    }
   
}
