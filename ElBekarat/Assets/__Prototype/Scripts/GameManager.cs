using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
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