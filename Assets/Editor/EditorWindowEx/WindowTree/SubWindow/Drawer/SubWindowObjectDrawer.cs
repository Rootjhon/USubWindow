﻿using UnityEngine;
using System.Collections;
using UnityEditor;

namespace EditorWinEx.Internal
{
    internal class SubWindowObjectDrawer : SubWindowDrawerBase
    {
        protected override SubWindowHelpBox helpBox
        {
            get { return m_ObjDrawer.helpBox; }
        }

        public override string Id
        {
            get { return m_Id; }
        }

        public override GUIContent Title
        {
            get { return m_ObjDrawer.Title; }
        }

        protected override EWSubWindowToolbarType toolBar
        {
            get { return m_ObjDrawer.toolBar; }
        }

        private SubWindowCustomDrawer m_ObjDrawer;

        private string m_Id;

        private bool m_IsLock = false;

        public SubWindowObjectDrawer(SubWindowCustomDrawer drawer)
        {
            this.m_ObjDrawer = drawer;
            this.m_Id = drawer.GetType().FullName;
        }

        public override void DrawWindow(Rect mainRect, Rect toolbarRect, Rect helpboxRect)
        {
            this.m_ObjDrawer.DrawMainWindow(mainRect);
            if (toolbarRect.width > 0 && toolbarRect.height > 0)
                this.m_ObjDrawer.DrawToolBar(toolbarRect);
            if (helpboxRect.width > 0 && helpboxRect.height > 0)
                this.m_ObjDrawer.DrawHelpBox(helpboxRect);
        }

        public override void DrawLeafToolBar(Rect rect)
        {
            base.DrawLeafToolBar(rect);
            if (m_ObjDrawer is ISubWinCustomMenu)
            {
                Rect popRect = new Rect(rect.x + rect.width - 12, rect.y + 7, 13, 11);
                if (GUI.Button(popRect, string.Empty,
                    GUIStyleCache.GetStyle("PaneOptions")))
                {
                    GenericMenu menu = new GenericMenu();
                    ((ISubWinCustomMenu)m_ObjDrawer).AddCustomMenu(menu);
                    if (menu.GetItemCount() > 0)
                        menu.DropDown(popRect);
                }
                rect = new Rect(rect.x + rect.width - 40, rect.y, rect.width - 40, rect.height);
            }
            if (m_ObjDrawer is ISubWinLock)
            {
                EditorGUI.BeginChangeCheck();
                m_IsLock = GUI.Toggle(new Rect(rect.x + rect.width - 20, rect.y + 3, 13, 11), m_IsLock, string.Empty,
                    GUIStyleCache.GetStyle("IN LockButton"));
                if (EditorGUI.EndChangeCheck())
                {
                    ((ISubWinLock)m_ObjDrawer).SetLockActive(m_IsLock);
                }
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            m_ObjDrawer.OnDisable();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            m_ObjDrawer.OnDestroy();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_ObjDrawer.OnEnable();
        }

        protected override bool OnInit()
        {
            m_ObjDrawer.Init();
            return true;
        }
    }
}