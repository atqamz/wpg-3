using UnityEngine;
using UnityEngine.UI;

namespace Bedroom
{
    public class BedPanel : MonoBehaviour
    {
        [SerializeField] private Image playerImage;
        [SerializeField] private Slider blanketSlider;

        private void Awake()
        {
            blanketSlider.value = 0;
            playerImage.enabled = false;

            gameObject.SetActive(false);
        }

        private void Start()
        {
            EventManager.Instance.onEnvironmentRange += OnEnvironmentRange;
            EventManager.Instance.onEnvironmentClick += OnEnvironmentClick;

            blanketSlider.onValueChanged.AddListener((value) => EventManager.Instance.BedBlanketChange(value));
        }

        public void OnEnvironmentRange(bool _isOn, EnvironmentType _environmentType)
        {
            if (_environmentType == EnvironmentType.BED)
            {
                if (_isOn)
                {
                    playerImage.enabled = false;
                    blanketSlider.interactable = false;
                }
            }
        }

        public void OnEnvironmentClick(EnvironmentType _environmentType)
        {
            if (_environmentType == EnvironmentType.BED)
            {
                playerImage.enabled = true;
                blanketSlider.interactable = true;
            }
        }
    }
}