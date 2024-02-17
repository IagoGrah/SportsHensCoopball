using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] bool rightSide;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.ScoreGoal(rightSide);
        }
    }
}
