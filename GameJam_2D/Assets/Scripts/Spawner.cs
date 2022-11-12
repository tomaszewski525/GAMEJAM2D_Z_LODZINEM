using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Object[] enemies;
    public float verticalBorder;
    public float horizontalBorder;
    public float[] probabilities;
    List<KeyValuePair<Object, float>> elements;


    public void Spawn()
    {
        Object enemy = Choose();
        Vector2 randomSpawnPos = new Vector2(Random.Range(-verticalBorder, verticalBorder), Random.Range(-horizontalBorder, horizontalBorder));
        Instantiate(enemy, randomSpawnPos, Quaternion.identity);
    }

    private void Start()
    { 
        elements = new List<KeyValuePair<Object, float>>();
        for (int i = 0; i < enemies.Length; i++)
        {
            elements.Add(new KeyValuePair<Object, float>(enemies[i], probabilities[i]));
        }
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
