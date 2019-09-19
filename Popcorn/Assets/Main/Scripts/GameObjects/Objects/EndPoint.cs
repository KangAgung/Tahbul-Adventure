using UnityEngine;
using System.Collections;
using PersonsTags = Popcorn.Metadatas.Tags.Persons;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Popcorn.GameObjects.Objects
{

    public class EndPoint : MonoBehaviour
    {

        [HideInInspector] public bool WasReachedTheEnd { get; private set; }

        void Awake() { WasReachedTheEnd = false; }
        
        void OnTriggerEnter2D(Collider2D otherCollider2D)
        {
            if (otherCollider2D.CompareTag(PersonsTags.Player.ToString()))
            {
                //yield WaitForSeconds (3);
                //SceneManager.LoadScene(0);
                WasReachedTheEnd = true;
            }
        }
        
    }

}