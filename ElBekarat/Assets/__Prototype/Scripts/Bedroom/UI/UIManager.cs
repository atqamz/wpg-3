using System.Collections;
using UnityEngine;

namespace ElBekarat.Bedroom.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private OnEnvironmentRangeUI onEnvironmentRangeUI;
        [SerializeField] private GameObject moodNotEnoughUI;

        private void Start()
        {
            Bedroom.EventManager.Instance.onEnvironmentRange += OnEnvironmentRange;
            Bedroom.EventManager.Instance.onEnvironmentClick += OnEnvironmentClick;

            Bedroom.EventManager.Instance.onMoodNotEnough += OnMoodNotEnough;

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

        private void OnMoodNotEnough()
        {
            moodNotEnoughUI.SetActive(true);
            onEnvironmentRangeUI.Hide();

            StartCoroutine(HideMoodNotEnoughUI());
        }

        private IEnumerator HideMoodNotEnoughUI()
        {
            yield return new WaitForSeconds(2f);

            moodNotEnoughUI.SetActive(false);
            onEnvironmentRangeUI.Show();
        }

        private void HideAllUI()
        {
            onEnvironmentRangeUI.Hide();
        }
    }
}
