using System;
using System.Runtime.CompilerServices;
using Godot;
using 仿炉石传说.系统框架.信号管理系统;
using GameFirstInit = 仿炉石传说.系统框架.初始化.GameFirstInit;
using CanvasManageSystem = 仿炉石传说.系统框架.画布层管理系统.CanvasManageSystem;
using InputManageSystem = 仿炉石传说.系统框架.输入管理系统.InputManageSystem;
using SaveDataManageSystem = 仿炉石传说.系统框架.存档系统.SaveDataManageSystem;
using SceneChangeSystem = 仿炉石传说.系统框架.场景切换系统.SceneChangeSystem;
using SettingManageSystem = 仿炉石传说.系统框架.设置管理系统.SettingManageSystem;

[assembly: InternalsVisibleTo("仿炉石传说.系统框架.初始化")]

namespace 仿炉石传说.工具库;

public static class GameUtil
{
    private static GameFirstInit _instance;

    /// <summary>
    ///     设置管理系统单例
    /// </summary>
    public static SettingManageSystem SettingManager { get; private set; }

    /// <summary>
    ///     存档管理系统单例
    /// </summary>
    public static SaveDataManageSystem SaveDataManager { get; private set; }

    /// <summary>
    ///     信号管理系统单例
    /// </summary>
    public static SignalManageSystem SignalManager { get; private set; }

    /// <summary>
    ///     输入管理系统单例
    /// </summary>
    public static InputManageSystem InputManager { get; private set; }

    /// <summary>
    ///     视口管理系统单例
    /// </summary>
    public static CanvasManageSystem CanvasManager { get; private set; }

    /// <summary>
    ///     场景切换系统单例
    /// </summary>
    public static SceneChangeSystem SceneChanger { get; private set; }

    # region 初始化相关，函数仅用于 GameFirstInit 使用

    /// <summary>
    ///     设置 GameFirstInit实例
    /// </summary>
    /// <param name="instance">实例对象</param>
    internal static void SetInstance(GameFirstInit instance)
    {
        GameUtil._instance = instance;
    }

    /// <summary>
    ///     设置初始化组件
    /// </summary>
    /// <param name="node">需要判断设置的节点</param>
    internal static void SetInitComponent(Node node)
    {
        switch (node)
        {
            case SettingManageSystem system:
                GameUtil.SettingManager = system;
                break;
            case SaveDataManageSystem system:
                GameUtil.SaveDataManager = system;
                break;
            case SignalManageSystem system:
                GameUtil.SignalManager = system;
                break;
            case InputManageSystem system:
                GameUtil.InputManager = system;
                break;
            case CanvasManageSystem system:
                GameUtil.CanvasManager = system;
                break;
            case SceneChangeSystem system:
                GameUtil.SceneChanger = system;
                break;
        }
    }

    # endregion

    /// <summary>
    ///     获取当前游戏环境
    /// </summary>
    /// <returns>游戏环境类型</returns>
    public static GameFirstInit.GameEnvType Env()
    {
        return GameUtil._instance.GameEnv;
    }

    /// <summary>
    ///     创建定时器
    /// </summary>
    /// <param name="timeSec">时间（秒）</param>
    /// <returns>定时器</returns>
    public static SceneTreeTimer CreatTimer(double timeSec)
    {
        return GameUtil._instance.GetTree().CreateTimer(timeSec);
    }

    /// <summary>
    ///     延迟一定时间后执行动作
    /// </summary>
    /// <param name="timeSec">时间（秒）</param>
    /// <param name="action">动作</param>
    public static void DelayAction(double timeSec, Action action)
    {
        GameUtil.CreatTimer(timeSec).Timeout += action;
    }
}