using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private Vector3 target;
    private NavMeshAgent agentComponent;

    private void Awake()
    {
        agentComponent = GetComponent<NavMeshAgent>();
        agentComponent.updateRotation = false;
        agentComponent.updateUpAxis = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            target.z = transform.position.z;

            agentComponent.SetDestination(target);
        }
    }
}
