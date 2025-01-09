using Godot;

namespace 仿炉石传说.系统框架.信号管理系统.系统初始化信号;

public partial class GameFirstInitSignal : SignalBase
{
    /// <summary>
    ///     游戏第一次初始化完成
    /// </summary>
    [Signal]
    public delegate void GameFirstInitFinishEventHandler();

    public override string[] GetAllSignalNames()
    {
        return
        [
            nameof(GameFirstInitSignal.GameFirstInitFinish)
        ];
    }

    #region 信号 GameFirstInitFinish

    public void ConnectGameFirstInitFinish(Callable callable)
    {
        Connect(nameof(GameFirstInitSignal.GameFirstInitFinish), callable);
    }

    public void ConnectGameFirstInitFinish(Callable callable, ConnectFlags flags)
    {
        Connect(nameof(GameFirstInitSignal.GameFirstInitFinish), callable, (uint)flags);
    }

    public void SafeEmitGameFirstInitFinish()
    {
        SafeEmitSignal(nameof(GameFirstInitSignal.GameFirstInitFinish));
    }

    public void EmitGameFirstInitFinish()
    {
        EmitSignal(nameof(GameFirstInitSignal.GameFirstInitFinish));
    }

    #endregion
}