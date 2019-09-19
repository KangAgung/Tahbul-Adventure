using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTPScript : MonoBehaviour
{
    GameObject panelHTP;
    // Start is called before the first frame update
    void Start()
    {
        panelHTP = this.gameObject;
        panelHTP.SetActive(false);
    }

    public void openHTP()
    {
        panelHTP.SetActive(true);
    }
    public void backHTP()
    {
        panelHTP.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
