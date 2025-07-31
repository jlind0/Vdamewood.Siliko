///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System;
using System.Runtime.InteropServices;

namespace Siliko
{
    internal static class C
    {
        // DataSource.h
        [DllImport("SilikoCore.dll")]
        public static extern IntPtr SilikoDataSourceNew(IDataSource NewState,
            DotNetDataSource.AdvanceFunction Advance,
            DotNetDataSource.GetFunction Get,
            DotNetDataSource.DeleteFunction Delete);
        [DllImport("SilikoCore.dll")]
        public static extern void SilikoDataSourceDelete(IntPtr DataSource);

        [DllImport("SilikoCore.dll")]
        public static extern void SilikoDataSourceTest(IntPtr Source);

        // FunctionCaller.h
        [DllImport("SilikoCore.dll")]
        public static extern int SilikoFunctionCallerSetUp();
        [DllImport("SilikoCore.dll")]
        public static extern void SilikoFunctionCallerTearDown();
        [DllImport("SilikoCore.dll")]
        public static extern Value SilikoFunctionCallerCall(string FunctionName, int ArgumentCount, [MarshalAs(UnmanagedType.LPArray)] Value[] Arguments);
        [DllImport("SilikoCore.dll")]
        public static extern int SilikoFunctionCallerInstall(string FunctionName, FunctionCaller.NativeFunction FunctionImplementation);

        // InfixParser.h:
        [DllImport("SilikoCore.dll")]
        public static extern IntPtr SilikoParseInfix(IntPtr input);

        // Lexer.h
        [DllImport("SilikoCore.dll")]
        public static extern IntPtr SilikoLexerNew(IntPtr InputSource);
        [DllImport("SilikoCore.dll")]
        public static extern void SilikoLexerDelete(IntPtr Lexer);
        [DllImport("SilikoCore.dll")]
        public static extern void SilikoLexerNext(IntPtr Lexer);
        [DllImport("SilikoCore.dll")]
        public static extern Token SilikoLexerGetToken(IntPtr Lexer);

        // SyntaxTree.h:
        [DllImport("SilikoCore.dll")]
        public static extern IntPtr SilikoSyntaxTreeNewInteger(long IntegerValue);
        [DllImport("SilikoCore.dll")]
        public static extern IntPtr SilikoSyntaxTreeNewFloat(double FloatValue);
        [DllImport("SilikoCore.dll")]
        public static extern IntPtr SilikoSyntaxTreeNewBranch(string Id);
        [DllImport("SilikoCore.dll")]
        public static extern IntPtr SilikoSyntaxTreeNewError();
        [DllImport("SilikoCore.dll")]
        public static extern IntPtr SilikoSyntaxTreeNewNothing();
        [DllImport("SilikoCore.dll")]
        public static extern void SilikoSyntaxTreeDelete(IntPtr SyntaxTree);
        [DllImport("SilikoCore.dll")]
        public static extern Value SilikoSyntaxTreeEvaluate(IntPtr SyntaxTree);
        [DllImport("SilikoCore.dll")]
        public static extern SyntaxTreeNodeType SilikoSyntaxTreeGetType(IntPtr SyntaxTree);
        [DllImport("SilikoCore.dll")]
        public static extern int SilikoSyntaxTreeIsError(IntPtr SyntaxTree);
        [DllImport("SilikoCore.dll")]
        public static extern int SilikoSyntaxTreeNegate(IntPtr SyntaxTree);
        [DllImport("SilikoCore.dll")]
        public static extern int SilikoSyntaxTreePushLeft(IntPtr BaseTree, IntPtr NewBranch);
        [DllImport("SilikoCore.dll")]
        public static extern int SilikoSyntaxTreePushRight(IntPtr BaseTree, IntPtr NewBranch);
        [DllImport("SilikoCore.dll")]
        public static extern int SilikoSyntaxTreeGraftLeft(IntPtr BaseTree, IntPtr NewBranch);
        [DllImport("SilikoCore.dll")]
        public static extern int SilikoSyntaxTreeGraftRight(IntPtr BaseTree, IntPtr NewBranch);
    }
}
