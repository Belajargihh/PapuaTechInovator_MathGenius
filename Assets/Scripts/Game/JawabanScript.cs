using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabanScript : MonoBehaviour
{
    public bool isCorrect= false;
    public QuizManager quizManager;

    public void Jawaban()
    {
        if(isCorrect)
        {
            Debug.Log("Jawaban Benar");
            quizManager.benar();
        }
        else 
        {
            Debug.Log("Jawaban Salah");
            quizManager.salah();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
