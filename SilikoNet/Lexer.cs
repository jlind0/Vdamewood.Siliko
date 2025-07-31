///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System;

namespace Siliko
{
    public class Lexer
    {
        private IntPtr backend;
        private DotNetDataSource source;

        public Lexer(IDataSource NewSource)
        {
            source = new DotNetDataSource(NewSource);
            backend = C.SilikoLexerNew(source.TakeBackend());
        }

        ~Lexer()
        {
            C.SilikoLexerDelete(backend);
        }

        public void Next()
        {
            C.SilikoLexerNext(backend);
        }

        public Token GetToken()
        {
            return C.SilikoLexerGetToken(backend);
        }
    }
}
