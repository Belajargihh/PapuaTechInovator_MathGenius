using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<Quiz> quiz;
    public GameObject[] options;
    public int currentPertanyaan;

    public GameObject Quizpanel;
    public GameObject Finish;
    public GameObject feedBenar;
    public GameObject feedSalah;


    public Text PertanyaanTxt;
    public  Text ScoreTxt;

    int totalPertanyaan = 0;
    public int score;

    private void Start()
    {
        totalPertanyaan = quiz.Count;
        Finish.SetActive(false);
        generatePertanyaan();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        Finish.SetActive(true);
        ScoreTxt.text = score.ToString();

    }

    public void benar()
    {
        score += 10;
        quiz.RemoveAt(currentPertanyaan);
        generatePertanyaan();
        

        // Aktifkan GameObject feedBenar
        if (feedBenar != null)
        {
            feedBenar.SetActive(true);
            AudioManager.Instance.PlaySFX("Benar");
        }
    }

    public void salah()
    {
        quiz.RemoveAt(currentPertanyaan);
        generatePertanyaan();

        // Aktifkan GameObject feedSalah
        if (feedSalah != null)
        {
            feedSalah.SetActive(true);
            AudioManager.Instance.PlaySFX("Salah");
        }
    }

    void SetJawaban()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<JawabanScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = quiz[currentPertanyaan].Jawaban[i];

            if(quiz[currentPertanyaan].CorrectPertanyaan == i+1)
            {
                options[i].GetComponent<JawabanScript>().isCorrect = true;
            }
        }
    }
    void generatePertanyaan()
    {
        // Menonaktifkan GameObject feedBenar dan feedSalah
        if (feedBenar != null)
        {
            feedBenar.SetActive(false);
        }

        if (feedSalah != null)
        {
            feedSalah.SetActive(false);
        }

        if(quiz.Count > 0)
        {
            currentPertanyaan = Random.Range(0, quiz.Count);

            PertanyaanTxt.text = quiz[currentPertanyaan].Pertanyaan;
            SetJawaban();
        }
        else
        {
            Debug.Log("Out ot Question");
            GameOver();
        }

    }
}
