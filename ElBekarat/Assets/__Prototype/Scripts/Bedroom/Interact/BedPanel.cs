using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom
{
    public class BedPanel : Interact, ITask
    {
        [SerializeField] private Image playerImage;
        [SerializeField] private Slider blanketSlider;

        public void OnTaskEnd()
        {
            // Calculate mood here
        }

        private void Awake()
        {
            blanketSlider.value = 0;
        }

        private void Start()
        {
            blanketSlider.onValueChanged.AddListener((value) => EventManager.Instance.BedBlanketChange(value));
        }
    }
}