using System.Collections.Generic;
using System.Linq;
using Godot;
using 仿炉石传说.工具库.常量池;
using SceneChangeCoverInterface = 仿炉石传说.系统框架.画布层管理系统.场景切换覆盖层.SceneChangeCoverInterface;
using StartMenuInterface = 仿炉石传说.系统框架.画布层管理系统.开始菜单界面.StartMenuInterface;
using UserInterface = 仿炉石传说.系统框架.画布层管理系统.用户界面.UserInterface;

namespace 仿炉石传说.系统框架.画布层管理系统;

/// <summary>
///     画布层管理系统，用于管理覆盖在游戏画布上的UI界面等其他组件
/// </summary>
public partial class CanvasManageSystem : Node
{
    public UserInterface             UserHud;
    public SceneChangeCoverInterface SceneChangeCover;
    public StartMenuInterface        StartMenu;

    private readonly List<CanvasLayerInterfaceBase> _interfaceList = [];

    public override void _Ready()
    {
        UserHud          = GetNode<UserInterface>("用户界面");
        SceneChangeCover = GetNode<SceneChangeCoverInterface>("场景切换覆盖层");
        StartMenu        = GetNode<StartMenuInterface>("开始菜单界面");

        InitInterfaceList();
        InitLayer();
    }

    /// <summary>
    ///     初始化所有画布层
    /// </summary>
    private void InitInterfaceList()
    {
        foreach (Node child in GetChildren())
            if (child is CanvasLayerInterfaceBase interfaceBase)
            {
                interfaceBase.Hide();
                _interfaceList.Add(interfaceBase);
            }
    }

    /// <summary>
    ///     初始化所有画布对应层级
    /// </summary>
    private void InitLayer()
    {
        // 100
        UserHud.Layer = CanvasManagerConstant.TopLayer;
        // 95
        SceneChangeCover.Layer = CanvasManagerConstant.TopLayer - CanvasManagerConstant.StepLayer;
        // 5
        StartMenu.Layer = CanvasManagerConstant.ZeroLayer + CanvasManagerConstant.StepLayer;
    }

    public override void _Input(InputEvent @event)
    {
        if (!@event.IsAction(InputManagerConstant.InputActionName.Test)) return;

        foreach (CanvasLayerInterfaceBase canvasLayerInterfaceBase in _interfaceList.Where(
                     canvasLayerInterfaceBase =>
                         canvasLayerInterfaceBase.CanBeActivated()))
            canvasLayerInterfaceBase.RespondToInput(@event);
    }
}