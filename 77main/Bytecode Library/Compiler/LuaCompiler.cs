﻿using Compiler.Binding;
using Compiler.Binding.Objects;
using System;
using System.Text;

namespace LuaCompiler_Test;

public class LuaCompiler
{
    private static readonly Encoding LuaEncoding = Encoding.GetEncoding(28591);

    public static byte[] Compile(string source)
    {
        // ReSharper disable once InconsistentNaming
        var Compiler = new Binding();

        var status = Compiler.LoadString(source);
        if (!status.Item1)
            throw new Exception(status.Item2.ToString());

        var function = (LuaFunction)status.Item2!;

        if (Compiler["string"] is not LuaTable stringTable || stringTable.Dictionary["dump"] is not LuaFunction dumpFunction)
            throw new Exception("Lua state error");

        var dumpedFunction = dumpFunction.Call(function);

        if (dumpedFunction.Length != 2 || dumpedFunction[0] is not string bytecode)
            throw new Exception("Couldn't dump function");

        return LuaEncoding.GetBytes(bytecode);
    }
}