using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaditsCanvas : MonoBehaviour
{
    GameObject panelCreadits;
    // Start is called before the first frame update
    void Start()
    {
        panelCreadits = this.gameObject;
        panelCreadits.SetActive(false);
    }

    public void openCreadits()
    {
        panelCreadits.SetActive(true);
    }
    public void backCreadits()
    {
        panelCreadits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
