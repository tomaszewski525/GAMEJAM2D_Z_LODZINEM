using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    private void Start()
    {
        Enemy.OnEnemyDeath += AddScore;
    }

    public void AddScore(Enemy e)
    {
        int addScore = e.score_num;
        score += addScore;
    }
}
