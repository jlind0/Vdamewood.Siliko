///# Copyright 2025 Vincent Damewood
///# SPDX-License-Identifier: LGPL-3.0-or-later

namespace Siliko
{
    public interface IDataSource
    {
        int Advance();
        char Get();
        void Delete();
    }
}
