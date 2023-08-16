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
        [MenuItem("Assets/Mark dirty")]
        [MenuItem("CONTEXT/Transform/Mark dirty")]
        [MenuItem("CONTEXT/GameObject/Mark dirty")]
        [MenuItem("CONTEXT/Object/Mark dirty")]
        public static void MarkDirty(MenuCommand cmd)
        {
            var context = cmd.context;
            var guids = Selection.assetGUIDs;
            Debug.Log(string.Join(", ", guids), context);

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var obj = AssetDatabase.LoadAssetAtPath<Object>(path);
                EditorUtility.SetDirty(obj);
            }
        }
    }
}
