using UnityEngine;

namespace ElBekarat
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {

        }

        private void Update()
        {

        }


        public static GameManager Instance;
        private void Awake()
        {
            #region SingletonDDOL
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            #endregion

        }
    }
}