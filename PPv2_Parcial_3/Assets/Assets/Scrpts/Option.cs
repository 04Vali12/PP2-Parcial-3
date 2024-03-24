using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    // El componente TMP ayuda a actualizar el texto que tiene
    // la pregunta en el ScriptableObject
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Esta funcion Actualiza el texto
    public void UpdateText()
    {
        //El componente  Children que contiene el Texto que se actualizará
        //al que ya está asignado en el ScriptableObject
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }
    //Esta Funcion comprueba que se seleccione una opcion y se llama a dos funciones
    // del LevelManager
    public void selectOption()
    {
        //Se asigna la respuesta correcta al ID que se encuentra en el Level manager 
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        // comprueba si el levelmanager selecciono una respuesta 
        LevelManager.Instance.CheckPlayerState();
    }
}

