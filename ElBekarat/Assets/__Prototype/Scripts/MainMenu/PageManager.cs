using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.MainMenu
{
    public class PageManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [Header("With Pop Up")]
        [SerializeField] private Button exitButton;
        [SerializeField] private Button settingButton;

        [Header("Without Pop Up")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button creditButton;
        [SerializeField] private Button figuraButton;

        private bool isExitOn = false;
        private bool isSettingOn = false;
        private bool isCreditOn = false;
        private bool isFiguraOn = false;

        private void Start()
        {
            exitButton.onClick.AddListener(SetExitAnimator);
            settingButton.onClick.AddListener(SetSettingAnimator);
            playButton.onClick.AddListener(Play);
            creditButton.onClick.AddListener(SetCreditAnimator);
            figuraButton.onClick.AddListener(SetFiguraAnimator);
        }

        public void SetExitAnimator()
        {
            isExitOn = !isExitOn;
            animator.SetBool("isExit", isExitOn);
        }

        public void SetSettingAnimator()
        {
            isSettingOn = !isSettingOn;
            animator.SetBool("isSetting", isSettingOn);
        }

        private void SetCreditAnimator()
        {
            isCreditOn = !isCreditOn;
            animator.SetBool("isCredit", isCreditOn);
        }

        private void SetFiguraAnimator()
        {
            isFiguraOn = !isFiguraOn;
            animator.SetBool("isFigura", isFiguraOn);
        }

        private void Play()
        {
            animator.SetBool("isPlay", true);

            StartCoroutine(Load());
        }

        private IEnumerator Load()
        {
            yield return new WaitForSeconds(2f);

            GameManager.Instance.LoadScene("Prolog");
        }
    }
}
