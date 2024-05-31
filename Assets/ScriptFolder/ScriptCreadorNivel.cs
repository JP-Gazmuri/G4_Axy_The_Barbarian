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
                    if (parts.Length == 3)
                    {
                        string type = parts[0];
                        if (float.TryParse(parts[1], out float x) && float.TryParse(parts[2], out float y))
                        {
                            Vector2 position = new Vector2(x, y);
                            FabricaObjetos.CrearObjeto(type, position);
                        }
                        else
                        {
                            Debug.LogError("Posicion invalida en linea: " + line);
                        }
                    }
                    else
                    {
                        Debug.LogError("Esquema mal hecho en la linea: " + line);
                    }
                }
            }
            else
            {
                Debug.LogError("No esta el archivo en la carpeta adecuada: " + filePath);
            }
        }

    }
