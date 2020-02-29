using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text score;
    private int currentScore = 0;

    public void AddScore(int add)
    {
        currentScore += add;
        score.text = currentScore.ToString();
    }
}
