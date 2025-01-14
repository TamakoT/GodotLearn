using Godot;
using 仿炉石传说.工具库;
using 仿炉石传说.系统框架.信号管理系统;
using CanvasManageSystem = 仿炉石传说.系统框架.画布层管理系统.CanvasManageSystem;
using InputManageSystem = 仿炉石传说.系统框架.输入管理系统.InputManageSystem;
using SaveDataManageSystem = 仿炉石传说.系统框架.存档系统.SaveDataManageSystem;
using SceneChangeSystem = 仿炉石传说.系统框架.场景切换系统.SceneChangeSystem;
using SettingManageSystem = 仿炉石传说.系统框架.设置管理系统.SettingManageSystem;

namespace 仿炉石传说.系统框架.初始化;

/// <summary>
///     初始化组件
///     Note ： Godot的节点树初始化时都是遵循深度优先遍历原则，ready和ExitTree函数是从子节点->父节点，但_EnterTree是从父节点->子节点
/// </summary>
public partial class GameFirstInit : Node
{
    public enum GameEnvType
    {
        Release,
        Test,
        Debug
    }

    [Export(PropertyHint.Enum, "Release,Test,Debug")]
    public GameEnvType GameEnv = GameEnvType.Debug;

    private SettingManageSystem  _settingManager;
    private SaveDataManageSystem _saveDataManager;
    private SignalManageSystem   _signalManager;
    private InputManageSystem    _inputManager;
    private CanvasManageSystem   _canvasManager;
    private SceneChangeSystem    _sceneChanger;

    public override void _Ready()
    {
        ProcessMode = ProcessModeEnum.Always;
        GameUtil.SetInstance(this);

        _settingManager  = GetNode<SettingManageSystem>("设置管理器");
        _saveDataManager = GetNode<SaveDataManageSystem>("存档管理器");
        _signalManager   = GetNode<SignalManageSystem>("信号管理器");
        _inputManager    = GetNode<InputManageSystem>("输入管理器");
        _canvasManager   = GetNode<CanvasManageSystem>("画布层管理器");
        _sceneChanger    = GetNode<SceneChangeSystem>("场景切换器");

        foreach (Node child in GetChildren()) GameUtil.SetInitComponent(child);

        Ready += async () =>
        {
            await ToSignal(GetTree().CreateTimer(2), SceneTreeTimer.SignalName.Timeout);
            _signalManager.GameFirstInitSignals.EmitGameFirstInitFinish();
        };
    }

    /// <summary>
    ///     游戏一切初始化操作的开始
    ///     读取游戏配置文件
    ///     读取游戏设置
    ///     加载游戏mod文件
    /// </summary>
    public override void _EnterTree()
    {
        ReadConfig();
    }

    private void ReadConfig()
    {
    }
}