using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1 : MonoBehaviour
{
    GameObject Chapter1Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Chapter1Canvas = this.gameObject;
        Chapter1Canvas.SetActive(false);
    }
    public void openChapter1Canvas()
    {
        Chapter1Canvas.SetActive(true);
    }
    public void backChapter1Canvas()
    {
        Chapter1Canvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
