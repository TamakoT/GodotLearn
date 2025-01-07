using Godot;
using 仿炉石传说.接口约定.信号;

namespace 仿炉石传说.系统框架.信号管理系统;

public partial class GameFirstInitSignal : Node
    , ISafeSignalInterface
{
    /// <summary>
    /// 游戏第一次初始化完成
    /// </summary>
    [Signal]
    public delegate void GameFirstInitFinishEventHandler();

    private ISafeSignalInterface _signalInterfaceInstance;

    public override void _Ready()
    {
        _signalInterfaceInstance = this;
    }

    /// <summary>
    ///     获取所有信号名
    /// </summary>
    /// <returns>名称集合</returns>
    public string[] GetAllSignalNames()
    {
        string[] names =
        {
            nameof(GameFirstInitSignal.GameFirstInitFinish),
        };
        return names;
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
        _signalInterfaceInstance.SafeEmitSignal(this, nameof(GameFirstInitSignal.GameFirstInitFinish));
    }

    public void EmitGameFirstInitFinish()
    {
        EmitSignal(nameof(GameFirstInitSignal.GameFirstInitFinish));
    }

    #endregion
}