using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    ScoreKeeper scoreKeeper;
    public Object[] enemies;
    public float verticalBorder;
    public float horizontalBorder;
    public float[] probabilities;
    public float[] secProbabilities;

    List<KeyValuePair<Object, float>> elements;
    //float time = 5.0f;
    Spawner_Handler spawner_Handler;

    public float delayTime;
    public int delayScore;
    public int timeOnStage;


    int playerScore;

    int stage = 1;
    //int nextStageScore = 10;

    float spawnerTime;

    //int playerScore_cp = 0;

    int newStage = 0;

    //bool startSpawn = false;

    float spawnTimer;
    public void Update()
    {
        delayTime -= Time.deltaTime;
        playerScore = scoreKeeper.score;

        print(playerScore);

        if (delayTime < 0 || playerScore > delayScore)
        {
            spawnerTime += Time.deltaTime;
            //print(spawnerTime % timeOnStage);

            if (timeOnStage - spawnerTime < 0)
            {
                spawnerTime -= timeOnStage;

                stage = stage + 1;

            }

            if (newStage != stage)
            {
                //spawner_Handler = Instantiate(spawner_Handler, transform.position, transform.rotation);
                newStage = stage;
                //startSpawn = true;
            }

        }


        if(stage != 0 && (delayTime < 0 || playerScore > delayScore))
        {
            float time = (float)timeOnStage / (float)stage;
            time = Mathf.Clamp(time, 0.5f, 10.0f);

            spawnTimer += Time.deltaTime;
            if (spawnTimer> time)
            {
                Spawn();
                spawnTimer = 0;
            }
        }

    }


    public void Spawn()
    {

        Object enemy = Choose();
        int index = Random.Range(0, 3);
        Transform ins = enemy.GetComponent<Transform>().GetChild(index);
        float x_offset = Random.Range(-2, 2);
        float y_offset = Random.Range(-2, 2);


        Vector2 randomSpawnPos = new Vector2(transform.position.x + x_offset, transform.position.y + y_offset);

        //Vector2 randomSpawnPos = new Vector2(Random.Range(-verticalBorder, verticalBorder), Random.Range(-horizontalBorder, horizontalBorder));
        // Quaternion.identity
        Instantiate(ins, randomSpawnPos, transform.rotation);
    }

    /*
    IEnumerator ISpawner()
    {
        while (true)
        {
            time = timeOnStage / stage;

            // Mathf.Clamp(time, 2.0f, 4.0f);
            Spawn();
            yield return new WaitForSeconds(time);
        }
    }*/

    /*
    void IncreseSpeed(Enemy e)
    {
        time -= 0.2f;
    }*/

    private void Start()
    {
        scoreKeeper = player.GetComponent<ScoreKeeper>();

        //Enemy.OnEnemyDeath += IncreseSpeed;
        elements = new List<KeyValuePair<Object, float>>();
        for (int i = 0; i < enemies.Length; i++)
        {
            elements.Add(new KeyValuePair<Object, float>(enemies[i], probabilities[i]));
        }

        //;
    }
    Object Choose()
    {

        System.Random r = new System.Random();
        float diceRoll = (float)(r.NextDouble());
        float cumulative = 0f;
        for (int i = 0; i < elements.Count; i++)
        {
            cumulative += elements[i].Value;
            if (diceRoll < cumulative)
            {
                return elements[i].Key;
            }
        }
        return new Object();
    }
}
