///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System.Runtime.InteropServices;

namespace Siliko
{
    public enum ValueStatus
    {
        INTEGER = 0,
        FLOAT = 1,
        MEMORY_ERR = 2,
        SYNTAX_ERR = 3,
        ZERO_DIV_ERR = 4,
        BAD_FUNCTION = 5,
        BAD_ARGUMENTS = 6,
        DOMAIN_ERR = 7,
        RANGE_ERR = 8
    };

    [StructLayout(LayoutKind.Explicit)]
    public struct Value
    {
        [FieldOffset(0)]
        public ValueStatus status;
        [FieldOffset(8)]
        public long i;
        [FieldOffset(8)]
        public double f;

        public Value(ValueStatus NewStatus)
        {
            this.status = NewStatus;
            this.f = 0.0;
            this.i = 0;
        }

        public Value(long NewValue)
        {
            this.status = ValueStatus.INTEGER;
            this.f = 0.0;
            this.i = NewValue;
        }

        public Value(double NewValue)
        {
            this.status = ValueStatus.FLOAT;
            this.i = 0;
            this.f = NewValue;
        }

        public override string ToString()
        {
            switch (status)
            {
                case ValueStatus.INTEGER:
                    return i.ToString();
                case ValueStatus.FLOAT:
                    return f.ToString();
                case ValueStatus.MEMORY_ERR:
                    return "Error: Out of memory";
                case ValueStatus.SYNTAX_ERR:
                    return "Error: Syntax error";
                case ValueStatus.ZERO_DIV_ERR:
                    return "Error: Division by zero";
                case ValueStatus.BAD_FUNCTION:
                    return "Error: Function not found";
                case ValueStatus.BAD_ARGUMENTS:
                    return "Error: Bad argument count";
                case ValueStatus.DOMAIN_ERR:
                    return "Error: Domain error";
                case ValueStatus.RANGE_ERR:
                    return "Error: Range error";
                default:
                    return "";
            };
        }
    }
}
