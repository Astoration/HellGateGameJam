using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData{

}

public class EventPopup : Singleton<EventPopup> {
    public static EventData eventData;

    public static void ShowEvent(EventData data){
        eventData = data;
        Instance.gameObject.SetActive(true);
    }

    private void OnEnable()
    {

    }

    private void InitBySetup(){

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
