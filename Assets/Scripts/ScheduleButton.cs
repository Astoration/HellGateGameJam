using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleButton : MonoBehaviour {

    private void OnMouseUpAsButton()
    {
        if (GameObject.Find("PopupSchedule") != null|| GameObject.Find("EventPopup") != null) return;
        PopupSchedule.Instantiate();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
