using UnityEngine;
using UnityEditor;

public class AssetRefresh : MonoBehaviour
{
    public static void Refresh()
    {
        AssetDatabase.Refresh();
    }
}
