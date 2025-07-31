///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System;

namespace Siliko
{
    public enum SyntaxTreeErrorType
    {
        Error = 0
    }

    public enum SyntaxTreeNodeType
    {
        NOTHING = 0,
        BRANCH,
        LEAF
    }

    public class SyntaxTreeNode
    {
        public const SyntaxTreeErrorType Error = SyntaxTreeErrorType.Error;
        private IntPtr backend;

        public SyntaxTreeNode()
        {
            backend = C.SilikoSyntaxTreeNewNothing();
        }

        public SyntaxTreeNode(long IntegerValue)
        {
            backend = C.SilikoSyntaxTreeNewInteger(IntegerValue);
        }

        public SyntaxTreeNode(double FloatValue)
        {
            backend = C.SilikoSyntaxTreeNewFloat(FloatValue);
        }

        public SyntaxTreeNode(string BranchId)
        {
            backend = C.SilikoSyntaxTreeNewBranch(BranchId);
        }

        public SyntaxTreeNode(SyntaxTreeErrorType e)
        {
            backend = C.SilikoSyntaxTreeNewError();
        }

        internal SyntaxTreeNode(IntPtr NewCStruct)
        {
            backend = NewCStruct;
        }

        ~SyntaxTreeNode()
        {
            C.SilikoSyntaxTreeDelete(backend);
        }

        public Value Evaluate()
        {
            return C.SilikoSyntaxTreeEvaluate(backend);
        }

        public SyntaxTreeNodeType GetNodeType()
        {
            return C.SilikoSyntaxTreeGetType(backend);
        }

        public bool IsError()
        {
            return C.SilikoSyntaxTreeIsError(backend) != 0;
        }

        public int Negate()
        {
            return C.SilikoSyntaxTreeNegate(backend);
        }

        public int PushLeft(SyntaxTreeNode NewBranch)
        {
            int rVal = C.SilikoSyntaxTreePushLeft(backend, NewBranch.backend);
            NewBranch.backend = IntPtr.Zero;
            return rVal;
        }

        public int PushRight(SyntaxTreeNode NewBranch)
        {
            int rVal = C.SilikoSyntaxTreePushRight(backend, NewBranch.backend);
            NewBranch.backend = IntPtr.Zero;
            return rVal;
        }

        public int GraftLeft(SyntaxTreeNode NewBranch)
        {
            int rVal = C.SilikoSyntaxTreeGraftLeft(backend, NewBranch.backend);
            NewBranch.backend = IntPtr.Zero;
            return rVal;
        }

        public int GraftRight(SyntaxTreeNode NewBranch)
        {
            int rVal = C.SilikoSyntaxTreeGraftRight(backend, NewBranch.backend);
            NewBranch.backend = IntPtr.Zero;
            return rVal;
        }
    }
}
