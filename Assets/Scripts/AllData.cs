using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllData : MonoBehaviour
{
    public Text dataQuiz;

    private AnswerButton hasilJawaban;
    private GameController soal;
    private QuestionData[] questionPool;

    private int indexQuiz;

    // Start is called before the first frame update
    void Start()
    {
        hasilJawaban = FindObjectOfType<AnswerButton>();
        soal = FindObjectOfType<GameController>();
    }

    private void ShowQuestion()
    {
        QuestionData questionData = questionPool[indexQuiz];
        dataQuiz.text = questionData.questionText;
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
