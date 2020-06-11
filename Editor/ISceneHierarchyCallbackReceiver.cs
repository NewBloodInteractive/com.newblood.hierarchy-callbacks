using UnityEngine;
using UnityEditor.IMGUI.Controls;

namespace NewBlood.Editor
{
    public interface ISceneHierarchyCallbackReceiver
    {
        void OnSceneHierarchyGUI(TreeViewItem item, Rect selectionRect, bool expanded);
    }
}
