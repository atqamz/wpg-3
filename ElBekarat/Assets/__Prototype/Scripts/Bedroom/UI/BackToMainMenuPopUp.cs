using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom.UI
{
    public class BackToMainMenuPopUp : MonoBehaviour
    {
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;

        private void Start()
        {
            yesButton.onClick.AddListener(BackToMainMenu);
            noButton.onClick.AddListener(() => PageManager.Instance.CanInteract = true);
        }

        public void BackToMainMenu()
        {
            PageManager.Instance.CanInteract = true;
            GameManager.Instance.LoadScene("MainMenu");
        }
    }
}
