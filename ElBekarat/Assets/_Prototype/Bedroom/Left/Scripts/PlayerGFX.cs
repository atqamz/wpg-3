using UnityEngine;
using UnityEngine.UI;

namespace Bedroom
{
    public class PlayerGFX : MonoBehaviour
    {
        [SerializeField] private Image playerImage;

        private void Start()
        {
            EventManager.Instance.onBed += OnBed;
        }

        private void OnBed(bool _isOn)
        {
            playerImage.enabled = !_isOn;
        }
    }
}