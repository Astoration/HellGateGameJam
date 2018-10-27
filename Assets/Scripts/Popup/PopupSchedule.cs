using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSchedule : MonoBehaviour {

    private static Canvas   m_canvas;

    public PopupSchedulePart[] m_arrPart;

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

        return popup;
    }

    private void OnSelect(PopupSchedulePart.DevelopmentPart part, PopupSchedulePart.Act act)
    {
        // 각 행동에 다른 처리 필요
        Debug.Log(part + ",    " + act);

        switch(part) {
            case PopupSchedulePart.DevelopmentPart.eProgrammer:
                switch(act) {
                    case PopupSchedulePart.Act.eWork:

                        break;

                    case PopupSchedulePart.Act.eHot6:

                        break;

                    case PopupSchedulePart.Act.eRamen:

                        break;

                    case PopupSchedulePart.Act.eSleep:

                        break;

                    case PopupSchedulePart.Act.eSearch:

                        break;

                    case PopupSchedulePart.Act.eGame:

                        break;
                }
                break;
            case PopupSchedulePart.DevelopmentPart.eDirector:
                switch (act)
                {
                    case PopupSchedulePart.Act.eWork:

                        break;

                    case PopupSchedulePart.Act.eHot6:

                        break;

                    case PopupSchedulePart.Act.eRamen:

                        break;

                    case PopupSchedulePart.Act.eSleep:

                        break;

                    case PopupSchedulePart.Act.eSearch:

                        break;

                    case PopupSchedulePart.Act.eGame:

                        break;
                }
                break;
            case PopupSchedulePart.DevelopmentPart.eArt:
                switch (act)
                {
                    case PopupSchedulePart.Act.eWork:

                        break;

                    case PopupSchedulePart.Act.eHot6:

                        break;

                    case PopupSchedulePart.Act.eRamen:

                        break;

                    case PopupSchedulePart.Act.eSleep:

                        break;

                    case PopupSchedulePart.Act.eSearch:

                        break;

                    case PopupSchedulePart.Act.eGame:

                        break;
                }
                break;
        }

    }

    public void OnConfirm()
    {
        Destroy(this.gameObject);
    }
   
}
