using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverPopup : MonoBehaviour {
    public Text title;
    public Text description;

    public void Init(string title, string description)
    {
        this.title.text = title;
        this.description.text = description;
    }

    public static GameObject Instantiate(string title, string description,Vector3 position){
        var instantiated = Instantiate(Resources.Load("Popup/OverPopup"),FindObjectOfType<Canvas>().transform) as GameObject;
        instantiated.GetComponent<RectTransform>().anchoredPosition = position;
        instantiated.GetComponent<OverPopup>().Init(title, description);
        return instantiated;
    }
}
