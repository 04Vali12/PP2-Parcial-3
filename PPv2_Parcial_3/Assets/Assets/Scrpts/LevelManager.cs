using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour

{
    public static LevelManager Instance;
    [Header("LevelData")]
    public Subject Lesson;

    [Header("user interface")]
    public TMP_Text textQuestion;
    public List<Option> Options;
    public GameObject CheckButton;


    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string CorrectAnswer;
    public int answerfromPlayer = 9;
    public GameObject AnswerContainer;
    public int currentAnswer;
    public TMP_Text questiongood;
    public Color red;
    public Color green;
    [Header("Current Lesson")]
    public Leccion currentLesson;

   //Singleton que garantiza que una clase solo tenga una instancia
   //y proporciona un punto de acceso 

    private void Awake()
    {
        
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        //Se establece la cantidad de preguntas que hay en la leccion para
        //selecionarlas y actualizarlas
        questionAmount = Lesson.leccionList.Count;
        // se le llama a la funcion para poder comprobar si ya se seleciono una opcion 
        LoadQuestion();
    }

    // Esta funcion carga la siguiente pregunta
    public void LoadQuestion()
    {
        //Asegura que la pregunta este dentro de los limites de la cantidad de preguntas asignadas
        if (currentQuestion < questionAmount)
        {
            currentLesson = Lesson.leccionList[currentQuestion];
            question = currentLesson.lessons;
            CorrectAnswer = currentLesson.options[currentLesson.CorrectAnswer];
            textQuestion.text = question;
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<Option>().OptionID = i;
                Options[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {
            Debug.Log("Fin de las preguntas");
        }
    }
    public void NextQuestion()
    {
        if (CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                
                bool isCorrect = currentLesson.options[answerfromPlayer] == CorrectAnswer;
                AnswerContainer.SetActive(true);
                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Color.green;
                    questiongood.text = "Respuesta Correcta" + ": " + CorrectAnswer;
                }
                else
                {
                    AnswerContainer.GetComponent<Image>().color = red;
                    questiongood.text = "Respuesta Incorrecta" + "Correcta" + ": " + CorrectAnswer;
                }
                currentQuestion++;
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));
               answerfromPlayer = 9;
            }
            else
            {

            }
        }
       
    }
    public void SetPlayerAnswer(int _answer)
    {
        answerfromPlayer = _answer;
    }
    public bool CheckPlayerState()
    {
        
        if (answerfromPlayer != 9)
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.gray;
            return false;
        }
    }
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f);
        AnswerContainer.SetActive(false);
        LoadQuestion();

        CheckPlayerState();
    }

}
