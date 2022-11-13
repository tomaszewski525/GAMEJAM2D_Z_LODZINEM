using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float verticalBorder;
    public float horizontalBorder;
    public float[] probabilities;
    public float[] secProbabilities;
    List<KeyValuePair<GameObject, float>> elements;
    float time = 5.0f;

    public void Spawn()
    {
        Object enemy = Choose();
        int index = Random.Range(0, 3);
        Transform ins = enemy.GetComponent<Transform>().GetChild(index);
        Vector2 randomSpawnPos = new Vector2(Random.Range(-verticalBorder, verticalBorder), Random.Range(-horizontalBorder, horizontalBorder));
        Instantiate(ins, randomSpawnPos, Quaternion.identity);
    }

    IEnumerator ISpawner()
    {
        while (true)
        {
            Mathf.Clamp(time, 2.0f, 4.0f);
            Spawn();
            yield return new WaitForSeconds(time);
        }
    }

    void IncreseSpeed(Enemy e)
    {
        time -= 0.2f;
    }

    private void Start()
    {
        Enemy.OnEnemyDeath += IncreseSpeed;
        elements = new List<KeyValuePair<GameObject, float>>();
        for (int i = 0; i < enemies.Length; i++)
        {
            elements.Add(new KeyValuePair<GameObject, float>(enemies[i], probabilities[i]));
        }
        StartCoroutine(ISpawner());
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
        return new GameObject();
    }
}
