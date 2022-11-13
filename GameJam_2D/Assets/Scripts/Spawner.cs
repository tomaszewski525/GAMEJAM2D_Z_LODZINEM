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
    public Vector2 x_offset;
    public Vector2 y_offset;

    int playerScore;

    int stage = 1;
    //int nextStageScore = 10;

    float spawnerTime;

    //int playerScore_cp = 0;

    int newStage = 0;

    //bool startSpawn = false;

    float spawnTimer;
    bool isActive = false;

    void Active(Menu e)
    {
        isActive = true;
    }

    public void Update()
    {
        if (isActive)
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


            if (stage != 0 && (delayTime < 0 || playerScore > delayScore))
            {
                float time = (float)timeOnStage / (float)stage;
                time = Mathf.Clamp(time, 0.5f, 10.0f);

                spawnTimer += Time.deltaTime;
                if (spawnTimer > time)
                {
                    Spawn();
                    spawnTimer = 0;
                }
            }
        }
    }


    public void Spawn()
    {

        Object enemy = Choose();
        int index = Random.Range(0, 3);
        Transform ins = enemy.GetComponent<Transform>().GetChild(index);
        float x_offset_2 = Random.Range(x_offset.x, x_offset.y);
        float y_offset_2 = Random.Range(y_offset.x, y_offset.y);


        Vector2 randomSpawnPos = new Vector2(transform.position.x + x_offset_2, transform.position.y + y_offset_2);

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
        Menu.pressPlay += Active;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

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
