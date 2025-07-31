///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

using System;

namespace Siliko
{
    internal class DotNetDataSource
    {
        public delegate int AdvanceFunction(IDataSource Src);
        public delegate sbyte GetFunction(IDataSource Src);
        public delegate void DeleteFunction(IDataSource Src);

        IDataSource MySource;
        private IntPtr backend;
        private bool ownsBackend = true;

        public DotNetDataSource(IDataSource NewSource)
        {
            MySource = NewSource;
            backend = C.SilikoDataSourceNew(NewSource, Advance, Get, Delete);
        }

        ~DotNetDataSource()
        {
            if (ownsBackend)
                C.SilikoDataSourceDelete(backend);
        }

        public IntPtr TakeBackend()
        {
            ownsBackend = false;
            return backend;
        }


        static int Advance(IDataSource Src)
        {
            return Src.Advance();
        }

        static sbyte Get(IDataSource Src)
        {
            return ((sbyte)Src.Get());
        }

        static void Delete(IDataSource Src)
        {
            Src.Delete();
        }
    }
}
