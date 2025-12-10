using UnityEditor;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace jamesribbon.EditorTools
{
    public static class FolderCreator
    {
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

                CreateDirectory(Combine(dataPath, defaultPath));

                //General Folders
                CreateFolders(defaultPath + "/Settings");
                CreateFolders(defaultPath + "/Documentation");
                CreateFolders(defaultPath + "/ThirdParty");

                //Art structure
                CreateFolders(defaultPath + "/Art/3D", "Models", "Materials", "Textures", "Animations");
                CreateFolders(defaultPath + "/Art/UI", "Sprites", "Fonts", "Icons");

                //Audio Structure
                CreateFolders(defaultPath + "/Audio", "Music", "SFX", "Voice");

                //Scripts structure
                CreateFolders(defaultPath + "/Scripts", "Core", "Player", "Enemies", "UI", "Systems", "Utilities");

                //Scenes structure
                CreateFolders(defaultPath + "/Scenes", "Levels", "Menu", "Testing");

                //Prefabs structure
                CreateFolders(defaultPath + "/Prefabs", "Characters", "Props", "Environment", "UI");

                //Unique Unity folders (outside _Project)
                CreateFolders(dataPath + "/Resources");
                CreateFolders(dataPath + "/StreamingAssets");
                CreateFolders(dataPath + "/Plugins");

                Refresh();

                Debug.Log("Default project folders created successfully!");
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

        private static void CreateFolders(string path)
        {
            var fullpath = Combine(dataPath, path);
           
            CreateDirectory(fullpath);
            
        }
    }
}
