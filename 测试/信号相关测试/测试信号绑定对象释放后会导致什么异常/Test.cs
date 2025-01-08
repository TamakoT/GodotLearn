using Godot;
using 仿炉石传说.工具库;

namespace 仿炉石传说.测试.信号相关测试.测试信号绑定对象释放后会导致什么异常;

public partial class Test : Node2D
{
    private TestNode _testNode;
    private TestNode _testNode2;
    private TestNode _testNode3;
    private TestNode _testNode4;

    public override void _Ready()
    {
        _testNode  = GetNode<TestNode>("测试信号节点");
        _testNode2 = GetNode<TestNode>("测试信号节点2");
        _testNode3 = GetNode<TestNode>("测试信号节点3");
        _testNode4 = GetNode<TestNode>("测试信号节点4");

        GameUtil.DelayAction(2, () =>
        {
            _testNode.QueueFree();
            _testNode4.QueueFree();
        });

        GameUtil.DelayAction(4, () =>
        {
            GD.Print($"测试节点testNode是否有效：{GodotObject.IsInstanceValid(_testNode)}");
            GD.Print($"测试节点testNode4是否有效：{GodotObject.IsInstanceValid(_testNode4)}");
            GameUtil.SignalManager.ForTestUseSignals.EmitTestSignal();
        });
    }
}