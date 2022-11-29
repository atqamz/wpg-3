using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceHandler : MonoBehaviour
{
    [SerializeField] Button atasButton;
    [SerializeField] Button bawahButton;

    int choice = 0;

    [SerializeField] GameObject choiceParent;

    private void Start()
    {
        atasButton.onClick.AddListener(OnAtasButtonClick);
        bawahButton.onClick.AddListener(OnBawahButtonClick);

        choiceParent.transform.GetChild(0).GetChild(choice).GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    private void OnBawahButtonClick()
    {
        if (choice + 1 > 2) return;
        choice++;

        choiceParent.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 50);
        choiceParent.transform.GetChild(0).GetChild(choice).GetComponent<TextMeshProUGUI>().color = Color.black;
        ResetColor();
    }

    private void OnAtasButtonClick()
    {
        if (choice - 1 < 0) return;
        choice--;

        choiceParent.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -50);
        choiceParent.transform.GetChild(0).GetChild(choice).GetComponent<TextMeshProUGUI>().color = Color.black;
        ResetColor();
    }

    private void ResetColor()
    {
        for (int i = 0; i < choiceParent.transform.GetChild(0).childCount; i++)
        {
            if (i == choice) continue;

            choiceParent.transform.GetChild(0).GetChild(i).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
}
