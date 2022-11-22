using System;
using UnityEngine;

namespace MainPanel
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public event Action<bool, EnvironmentType> onEnvironment;
        public void OnEnvironment(bool _isOn, EnvironmentType _environmentType)
        {
            onEnvironment?.Invoke(_isOn, _environmentType);
        }

        public event Action<EnvironmentType> onClickEnvironment;
        public void OnClickEnvironment(EnvironmentType _environmentType)
        {
            onClickEnvironment?.Invoke(_environmentType);
        }
    }
}
