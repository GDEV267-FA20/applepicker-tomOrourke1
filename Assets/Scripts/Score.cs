using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score 
{

    private int score;

    public Score()
    {
        score = 0;
    }

    public Score(int score)
    {
        this.score = score;

    }


    public void AddScore(int score)
    {
        this.score += score;
    }

    public int GetScore()
    {
        return score;
    }


}
