using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3 : MonoBehaviour
{
    GameObject Chapter3Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Chapter3Canvas = this.gameObject;
        Chapter3Canvas.SetActive(false);
    }
    public void openChapter3Canvas()
    {
        Chapter3Canvas.SetActive(true);
    }
    public void backChapter3Canvas()
    {
        Chapter3Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
