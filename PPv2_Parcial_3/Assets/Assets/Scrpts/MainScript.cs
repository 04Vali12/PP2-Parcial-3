using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
        public static MainScript instance;
        public string selectedLesson = "dummy"; // Cambiado el nombre de la variable

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

        public void SetSelectedLesson(string lesson) // Cambiado el nombre de la funci�n
        {
            selectedLesson = lesson;
            PlayerPrefs.SetString("SelectedLesson", selectedLesson); // Corregido PlayerPREFS a PlayerPrefs
        }

        public void BeginGame()
        {
            SceneManager.LoadScene("Leccion 1");
        }
    public void BeginGame2()
    {
        SceneManager.LoadScene("PantallaInicio");
    }
}