using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData{
    public PositionType position;
    public bool useItem;
    public bool onIndex;
    public List<int> acceptTurn;
    public string content;
    public List<string> choose;
    public List<ResultInfo> results;
}

public class ResultInfo
{
    public List<ActionInfo> action;
}

public class ActionInfo{
    public string method;
    public int amount;
    public string log;
}