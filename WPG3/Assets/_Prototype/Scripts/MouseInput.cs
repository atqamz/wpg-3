using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public static Vector3 GetMouseWorldPosition()
    {
        // get the mouse position
        Vector3 mousePosition = Input.mousePosition;

        // convert the mouse position to a world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        return worldPosition;
    }
}