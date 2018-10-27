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
        if (false)
        {
            result += newLine;
        }
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
