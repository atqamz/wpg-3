using System;
using UnityEngine;

namespace MainPanel
{
    public class Bed : BaseEnvironment
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    EventManager.Instance.OnClickEnvironment(environmentType);
                }
            }
        }

        public event Action<float> onBlanketSliderValueChanged;
        public void OnBlanketSliderValueChanged(float _value)
        {
            onBlanketSliderValueChanged?.Invoke(_value);
        }
    }
}

