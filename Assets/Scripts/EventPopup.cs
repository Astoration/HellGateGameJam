using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopup : MonoBehaviour{
    public Image image;
    public Text content;
    public GameObject[] chooses;

    public static EventPopup instance;
    
	// Use this for initialization
	void Awake () {
        instance = this;
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(EventData data){
        gameObject.SetActive(true);
        image.sprite = Resources.Load<Sprite>("profiles/" + data.image);
        content.text = data.content;
        int index = 0;
        foreach(var item in chooses){
            if(index<data.choose.Count){
                item.SetActive(true);
                var result = data.results[index];
                item.GetComponentInChildren<Text>().text = data.choose[index];
                item.GetComponent<Button>().onClick.RemoveAllListeners();
                if (data.useItem)
                {
                    string itemName = data.choose[index];
                    bool hasItem = false;
                    foreach(var inventory in Gamedata.m_listInventory){
                        if(itemName == inventory.Name){
                            hasItem = true;
                        }
                    }
                    if (!hasItem&&index!=data.results.Count-1)
                    {
                        item.GetComponent<Image>().color = Color.gray;
                        index += 1;
                        continue;
                    }
                }
                item.GetComponent<Image>().color = Color.white;
                item.GetComponent<Button>().onClick.AddListener(() =>
                {
                    ShowResult(result);
                });
            }else{
                item.SetActive(false);
            }
            index += 1;
        }

    }

    public void ShowResult(ResultInfo result){
        var resultString = "";
        foreach (var action in result.action)
        {
            if (action.method != null)
            {
                gameObject.SendMessage(action.method + action.target, action.amount,SendMessageOptions.DontRequireReceiver);
            }
            if (action.log != null)
            {
                if (!resultString.Equals("")) resultString += System.Environment.NewLine;
                resultString += action.log;
            }
        }
        content.text = resultString;
        int index = 0;
        foreach (var item in chooses)
        {
            if (index < 1)
            {
                item.SetActive(true);
                item.GetComponent<Image>().color = Color.white;
                item.GetComponent<Button>().onClick.RemoveAllListeners();
                item.GetComponent<Button>().onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);
                });
                item.GetComponentInChildren<Text>().text = "확인";
            }
            else
            {
                item.SetActive(false);
            }
            index += 1;
        }
    }
}
