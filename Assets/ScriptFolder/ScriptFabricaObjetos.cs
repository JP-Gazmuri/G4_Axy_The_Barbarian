using UnityEngine;

public class ScriptFabricaObjetos : MonoBehaviour
{
    public GameObject WallPrefab;
    public GameObject ExitPrefab;
    public GameObject WinPrefab;
    public GameObject BlindGazerPrefab;
    public GameObject DrunkSkeletonPrefab;
    public GameObject MainCharacterPrefab;
    public Transform parentObject;

    public GameObject CrearObjeto(string type, Vector2 position, Quaternion rotation)
    {
        GameObject prefab = null;
        switch (type.ToLower())
        {
            case "wall":
                prefab = WallPrefab;
                break;
            case "maincharacter":
                prefab = MainCharacterPrefab;
                break;
            case "drunkskeleton":
                prefab = DrunkSkeletonPrefab;
                break;
            case "win":
                prefab = WinPrefab;
                break;
            case "blindgazer":
                prefab = BlindGazerPrefab;
                break;
            case "exit":
                prefab = ExitPrefab;
                break;
            default:
                Debug.LogError("Unknown object type: " + type);
                break;
        }

        if (prefab != null)
        {
            return Instantiate(prefab, position, rotation, parentObject);
        }

        return null;
    }
}

