using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerArrowSwitch : MonoBehaviour
{
    public string currentArrows = "UDLR";
    public string[] arrowSwitchTypes = {"LR", "UD", "LU", "LD", "UR", "RD"};

    private void Start()
    {
        Enemy.OnEnemyDeath += SwitchArrows;
    }
    public void SwitchArrows(Enemy e)
    {
        int arrowSwitchTypeNum = e.enemyType;
        string arrowSwitchType = arrowSwitchTypes[arrowSwitchTypeNum];
        char firstKey = arrowSwitchType[0];
        char secondKey = arrowSwitchType[1];
        currentArrows = currentArrows.Replace(firstKey, '~').Replace(secondKey, firstKey).Replace('~', secondKey);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<IEnemy>() == null) { return; }
        Enemy e = collision.collider.GetComponent<Enemy>();
        e.OnHit(3);
    }
}
