using UnityEngine;

namespace ProjectWPG
{
    public class Movement : MonoBehaviour
    {
        private Kara kara;
        private Vector2 targetPosition;

        private void Awake()
        {
            kara = GetComponent<Kara>();
            targetPosition = transform.position;
        }

        private void Update()
        {
            // mouse click
            if (Input.GetMouseButtonDown(0))
            {
                // get mouse position
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // get target position
                targetPosition = mousePosition;
            }

            if (targetPosition != null)
            {
                if (ReachDestination(targetPosition)) return;

                Vector3 moveDirection = ((Vector2)targetPosition - (Vector2)transform.position).normalized;
                transform.position += moveDirection * kara.MoveSpeed * Time.deltaTime;

            }
        }


        private bool ReachDestination(Vector2 _targetPosition)
        {
            float stoppingDistance = 0.1f;
            float distance = Vector3.Distance(transform.position, _targetPosition);

            if (distance <= stoppingDistance)
                return true;
            else
                return false;
        }
    }

}
