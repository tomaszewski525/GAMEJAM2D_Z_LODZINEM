using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerArrowSwitch : MonoBehaviour
{

    public string currentArrows = "UDLR";
    public string[] arrowSwitchTypes = {"LR", "LU", "LD", "UD", "UR", "RD"};
    public void SwitchArrows(string arrowSwitchType)
    {
        char firstKey = arrowSwitchType[0];
        char secondKey = arrowSwitchType[1];
        currentArrows = currentArrows.Replace(firstKey, '~').Replace(secondKey, firstKey).Replace('~', secondKey);
    }

}
