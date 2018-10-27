using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EventData{
    public string image;
    public bool useItem;
    public bool onIndex;
    public List<int> acceptTurn;
    public string content;
    public List<string> choose;
    public List<ResultInfo> results;
}

[Serializable]
public class ResultInfo
{
    public List<ActionInfo> action;
}

[Serializable]
public class ActionInfo{
    public string method;
    public string target;
    public int amount;
    public string log;
}