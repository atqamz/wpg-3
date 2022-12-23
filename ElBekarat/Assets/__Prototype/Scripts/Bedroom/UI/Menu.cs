using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom.UI
{
    public class Menu : MonoBehaviour
    {
        bool isInGameMenuOn = false;
        private Animator inGameMenuAnimator;
        [SerializeField] private Button inGameMenuButton;

        [Header("Pop Up")]
        [SerializeField] private Button backToMainMenuButton;
        [SerializeField] private GameObject backToMainMenuPopUp;

        private void Start()
        {
            inGameMenuButton.onClick.AddListener(SetInGameMenuAnimator);
            backToMainMenuButton.onClick.AddListener(ShowBackToMainMenuPopUp);
        }

        public void SetInGameMenuAnimator()
        {
            isInGameMenuOn = !isInGameMenuOn;
            inGameMenuAnimator.SetBool("isOn", isInGameMenuOn);
        }

        public void ShowBackToMainMenuPopUp()
        {
            PageManager.Instance.CanInteract = false;
            backToMainMenuPopUp.SetActive(true);
        }

        private void Awake()
        {
            inGameMenuAnimator = GetComponent<Animator>();
        }
    }
}
