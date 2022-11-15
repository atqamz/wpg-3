using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectWPG
{
    public class ExampleObject : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Player Entered!");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Interact();
            }
        }
    }
}
