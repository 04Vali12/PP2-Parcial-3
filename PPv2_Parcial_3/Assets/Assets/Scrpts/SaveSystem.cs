using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;
    public Subject data;
    public SubjectContainer subject;

    private void Awake()
    {
        // Verifica si ya existe una instancia de SaveSystem
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this; // Asigna esta instancia como la instancia única
        }
        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectedLesson"));
    }
    private void Start()
    {
        //SaveToJSON("LeccionCompleta.json", data);
    }

    /// <summary>
    /// Guarda los datos en formato JSON en un archivo.
    /// </summary>
    /// <param name="_fileName">Nombre del archivo.</param>
    /// <param name="_data">Datos a guardar.</param>
    public void SaveToJSON(string _fileName, object _data)
    {
        if (_data != null)
        {
            // Convierte los datos a formato JSON
            string JSONData = JsonUtility.ToJson(_data,true);

            // Verifica si los datos en formato JSON no están vacíos
            if (JSONData.Length != 0)
            {
                Debug.Log("JSON String: " + JSONData);
                string fileName = _fileName + ".json"; // Agrega la extensión ".json" al nombre del archivo
                string filePath = Path.Combine(Application.dataPath + "/Resources/JSONS/", fileName);
                // Escribe los datos en el archivo
                File.WriteAllText(filePath, JSONData);
                Debug.Log("JSON almacenado en la direccion: " + filePath);

            }
            else
            {
                Debug.LogWarning("ERROR - SaveSystem: JSONData is empty");
            }
        }
        else
        {
            Debug.LogWarning("ERROR - SaveSystem: _data is null, check for param [object _data]");
        }
    }

    /// <summary>
    /// Carga los datos desde un archivo JSON.
    /// </summary>
    /// <typeparam name="T">Tipo de datos a cargar.</typeparam>
    /// <param name="_fileName">Nombre del archivo.</param>
    /// <returns>Datos cargados.</returns>
    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        T data = new T(); // Crea una nueva instancia de los datos a cargar
        string path = Path.Combine(Application.dataPath+ "/Resources/jsons/"+ _fileName + ".json");

        string JSON_data = "";

        if (File.Exists(path))
        {
            // Lee los datos del archivo JSON
             JSON_data = File.ReadAllText(path);
            Debug.Log("JSON STRING: " + JSON_data);

            // Verifica si los datos en formato JSON no están vacíos
            if (JSON_data.Length != 0)
            {
                // Sobrescribe los datos con los datos cargados desde JSON
                JsonUtility.FromJsonOverwrite(JSON_data, data);
            }
            else
            {
                Debug.LogWarning("ERROR - SaveSystem: JSONData is empty, check for local variable [string JSONData]");
            }
        }
        else
        {
            Debug.LogWarning("ERROR - SaveSystem: File not found at path: " + path);
        }

        return data; // Devuelve los datos cargados
    }
}