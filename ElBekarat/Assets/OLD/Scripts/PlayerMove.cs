using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    List<Vector2> path = new List<Vector2>();
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // watch mouse position to make player follow until mouse button is released
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            path.Add(mousePos);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (path.Count > 0)
            {
                ExecutePath();
            }
        }


    }

    void ExecutePath()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Vector2 point in path)
        {
            while (Vector2.Distance(transform.position, point) > 0.05f)
            {
                transform.position = Vector2.MoveTowards(transform.position, point, 5f * Time.deltaTime);
                yield return null;
            }
        }
        path.Clear();
    }
}
