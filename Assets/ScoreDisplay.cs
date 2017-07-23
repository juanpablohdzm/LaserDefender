using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start ()
    {
        text.text = "Score: " + ScoreKeeper.score;
        ScoreKeeper.ResetScore();
	}
	
	
}
