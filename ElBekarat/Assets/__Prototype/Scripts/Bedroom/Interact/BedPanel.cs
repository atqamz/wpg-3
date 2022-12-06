using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom
{
    public class BedPanel : MonoBehaviour
    {
        [SerializeField] private Image playerImage;
        [SerializeField] private Slider blanketSlider;

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