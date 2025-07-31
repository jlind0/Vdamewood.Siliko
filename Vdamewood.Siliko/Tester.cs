///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System;
using Siliko;

namespace Tester
{
    class Program
    {        static void Main(string[] args)
        {
            Siliko.FunctionCaller.SetUp();
            IDataSource src = new StringSource(args[0]);
            Console.WriteLine(InfixParser.Parse(src).Evaluate().ToString());
            GC.KeepAlive(src);
            Siliko.FunctionCaller.TearDown();
        }
    }
}
