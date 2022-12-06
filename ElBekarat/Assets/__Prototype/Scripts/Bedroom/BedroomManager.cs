using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom
{
    public class BedroomManager : MonoBehaviour
    {
        public static BedroomManager Instance { get; private set; }

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
        [SerializeField] private GameObject Left;
        [SerializeField] private GameObject Right;

        private void Start()
        {
            Debug.Log("Prolog ended");
            StartCoroutine(OverlayFadeOut());

            Left.SetActive(true);
            Right.SetActive(true);
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
    }
}
