using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text text;
    public static float score=0;
    private void Start()
    {

        ResetScore();
    }


    public void SetScore(float points)
    {
        score += points;
        text.text = "Score: " + score;
    }
    public static void ResetScore()
    {
        score = 0;
    }

}
