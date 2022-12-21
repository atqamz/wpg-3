using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElBekarat.Bedroom
{
    public class StaticFront : MonoBehaviour
    {
        private GameObject player;

        private void Update()
        {
            Vector2 playerPosition = player.GetComponent<RectTransform>().position;
            playerPosition = Camera.main.WorldToScreenPoint(playerPosition);

            foreach (RectTransform child in GetComponent<RectTransform>())
            {
                // get child box collider
                BoxCollider2D boxCollider = child.GetComponent<BoxCollider2D>();
                Vector2 offset = boxCollider.offset;

                // get position
                Vector2 position = (Vector2)Camera.main.WorldToScreenPoint(child.position) + offset;

                if (playerPosition.y < position.y)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }

            }
        }

        private void Awake()
        {
            player = GameObject.Find("Player");
        }
    }
}
