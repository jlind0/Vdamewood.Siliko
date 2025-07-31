///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Siliko
{
    public static class FunctionCaller
    {
        internal delegate Value NativeFunction(int argc, Value[] argv);
        public delegate Value DotNetFunction(Value[] argv);

        internal class DotNetWrapper
        {
            DotNetFunction Backend;
            public DotNetWrapper(DotNetFunction NewFunction)
            {
                Backend = NewFunction;
            }

            public Value Invoke(int argc, [MarshalAs(UnmanagedType.LPArray)] Value[] argv)
            {
                Value[] WrapArgv = new Value[argc];
                for (int i = 0; i < argc; i++)
                    WrapArgv[i] = argv[i];
                return Backend(WrapArgv);
            }
        }
        
        static List<DotNetWrapper> Wrappers = new List<DotNetWrapper>();


        public static int SetUp()
        {
            return C.SilikoFunctionCallerSetUp();
        }

        public static void TearDown()
        {
            C.SilikoFunctionCallerTearDown();
            Wrappers.Clear();
        }

        public static Value Call(string FunctionName, Value[] Arguments)
        {
            return C.SilikoFunctionCallerCall(FunctionName, Arguments.Length, Arguments);
        }

        public static int Install(string FunctionName, DotNetFunction Implementation)
        {
            DotNetWrapper Wrapper = new DotNetWrapper(Implementation);
            Wrappers.Add(Wrapper);
            return C.SilikoFunctionCallerInstall(FunctionName, Wrapper.Invoke);
        }
    }
}
