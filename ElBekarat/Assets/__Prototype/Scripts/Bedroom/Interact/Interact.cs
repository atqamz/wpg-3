using UnityEngine;

namespace ElBekarat.Bedroom
{
    public class Interact : MonoBehaviour
    {
        [SerializeField] private int[] minimumMood = new int[3];
        [SerializeField] private int[] completingMood = new int[3];
        [SerializeField] private int[] uncompletingMood = new int[3];

        public bool IsMoodEnough()
        {
            return PlayerStats.Instance.GetHappiness() >= minimumMood[0] &&
                   PlayerStats.Instance.GetMotivation() >= minimumMood[1] &&
                   PlayerStats.Instance.GetGoals() >= minimumMood[2];
        }

        protected void AddCompletingMood()
        {
            PlayerStats.Instance.ChangeHappiness(PlayerStats.Instance.GetHappiness() + completingMood[0]);
            PlayerStats.Instance.ChangeMotivation(PlayerStats.Instance.GetMotivation() + completingMood[1]);
            PlayerStats.Instance.ChangeGoals(PlayerStats.Instance.GetGoals() + completingMood[2]);
        }

        protected void AddUncompletingMood()
        {
            PlayerStats.Instance.ChangeHappiness(PlayerStats.Instance.GetHappiness() + uncompletingMood[0]);
            PlayerStats.Instance.ChangeMotivation(PlayerStats.Instance.GetMotivation() + uncompletingMood[1]);
            PlayerStats.Instance.ChangeGoals(PlayerStats.Instance.GetGoals() + uncompletingMood[2]);
        }
    }
}