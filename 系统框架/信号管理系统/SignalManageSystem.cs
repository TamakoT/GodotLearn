using Godot;

namespace 仿炉石传说.系统框架.信号管理系统;

/// <summary>
///     信号管理器
///     将信号集中创建于此，通过该系统发射信号，监听信号，进行信号处理
///     注意：创建的信号名称必须以EventHandler结尾，并标记Signal特性
/// </summary>
public partial class SignalManageSystem : Node
{
    public GameFirstInitSignal GameFirstInitSignals;
    public ForTestUseSignal    ForTestUseSignals;

    public override void _Ready()
    {
        GameFirstInitSignals = GetNode<GameFirstInitSignal>("系统初始化信号");
        ForTestUseSignals    = GetNode<ForTestUseSignal>("测试专用信号");
    }
}