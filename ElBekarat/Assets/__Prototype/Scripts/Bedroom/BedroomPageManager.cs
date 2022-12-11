using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom
{
    public class BedroomPageManager : MonoBehaviour
    {
        [SerializeField] private Image overlayGFX;

        private void Start()
        {
            StartCoroutine(OverlayFadeOut());
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

        public static BedroomPageManager Instance { get; private set; }
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
