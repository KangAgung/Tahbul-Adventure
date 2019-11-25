using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2 : MonoBehaviour
{
    GameObject Chapter2Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Chapter2Canvas = this.gameObject;
        Chapter2Canvas.SetActive(false);
    }
    public void openChapter2Canvas()
    {
        Chapter2Canvas.SetActive(true);
    }
    public void backChapter2Canvas()
    {
        Chapter2Canvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
