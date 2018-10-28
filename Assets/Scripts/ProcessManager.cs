using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class ProcessManager : Singleton<ProcessManager> {
    public int turn = 1;
    [SerializeField]
    List<EventData> eventList;
    public TextAsset eventJson;

    public int directorProgress = 0;
    public int programmerProgress = 0;
    public int artProgress = 0;

    public int difficult = 1000;

	// Use this for initialization
    void Start () {
        eventList = JsonMapper.ToObject<List<EventData>>(eventJson.text);
        InvokeEvent();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InvokeEvent(){
        var eventData = eventList[Random.Range(0, eventList.Count)];
        EventPopup.instance.Init(eventData);
    }
}
