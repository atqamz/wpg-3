using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.MainMenu
{
    public class SettingPopUp : MonoBehaviour
    {
        [SerializeField] private PageManager pageManager;
        [SerializeField] private Button closeButton;

        private void Start()
        {
            closeButton.onClick.AddListener(() => pageManager.SetSettingAnimator());
        }
    }
}
