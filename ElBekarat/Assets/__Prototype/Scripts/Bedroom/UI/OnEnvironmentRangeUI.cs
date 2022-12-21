using UnityEngine;
using TMPro;

namespace ElBekarat.Bedroom.UI
{
    public class OnEnvironmentRangeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI infoText;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetInfoText(string _text)
        {
            infoText.text = _text;
        }
    }
}