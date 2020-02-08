using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Popcorn.Metadatas;

public class areaScript : MonoBehaviour
{
    [RequireComponent(typeof(Collider2D))]
    public class WeakPoint : MonoBehaviour
    {
        [HideInInspector] public bool IsColliding { get; private set; }

        void OnCollisionEnter2D(Collision2D otherCollider2D)
        {
            if (otherCollider2D.gameObject.CompareTag(Tags.Persons.Player.ToString())) { print("masuk pak"); }
        }

        void OnCollisionExit2D(Collision2D otherCollider2D)
        {
            if (otherCollider2D.gameObject.CompareTag(Tags.Persons.Player.ToString())) { print("keluar pak"); }
        }

    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider otherCollider2D)
    {
        if (otherCollider2D.gameObject.tag == "Player")
        {
            print("masuk pak");

        }
    }
}
