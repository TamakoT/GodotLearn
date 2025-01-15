using Godot;

namespace 仿炉石传说.系统框架.画布层管理系统.用户界面;

public partial class UserInterface : CanvasLayerInterfaceBase
{
    public override void _Ready()
    {
    }

    public override void RespondToInput(InputEvent @event)
    {
        GD.Print("用户界面 响应了输入");
    }

    public override bool CanBeActivated()
    {
        return true;
    }
}