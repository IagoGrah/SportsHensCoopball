using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingletonBehaviour<GameManager>
{
    [SerializeField] float goalScreenDuration = 1f;
    
    public GameObject GoalScreen;
    public GameObject LeftGoalEffects;
    public GameObject RightGoalEffects;

    public int LeftScore;
    public int RightScore;

    bool goalScored;

    public void ScoreGoal(bool rightSide)
    {
        if (!goalScored)
        {
            StartCoroutine(GoalCoroutine(rightSide));
        }
    }

    IEnumerator GoalCoroutine(bool rightSide)
    {
        goalScored = true;
        if (GoalScreen != null)
        {
            GoalScreen.SetActive(true);
        }
        if (rightSide)
        {
            RightScore++;
            if (LeftGoalEffects)
            {
                LeftGoalEffects.SetActive(true);
            }
        }
        else
        {
            LeftScore++;
            if (RightGoalEffects)
            {
                RightGoalEffects.SetActive(true);
            }
        }

        AudioManager.Instance.PlayGoalSound();

        yield return new WaitForSeconds(goalScreenDuration);
        goalScored = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
