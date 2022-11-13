using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UI : MonoBehaviour
{
    public Transform[] KeysUI;
    public Transform[] HeartUI;
    public Sprite emptyHeart;
    public PlayerMovement playerM;
    public Player player;

    public Color from;
    public Color to;
    public float colorDuration;
    int index = 4;

    string[] arrowSwitchTypes = { "WS", "AD", "AW", "DW", "AS", "SD" };
    private void Awake()
    {
        Enemy.OnEnemyDeath += SwapUI;
        Player.OnPlayerHit += LoseHeart;
    }

    void LoseHeart()
    {
        HeartUI[index].GetComponent<SpriteRenderer>().sprite = emptyHeart;
        index--;
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
        StartCoroutine(FlashUI(f));
        StartCoroutine(FlashUI(s));
    }

   IEnumerator FlashUI(GameObject go)
    {
        float t = 0f;
        SpriteRenderer ren = go.GetComponent<SpriteRenderer>();
        while (t < colorDuration)
        { 
            t += Time.deltaTime;
            ren.color = Color.Lerp(from, to, t/colorDuration);
            yield return null;
        }
    }
}
