using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvOverlay : MonoBehaviour
{
    private SpriteRenderer spriteRendererComponent;

    private void Awake()
    {
        spriteRendererComponent = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRendererComponent.color = new Color(0, 0, 0, 0);
        OverlayManager.Instance.OnChangeBlanketValue += OverlayManager_OnChangeBlanketValue;
    }

    private void OverlayManager_OnChangeBlanketValue(float _value)
    {
        spriteRendererComponent.color = new Color(0, 0, 0, _value);
    }
}
