using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMovement playerMovement;
    public Animator playerAnim;
    [Header("Level1")]
    public GameObject levelOneOpener;
    [Header("Level2")]
    public GameObject obstacle;
    public GameObject deadJack;
    public GameObject levelTwoOpener;

    [Header("Level4")]
    public bool canTeleport = false;
    [Header("Level5")]
    public GameObject secondStoryObject;
    [Header("LevelSecretKiller")]
    public GameObject secondStoryBox;
    public GameObject door;
    public GameObject SecretKiller;
    public GameObject knife;
    [Header("LevelGoToFinal")]
    public GameObject SecretKillerForFinal;
    public GameObject JackDead;
    public GameObject farDoor;



    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void Awake()
    {
        MakeInstance();
    }

    public void OpenLevelOneDoor()
    {
        levelOneOpener.transform.DORotate(new Vector3(0, 90, 0), 2f);
    }

    public void OpenLevelTwoDoor()
    {
        obstacle.SetActive(false);
        deadJack.SetActive(false);
        levelTwoOpener.transform.DORotate(new Vector3(0, 90, 0), 2f);
    }

    public void SecondSceneLoader()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void ThirdSceneTeleportOpener()
    {
        canTeleport = true;
    }
    public void SecondStoryPartActivater()
    {
        secondStoryObject.SetActive(true);
    }

    public void SecondStoryPartFinish()
    {
        canTeleport = true;
    }

    public void GoToRick()
    {
        knife.SetActive(false);
        playerMovement.enabled = false;
        playerAnim.SetBool("isWalking", false);
        door.transform.DORotate(new Vector3(0, 90, 0), 1.5f);
        //Vector3(2.25,0,-2.5)
        //Vector3(-0.5,0,-2.3) FiNAL
        //Vector3(0.5,0,-2.3) Mid
        SecretKiller.transform.DOMove(new Vector3(0.5f, 0, -2.3f), 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            SecretKiller.transform.DOMove(new Vector3(-1f, 0, -1.8f), 2f).SetEase(Ease.Linear);
            SecretKiller.transform.DORotate(new Vector3(0, -30, 0), 2.1f).SetEase(Ease.Linear);
        });
        StartCoroutine(WaitForSecretAnim());
    }

    public void BackToReality()
    {

        SceneManager.LoadScene("Scene6");
    }


    IEnumerator WaitForSecretAnim()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Scene4");
    }

    public void KillerKillJack()
    {
        SecretKillerForFinal.GetComponent<Animator>().SetBool("isTriggered", true);
        StartCoroutine(JackDeadAnim());
    }

    IEnumerator JackDeadAnim()
    {
        yield return new WaitForSeconds(1f);
        playerMovement.enabled = false;
        playerAnim.SetBool("isWalking", false);
        JackDead.GetComponent<Animator>().SetBool("isTriggered", true);
        yield return new WaitForSeconds(2.5f);
        SecretKillerForFinal.GetComponent<Animator>().SetBool("isRunning", true);
        SecretKillerForFinal.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        SecretKillerForFinal.transform.DOMove(new Vector3(2.5f, 0, -2.2f), 2.5f).OnComplete(() => SecretKillerForFinal.SetActive(false));
        playerMovement.enabled = true;
        playerAnim.SetBool("isWalking", true);


    }

    public void CloseDoorAfterRun()
    {
        farDoor.transform.DORotate(new Vector3(0, 0, 0), 3.5f);
    }

    public void OpenDoorAfterClose()
    {
        farDoor.transform.DORotate(new Vector3(0, -70, 0), 2f);
        StartCoroutine(AfterDoorOpening());
    }

    IEnumerator AfterDoorOpening()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scene7");
    }

    public void WaitForBloodDiscuss()
    {
        secondStoryBox.SetActive(true);
    }

}
