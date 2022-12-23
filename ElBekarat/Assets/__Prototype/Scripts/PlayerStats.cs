using System;
using UnityEngine;

namespace ElBekarat
{
    public class PlayerStats : MonoBehaviour
    {
        private Kara kara;

        private void Start()
        {
            if (PlayerPrefs.HasKey("Happiness") && PlayerPrefs.HasKey("Motivation") && PlayerPrefs.HasKey("Goals"))
            {
                ChangeHappiness(PlayerPrefs.GetFloat("Happiness"));
                ChangeMotivation(PlayerPrefs.GetFloat("Motivation"));
                ChangeGoals(PlayerPrefs.GetFloat("Goals"));

                return;
            }

            RandomizeStats();
        }

        private void RandomizeStats()
        {
            int[] stats = { 20, 10, 10 };

            for (int i = 0; i < stats.Length; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, stats.Length);
                int temp = stats[i];
                stats[i] = stats[randomIndex];
                stats[randomIndex] = temp;
            }

            ChangeHappiness(stats[0]);
            ChangeMotivation(stats[1]);
            ChangeGoals(stats[2]);
        }

        private void SetHappiness(float _value)
        {
            kara.HappinessMeter = _value;
            // PlayerPrefs.SetFloat("Happiness", _value);
        }

        public float GetHappiness()
        {
            return kara.HappinessMeter;
        }

        private void SetMotivation(float _value)
        {
            kara.MotivationMeter = _value;
            // PlayerPrefs.SetFloat("Motivation", _value);
        }

        public float GetMotivation()
        {
            return kara.MotivationMeter;
        }

        private void SetGoals(float _value)
        {
            kara.GoalsMeter = _value;
            // PlayerPrefs.SetFloat("Goals", _value);
        }

        public float GetGoals()
        {
            return kara.GoalsMeter;
        }

        // observer pattern
        public Action<float> OnHappinessChange;
        public Action<float> OnMotivationChange;
        public Action<float> OnGoalsChange;

        public void ChangeHappiness(float _value)
        {
            SetHappiness(_value);
            OnHappinessChange?.Invoke(_value);
        }

        public void ChangeMotivation(float _value)
        {
            SetMotivation(_value);
            OnMotivationChange?.Invoke(_value);
        }

        public void ChangeGoals(float _value)
        {
            SetGoals(_value);
            OnGoalsChange?.Invoke(_value);
        }

        // singleton pattern
        public static PlayerStats Instance { get; private set; }
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

            kara = new Kara();
        }
    }
}