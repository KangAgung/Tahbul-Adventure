using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayScript : MonoBehaviour
{
    GameObject PlayCanvas;
    // Start is called before the first frame update
    void Start()
    {
        PlayCanvas = this.gameObject;
        PlayCanvas.SetActive(false);
    }
    public void openPlayCanvas()
    {
        PlayCanvas.SetActive(true);
    }
    public void backPlayCanvas()
    {
        PlayCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
