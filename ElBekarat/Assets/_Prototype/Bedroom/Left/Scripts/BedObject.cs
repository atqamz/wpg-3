using UnityEngine;

namespace Bedroom
{
    public class BedObject : BaseEnvObject
    {
        private void Awake()
        {
            environmentType = EnvironmentType.BED;
        }

        private void Start()
        {
            EventManager.Instance.onEnvironmentClick += OnEnvironmentClick;
        }

        private void OnEnvironmentClick(EnvironmentType _environmentType)
        {
            if (_environmentType == EnvironmentType.BED)
            {
                EventManager.Instance.Bed(true);

                environmentPanel.SetActive(true);
            }
        }

        new private void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);

            EventManager.Instance.Bed(false);
        }
    }
}

