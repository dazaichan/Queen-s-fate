using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    [SerializeField]
    private GameObject[] characters2;
    private GameObject currentCharacter;
    private GameObject currentCharacter2;
    Animator charAnim;
    Animator charAnim2;
    private int characterIndex;
    private int characterIndex2;
    [SerializeField]
    Button yuraBtn, tamachiBtn;
    [SerializeField]
    Button yuraBtn2, tamachiBtn2;
    [SerializeField]
    Button start1, start2;
    bool player1Locked, player2Locked;

    private void Start()
    {
        characterIndex = 0;
        characterIndex2 = 0;
        currentCharacter = characters[characterIndex];
        currentCharacter2 = characters2[characterIndex2];
        player1Locked = false;
        player2Locked = false;
    }

    private void Update()
    {
        PlayAnimation();
    }
    public void ChangeCharacter(int index)
    {
        for(int i =0; i<characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
        characters[index].SetActive(true);
        currentCharacter = characters[index];
        characterIndex = index;
    }

    public void ChangeCharacter2(int index)
    {
        for (int i = 0; i < characters2.Length; i++)
        {
            characters2[i].SetActive(false);
        }
        characters2[index].SetActive(true);
        currentCharacter2 = characters2[index];
        characterIndex2 = index;
    }

    public void LockChar1()
    {
        yuraBtn.interactable = false;
        tamachiBtn.interactable = false;
        start1.gameObject.SetActive(false);
        player1Locked = true;
    }

    public void LockChar2()
    {
        yuraBtn2.interactable = false;
        tamachiBtn2.interactable = false;
        start2.gameObject.SetActive(false);
        player2Locked = true;
    }

    public void PlayAnimation()
    {
        if (player1Locked && player2Locked)
        {
            player1Locked = false;
            player2Locked = false;
            charAnim = currentCharacter.GetComponent<Animator>();
            charAnim.SetBool("CharSelected", true);
            charAnim2 = currentCharacter2.GetComponent<Animator>();
            charAnim2.SetBool("CharSelected", true);
            StartCoroutine(ZoomCamera(Camera.main, 1.5f,-1.55f, 0.16f, 6.3f, 2f));
            StartCoroutine(GameStart(2f));
        }
    }

    public IEnumerator ZoomCamera(Camera cam, float goal, float char1X, float char2X, float goalHeight, float time)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        float start = cam.orthographicSize;
        float heightStart = cam.transform.position.y;
        float char1Start = currentCharacter.transform.localPosition.x;
        float char2Start = currentCharacter2.transform.localPosition.x;
        Debug.Log(char1Start);
        Debug.Log(char2Start);
        float timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(start, goal, timer / time);
            cam.transform.position = new Vector3(cam.transform.position.x, 
                Mathf.Lerp(heightStart, goalHeight, timer / time), cam.transform.position.z);
            currentCharacter.transform.localPosition = new Vector3(Mathf.Lerp(char1Start, char1X, timer / time),
                                                    currentCharacter.transform.localPosition.y, currentCharacter.transform.localPosition.z);
            currentCharacter2.transform.localPosition = new Vector3(Mathf.Lerp(char2Start, char2X, timer / time),
                                                    currentCharacter2.transform.localPosition.y, currentCharacter2.transform.localPosition.z);
            yield return null;
        }
        cam.fieldOfView = goal;
        watch.Stop();
        float elapsedMs = watch.ElapsedMilliseconds;
        Debug.Log("Seconds Wanted: " + time);
        Debug.Log("Seconds Took: " + elapsedMs / 1000);
    }

    public IEnumerator GameStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PlayerPrefs.SetInt("characterSelected", characterIndex);
        PlayerPrefs.SetInt("characterSelectedPlayer2", characterIndex2);
        SceneManager.LoadScene("MapSelection");
    }

}
