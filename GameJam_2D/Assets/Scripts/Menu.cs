using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public delegate void OnPressPlay(Menu e);
    public static event OnPressPlay pressPlay;

    public Text[] texts;
    public float time;
    public Color to;
    public GameObject panel;
    public Text[] endScene;
    public Color endScreneFrom;
    public Color endScreneTo;
    public AudioClip backing;

    bool finish;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play();
            pressPlay?.Invoke(this);

        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && finish)
        {
            Reload();
        }
    }

    void Reload()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Start()
    {
        Player.OnPlayerDeath += EndScene;
        Player.OnPlayerDeath += Final;
    }

    void Final()
    {
        finish = true;
    }

    void EndScene()
    {
        StartCoroutine(SlowTime());
        StartCoroutine(ShowEndScrene(endScene[0]));
        StartCoroutine(ShowEndScrene(endScene[1]));
    }

    IEnumerator ShowEndScrene(Text te)
    {
        float t = 0f;
        while (t < 2)
        {
            t += Time.deltaTime;
            te.color = Color.Lerp(endScreneFrom, endScreneTo, t / time);
            yield return null;
        }
        yield return null;
    }
    IEnumerator SlowTime()
    {
        float t = 0f;
        while (t < 2)
        {
            t += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(1, 0, t / time);
            yield return null;
        }
    }

    void Play()
    {
        StartCoroutine(UnFadeScreen());
        for (int i = 0; i < texts.Length; i++)
        {
            GetComponent<AudioSource>().PlayOneShot(backing);
            StartCoroutine(FadeText(texts[i]));
        }
    }

    IEnumerator FadeText(Text text)
    {
        float t = 0f;
        Color initialA = text.color;
        while (t < time)
        {
            t += Time.deltaTime;
            text.color = Color.Lerp(initialA, to, t / time);
            yield return null;
        }
    }

    IEnumerator UnFadeScreen()
    {
        float t = 0f;
        Image image = panel.GetComponent<Image>();
        Color initialA = image.color;
        while (t < time)
        {
            t += Time.deltaTime;
            image.color = Color.Lerp(initialA, to, t / time);
            yield return null;
        }
    }

    void Quit()
    {
        Application.Quit();
    }
}
