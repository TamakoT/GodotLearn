using Godot;
using 仿炉石传说.系统框架.视口管理系统;

namespace 仿炉石传说.系统框架.画布层管理系统.开始菜单界面;

public partial class StartMenuInterface : CanvasLayerInterfaceBase
{
    public override void RespondToInput(InputEvent @event)
    {
        GD.Print("开始菜单界面 响应了输入");
    }

    public override bool CanBeActivated()
    {
        return true;
    }
}