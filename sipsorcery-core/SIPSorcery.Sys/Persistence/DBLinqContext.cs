﻿// ============================================================================
// FileName: DBLinqContext.cs
//
// Description:
// Class to create DBLinq data contexts.
//
// Author(s):
// Aaron Clauson
//
// History:
// 20 Aor 2009	Aaron Clauson	Created.
//
// License: 
// This software is licensed under the BSD License http://www.opensource.org/licenses/bsd-license.php
//
// Copyright (c) 2009 Aaron Clauson (aaronc@blueface.ie), Blue Face Ltd, Dublin, Ireland (www.blueface.ie)
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that 
// the following conditions are met:
//
// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer. 
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following 
// disclaimer in the documentation and/or other materials provided with the distribution. Neither the name of Blue Face Ltd. 
// nor the names of its contributors may be used to endorse or promote products derived from this software without specific 
// prior written permission. 
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, 
// BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
// OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbLinq.Data.Linq;
using DbLinq.Vendor;
using MySql.Data.MySqlClient;
using Npgsql;

namespace SIPSorcery.Sys {

    public class DBLinqContext {

        public static DataContext CreateDBLinqDataContext(StorageTypes storageType, string connectionString) {
            switch (storageType) {
                case StorageTypes.DBLinqMySQL:
                    return new DataContext(new MySqlConnection(connectionString), new DbLinq.MySql.MySqlVendor());
                case StorageTypes.DBLinqPostgresql:
                    return new DataContext(new NpgsqlConnection(connectionString), new DbLinq.PostgreSql.PgsqlVendor());
                default:
                    throw new NotSupportedException("Database type " + storageType + " is not supported by CreateDBLinqDataContext.");
            }
        }
    }
}