using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusWindow : MonoBehaviour {

    public Text m_textTotalDevelopTime;
    public Text m_textValue_Director;
    public Text m_textValue_Programmer;
    public Text m_textValue_Artist;

    public Image m_imgGage_Director;
    public Image m_imgGage_Programmer;
    public Image m_imgGage_Artist;


    private void Start()
    {
        m_imgGage_Director.fillAmount = 0.33f;
    }

}
