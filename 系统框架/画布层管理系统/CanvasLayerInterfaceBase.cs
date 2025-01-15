using Godot;

namespace 仿炉石传说.系统框架.画布层管理系统;

/// <summary>
///     视口层基类
/// </summary>
[GlobalClass]
public abstract partial class CanvasLayerInterfaceBase : CanvasLayer
{
    /// <summary>
    ///     响应输入事件
    /// </summary>
    /// <param name="event">输入事件</param>
    public virtual void RespondToInput(InputEvent @event)
    {
    }

    /// <summary>
    ///     是否可被激活
    /// </summary>
    /// <returns>true - 可以， false - 不可以</returns>
    public virtual bool CanBeActivated()
    {
        return false;
    }
}