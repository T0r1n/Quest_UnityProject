using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CheckAns : MonoBehaviour
{
    public TMP_InputField AnswerInput;
    public ButtonManager buttonManager;
    public PanelControl panelControl;
    public RectTransform RTInput;

    public void Check(){
        Debug.Log(AnswerInput.text.ToLower());
        Debug.Log(StaticFile.qAnswer.ToLower());
        if(AnswerInput.text.ToLower() == StaticFile.qAnswer.ToLower()){
            Debug.Log("Ответ верный");
            buttonManager.DisableLastButton();
            panelControl.CloseHUD();
        }
        AnswerInput.text = "";
    }
}
