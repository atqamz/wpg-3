using UnityEngine;
using UnityEngine.UI;

public class TaskSleep : MonoBehaviour
{
    [SerializeField] private Slider sliderComponent;

    private void Start()
    {
        sliderComponent.onValueChanged.AddListener((_value) => OverlayManager.Instance.ChangeBlankedValue(_value));
    }
}
