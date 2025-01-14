using System;
using System.Diagnostics;
using System.Reflection;
using Godot;

namespace 仿炉石传说.工具库.异常工具;

public static class ExceptionUtil
{
    public static void PrintError(string errorMessage)
    {
#if DEBUG || EXPORTDEBUG
        uint randi = GD.Randi();
        // true 表示收集文件和行号信息
        StackTrace stackTrace = new(true);
        // 获取调用方法的栈帧（1 表示上一级）
        StackFrame frame = stackTrace.GetFrame(1);

        if (frame == null) return;
        // 获取调用者的文件名、行号
        string fileName   = frame.GetFileName();
        int    lineNumber = frame.GetFileLineNumber();
        GD.PrintErr($"[{randi:D10}][{DateTime.Now:yyyy-MM-dd HH:mm:ss}]Debug信息追踪：");
        GD.PrintErr($"[{randi:D10}]文件-{{{fileName}}}，第{{{lineNumber}}}行");

        // 获取调用方法的反射对象
        MethodBase method = frame.GetMethod();
        if (method == null) return;
        // 获取调用者的类型
        Type callerObject = method.ReflectedType;
        if (callerObject == null) return;
        string callerName = method.Name;
        GD.PrintErr($"[{randi:D10}]调用自：{callerObject.FullName}::{callerName}");
        GD.PrintErr($"[{randi:D10}]发生错误：{errorMessage}");
#else
        GD.PrintErr($"{errorMessage}");
#endif
    }
}