// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using BSOA.Column;
using BSOA.Collections;
using BSOA.Model;

namespace BSOA.Test.Model.V1
{
    /// <summary>
    ///  BSOA GENERATED Table for 'Person'
    /// </summary>
    internal partial class PersonTable : Table<Person>
    {
        internal PersonDatabase Database;

        internal IColumn<byte> Age;
        internal IColumn<string> Name;

        public PersonTable(IDatabase database, Dictionary<string, IColumn> columns = null) : base(database, columns)
        {
            Database = (PersonDatabase)database;
            GetOrBuildColumns();
        }

        public override void GetOrBuildColumns()
        {
            Age = GetOrBuild(nameof(Age), () => Database.BuildColumn<byte>(nameof(Person), nameof(Age), default));
            Name = GetOrBuild(nameof(Name), () => Database.BuildColumn<string>(nameof(Person), nameof(Name), default));
        }

        public override Person Get(int index)
        {
            return (index == -1 ? null : new Person(this, index));
        }
    }
}
