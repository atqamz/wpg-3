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
                environmentPanel.SetActive(true);
            }
        }
    }
}

