using System;
using UnityEngine;

namespace LeftMainPanel
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public event Action<bool> OnClickRange;
        public void ClickRange(bool _isOn)
        {
            Debug.Log("ClickRange : " + _isOn);

            OnClickRange?.Invoke(_isOn);
        }

        public event Action<EnvironmentType> OnClickEnvironment;
        public void ClickEnvironment(EnvironmentType _environmentType)
        {
            OnClickEnvironment?.Invoke(_environmentType);
        }
    }
}
