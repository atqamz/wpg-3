using UnityEngine;
using UnityEngine.UI;

namespace Bedroom
{
    public class Left : MonoBehaviour
    {
        [SerializeField] private Image overlayImage;

        private void Start()
        {
            EventManager.Instance.onBedBlanketChange += OnBedBlanketChange;
        }

        private void OnBedBlanketChange(float _value)
        {
            overlayImage.color = new Color(overlayImage.color.r, overlayImage.color.g, overlayImage.color.b, _value);
        }
    }
}

