using UnityEngine;

namespace LeftMainPanel
{
    public class BaseEnvironment : MonoBehaviour, IClickable
    {
        [SerializeField] private Transform clickPosition;

        public Vector3 OnClickPosition()
        {
            return clickPosition.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.Instance.ClickRange(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.Instance.ClickRange(false);
            }
        }
    }
}