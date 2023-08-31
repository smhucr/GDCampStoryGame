using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class FinalStory : MonoBehaviour
{
    public CameraController cameraController;
    public GameObject[] spotLights;
    public GameObject[] redSpotLights;
    public GameObject[] mainCharacters;
    public GameObject[] sideCharacters;
    public GameObject knife;
    public GameObject choosePanel;
    public GameObject mainPlayableCharacterCamera;
    public Image blackScreen;
    public GameObject gameOverText;

    private void Start()
    {
        StartCoroutine(OpenSpotLightsBeforeChoosing());
    }

    IEnumerator OpenSpotLightsBeforeChoosing()
    {
        yield return new WaitForSeconds(5f);
        spotLights[0].SetActive(true);
        yield return new WaitForSeconds(3f);
        spotLights[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        spotLights[2].SetActive(true);
        yield return new WaitForSeconds(5f);
        choosePanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        cameraController.enabled = false;
    }

    public void ContinueStory()
    {
        StartCoroutine(AfterSelect());
    }

    IEnumerator AfterSelect()
    {
        cameraController.enabled = true;
        choosePanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(5f);
        spotLights[0].SetActive(false);
        yield return new WaitForSeconds(3f);
        spotLights[1].SetActive(false);
        yield return new WaitForSeconds(3f);
        spotLights[2].SetActive(false);
        yield return new WaitForSeconds(4f);
        yield return new WaitForSeconds(1f);
        sideCharacters[0].SetActive(false);
        redSpotLights[0].SetActive(true);
        mainCharacters[0].SetActive(true);
        yield return new WaitForSeconds(3f);
        sideCharacters[1].SetActive(false);
        redSpotLights[1].SetActive(true);
        mainCharacters[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        sideCharacters[2].SetActive(false);
        redSpotLights[2].SetActive(true);
        mainCharacters[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        redSpotLights[3].SetActive(true);
        knife.SetActive(false);
        cameraController.enabled = false;
        yield return new WaitForSeconds(3f);
        mainPlayableCharacterCamera.transform.DOLocalRotate(new Vector3(80, 0, 0), 4);
        yield return new WaitForSeconds(4.5f);
        redSpotLights[3].SetActive(true);
        knife.SetActive(true);
        yield return new WaitForSeconds(1);
        spotLights[3].SetActive(true);
        redSpotLights[3].SetActive(false);
        knife.SetActive(false);
        yield return new WaitForSeconds(1);
        spotLights[3].SetActive(false);
        redSpotLights[3].SetActive(true);
        knife.SetActive(true);
        yield return new WaitForSeconds(1);
        spotLights[3].SetActive(true);
        redSpotLights[3].SetActive(false);
        knife.SetActive(false);
        yield return new WaitForSeconds(1);
        spotLights[3].SetActive(false);
        redSpotLights[3].SetActive(true);
        knife.SetActive(true);
        blackScreen.DOFade(1, 7).SetEase(Ease.Linear);
        yield return new WaitForSeconds(7.5f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }


}
