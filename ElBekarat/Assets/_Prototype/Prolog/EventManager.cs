using System;
using UnityEngine;

namespace Prolog
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public event Action onPrologEnd;
        public void PrologEnd()
        {
            onPrologEnd?.Invoke();
        }
    }
}