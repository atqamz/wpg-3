using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ElBekarat.Prolog
{
    public class PrologPageManager : MonoBehaviour
    {
        [SerializeField] private Image overlayGFX;

        [SerializeField] private BookPro logBook;

        private void Start()
        {
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
        }

        private IEnumerator EndProlog()
        {
            yield return new WaitForSeconds(2f);

            StartCoroutine(OverlayFade(1));

            yield return new WaitForSeconds(3f);

            GameManager.Instance.LoadScene("Bedroom");
        }

        public void CheckIfPageIsDone()
        {
            if (logBook.CurrentPaper == logBook.papers.Length - 1)
            {
                StartCoroutine(EndProlog());
            }
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