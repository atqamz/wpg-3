using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ElBekarat.Bedroom
{
    public class PhonePanel : MonoBehaviour, ITask
    {
        [SerializeField] private GameObject chatArea;
        private List<Image> chatMessageList;

        private void Awake()
        {
            chatMessageList = new List<Image>();
            AppendAllChatMessages();
        }

        private void Start()
        {
            HideAllChatMessages();
            StartCoroutine(StartConversation());
        }

        private IEnumerator StartConversation()
        {
            yield return new WaitForSeconds(1f);
            ShowChatMessage(0);
            yield return new WaitForSeconds(1f);
            ShowChatMessage(1);
            yield return new WaitForSeconds(1f);
            ShowChatMessage(2);
            yield return new WaitForSeconds(1f);
            ShowChatMessage(3);
            yield return new WaitForSeconds(2f);
            ShowChatMessage(4);
            yield return new WaitForSeconds(1f);
            ShowChatMessage(5);
            yield return new WaitForSeconds(1f);
            ShowChatMessage(6);
            yield return new WaitForSeconds(2f);
            ShowChatMessage(7);
            yield return new WaitForSeconds(1f);
            ShowChatMessage(8);
            yield return new WaitForSeconds(2f);
            ShowChatMessage(9);
            yield return new WaitForSeconds(1f);
            ShowChatMessage(10);
            yield return new WaitForSeconds(1f);
            ShowChatMessage(11);
        }

        private void AppendAllChatMessages()
        {
            for (int i = 0; i < chatArea.transform.childCount; i++)
            {
                chatMessageList.Add(chatArea.transform.GetChild(i).GetComponent<Image>());
            }
        }

        private void HideAllChatMessages()
        {
            foreach (Image chatMessage in chatMessageList)
            {
                chatMessage.enabled = false;
            }
        }

        private void ShowChatMessage(int _index)
        {
            chatMessageList[_index].enabled = true;
        }

        public void OnTaskEnd()
        {
            // status logic here
        }
    }
}
