using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private Text text;
    private float score=0;
    private void Start()
    {
         text = GameObject.FindObjectOfType<Text>();
         Reset();
    }


    public void SetScore(float points)
    {
        score += points;
        text.text = "Score: " + score;
    }
    private void Reset()
    {
        score = 0;
        text.text = "Score: 0";
    }

}
