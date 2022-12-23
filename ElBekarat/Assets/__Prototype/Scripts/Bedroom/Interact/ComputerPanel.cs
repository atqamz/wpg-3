using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ElBekarat.Bedroom
{
    public class ComputerPanel : Interact, ITask
    {
        [SerializeField] private Button enterButton;
        [SerializeField] private TextMeshProUGUI monitorText;

        public void OnTaskEnd()
        {
            AddCompletingMood();
        }

        private void Awake()
        {
            enterButton.onClick.AddListener(OnEnterButtonClick);
        }

        private void OnEnterButtonClick()
        {
            monitorText.text = "Assignment submitted!";
            OnTaskEnd();
        }
    }
}
