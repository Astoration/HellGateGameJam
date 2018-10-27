using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupEvent : MonoBehaviour {

    public enum SelectType
    {
        eImageSelect,
        eTextSelect
    }

    private static Canvas m_canvas;

    public Image m_imgPortrait;
    public Text m_textContent;
    public SelectType m_typeSelect;

    private void Awake()
    {
        m_canvas = FindObjectOfType<Canvas>();

        // 내용 불러와야함
        m_textContent.text = "개발자가 뭐어떡했냐에 따라 상태를 표시해줄건데";
    }
    
    public static PopupEvent Instantiate()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Popup/PopupEvent"));

        if (obj == null || obj.GetComponent<PopupEvent>() == null)
        {
            Debug.LogError("<color=red> Resource Loading Error!! - PopupEvent </color>");
            return null;
        }

        PopupEvent popup = obj.GetComponent<PopupEvent>();
        obj.transform.parent = m_canvas.transform;
        return popup;
    }


}
