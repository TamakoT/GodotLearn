using Godot;

namespace 仿炉石传说.系统框架.画布层管理系统.场景切换覆盖层;

public partial class SceneChangeCoverInterface : CanvasLayerInterfaceBase
{
    public override void RespondToInput(InputEvent @event)
    {
        GD.Print("场景切换覆盖层 响应了输入");
    }

    public override bool CanBeActivated()
    {
        return true;
    }
}