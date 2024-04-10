using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
        public static MainScript instance;
        public string selectedLessonValue = "dummy"; // Cambiado el nombre de la variable

        private void Awake()
        {
            if (instance != null)
            {
                return;
            }
            else
            {
                instance = this;
            }
        }

        public void SetSelectedLesson(string lesson) // Cambiado el nombre de la función
        {
            selectedLessonValue = lesson;
            PlayerPrefs.SetString("SelectedLesson", selectedLessonValue); // Corregido PlayerPREFS a PlayerPrefs
        }

        public void BeginGame()
        {
            SceneManager.LoadScene("Lesson");
        }
}