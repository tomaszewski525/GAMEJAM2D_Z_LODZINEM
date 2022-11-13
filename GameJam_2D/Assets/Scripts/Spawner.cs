using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Object[] enemies;
    public float verticalBorder;
    public float horizontalBorder;
    public float[] probabilities;
    public float[] secProbabilities;
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

    Object Choose(Object o)
    {
        Transform[] children;
        for (int i=0; i <= 3; i++)
        {
            //children.Append()
        }
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
