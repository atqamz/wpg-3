using UnityEngine;
using UnityEngine.UI;
using MainPanel;

namespace EnvPanel
{
    public class BedPanel : MonoBehaviour
    {
        [SerializeField] private Slider blanketSlider;
        [SerializeField] private Image playerImage;

        private void Awake()
        {
            blanketSlider.value = 0;
            playerImage.enabled = false;
        }

        private void Start()
        {
            EventManager.Instance.onEnvironmentRange += OnEnvironmentRange;
            EventManager.Instance.onEnvironmentClick += OnEnvironmentClick;

            blanketSlider.onValueChanged.AddListener((value) => EventManager.Instance.BedBlanketChange(value));
        }

        private void OnEnvironmentRange(bool _isOn, EnvironmentType _environmentType)
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

        private void OnEnvironmentClick(EnvironmentType _environmentType)
        {
            if (_environmentType == EnvironmentType.BED)
            {
                playerImage.enabled = true;
                blanketSlider.interactable = true;
            }
        }
    }
}