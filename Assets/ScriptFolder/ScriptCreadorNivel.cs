using System.IO;
using UnityEngine;

public class ScriptCreadorNivel : MonoBehaviour
{
    public string EsquemaNivel;
    public ScriptFabricaObjetos FabricaObjetos;

    void Start()
    {
        CargarNivel();
    }

    void CargarNivel()
    {
        string filePath = Path.Combine(Application.dataPath, "Niveles", EsquemaNivel);
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length == 4)
                {
                    string type = parts[0];
                    if (float.TryParse(parts[1], out float x) && float.TryParse(parts[2], out float y) && float.TryParse(parts[3], out float rotation))
                    {
                        Vector2 position = new Vector2(x, y);
                        Quaternion rotationQuaternion = Quaternion.Euler(0f, 0f, rotation);
                        FabricaObjetos.CrearObjeto(type, position, rotationQuaternion);
                    }
                    else
                    {
                        Debug.LogError("Valores inválidos en la línea: " + line);
                    }
                }
                else
                {
                    Debug.LogError("Esquema mal hecho en la línea: " + line);
                }
            }
        }
        else
        {
            Debug.LogError("El archivo no se encuentra en la carpeta adecuada: " + filePath);
        }
    }
}

