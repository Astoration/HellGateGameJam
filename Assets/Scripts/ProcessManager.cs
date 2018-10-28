using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class ProcessManager : Singleton<ProcessManager> {
    public int turn = 1;
    [SerializeField]
    List<EventData> eventList;
    public TextAsset eventJson;

    private int directorProgress = 0;
    private int programmerProgress = 0;
    private int artProgress = 0;

    public int difficult = 1000;

    public int DirectorProgress
    {
        get
        {
            return directorProgress;
        }

        set
        {
            directorProgress = Mathf.Clamp(value, 0, 2000);
        }
    }

    public int ProgrammerProgress
    {
        get
        {
            return programmerProgress;
        }

        set
        {
            programmerProgress = Mathf.Clamp(value, 0, 2000);
        }
    }

    public int ArtProgress
    {
        get
        {
            return artProgress;
        }

        set
        {
            artProgress = Mathf.Clamp(value,0,2000);
        }
    }

    // Use this for initialization
    void Start () {
        difficult = PlayerPrefs.GetInt("difficult", 600);
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
