using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurControl : MonoBehaviour
{
    
    public GameObject Blur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlurO()
    {
        Blur.SetActive(true);
    }

    public void BlurC()
    {
        Blur.SetActive(false);
    }
}

