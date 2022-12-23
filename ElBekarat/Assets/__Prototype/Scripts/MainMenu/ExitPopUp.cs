using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.MainMenu
{
    public class ExitPopUp : MonoBehaviour
    {
        [SerializeField] private PageManager pageManager;
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;

        private void Start()
        {
            yesButton.onClick.AddListener(Exit);
            noButton.onClick.AddListener(() => pageManager.SetExitAnimator());
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
