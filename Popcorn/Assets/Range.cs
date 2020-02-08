using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    private EnemyAI parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<EnemyAI>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            parent.InvokeRepeating("UpdatePath", 0f,.5f); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.CancelInvoke();
            //parent.InvokeRepeating("UpdatePath", 0f, 0f);
        }
    }
}
