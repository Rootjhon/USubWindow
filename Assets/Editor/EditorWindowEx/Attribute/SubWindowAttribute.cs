﻿using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// 子窗口图标
/// </summary>
public enum SubWindowIcon
{
    None,
    BuildSetting,
    Hierarchy,
    Scene,
    Inspector,
    Game,
    Console,
    Project,
    Animation,
    Profiler,
    AudioMixer,
    AssetStore,
    Animator,
    Lighting,
    Occlusion,
    Navigation,
    Web,
    IPhone,
    Android,
    Shader,
    Avator,
    GameObject,
    Camera,
    JavaScript,
    CSharp,
    Sprite,
    Text,
    AnimatorController,
    Terrain,
    MeshRenderer,
    Font,
    Material,
    GameManager,
    Texture,
    Scriptable,
    CGProgram,
    Favorite,
    Search,
    Player,
    Movie,
    Audio,
    Setting,
}

/// <summary>
/// 工具栏类型
/// </summary>
public enum SubWindowToolbarType
{
    None,
    Normal,
    Mini,
}

/// <summary>
/// 子窗口标签-给具体的窗口绘制方法添加该标签
/// 支持1~3个Rect类型参数，分别表示实际绘制区域、工具栏区域、helpbox区域
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class SubWindowAttribute : Attribute
{
    /// <summary>
    /// 标题
    /// </summary>
    public string title;

    /// <summary>
    /// 是否激活
    /// </summary>
    public bool active;

    /// <summary>
    /// 窗口样式类型
    /// </summary>
    public SubWindowStyle windowStyle;

    /// <summary>
    /// 图标
    /// </summary>
    public string iconPath;

    /// <summary>
    /// 是否显示工具栏
    /// </summary>
    public SubWindowToolbarType toolbar;

    /// <summary>
    /// 帮助栏样式
    /// </summary>
    public SubWindowHelpBoxType helpBox;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="icon">图标</param>
    /// <param name="active">初始是否激活</param>
    /// <param name="windowStyle">窗口样式</param>
    /// <param name="toolbar">是否显示工具栏</param>
    /// <param name="helpBox">帮助栏样式</param>
    public SubWindowAttribute(string title, SubWindowIcon icon = SubWindowIcon.None, bool active = true, SubWindowStyle windowStyle = SubWindowStyle.Default, SubWindowToolbarType toolbar = SubWindowToolbarType.None, SubWindowHelpBoxType helpBox = SubWindowHelpBoxType.None)
    {
        this.title = title;
        this.active = active;
        this.windowStyle = windowStyle;
        this.toolbar = toolbar;
        this.helpBox = helpBox;
        this.iconPath = GUIEx.GetIconPath(icon);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="icon">图标</param>
    /// <param name="active">初始是否激活</param>
    /// <param name="windowStyle">窗口样式</param>
    /// <param name="toolbar">是否显示工具栏</param>
    /// <param name="helpBox">帮助栏样式</param>
    public SubWindowAttribute(string title, string icon, bool active = true, SubWindowStyle windowStyle = SubWindowStyle.Default, SubWindowToolbarType toolbar = SubWindowToolbarType.None, SubWindowHelpBoxType helpBox = SubWindowHelpBoxType.None)
    {
        this.title = title;
        this.active = active;
        this.windowStyle = windowStyle;
        this.toolbar = toolbar;
        this.helpBox = helpBox;
        this.iconPath = icon;
    }

}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class SubWindowHandleAttribute : Attribute
{
    /// <summary>
    /// 目标窗口类型
    /// </summary>
    public Type targetWinType;

    /// <summary>
    /// 是否激活
    /// </summary>
    public bool active;

    /// <summary>
    /// 窗口样式类型
    /// </summary>
    public SubWindowStyle windowStyle;

    public SubWindowHandleAttribute(Type targetWinType, SubWindowStyle windowStyle = SubWindowStyle.Default, bool active = true)
    {
        this.targetWinType = targetWinType;
        this.active = active;
        this.windowStyle = windowStyle;
    }
}
