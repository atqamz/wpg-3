namespace Game.Bedroom
{
    public class PhoneObject : BaseEnvObject
    {
        private void Awake()
        {
            environmentType = EnvironmentType.PHONE;
        }

        private void Start()
        {
            EventManager.Instance.onEnvironmentClick += OnEnvironmentClick;
        }

        private void OnEnvironmentClick(EnvironmentType _environmentType)
        {
            if (_environmentType == EnvironmentType.PHONE)
            {
                environmentPanel.SetActive(true);
            }
        }
    }
}