using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberManager : Singleton<MemberManager> {
    public Dictionary<PositionType, Member> members = new Dictionary<PositionType, Member>();

    public void InitMembers(){
        ClearMember();
        foreach (PositionType type in (PositionType[])PositionType.GetValues(typeof(PositionType)))
        {
            members.Add(type, new Member(type));
        }
    }

    private void ClearMember(){
        members.Clear();
    }

	// Use this for initialization
	void Start () {
        InitMembers();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
