using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Editor utility to create a placeholder MainShop scene with required GameObjects
public static class CreateMainShopScene
{
    [MenuItem("Locadora/Create MainShop Scene")]
    public static void CreateScene()
    {
        // Create new scene with default objects
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        // Main Camera
        var camGO = new GameObject("Main Camera", typeof(Camera));
        var cam = camGO.GetComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = 5f;
        camGO.transform.position = new Vector3(0f, 0f, -10f);
        camGO.tag = "MainCamera";

        // Add CameraController if available
        var script = UnityEditor.AssetDatabase.LoadAssetAtPath<MonoScript>("Assets/Scripts/Managers/CameraController.cs");
        if (script != null && script.GetClass() != null)
        {
            camGO.AddComponent(script.GetClass());
        }

        // Managers root
        var managers = new GameObject("Managers");
        // Add InventoryManager if available
        var invScript = UnityEditor.AssetDatabase.LoadAssetAtPath<MonoScript>("Assets/Scripts/Managers/InventoryManager.cs");
        if (invScript != null && invScript.GetClass() != null)
        {
            managers.AddComponent(invScript.GetClass());
        }

        // Environment root (placeholders for shelves and consoles)
        var env = new GameObject("Environment");
        var shelves = new GameObject("Shelves");
        shelves.transform.SetParent(env.transform);
        var consoles = new GameObject("Consoles");
        consoles.transform.SetParent(env.transform);

        // HUD root
        var hud = new GameObject("HUD");

        // Save scene to Assets/Scenes/MainShop.unity
        System.IO.Directory.CreateDirectory("Assets/Scenes");
        var scenePath = "Assets/Scenes/MainShop.unity";
        EditorSceneManager.SaveScene(scene, scenePath);
        AssetDatabase.Refresh();
        Debug.Log($"MainShop scene created at {scenePath}");

        // Focus Project window on scene
        var obj = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        Selection.activeObject = obj;
    }
}
