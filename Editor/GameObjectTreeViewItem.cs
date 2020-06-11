using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.IMGUI.Controls;
using Object = UnityEngine.Object;

namespace NewBlood.Editor
{
    sealed class GameObjectTreeViewItem : WrappedTreeViewItem
    {
        static readonly Type s_GameObjectTreeViewItem = Type.GetType("UnityEditor.GameObjectTreeViewItem, UnityEditor", true);

        static readonly PropertyInfo s_ColorCode = s_GameObjectTreeViewItem.GetProperty("colorCode");

        static readonly PropertyInfo s_ObjectPPTR = s_GameObjectTreeViewItem.GetProperty("objectPPTR");

        static readonly PropertyInfo s_LazyInitializationDone = s_GameObjectTreeViewItem.GetProperty("lazyInitializationDone");

        static readonly PropertyInfo s_ShowPrefabModeButton = s_GameObjectTreeViewItem.GetProperty("showPrefabModeButton");

        static readonly PropertyInfo s_OverlayIcon = s_GameObjectTreeViewItem.GetProperty("overlayIcon");

        static readonly PropertyInfo s_SelectedIcon = s_GameObjectTreeViewItem.GetProperty("selectedIcon");

        static readonly PropertyInfo s_IsSceneHeader = s_GameObjectTreeViewItem.GetProperty("isSceneHeader");

        static readonly PropertyInfo s_Scene = s_GameObjectTreeViewItem.GetProperty("scene");

        public GameObjectTreeViewItem(TreeViewItem baseItem)
            : base(baseItem)
        {
            if (!s_GameObjectTreeViewItem.IsAssignableFrom(baseItem.GetType()))
                throw new ArgumentException(nameof(baseItem));
        }

        public int colorCode
        {
            get => (int)s_ColorCode.GetValue(baseItem);
            set => s_ColorCode.SetValue(baseItem, value);
        }

        public Object objectPPTR
        {
            get => (Object)s_ObjectPPTR.GetValue(baseItem);
            set => s_ObjectPPTR.SetValue(baseItem, value);
        }

        public bool lazyInitializationDone
        {
            get => (bool)s_LazyInitializationDone.GetValue(baseItem);
            set => s_LazyInitializationDone.SetValue(baseItem, value);
        }

        public bool showPrefabModeButton
        {
            get => (bool)s_ShowPrefabModeButton.GetValue(baseItem);
            set => s_ShowPrefabModeButton.SetValue(baseItem, value);
        }

        public Texture2D overlayIcon
        {
            get => (Texture2D)s_OverlayIcon.GetValue(baseItem);
            set => s_OverlayIcon.SetValue(baseItem, value);
        }

        public Texture2D selectedIcon
        {
            get => (Texture2D)s_SelectedIcon.GetValue(baseItem);
            set => s_SelectedIcon.SetValue(baseItem, value);
        }

        public bool isSceneHeader
        {
            get => (bool)s_IsSceneHeader.GetValue(baseItem);
            set => s_IsSceneHeader.SetValue(baseItem, value);
        }

        public Scene scene
        {
            get => (Scene)s_Scene.GetValue(baseItem);
            set => s_Scene.SetValue(baseItem, value);
        }
    }
}
