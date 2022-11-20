using UnityEngine;

namespace LeftMainPanel
{
    public class Bed : BaseEnvironment
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    EventManager.Instance.ClickEnvironment(EnvironmentType.BED);
                }
            }
        }
    }
}

