using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;

public class BuildToolWindow : EditorWindow
{

    static BuildToolWindow()
    {
        EditorApplication.playModeStateChanged += LoadLastOpenedScene;
    }

    [MenuItem("Tools/Build Tool")]
    public static void ShowWindow()
    {
        GetWindow<BuildToolWindow>("Build Tool");
    }

    private string lastScene;
    private string loadGameScene = "Assets/Scenes/GameMenu.unity";

    void OnGUI()
    {
        if (!Application.isPlaying && GUILayout.Button("Play from start"))
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                SetPlayModeStartScene(loadGameScene);
                EditorApplication.isPlaying = true;
            }
        }

        EditorGUILayout.Space(10);

        if (GUILayout.Button("Build Windows release"))
        {
            BuildGame("Builds/WindowsRelease/GGJ2022.exe", false, BuildTarget.StandaloneWindows64);
        }
        if (GUILayout.Button("Build Windows debug"))
        {
            BuildGame("Builds/WindowsDebug/GGJ2022.exe", true, BuildTarget.StandaloneWindows64);
        }
    }
    void SetPlayModeStartScene(string scenePath)
    {
        SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        if (myWantedStartScene != null)
        {
            EditorSceneManager.playModeStartScene = myWantedStartScene;
        }
        else
        {
            Debug.LogError("Could not find Scene " + scenePath);
        }
    }

    void Update()
    {
        if (!EditorApplication.isPlaying)
        {
            if (!string.IsNullOrEmpty(lastScene))
            {
                EditorSceneManager.OpenScene(lastScene);
                lastScene = null;
            }
        }
    }

    public static bool BuildGame(string path, bool developmentBuild, BuildTarget buildTarget)
    {
        Debug.Log("Building...");

        var report = BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, path, buildTarget, developmentBuild
                ? (BuildOptions.Development | BuildOptions.ConnectWithProfiler)
                : BuildOptions.None);
        var summary = report.summary;

        switch (summary.result)
        {
            case BuildResult.Succeeded:
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
                return true;

            case BuildResult.Failed:
                Debug.Log("Build failed");
                return false;

            default:
                return false;
        }
    }

    private static void LoadLastOpenedScene(PlayModeStateChange playModeStateChange)
    {
        if (playModeStateChange == PlayModeStateChange.EnteredPlayMode)
        {
            EditorSceneManager.playModeStartScene = null;
        }
    }
}
