using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    public Animator AnimPanel;
    public Animator AnimBlur;
    public GameObject Blur;

    public Animator Hint;

    public TextMeshProUGUI textHint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ViewHint(){
        textHint.text = StaticFile.qHint;
        StartCoroutine(oHint());
    }

    IEnumerator oHint()
    {
        Button button = GetComponent<Button>();
        button.interactable = false;
        Hint.SetBool("HintTrig",true);
        yield return new WaitForSeconds(4.0f);
        button.interactable = true;
        Hint.SetBool("HintTrig",false);
    }

    public void OpenHUD()
    {
        Blur.SetActive(true);
        AnimPanel.SetBool("PanelTrig", true);
        AnimBlur.SetBool("BlurTrig", true);
        //AnimPanel.SetTrigger("PanelTrig");
        //AnimBlur.SetTrigger("BlurTrig");
    }

    public void CloseHUD()
    {
        AnimPanel.SetBool("PanelTrig", false);
        AnimBlur.SetBool("BlurTrig", false);
    }


}
