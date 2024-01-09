using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeController : MonoBehaviour
{
    public Animator AnimPanel;
    public Animator AnimBlur;
    public GameObject Blur;
    

        public void OpenCode()
    {
        Blur.SetActive(true);
        AnimPanel.SetBool("CodeTrig", true);
        AnimBlur.SetBool("BlurTrig", true);
        
    }

    public void CloseCode()
    {
        AnimPanel.SetBool("CodeTrig", false);
        AnimBlur.SetBool("BlurTrig", false);
    }
}
