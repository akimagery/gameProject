using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_System : MonoBehaviour
{
    public string[] Dialogue_Texts;
    public Text Dialogue_Text;
    public Text Speaker_Name_Text;

    private bool _dont_show_answers = false;

    public int Action = 0;

    public GameObject Dialogue_Panel;

    public float charactersPerSecond = 15;

    private string[] texts = new string[4];

    public GameObject[] Answers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Action = 0;
        if(collision.transform.tag == "Player")
        {
            Dialogue_Panel.SetActive(true);
            StartCoroutine(TypeTextUncapped(Dialogue_Texts[0], "Эмили"));
            texts[0] = "Привет";
            texts[1] = "Пока";
            SetCountAnswers(texts);
            _dont_show_answers = false;
            Action++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            StopAllCoroutines();
            Dialogue_Panel.SetActive(false);
            texts[0] = "";
            texts[1] = "";
            texts[2] = "";
            texts[3] = "";
            SetCountAnswers(null);
            _dont_show_answers = false;
        }
    }

    public void OnClickAnswerTest(int ID)
    {
        if (Answers[ID].GetComponentInChildren<Text>().text == "Привет")
        {
            StartCoroutine(TypeTextUncapped(Dialogue_Texts[1], "Эмили"));
            texts[0] = "Хорошо";
            texts[1] = "Пока";
            SetCountAnswers(texts);
            _dont_show_answers = false;
            Action++;
        }
        else if (Answers[ID].GetComponentInChildren<Text>().text == "Пока")
        {
            StartCoroutine(TypeTextUncapped(Dialogue_Texts[2], "Эмили"));
            SetCountAnswers(texts);
            _dont_show_answers = true;
            Action++;
        }
        else if (Answers[ID].GetComponentInChildren<Text>().text == "Хорошо")
        {
            StartCoroutine(TypeTextUncapped(Dialogue_Texts[3], "Эмили"));
            SetCountAnswers(null);
            _dont_show_answers = true;
            Action++;
        }
    }

    private void SetCountAnswers(string[] answers)
    {
        if(answers != null)
        {
            for (int i = 0; i < 2; i++)
            {
                Answers[i].GetComponentInChildren<Text>().text = answers[i];
            }
        }
        else if(answers == null)
        {
            for (int i = 0; i < 2; i++)
            {
                Answers[i].SetActive(false);
            }
        }
    }

    private IEnumerator TypeTextUncapped(string line, string speakerName)
    {
        Speaker_Name_Text.text = speakerName;
        float timer = 0;
        float interval = 1 / charactersPerSecond;
        string textBuffer = null;
        char[] chars = line.ToCharArray();
        int i = 0;

        while (i < chars.Length)
        {
            Answers[0].SetActive(false);
            Answers[1].SetActive(false);
            if (timer < Time.deltaTime)
            {
                textBuffer += chars[i];
                Dialogue_Text.text = textBuffer;
                timer += interval;
                i++;
            }
            else
            {
                timer -= Time.deltaTime;
                yield return null;
            }
        }
        if (i >= chars.Length && _dont_show_answers == false)
        {
            Answers[0].SetActive(true);
            Answers[1].SetActive(true);
        }
    }
}
