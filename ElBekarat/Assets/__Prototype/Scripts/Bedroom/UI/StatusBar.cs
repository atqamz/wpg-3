using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom.UI
{
    public class StatusBar : MonoBehaviour
    {
        [SerializeField] private StatusType statusType;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            switch (statusType)
            {
                case StatusType.HAPPINESS:
                    PlayerStats.Instance.OnHappinessChange += UpdateStatus;
                    break;
                case StatusType.MOTIVATION:
                    PlayerStats.Instance.OnMotivationChange += UpdateStatus;
                    break;
                case StatusType.GOALS:
                    PlayerStats.Instance.OnGoalsChange += UpdateStatus;
                    break;
            }
        }

        private void UpdateStatus(float _value)
        {
            slider.value = _value;
        }
    }
}