using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

[Serializable]
public enum PositionType{
    None,
    [StringValue("기획자")]
    Director,
    [StringValue("프로그래머")]
    Programmer,
    [StringValue("아트")]
    Art,
}

public class Member{
    private PositionType type;
    private int hunger = 100;
    private int sleepy = 100;
    private int condition = 100;
    public int debuf3 = 0;
    public int debuf4 = 0;

    public Member(PositionType type)
    {
        this.type = type;
    }

    public int Sleepy
    {
        get
        {
            return sleepy;
        }

        set
        {
            sleepy = Mathf.Clamp(value,0,100);
        }
    }

    public int Condition
    {
        get
        {
            return condition;
        }

        set
        {
            condition = Mathf.Clamp(value, 0, 100);
        }
    }

    public int Hunger
    {
        get
        {
            return hunger;
        }

        set
        {
            hunger = Mathf.Clamp(value, 0, 100);
        }
    }

    public string Update(){
        var positionString = StringEnum.GetStringValue(type);
        var resultString = string.Format("{0}는 작업을 했다. {0} {1} 완료 - ({1}/{2})\n", positionString, condition, ProcessManager.Instance.difficult);
        Hunger -= 20;
        Sleepy -= 20;
        Condition -= 10;
        if (Hunger == 0)
        {
            condition -= 10;
            resultString += string.Format("{0}는 굶주려있다. 작업시 개발력 10 추가 감소.\n", positionString);
        }
        if (Sleepy == 0)
        {
            condition -= 10;
            resultString += string.Format("{0}는 잠을 자지 못해 고통받고 있다. 작업시 개발력 10 추가 감소.\n", positionString);

        }
        if (0<debuf3){
            debuf3 -= 1;
            condition -= 10;
            resultString += string.Format("{0}는 스트레스로 인해 멘탈이 붕괴됐다. 작업시 개발력 10 추가 감소\n", positionString);

        }
        if (0 < debuf4)
        {
            debuf4 -= 1;
            condition -= 10;
            resultString += string.Format("{0}는 부상으로 인해 고통받고 있다. 작업시 개발력 10 추가 감소.\n", positionString);
        }
        resultString += Environment.NewLine;
        return resultString;
    }
}
