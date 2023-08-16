//----------------------------------------
// MIT License
// Copyright(c) 2023 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Lumpn.Versioning
{
    public static class AssetUtils
    {
        [MenuItem("Utils/Versioning/Mark dirty (selected files)")]
        public static void MarkDirty()
        {
            var guids = Selection.assetGUIDs;
            Debug.Log(string.Join(", ", guids));

            foreach(var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var obj = AssetDatabase.LoadAssetAtPath<Object>(path);
                EditorUtility.SetDirty(obj);
            }
        }
    }
}
