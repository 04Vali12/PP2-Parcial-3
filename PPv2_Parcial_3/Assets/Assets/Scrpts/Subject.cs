using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subject", menuName="ScriptableObjects/New_Lesson", order = 1)]

public class Subject : ScriptableObject
{
    //Scriptable Object sirve para crear una leccion la cual hereda informacion y puede ser alterada
    //sin alterar el codigo original

    //Este es el código que se hereda 
    [Header("GameObject Configuration")]
    public int Lesson = 0;
    [Header("Lession Quest Configuration")]
    public List<Leccion> leccionList;
} 
