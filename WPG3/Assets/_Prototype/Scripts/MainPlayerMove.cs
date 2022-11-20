using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MainPlayerMove : MonoBehaviour
{
    AIPath aiPathComponent;

    private void Awake()
    {
        aiPathComponent = GetComponent<AIPath>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get the mouse position
            Vector3 mousePosition = Input.mousePosition;

            // if mouse position is not on Obstacle Layer Mask
            if (!Physics2D.OverlapPoint(mousePosition, LayerMask.GetMask("Unwalkable")))
            {
                aiPathComponent.destination = mousePosition;
            }
        }
    }
}
