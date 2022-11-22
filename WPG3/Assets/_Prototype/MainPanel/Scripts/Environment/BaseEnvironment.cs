using UnityEngine;

namespace MainPanel
{
    public class BaseEnvironment : MonoBehaviour, IClickable
    {
        [SerializeField] private Transform clickPosition;
        [SerializeField] protected EnvironmentType environmentType;

        public Vector3 OnClickPosition()
        {
            return clickPosition.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.Instance.OnEnvironment(true, environmentType);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.Instance.OnEnvironment(false, environmentType);
            }
        }
    }
}