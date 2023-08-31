using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class StoryText : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject panel;
    public string[] sentences;
    private int index = 0;
    public float textSpeed;
    private bool isWriting = false;
    public UnityEvent Function;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isWriting)
        {
            panel.SetActive(true);
            isWriting = true;
            NextText();
        }
    }

    /*private void OnEnable()
    {
        NextText();
    }*/
    private void NextText()
    {
        if (index <= sentences.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            Function?.Invoke();
            panel.SetActive(false);
        }
    }
    IEnumerator WriteSentence()
    {

        foreach (char Character in sentences[index].ToCharArray())
        {
            dialogueText.text += Character;
            yield return new WaitForSeconds(textSpeed);

        }
        index++;
        yield return new WaitForSeconds(0.8f);
        NextText();
    }

    public void HellowWorld()
    {
        print("Ben bir fonksiyonum heehe");
    }

}
