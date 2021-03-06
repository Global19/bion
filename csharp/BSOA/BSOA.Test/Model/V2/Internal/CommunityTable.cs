// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using BSOA.Collections;
using BSOA.Column;
using BSOA.Model;

namespace BSOA.Test.Model.V2
{
    /// <summary>
    ///  BSOA GENERATED Table for 'Community'
    /// </summary>
    internal partial class CommunityTable : Table<Community>
    {
        internal PersonDatabase Database;

        internal IColumn<NumberList<int>> People;

        public CommunityTable(IDatabase database, Dictionary<string, IColumn> columns = null) : base(database, columns)
        {
            Database = (PersonDatabase)database;
            GetOrBuildColumns();
        }

        public override void GetOrBuildColumns()
        {
            People = GetOrBuild(nameof(People), () => (IColumn<NumberList<int>>)new RefListColumn(nameof(PersonDatabase.Person)));
        }

        public override Community Get(int index)
        {
            return (index == -1 ? null : new Community(this, index));
        }
    }
}
