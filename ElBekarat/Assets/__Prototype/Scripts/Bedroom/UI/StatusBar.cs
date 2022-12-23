using System.Collections;
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
            float time = 1f;
            StartCoroutine(AnimateValue(_value, time));
        }

        private IEnumerator AnimateValue(float _value, float _time)
        {
            float startValue = slider.value;
            float endValue = _value;
            float elapsedTime = 0;

            while (elapsedTime < _time)
            {
                slider.value = Mathf.Lerp(startValue, endValue, (elapsedTime / _time));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            slider.value = endValue;
        }
    }
}