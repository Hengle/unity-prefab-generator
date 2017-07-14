using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using System.IO;

public class FontChange
{
    [MenuItem("Tools/一键替换所有字体")]
    private static void ReplaceText()
    {
        var fileID = "10102";
        var guid = "0000000000000000e000000000000000";
        var type = 0;
        var pattern = "m_Font: {fileID: [0-9]+, guid: [0-9a-z]{32}, type: [0-9]+}";
        var replacement = "m_Font: {fileID: " + fileID + ", guid: " + guid + ", type: " + type + "}";
        var assets = AssetDatabase.FindAssets("t:Prefab t:SceneAsset");
        for (var i = 0; i < assets.Length; i++)
        {
            var assetPath = AssetDatabase.GUIDToAssetPath(assets[i]);
            EditorUtility.DisplayProgressBar("Hold on", assetPath, 1.0f * i / assets.Length);
            var input = File.ReadAllText(assetPath); var contents =
                Regex.Replace(input, pattern, replacement);
            File.WriteAllText(assetPath, contents);
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
    }
}
