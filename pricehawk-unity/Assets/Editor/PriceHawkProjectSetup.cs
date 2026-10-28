#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

/// <summary>Creates and registers the empty scene needed to run/build the auto-bootstrapped app.</summary>
[InitializeOnLoad]
internal static class PriceHawkProjectSetup
{
    private const string ScenePath = "Assets/Scenes/PriceHawk.unity";

    static PriceHawkProjectSetup()
    {
        EditorApplication.delayCall += EnsureStartupScene;
    }

    private static void EnsureStartupScene()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isCompiling)
        {
            EditorApplication.delayCall += EnsureStartupScene;
            return;
        }

        Directory.CreateDirectory(Path.Combine(Application.dataPath, "Scenes"));
        if (!File.Exists(Path.Combine(Application.dataPath, "Scenes", "PriceHawk.unity")))
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            EditorSceneManager.SaveScene(scene, ScenePath);
        }

        var scenes = EditorBuildSettings.scenes;
        foreach (var entry in scenes)
        {
            if (entry.path == ScenePath && entry.enabled)
                return;
        }

        var updated = new EditorBuildSettingsScene[scenes.Length + 1];
        scenes.CopyTo(updated, 0);
        updated[scenes.Length] = new EditorBuildSettingsScene(ScenePath, true);
        EditorBuildSettings.scenes = updated;
    }
}
#endif
