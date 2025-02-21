using UnityEditor;
using UnityEngine.WSA;

namespace jamesribbon.EditorTools
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Project Folders")]
        public static void CreateDefaultProjectFolders()
        {
            FolderCreator.CreateDefaultProjectFolders();
        }
    }
}
