///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System;

namespace Siliko
{
    public static class InfixParser
    {
        public static SyntaxTreeNode Parse(IDataSource input)
        {
            DotNetDataSource ds = new DotNetDataSource(input);
            SyntaxTreeNode rVal = new SyntaxTreeNode(C.SilikoParseInfix(ds.TakeBackend()));
            GC.KeepAlive(ds);
            return rVal;
        }
    }
}
