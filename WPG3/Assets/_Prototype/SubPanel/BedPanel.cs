using UnityEngine;
using UnityEngine.UI;
using MainPanel;

namespace BedPanel
{
    public class BedPanel : MonoBehaviour
    {
        [SerializeField] private Image playerImage;
        [SerializeField] private Slider blanketSlider;

        private Bed bedComponent;

        private void Awake()
        {
            gameObject.SetActive(false);
            bedComponent = FindObjectOfType<Bed>();
        }

        private void Start()
        {
            blanketSlider.onValueChanged.AddListener((value) => bedComponent.OnBlanketSliderValueChanged(value));
        }

        public void ShowPanel()
        {
            gameObject.SetActive(true);
            playerImage.enabled = false;

            blanketSlider.value = 0;
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }

        public void ShowPlayerImage()
        {
            playerImage.enabled = true;
        }
    }

}
