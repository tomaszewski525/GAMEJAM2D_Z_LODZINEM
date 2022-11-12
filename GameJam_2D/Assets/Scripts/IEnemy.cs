using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public void Move();
    public void Shoot();
    public void SetEnemyType();
}
