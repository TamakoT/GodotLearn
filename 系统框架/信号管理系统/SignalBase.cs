using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;
using 仿炉石传说.工具库.异常工具;
using Array = System.Array;

namespace 仿炉石传说.系统框架.信号管理系统;

[GlobalClass]
public abstract partial class SignalBase : Node
{
    /// <summary>
    ///     获取节点拥有的所有信号
    /// </summary>
    /// <returns>信号名称集合</returns>
    public virtual string[] GetAllSignalNames()
    {
        ExceptionUtil.PrintError("获取节点拥有的所有信号，子类必须重写");
        return Array.Empty<string>();
    }

    /// <summary>
    ///     安全的发射信号（在发射信号前会清除对应信号的无效调用者）
    /// </summary>
    /// <param name="signalName">信号名</param>
    /// <param name="args">参数</param>
    protected void SafeEmitSignal(string signalName, params Variant[] args)
    {
        ClearSignalInvalidCallables(signalName);
        EmitSignal(signalName, args);
    }

    /// <summary>
    ///     清除指定信号的无效的回调
    /// </summary>
    /// <param name="node">当前节点</param>
    /// <param name="signalName">信号名称</param>
    protected void ClearSignalInvalidCallables(string signalName)
    {
        Array<Dictionary> signalConnectionList = GetSignalConnectionList(signalName);
        List<Callable> callables = signalConnectionList
                                  .Select(dict => (Callable)dict["callable"])
                                  .Where(callable =>
                                       !GodotObject.IsInstanceValid(callable.Target))
                                  .ToList();
        callables.ForEach(callable => Disconnect(signalName, callable));
    }

    /// <summary>
    ///     清除所有信号的无效的回调
    /// </summary>
    /// <param name="node">当前节点</param>
    protected void ClearAllSignalInvalidCallables()
    {
        string[] allSignalNames = GetAllSignalNames();
        foreach (string signalName in allSignalNames) ClearSignalInvalidCallables(signalName);
    }
}