using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ElBekarat.Bedroom
{
    public class ComputerPanel : MonoBehaviour, ITask
    {
        [SerializeField] private Button enterButton;
        [SerializeField] private TextMeshProUGUI monitorText;

        private void Awake()
        {
            enterButton.onClick.AddListener(OnEnterButtonClick);
        }

        private void OnEnterButtonClick()
        {
            monitorText.text = "Assignment submitted!";
            OnTaskEnd();
        }

        public void OnTaskEnd()
        {
            // status logic here
        }
    }
}
