namespace Game.Bedroom
{
    public class ComputerObject : BaseEnvObject
    {
        private void Awake()
        {
            environmentType = EnvironmentType.COMPUTER;
        }

        private void Start()
        {
            EventManager.Instance.onEnvironmentClick += OnEnvironmentClick;
        }

        private void OnEnvironmentClick(EnvironmentType _environmentType)
        {
            if (_environmentType == EnvironmentType.COMPUTER)
            {
                environmentPanel.SetActive(true);
            }
        }
    }
}