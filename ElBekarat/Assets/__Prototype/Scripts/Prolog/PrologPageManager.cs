using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace ElBekarat.Prolog
{
    public class PrologPageManager : MonoBehaviour
    {
        [SerializeField] private Image overlayGFX;

        [Header("Prolog")]
        [SerializeField][TextArea(3, 10)] private List<string> prologTextList;
        [SerializeField] private TextMeshProUGUI prologText;
        [SerializeField] private float prologTextSpeed = 0.05f;
        [SerializeField] private Button nextButton;
        private Coroutine typeLineCoroutine;

        private void Start()
        {
            nextButton.onClick.AddListener(OnNextButtonClick);

            prologText.text = string.Empty;

            StartCoroutine(StartProlog());
        }

        private IEnumerator OverlayFade(float _fade)
        {
            overlayGFX.gameObject.SetActive(true);

            if (_fade == 0)
            {
                overlayGFX.canvasRenderer.SetAlpha(1f);
            }
            else
            {
                overlayGFX.canvasRenderer.SetAlpha(0f);
            }

            overlayGFX.CrossFadeAlpha(_fade, 2f, false);

            yield return new WaitForSeconds(2f);
        }

        private IEnumerator StartProlog()
        {
            StartCoroutine(OverlayFade(0));
            yield return new WaitForSeconds(2f);
            overlayGFX.gameObject.SetActive(false);

            typeLineCoroutine = StartCoroutine(TypeLine());
        }

        private IEnumerator EndProlog()
        {
            StartCoroutine(OverlayFade(1));

            yield return new WaitForSeconds(3f);

            SceneManager.LoadScene("Bedroom");
        }

        private void NextLine()
        {
            if (prologTextList.Count > 0)
            {
                typeLineCoroutine = StartCoroutine(TypeLine());
            }
            else
            {
                StartCoroutine(EndProlog());
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

        public static PrologPageManager Instance { get; private set; }
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
    }
}