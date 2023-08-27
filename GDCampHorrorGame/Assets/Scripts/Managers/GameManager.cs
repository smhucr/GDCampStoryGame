using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject levelOneOpener;

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


}
