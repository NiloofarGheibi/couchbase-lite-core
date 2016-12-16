﻿//
// C4DBQuery.cs
//
// Author:
// 	Jim Borden  <jim.borden@couchbase.com>
//
// Copyright (c) 2016 Couchbase, Inc All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace LiteCore.Interop
{
    public unsafe partial struct C4IndexOptions : IDisposable
    {
        public void Dispose()
        {
            var old = Interlocked.Exchange(ref _language, IntPtr.Zero);
            if(old != IntPtr.Zero) {
                Marshal.FreeHGlobal(old);
            }
        }
    }

    public enum C4IndexType : uint
    {
        Value,     // Regular index of property ValueIndex
        FullText,  // Full-text index
        Geo        // Geospatial index of GeoJSON values (NOT YET IMPLEMENTED)
    }
}
