using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace jamesribbon
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Project Folders")]
        public static void CreateDefaultProjectFolders()
        {
            // Show a confirmation pop up
            bool isConfirmed = EditorUtility.DisplayDialog(
                "Create Default Project Folders",
                "Are you sure you want to create the default project folders? Only use this for new projects",
                "Yes",
                "No"
            );

            if (isConfirmed)
            {
                string defaultPath = "_Project";

                CreateFolders(defaultPath + "/Audio", "SoundEffects", "Music");
                CreateFolders(defaultPath + "/Content", "Characters", "Environment", "UI");
                CreateFolders(defaultPath + "/Prefabs", "Characters", "Environment", "UI");
                CreateFolders(defaultPath + "/Scenes", "Core", "Levels", "Menus", "Testing");
                CreateFolders(defaultPath + "/Scripts", "Audio", "Gameplay", "Content", "UI");

                Refresh();
            }
        }

        private static void CreateFolders(string root, params string[] dir)
        {
            var fullpath = Combine(dataPath, root);

            foreach (var newDirectory in dir)
            {
                CreateDirectory(Combine(fullpath, newDirectory));
            }
        }

        private static void CreateFolder(string path, string newFolderName)
        {
            string fullPath = Combine(dataPath, path, newFolderName);

            if (!Exists(fullPath))
            {
                CreateDirectory(fullPath);
#if UNITY_EDITOR
                Debug.Log($"Created folder: {fullPath}");
#endif
            }
            else
            {
#if UNITY_EDITOR

                Debug.Log($"Folder already exists: {fullPath}");
#endif
            }
        }
    }
}
