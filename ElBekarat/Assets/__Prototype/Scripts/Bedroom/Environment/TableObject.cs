namespace ElBekarat.Bedroom
{
    public class TableObject : BaseEnvObject
    {
        private void Awake()
        {
            environmentType = EnvironmentType.TABLE;
        }

        private void Start()
        {
            EventManager.Instance.onEnvironmentClick += OnEnvironmentClick;
        }

        private void OnEnvironmentClick(EnvironmentType _environmentType)
        {
            if (_environmentType == EnvironmentType.TABLE)
            {
                environmentPanel.SetActive(true);
            }
        }
    }
}