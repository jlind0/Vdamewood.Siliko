///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System;
using System.Runtime.InteropServices;

namespace Siliko
{
	public enum TokenType
	{
		ERROR = -1,
		UNSET = 0,
		LPAREN = ((sbyte)'('),
		RPAREN = ((sbyte)')'),
		MULTIPLY = ((sbyte)'*'),
		ADDITION = ((sbyte)'+'),
		COMMA = ((sbyte)','),
		SUBTRACT = ((sbyte)'-'),
		DIVISION = ((sbyte)'/'),
		EXPONENT = ((sbyte)'^'),
		DICE = ((sbyte)'d'),
		INTEGER = 256,
		FLOAT,
		ID,
		EOL
	};

	[StructLayout(LayoutKind.Explicit)]
	public struct Token
    {
		[FieldOffset(0)]
		TokenType Type;
		[FieldOffset(8)]
		IntPtr Id;
		[FieldOffset(8)]
		long Integer;
		[FieldOffset(8)]
		double Float;

		public string GetId()
		{
			if (Type == TokenType.ID)
            {
				return Marshal.PtrToStringAnsi(Id);
            }
			return "";
		}
	}
}
