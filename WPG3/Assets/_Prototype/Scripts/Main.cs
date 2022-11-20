using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Main : MonoBehaviour
{
    private void Start()
    {
        AstarPath.active.Scan();
        AstarPath.active.logPathResults = PathLog.None;
    }
}
