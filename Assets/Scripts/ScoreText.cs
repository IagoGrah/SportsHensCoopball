using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] bool rightSide;

    void Start()
    {
        var scoreText = GetComponent<TMP_Text>();
        scoreText.text = (rightSide ? GameManager.Instance.RightScore : GameManager.Instance.LeftScore).ToString();
    }
}
