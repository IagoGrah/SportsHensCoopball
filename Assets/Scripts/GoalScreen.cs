using UnityEngine;

public class GoalScreen : MonoBehaviour
{
    [SerializeField] GameObject image;

    void Start()
    {
        GameManager.Instance.GoalScreen = image;
    }
}
