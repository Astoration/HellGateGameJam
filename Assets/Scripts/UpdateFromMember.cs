using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpdateFromMember : MonoBehaviour {
    public PositionType type;
    public string TypeString{
        get{
            return StringEnum.GetStringValue(type);
        }
    }
    private MouseOverable popup;

    private void Awake()
    {
        popup = GetComponent<MouseOverable>();
    }

    private string MakeDescription(Member member)
    {
        string result = "";
        result += BuildCondition(member);
        result += BuildStatus(member);
        return result;
    }

    private string BuildStatus(Member member)
    {
        const string newLine = "\n";
        string result = "";
        if (0<member.sleepTurn)
        {
            result += "수면" + newLine;
        }
        if (0 < member.playTurn)
        {
            result += "일 안하고 쳐 노는중" + newLine;
        }
        if (0 < member.adventureTurn)
        {
            result += "보급을 핑계로 탈주중" + newLine;
        }
        if (0 < member.debuf3)
        {
            result += "멘탈붕괴" + newLine;
        }
        if (0 < member.debuf4)
        {
            result += "부상" + newLine;
        }
        if (member.Sleepy <= 0)
        {
            result += "멘탈붕괴" + newLine;
        }
        if (member.Hunger <= 0)
        {
            result += "굶주림" + newLine;
        }
        if (0 < result.Length) result = newLine + result;
        return result;
    }

    private string BuildCondition(Member member)
    {
        return string.Format("개발력: {0}", member.Condition);
    }

    public void Update()
    {
        popup.title = TypeString;
        var member = MemberManager.Instance.members[type];
        popup.description = MakeDescription(member);
    }
}
