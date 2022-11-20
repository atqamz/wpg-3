using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace LeftMainPanel
{
    public class PlayerMove : MonoBehaviour
    {
        AIPath aiPathComponent;

        private void Awake()
        {
            aiPathComponent = GetComponent<AIPath>();
        }

        private void Start()
        {
            // first scan
            AstarPath.active.Scan();

            // disable AstarPath logs
            AstarPath.active.logPathResults = PathLog.None;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = MouseInput.GetMouseWorldPosition();

                // if mouse position is not on Obstacle Layer Mask
                if (Physics2D.OverlapPoint(position, LayerMask.GetMask("Unwalkable")))
                {
                    // get the Environment click position
                    Collider2D collider = Physics2D.OverlapPoint(position, LayerMask.GetMask("Unwalkable"));
                    Vector3 clickablePosition = collider.GetComponent<IClickable>().OnClickPosition();

                    // set path to Environment click position
                    aiPathComponent.destination = clickablePosition;
                    aiPathComponent.SearchPath();
                }
                else
                {
                    // find path to mouse position 
                    aiPathComponent.destination = position;
                    aiPathComponent.SearchPath();
                }
            }
        }
    }

}
