using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class MouseOverable : EventTrigger
{
    public string title;
    public string description;
    public bool useBack = false;
    private GameObject popup;

    private void OnMouseEnter()
    {
        popup = OverPopup.Instantiate(title, description, Input.mousePosition);
        if(useBack)
            popup.transform.SetSiblingIndex(0);
    }

    private void OnMouseExit()
    {
        Destroy(popup);
    }
  

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (title != ""){
            base.OnPointerEnter(eventData);
            popup = OverPopup.Instantiate(title, description, eventData.position);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        Destroy(popup);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(MouseOverable))]
public class MouseOverableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MouseOverable component = target as MouseOverable;
        component.title = EditorGUILayout.TextField("title", component.title);
        component.description = EditorGUILayout.TextField("description", component.description);
        component.useBack = EditorGUILayout.Toggle("useBack", component.useBack);
    }
}
#endif
