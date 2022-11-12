using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UI : MonoBehaviour
{
    public Transform[] KeysUI;
    public PlayerMovement playerM;
    private string pattern;

    string[] arrowSwitchTypes = { "WS", "AD", "AW", "DW", "AS", "SD" };
    private void Awake()
    {
        Enemy.OnEnemyDeath += SwapUI;
    }

    private void Update()
    {
        pattern = playerM.movementKeyPattern;
    }

    void SwapUI(Enemy e)
    {
        int index = e.enemyType;
        string str = arrowSwitchTypes[index];
        char first = str[0];
        char second = str[1];
        GameObject f = GameObject.FindGameObjectWithTag(first.ToString());
        GameObject s = GameObject.FindGameObjectWithTag(second.ToString());
        Vector3 tempPosition = f.transform.position;
        f.transform.position = s.transform.position;
        s.transform.position = tempPosition;
    }

    IEnumerator FlashUI(Transform f1, Transform f2)
    {
        yield return null;
    }
}
