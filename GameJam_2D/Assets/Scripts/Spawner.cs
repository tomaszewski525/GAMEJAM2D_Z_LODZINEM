using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Object[] enemies;
    public float verticalBorder;
    public float horizontalBorder;

    public void Spawn(int i)
    {
        Vector2 randomSpawnPos = new Vector2(Random.Range(-verticalBorder, verticalBorder), Random.Range(-horizontalBorder, horizontalBorder));
        Instantiate(enemies[i], randomSpawnPos, Quaternion.identity);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(0, 3);
            Spawn(index);
        }
    }
}
