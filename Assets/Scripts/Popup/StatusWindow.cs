using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusWindow : MonoBehaviour {
    public Text turn;

    public Text m_textTotalDevelopTime;
    public Text m_textValue_Director;
    public Text m_textValue_Programmer;
    public Text m_textValue_Artist;

    public Image m_imgGage_Director;
    public Image m_imgGage_Programmer;
    public Image m_imgGage_Artist;


    private void Start()
    {

    }

    private void Update()
    {
        turn.text = (ProcessManager.Instance.turn*2).ToString("D2");
        m_imgGage_Director.fillAmount = (float)ProcessManager.Instance.directorProgress / (float)ProcessManager.Instance.difficult;
        m_imgGage_Programmer.fillAmount = (float)ProcessManager.Instance.programmerProgress / (float)ProcessManager.Instance.difficult;
        m_imgGage_Artist.fillAmount = (float)ProcessManager.Instance.artProgress / (float)ProcessManager.Instance.difficult;
        m_textValue_Director.text = ProcessManager.Instance.directorProgress.ToString("D4");
        m_textValue_Programmer.text = ProcessManager.Instance.programmerProgress.ToString("D4");
        m_textValue_Artist.text = ProcessManager.Instance.artProgress.ToString("D4");
    }

}
