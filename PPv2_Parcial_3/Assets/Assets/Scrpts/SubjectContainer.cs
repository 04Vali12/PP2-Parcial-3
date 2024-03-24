using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubjectContainer 
{
    [Header("GameObject configuration")]
    [SerializeField]
    public int lesson = 0;
    [Header("Lesson Quest Configuration")]
    [SerializeField]
    public List<Leccion> leccionList;
}
