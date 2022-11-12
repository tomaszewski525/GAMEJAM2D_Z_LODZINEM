using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerArrowSwitch : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public string currentArrows = "UDLR";
    public string[] arrowSwitchTypes = {"LR", "UD", "LU", "LD", "UR", "RD"};

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        Enemy.OnEnemyDeath += SwitchArrows;
        Enemy.OnEnemyDeath += SendCurrentKeyPattern;
    }

    private void SendCurrentKeyPattern(Enemy e)
    {
        playerMovement.movementKeyPattern = currentArrows;
        print("sendcirre");
    }
    public void SwitchArrows(Enemy e)
    {
        int arrowSwitchTypeNum = e.enemyType;
        string arrowSwitchType = arrowSwitchTypes[arrowSwitchTypeNum];
        char firstKey = arrowSwitchType[0];
        char secondKey = arrowSwitchType[1];
        currentArrows = currentArrows.Replace(firstKey, '~').Replace(secondKey, firstKey).Replace('~', secondKey);
        print("switcharrows");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<IEnemy>() == null) { return; }
        Enemy e = collision.collider.GetComponent<Enemy>();
        e.OnHit(3);
    }
}
