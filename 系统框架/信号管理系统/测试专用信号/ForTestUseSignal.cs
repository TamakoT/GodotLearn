using Godot;

namespace 仿炉石传说.系统框架.信号管理系统.测试专用信号;

public partial class ForTestUseSignal : SignalBase
{
    /// <summary>
    ///     测试信号
    /// </summary>
    [Signal]
    public delegate void TestSignalEventHandler();

    public override string[] GetAllSignalNames()
    {
        return
        [
            nameof(ForTestUseSignal.TestSignal)
        ];
    }

    #region 信号 TestSignal

    public void ConnectTestSignal(Callable callable)
    {
        Connect(nameof(ForTestUseSignal.TestSignal), callable);
    }

    public void ConnectTestSignal(Callable callable, ConnectFlags flags)
    {
        Connect(nameof(ForTestUseSignal.TestSignal), callable, (uint)flags);
    }

    public void SafeEmitTestSignal()
    {
        SafeEmitSignal(nameof(ForTestUseSignal.TestSignal));
    }

    public void EmitTestSignal()
    {
        EmitSignal(nameof(ForTestUseSignal.TestSignal));
    }

    #endregion
}