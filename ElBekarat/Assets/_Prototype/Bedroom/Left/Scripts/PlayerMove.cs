using UnityEngine;
using Pathfinding;

namespace Bedroom
{
    public class PlayerMove : MonoBehaviour
    {
        private AIPath aiPathComponent;

        [SerializeField] private LayerMask environmentLayerMask;
        [SerializeField] private LayerMask environmentFloorLayerMask;

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

                // if mouse position is on Environment Layer Mask
                if (Physics2D.OverlapPoint(position, environmentLayerMask))
                {
                    // get the Environment click position
                    Collider2D collider = Physics2D.OverlapPoint(position, LayerMask.GetMask("Environment"));
                    Vector3 clickablePosition = collider.TryGetComponent<IClickable>(out IClickable clickable) ? clickable.OnClickPosition() : Vector3.zero;
                    if (clickablePosition == Vector3.zero) return;

                    // set path to Environment click position
                    aiPathComponent.destination = clickablePosition;
                    aiPathComponent.SearchPath();
                }

                // else if mouse position is on EnvironmentFloor Layer Mask
                else if (Physics2D.OverlapPoint(position, environmentFloorLayerMask))
                {
                    // find path to mouse position 
                    aiPathComponent.destination = position;
                    aiPathComponent.SearchPath();
                }
            }
        }
    }

}
