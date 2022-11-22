using UnityEngine;

namespace MainPanel
{
    public class BaseEnvironment : MonoBehaviour, IClickable
    {
        [SerializeField] private Transform clickPosition;
        [SerializeField] protected EnvironmentType environmentType;
        [SerializeField] protected GameObject environmentPanel;
        protected bool onRange;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (onRange)
                {
                    EventManager.Instance.EnvironmentClick(environmentType);
                }
            }
        }

        public Vector3 OnClickPosition()
        {
            return clickPosition.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                environmentPanel.SetActive(true);

                onRange = true;
                EventManager.Instance.EnvironmentRange(true, environmentType);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                environmentPanel.SetActive(false);

                onRange = false;
                EventManager.Instance.EnvironmentRange(false, environmentType);
            }
        }
    }
}