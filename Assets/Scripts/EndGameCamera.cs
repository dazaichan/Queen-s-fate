using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameCamera : MonoBehaviour
{
    public GameObject back, replay, exit;
    public Texture[] playerTexts;
    public RawImage winnerText;
    public AudioSource winAudio;

    private int winner;
    void Start()
    {
        winner = PlayerPrefs.GetInt("winner");
        Debug.Log(winner);
        if (winner == 0 || winner == 1)
        {
            winnerText.texture = playerTexts[0];
        }
        else
            winnerText.texture = playerTexts[1];

        StartCoroutine(ZoomCamera(Camera.main, -3.2f, 2f));
        StartCoroutine(GameRestart(2f));
        StartCoroutine(PlayWinAudio(0.4f));

    }

    public IEnumerator ZoomCamera(Camera cam, float goal, float time)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        float start = cam.transform.position.z;
        Debug.Log(cam.transform.position.z);
        float timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, Mathf.Lerp(start, goal, timer / time));
            yield return null;
        }
        //cam.fieldOfView = goal;
        watch.Stop();
        float elapsedMs = watch.ElapsedMilliseconds;
    }

    public IEnumerator GameRestart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        back.SetActive(true);
        replay.SetActive(true);
        exit.SetActive(true);
    }

    public IEnumerator PlayWinAudio(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        winAudio.Play();
    }
}
