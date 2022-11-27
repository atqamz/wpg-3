using System;
using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    #region singleton
    private static OverlayManager instance;
    public static OverlayManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<OverlayManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion singleton

    public event Action<float> OnChangeBlanketValue;
    public void ChangeBlankedValue(float value)
    {
        OnChangeBlanketValue?.Invoke(value);
    }
}
