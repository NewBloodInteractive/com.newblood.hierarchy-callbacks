using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace NewBlood.Editor
{
    static class SceneHierarchyCallbackSender
    {
        static List<ISceneHierarchyCallbackReceiver> s_Receivers;

        [InitializeOnLoadMethod]
        static void Initialize()
        {
            s_Receivers                                 = new List<ISceneHierarchyCallbackReceiver>();
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemGUI;
        }

        static void OnHierarchyWindowItemGUI(int instanceID, Rect selectionRect)
        {
            foreach (var window in SceneHierarchyWindow.GetAllSceneHierarchyWindows())
            {
                var data = window.sceneHierarchy.treeView.data;
                var item = new GameObjectTreeViewItem(data.FindItem(instanceID));

                if (item.objectPPTR is GameObject gameObject)
                {
                    gameObject.GetComponents(s_Receivers);

                    foreach (ISceneHierarchyCallbackReceiver receiver in s_Receivers)
                    {
                        receiver.OnSceneHierarchyGUI(item, selectionRect, data.IsExpanded(instanceID));
                    }
                }
            }
        }
    }
}
