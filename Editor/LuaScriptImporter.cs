using System.IO;
using UnityEngine;
using UnityEditor;

#if UNITY_2020_1_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif

namespace LuaScriptsSupportEditor {
    /// <summary>
    /// A custom scripted importer that handles importing ".lua" files as text assets.
    /// </summary>
    [ScriptedImporter(1, "lua")]
    public class LuaScriptImporter : ScriptedImporter {
        [SerializeField] private TextAsset luaScript;

        public override void OnImportAsset(AssetImportContext ctx) {
            string fileText = File.ReadAllText(ctx.assetPath);
            luaScript = new TextAsset(fileText);

            Texture2D icon = Resources.Load<Texture2D>("Editor/Icons/LuaScript Icon");
            ctx.AddObjectToAsset("Lua Script", luaScript, icon);
            ctx.SetMainObject(luaScript);
        }

        [MenuItem("Assets/Create/Lua Script", false, 80)]
        public static void CreateLuaScript() {
            string assetFileName = "New Lua Script.lua";
            string defaultLuaCode = @"print(""Hello World from Lua!"")" + "\n";
            ProjectWindowUtil.CreateAssetWithContent(assetFileName, defaultLuaCode);
        }
    }
}
