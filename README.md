# Scene Hierarchy Callbacks
Allows customization of the scene hierarchy tree through callbacks.

# Usage
This package exposes an interface (`NewBlood.Editor.ISceneHierarchyCallbackReceiver`) for receiving callbacks when a GameObject is drawn in the scene hierarchy. Unlike the existing `EditorApplication.hierarchyWindowItemOnGUI` callback, access to the `TreeViewItem` is given, allowing you to change the icon and other properties.

```CSharp
namespace NewBlood.Editor
{
    public interface ISceneHierarchyCallbackReceiver
    {
        void OnSceneHierarchyGUI(TreeViewItem item, Rect selectionRect, bool expanded);
    }
}
```
