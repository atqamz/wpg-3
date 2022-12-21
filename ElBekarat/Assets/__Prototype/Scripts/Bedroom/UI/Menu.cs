using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom.UI
{
    public class Menu : MonoBehaviour
    {
        bool isInGameMenuOn = false;
        private Animator inGameMenuAnimator;
        [SerializeField] private Button inGameMenuButton;

        public void SetOnInGameMenuAnimator()
        {
            isInGameMenuOn = !isInGameMenuOn;
            inGameMenuAnimator.SetBool("isOn", isInGameMenuOn);
        }

        private void Awake()
        {
            inGameMenuAnimator = GetComponent<Animator>();
            inGameMenuButton.onClick.AddListener(SetOnInGameMenuAnimator);
        }
    }
}
