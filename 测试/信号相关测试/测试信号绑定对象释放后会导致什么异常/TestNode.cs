using Godot;
using 仿炉石传说.工具库;

namespace 仿炉石传说.测试.信号相关测试.测试信号绑定对象释放后会导致什么异常;

public partial class TestNode : Node2D
{
    public override void _Ready()
    {
        GameUtil.SignalManager.ForTestUseSignals.ConnectTestSignal(Callable.From(() =>
        {
            GD.Print($"节点【{Name}】接收到了TestSignal信号");
        }));
    }
}