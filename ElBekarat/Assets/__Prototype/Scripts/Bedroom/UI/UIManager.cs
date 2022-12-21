using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private OnEnvironmentRangeUI onEnvironmentRangeUI;

        private void Start()
        {
            Bedroom.EventManager.Instance.onEnvironmentRange += OnEnvironmentRange;
            Bedroom.EventManager.Instance.onEnvironmentClick += OnEnvironmentClick;

            HideAllUI();
        }

        private void OnEnvironmentRange(bool _isOn, Bedroom.EnvironmentType _environmentType)
        {
            if (_isOn)
                onEnvironmentRangeUI.Show();
            else
                onEnvironmentRangeUI.Hide();
        }

        private void OnEnvironmentClick(Bedroom.EnvironmentType _environmentType)
        {
            onEnvironmentRangeUI.Hide();
        }

        private void HideAllUI()
        {
            onEnvironmentRangeUI.Hide();
        }
    }
}
