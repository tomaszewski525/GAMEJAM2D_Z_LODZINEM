using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerArrowSwitch : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public string currentArrows = "WSAD";
    public string[] arrowSwitchTypes = {"WS", "AD", "AW", "DW", "AS", "SD"};

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        Enemy.OnEnemyDeath += SwitchArrows;
        Enemy.OnEnemyDeath += SendCurrentKeyPattern;
    }

    private void SendCurrentKeyPattern(Enemy e)
    {
        playerMovement.movementKeyPattern = currentArrows;
    }
    public void SwitchArrows(Enemy e)
    {
        int arrowSwitchTypeNum = e.enemyType;
        string arrowSwitchType = arrowSwitchTypes[arrowSwitchTypeNum];
        char firstKey = arrowSwitchType[0];
        char secondKey = arrowSwitchType[1];
        currentArrows = currentArrows.Replace(firstKey, '~').Replace(secondKey, firstKey).Replace('~', secondKey);
    }
}
