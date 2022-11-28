using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

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
            Prolog.EventManager.Instance.onPrologEnd += OnPrologEnd;

            Left.SetActive(false);
            Right.SetActive(false);
        }

        private void OnPrologEnd()
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

    public class Kara
    {
        public static Kara Instance { get; private set; }

        public void Awake()
        {
            Instance = this;
        }

        private float happinessMeter;
        public float HappinessMeter
        {
            get { return happinessMeter; }
            set
            {
                happinessMeter = value;
                if (happinessMeter < 0)
                {
                    happinessMeter = 0;
                }
                if (happinessMeter > 100)
                {
                    happinessMeter = 100;
                }
            }
        }

        private float motivationMeter;
        public float MotivationMeter
        {
            get { return motivationMeter; }
            set
            {
                motivationMeter = value;
                if (motivationMeter < 0)
                {
                    motivationMeter = 0;
                }
                if (motivationMeter > 100)
                {
                    motivationMeter = 100;
                }
            }
        }

        private float goalsMeter;
        public float GoalsMeter
        {
            get { return goalsMeter; }
            set
            {
                goalsMeter = value;
                if (goalsMeter < 0)
                {
                    goalsMeter = 0;
                }
                if (goalsMeter > 100)
                {
                    goalsMeter = 100;
                }
            }
        }
    }
}