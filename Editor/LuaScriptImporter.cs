using System.IO;
using UnityEngine;
using UnityEditor;

using UnityEditor.AssetImporters;

namespace PS2k.LuaScriptAssets {
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

        [MenuItem(
#if UNITY_6000_0_OR_NEWER
            "Assets/Create/Scripting/Lua Script"
#else
            "Assets/Create/Lua Script"
#endif
            , false, 80)]
        public static void CreateLuaScript() {
            string assetFileName = "New Lua Script.lua";
            string defaultLuaCode = @"print(""Hello World from Lua!"")" + "\n";
            ProjectWindowUtil.CreateAssetWithContent(assetFileName, defaultLuaCode);
        }
    }
}
