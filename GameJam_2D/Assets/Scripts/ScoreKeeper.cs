using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    Text t;
    private void Start()
    {
        t = GetComponent<Text>();
        Enemy.OnEnemyDeath += AddScore;
    }

    public void AddScore(Enemy e)
    {
        int addScore = e.score_num;
        score += addScore;
    }

    private void Update()
    {
        t.text = score.ToString();
    }
}
