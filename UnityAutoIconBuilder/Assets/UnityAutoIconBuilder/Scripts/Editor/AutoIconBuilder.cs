using NUnit.Framework;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;

public class AutoIconBuilder : IPreprocessBuildWithReport
{
    const string tmpIconPath = "UnityAutoIconBuilder/Generated/tmpIcon.png";
    const string configImagePrefabPath = "Assets/UnityAutoIconBuilder/Res/ConfigrationImageGenSystem.prefab";

    public int callbackOrder
    {
        get
        {
            return 0;
        }
    }

    public void OnPreprocessBuild(BuildReport report)
    {
        GenerateConfigrationImage();
    }

    public static void GenerateConfigrationImage()
    {
        // Icon を生成。まずは元となるPrefabを読みこんでその中身を変える
        var iconGenPrefab = AssetDatabase.LoadAssetAtPath<GenSystemPrefab>(configImagePrefabPath);
        var iconGen = Object.Instantiate(iconGenPrefab);

        // バージョン番号
        string verStr = string.Format(iconGen.VersionFormat, Application.version);
        iconGen.Version.text = verStr;

        // RenderTexture に焼き込んだ画像をTexture2Dにする
        Camera camera = iconGen.Camera;
        camera.Render();
        RenderTexture original = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;
        Texture2D newTexture = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        newTexture.ReadPixels(new Rect(0, 0, newTexture.width, newTexture.height), 0, 0);
        newTexture.Apply();

        // いったんオリジナルアイコンとしてpngとして吐く
        byte[] bytes = newTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/" + tmpIconPath, bytes);
        AssetDatabase.Refresh();
        Texture2D newIconImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/" + tmpIconPath);

        // できたTexture2Dをアイコンにセットする
        SetConfigrationImage(newIconImage);

        // 後片付け
        Object.DestroyImmediate(newTexture);
        Object.DestroyImmediate(iconGen.gameObject);

        AssetDatabase.Refresh();
    }

    private static void SetConfigrationImage(Texture2D originalIcon)
    {
        PlayerSettings.resolutionDialogBanner = originalIcon;
    }
}
