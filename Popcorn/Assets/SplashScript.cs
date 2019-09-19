using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScript : MonoBehaviour
{
    GameObject panelSplash;
    // Start is called before the first frame update
    void Start()
    {
        panelSplash = this.gameObject;
        panelSplash.SetActive(true);
    }

    public void nextMenu()
    {
        panelSplash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
