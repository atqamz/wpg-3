using UnityEngine;

namespace ElBekarat.Bedroom
{
    public class BaseEnvObject : MonoBehaviour, IClickable
    {
        [SerializeField] private Transform clickPosition;
        [SerializeField] protected EnvironmentType environmentType;
        [SerializeField] protected GameObject environmentPanel;
        protected bool onRange;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!onRange)
                    return;

                if (!environmentPanel.GetComponent<Interact>().IsMoodEnough())
                {
                    EventManager.Instance.MoodNotEnough();
                    return;
                }

                environmentPanel.SetActive(true);

                EventManager.Instance.EnvironmentClick(environmentType);
            }
        }

        public Vector3 OnClickPosition()
        {
            return clickPosition.position;
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                onRange = true;
                EventManager.Instance.EnvironmentRange(true, environmentType);
            }
        }

        protected void OnTriggerExit2D(Collider2D other)
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