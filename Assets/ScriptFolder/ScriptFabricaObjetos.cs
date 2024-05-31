using UnityEngine;

public class ScriptFabricaObjetos : MonoBehaviour
{
    public GameObject WallPrefab;
    public GameObject ExitPrefab;
    public GameObject WinPrefab;
    public GameObject BlindGazerPrefab;
    public GameObject DrunkSkeletonPrefab;
    public GameObject MainCharacterPrefab;

    public GameObject CrearObjeto(string type, Vector2 position)
    {
        GameObject prefab = null;
        switch (type)
        {
            case "wall":
                prefab = WallPrefab;
                break;
            case "MainCharacter":
                prefab = MainCharacterPrefab;
                break;
            case "DrunkSkeleton":
                prefab = DrunkSkeletonPrefab;
                break;
            case "win":
                prefab = WinPrefab;
                break;
            case "BlindGazer":
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
            return Instantiate(prefab, position, Quaternion.identity);
        }

        return null;
    }
}
