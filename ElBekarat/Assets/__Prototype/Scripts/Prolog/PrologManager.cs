using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Prolog
{
    public class PrologManager : MonoBehaviour
    {
        public static PrologManager Instance { get; private set; }

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [SerializeField] private Image overlayGFX;

        [Header("Prolog")]
        [SerializeField][TextArea(3, 10)] private List<string> prologTextList;
        [SerializeField] private TextMeshProUGUI prologText;
        [SerializeField] private float prologTextSpeed = 0.05f;
        [SerializeField] private Button nextButton;
        private Coroutine typeLineCoroutine;


        [Header("Skip")]
        [SerializeField] private Button skipButton;

        private void Start()
        {
            nextButton.onClick.AddListener(OnNextButtonClick);

            prologText.text = string.Empty;

            StartCoroutine(StartProlog());
        }

        private IEnumerator OverlayFadeOut()
        {
            overlayGFX.gameObject.SetActive(true);
            float alpha = 1f;
            while (alpha > 0)
            {
                alpha -= Time.deltaTime;
                overlayGFX.color = new Color(0, 0, 0, alpha);
                yield return null;
            }
            overlayGFX.gameObject.SetActive(false);
        }

        private IEnumerator StartProlog()
        {
            StartCoroutine(OverlayFadeOut());

            yield return new WaitForSeconds(1f);

            typeLineCoroutine = StartCoroutine(TypeLine());
            StartCoroutine(ShowSkipButton());
        }

        private void NextLine()
        {
            if (prologTextList.Count > 0)
            {
                typeLineCoroutine = StartCoroutine(TypeLine());
            }
            else
            {
                SceneManager.LoadScene("Bedroom");
            }
        }

        private IEnumerator TypeLine()
        {
            string line = prologTextList[0];
            prologText.text = "";
            foreach (char letter in line.ToCharArray())
            {
                prologText.text += letter;
                yield return new WaitForSeconds(prologTextSpeed);
            }

            typeLineCoroutine = null;
        }

        public void OnNextButtonClick()
        {
            if (typeLineCoroutine != null)
            {
                StopCoroutine(typeLineCoroutine);
                prologText.text = prologTextList[0];
                typeLineCoroutine = null;
                return;
            }
            prologTextList.RemoveAt(0);

            NextLine();
        }

        private void OnSkipButtonClick()
        {
            skipButton.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(UnityEngine.Random.Range(-100, -500), UnityEngine.Random.Range(-100, -500));
        }

        private IEnumerator<WaitForSeconds> ShowSkipButton()
        {
            skipButton.interactable = false;
            yield return new WaitForSeconds(5f);
            skipButton.interactable = true;
        }
    }
}