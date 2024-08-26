using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;

namespace Juant0Tools
{
    public static class SetupProject
    {
        [MenuItem("Tools/Setup/CreateFolders")]
        public static void CreateDefaultFolders()
        {
            FolderUtility.CreateDeafault("Project", "Animation", "InputActions", "Models", "Material", "Prefab", "Scenes", "ScriptableObject", "Scripts", "Textures", "UserInterface");
            Refresh();
        }

        static class FolderUtility
        {
            public static void CreateDeafault(string root, params string[] folders)
            {
                string fullpath = Combine(Application.dataPath, root);
                foreach (string folder in folders)
                {
                    string path = Combine(fullpath, folder);
                    if (!Exists(path))
                        CreateDirectory(path);
                }
            }
        }
    }
}
