using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour
{
    public Gun gun;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        text.text = "Bullets -> " + (gun.shotsRemainingInBurst).ToString();
    }
}
