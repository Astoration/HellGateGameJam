using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class MouseOverable : EventTrigger
{
    public string title;
    public string description;
    private GameObject popup;

    private void OnMouseEnter()
    {
        popup = OverPopup.Instantiate(title, description, Input.mousePosition);
    }

    private void OnMouseExit()
    {
        Destroy(popup);
    }



    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        popup = OverPopup.Instantiate(title, description, eventData.position);
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

    }
}
#endif
