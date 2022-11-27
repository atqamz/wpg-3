using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bedroom
{
    public class TablePanel : MonoBehaviour, ITask
    {
        [Header("Makan")]
        [SerializeField] private Button makanButton;
        [SerializeField] private Image isiMakanImage;
        [SerializeField] private List<Sprite> isiMakanSprites;
        private int isiMakanIndex = 0;

        [Header("Minum")]
        [SerializeField] private Slider minumSlider;
        private float minumCurrentValue;

        private void Awake()
        {
            makanButton.onClick.AddListener(OnMakanButtonClick);
            minumSlider.onValueChanged.AddListener(OnMinumSlideChange);

            minumCurrentValue = minumSlider.maxValue;
        }

        private void OnMakanButtonClick()
        {
            if (IsDoneMakan()) return;

            isiMakanIndex++;
            isiMakanImage.sprite = isiMakanSprites[isiMakanIndex];

            if (IsDoneMakan() && IsDoneMinum())
            {
                OnTaskEnd();
                return;
            }
        }

        private void OnMinumSlideChange(float _value)
        {
            PreventIncreasedValue(minumSlider, _value);

            if (IsDoneMinum() && IsDoneMakan())
            {
                OnTaskEnd();
                return;
            }
        }

        private void ChangeIsiMakanSprite()
        {
            isiMakanImage.sprite = isiMakanSprites[isiMakanIndex];
            isiMakanIndex++;
        }

        private void PreventIncreasedValue(Slider _slider, float _newValue)
        {
            if (_newValue <= minumCurrentValue)
            {
                minumCurrentValue = _newValue;
                minumSlider.value = minumCurrentValue;
            }
            else
            {
                _slider.value = minumCurrentValue;
            }
        }

        private bool IsDoneMakan()
        {
            return isiMakanImage.sprite == isiMakanSprites[isiMakanSprites.Count - 1];
        }

        private bool IsDoneMinum()
        {
            return minumSlider.value == minumSlider.minValue;
        }

        public void OnTaskEnd()
        {
            // status logic here
        }
    }
}