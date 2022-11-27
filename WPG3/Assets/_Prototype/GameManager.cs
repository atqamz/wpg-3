using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public class Kara
{
    public static Kara Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    private float happinessMeter;
    public float HappinessMeter
    {
        get { return happinessMeter; }
        set
        {
            happinessMeter = value;
            if (happinessMeter < 0)
            {
                happinessMeter = 0;
            }
            if (happinessMeter > 100)
            {
                happinessMeter = 100;
            }
        }
    }

    private float motivationMeter;
    public float MotivationMeter
    {
        get { return motivationMeter; }
        set
        {
            motivationMeter = value;
            if (motivationMeter < 0)
            {
                motivationMeter = 0;
            }
            if (motivationMeter > 100)
            {
                motivationMeter = 100;
            }
        }
    }

    private float goalsMeter;
    public float GoalsMeter
    {
        get { return goalsMeter; }
        set
        {
            goalsMeter = value;
            if (goalsMeter < 0)
            {
                goalsMeter = 0;
            }
            if (goalsMeter > 100)
            {
                goalsMeter = 100;
            }
        }
    }
}