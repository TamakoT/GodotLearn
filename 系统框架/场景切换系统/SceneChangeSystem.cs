using Godot;
using Masuit.Tools;
using 仿炉石传说.工具库.异常工具;

namespace 仿炉石传说.系统框架.场景切换系统;

public partial class SceneChangeSystem : Node
{
    /// <summary>
    /// 转换到指定场景
    /// </summary>
    /// <param name="scene">打包的场景</param>
    public void ChangeScene(PackedScene scene)
    {
        if (!GodotObject.IsInstanceValid(scene))
        {
            ExceptionUtil.PrintError("切换场景的打包场景不合法，停止切换");
            return;
        }

        GetTree().ChangeSceneToPacked(scene);
    }

    /// <summary>
    /// 转换到指定场景
    /// </summary>
    /// <param name="scenePath">场景文件路径</param>
    public void ChangeScene(string scenePath)
    {
        if (scenePath.IsNullOrEmpty())
        {
            ExceptionUtil.PrintError("切换场景的路径为空，停止切换");
            return;
        }

        GetTree().ChangeSceneToFile(scenePath);
    }
}