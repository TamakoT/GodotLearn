using System.Collections.Generic;
using System.Linq;
using Godot;
using 仿炉石传说.工具库.常量池;
using 仿炉石传说.系统框架.视口管理系统.场景切换覆盖层;
using 仿炉石传说.系统框架.视口管理系统.开始菜单界面;
using 仿炉石传说.系统框架.视口管理系统.用户界面;

namespace 仿炉石传说.系统框架.视口管理系统;

public partial class CanvasManageSystem : Node
{
    private UserInterface             _userInterface;
    private SceneChangeCoverInterface _sceneChangeCoverInterface;
    private StartMenuInterface        _startMenuInterface;

    private readonly List<CanvasLayerInterfaceBase> _interfaceList = [];

    public override void _Ready()
    {
        _userInterface             = GetNode<UserInterface>("用户界面");
        _sceneChangeCoverInterface = GetNode<SceneChangeCoverInterface>("场景切换覆盖层");
        _startMenuInterface        = GetNode<StartMenuInterface>("开始菜单界面");

        InitInterfaceList();
        InitLayer();
    }

    /// <summary>
    ///     初始化所有视口
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
    ///     初始化所有视口的对应层级
    /// </summary>
    private void InitLayer()
    {
        // 100
        _userInterface.Layer = CanvasManagerConstant.TopLayer;
        // 95
        _sceneChangeCoverInterface.Layer = CanvasManagerConstant.TopLayer - CanvasManagerConstant.StepLayer;
        // 5
        _startMenuInterface.Layer = CanvasManagerConstant.ZeroLayer + CanvasManagerConstant.StepLayer;
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