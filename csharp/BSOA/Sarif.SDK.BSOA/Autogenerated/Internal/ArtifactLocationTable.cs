// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using BSOA.Column;
using BSOA.Model;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    ///  BSOA GENERATED Table for 'ArtifactLocation'
    /// </summary>
    internal partial class ArtifactLocationTable : Table<ArtifactLocation>
    {
        internal SarifLogDatabase Database;

        internal IColumn<Uri> Uri;
        internal IColumn<string> UriBaseId;
        internal IColumn<int> Index;
        internal RefColumn Description;
        internal IColumn<IDictionary<string, SerializedPropertyInfo>> Properties;

        internal ArtifactLocationTable(SarifLogDatabase database) : base()
        {
            Database = database;

            Uri = AddColumn(nameof(Uri), ColumnFactory.Build<Uri>(default));
            UriBaseId = AddColumn(nameof(UriBaseId), ColumnFactory.Build<string>(default));
            Index = AddColumn(nameof(Index), ColumnFactory.Build<int>(-1));
            Description = AddColumn(nameof(Description), new RefColumn(nameof(SarifLogDatabase.Message)));
            Properties = AddColumn(nameof(Properties), new DictionaryColumn<string, SerializedPropertyInfo>(new DistinctColumn<string>(new StringColumn()), new SerializedPropertyInfoColumn()));
        }

        public override ArtifactLocation Get(int index)
        {
            return (index == -1 ? null : new ArtifactLocation(this, index));
        }
    }
}
