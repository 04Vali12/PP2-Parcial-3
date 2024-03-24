using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLessions = 0;
    public bool AreaAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject LessonData;

    public void Start()
    {
        // Esta línea comprueba si LevelContainer no es nula 

        if (lessonContainer != null)
        {
            //El metodo OnUpdateUI se encarga de actualizar el HUD del juego relacionado con la leccion 
            OnUpdateUI();
        }
        else
        {
            //Debug.LogWarning emite una advertencia indicando que un GameObject es nulo
            Debug.LogWarning("GameObject nulo, revisa las variables del tipo GameObject LessonContainer");
        }
    }

    //Este metodo actualiza en el menu el texto que indica el lesson

    public void OnUpdateUI()
    {
        // Esta línea comprueba si StageTitle o LessonStage son nulos 
        if(StageTitle != null || LessonStage != null)
        {
            //Esta arreglo Actualiza el texto, asi se indica en que leccion se encuentra el usuario
            StageTitle.text = "leccion" + Lection;
            LessonStage.text = "Leccion " + CurrentLession + "de" + TotalLessions;

        }
        else
        {
            //Se menadara un avizo de que no se han asignado los objetos en sus slots correspondientes 
       
            Debug.LogWarning("GameObject nulo, revisa las variables del tipo TMP_Text");
        }
    }
    // Con este metodo se activa o desactiva la ventana de LevelContainer 
    public void EnableWindow()
    {
        OnUpdateUI();

        if (lessonContainer.activeSelf)
        {
            //Se desactiva el objeto si está activado 
            lessonContainer.SetActive(false);
        }
        else
        {
            //Activa el objeto si este esta desactivado
            lessonContainer.SetActive(true);
        }
    }
}
