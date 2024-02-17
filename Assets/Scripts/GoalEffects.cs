using UnityEngine;

public class GoalEffects : MonoBehaviour
{
    [SerializeField] bool rightSide;
    [SerializeField] GameObject particles;

    void Start()
    {
        if (rightSide)
        {
            GameManager.Instance.LeftGoalEffects = particles;
        }
        else
        {
            GameManager.Instance.RightGoalEffects = particles;
        }
    }
}
