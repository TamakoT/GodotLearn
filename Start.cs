using System;
using Godot;
using 仿炉石传说.工具库;
using 仿炉石传说.工具库.异常工具;
using 仿炉石传说.系统框架.信号管理系统;
using GameFirstInit = 仿炉石传说.系统框架.初始化.GameFirstInit;

namespace 仿炉石传说;

/// <summary>
/// 一切的开始
/// </summary>
public partial class Start : Node2D
{
    /// <summary>
    ///     当环境为release时，加载的场景路径
    /// </summary>
    [Export(PropertyHint.File, "*.tscn")] public string StartScenePath;

    /// <summary>
    ///     当环境为test时，加载的场景路径
    /// </summary>
    [Export(PropertyHint.File, "*.tscn")] public string TestScenePath;

    /// <summary>
    ///     当环境为debug时，加载的场景路径
    /// </summary>
    [Export(PropertyHint.File, "*.tscn")] public string DebugScenePath;

    public override void _Ready()
    {
        Ready += () =>
        {
            switch (GameUtil.Env())
            {
                case GameFirstInit.GameEnvType.Release:
                    GameUtil.SceneChanger.ChangeScene(StartScenePath);
                    break;
                case GameFirstInit.GameEnvType.Test:
                    GameUtil.SceneChanger.ChangeScene(TestScenePath);
                    break;
                case GameFirstInit.GameEnvType.Debug:
                    GameUtil.SceneChanger.ChangeScene(DebugScenePath);
                    break;
                default:
                    ExceptionUtil.PrintError("环境未配置，请先配置该环境");
                    break;
            }
        };
    }
}