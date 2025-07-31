///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

namespace Siliko
{
    public class StringSource : IDataSource
    {
        string buffer;
        int idx = 0;

        public StringSource(string Newbuffer)
        {
            buffer = Newbuffer;
        }

        public int Advance()
        {
            if (idx < buffer.Length)
            {
                idx++;
                return -1;
            }
            return 0;
        }

        public void Delete()
        {
        }

        public char Get()
        {
            if (idx < buffer.Length)
            {
                return buffer[idx];
            }
            return '\0';
        }
    }
}
