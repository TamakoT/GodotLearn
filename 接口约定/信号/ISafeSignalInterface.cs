using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;
using Array = System.Array;

namespace 仿炉石传说.接口约定.信号;

public interface ISafeSignalInterface
{
    /// <summary>
    ///     安全的发射信号（在发射信号前会清除对应信号的无效调用者）
    /// </summary>
    /// <param name="node">信号拥有者</param>
    /// <param name="signalName">信号名</param>
    /// <param name="args">参数</param>
    void SafeEmitSignal(Node node, string signalName, params Variant[] args)
    {
        ClearSignalInvalidCallables(node, signalName);
        node.EmitSignal(signalName, args);
    }

    /// <summary>
    ///     获取节点拥有的所有信号
    /// </summary>
    /// <returns>信号名称集合</returns>
    string[] GetAllSignalNames();

    /// <summary>
    ///     清除指定信号的无效的回调
    /// </summary>
    /// <param name="node">当前节点</param>
    /// <param name="signalName">信号名称</param>
    void ClearSignalInvalidCallables(Node node, string signalName)
    {
        Array<Dictionary> signalConnectionList = node.GetSignalConnectionList(signalName);
        List<Callable> callables = signalConnectionList
                                  .Select(dict => (Callable)dict["callable"])
                                  .Where(callable =>
                                       !GodotObject.IsInstanceValid(callable.Target))
                                  .ToList();
        callables.ForEach(callable => node.Disconnect(signalName, callable));
    }

    /// <summary>
    ///     清除所有信号的无效的回调
    /// </summary>
    /// <param name="node">当前节点</param>
    void ClearAllSignalInvalidCallables(Node node)
    {
        string[] allSignalNames = GetAllSignalNames();
        foreach (string signalName in allSignalNames)
        {
            ClearSignalInvalidCallables(node, signalName);
        }
    }
}