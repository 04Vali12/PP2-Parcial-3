using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    public string SelectedLesson = dummy;
    // Start is called before the first frame update
    private void Awake ()
    {
        if (instance != null)
        {
            return;
        }
        else;
        {
            instance = this;
        }
    }

    
    public void SelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        PlayerPREFS.SetString("SelectedLesson", SelectedLesson);
    }
    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson"); 
    }
}
