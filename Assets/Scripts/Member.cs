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
    public int sleepTurn = 0;
    public int playTurn = 0;
    public int adventureTurn = 0;

    public bool Usable{
        get{
            return adventureTurn == 0 && playTurn == 0 && sleepTurn == 0;
        }
    }

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

    public string Update(bool doWork=false){
        var positionString = StringEnum.GetStringValue(type);
        var resultString = "";
        if (Usable&&doWork)
        {
            resultString = string.Format("{0}는 작업을 했다. {0} {1} 완료 - ({1}/{2})\n", positionString, condition, ProcessManager.Instance.difficult);
        }else{
            if(sleepTurn!=0){
                sleepTurn -= 1;
                if (sleepTurn == 0)
                {
                    resultString = string.Format("{0}는 자고있다.\n", positionString);

                }
                else
                {
                    Sleepy += 100;
                    resultString = string.Format("{0}는 잠을 자고 일어났다. 수면욕이 모두 충족되었다.\n", positionString);
                }
            }
            else if(playTurn!=0){
                playTurn -= 1;
                if (playTurn == 0)
                {
                    resultString = string.Format("{0}는 게임 중이다..\n", positionString);

                }
                else
                {
                    var heal = UnityEngine.Random.Range(25, 50);
                    Condition += heal;
                    resultString = string.Format(@"{0}는 신나게 놀았다. {1}만큼 개발력이 회복되었다.\n", positionString, heal);
                }
            }
            else if(adventureTurn != 0){
                adventureTurn -= 1;
                if (adventureTurn == 0)
                {
                    resultString = string.Format("{0}는 탐색 중이다.\n", positionString);
                }
                else
                {
                    var item = Gamedata.m_listItem[UnityEngine.Random.Range(0, Gamedata.m_listItem.Count)];
                    Gamedata.m_listInventory.Add(item);
                    resultString = string.Format("{0}는 탐색을 마치고 돌아왔다. {1} 획득.\n", positionString,item.Name);
                }
            }
        }
        Hunger -= 20;
        Sleepy -= 20;
        if (Usable&&doWork)
        {
            Condition -= 10;
        }
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
