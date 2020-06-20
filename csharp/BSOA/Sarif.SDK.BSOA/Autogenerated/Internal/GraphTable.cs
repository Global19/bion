// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using BSOA.Column;
using BSOA.Model;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    ///  BSOA GENERATED Table for 'Graph'
    /// </summary>
    internal partial class GraphTable : Table<Graph>
    {
        internal SarifLogDatabase Database;

        internal RefColumn Description;
        internal RefListColumn Nodes;
        internal RefListColumn Edges;
        internal IColumn<IDictionary<String, SerializedPropertyInfo>> Properties;

        internal GraphTable(SarifLogDatabase database) : base()
        {
            Database = database;

            Description = AddColumn(nameof(Description), new RefColumn(nameof(SarifLogDatabase.Message)));
            Nodes = AddColumn(nameof(Nodes), new RefListColumn(nameof(SarifLogDatabase.Node)));
            Edges = AddColumn(nameof(Edges), new RefListColumn(nameof(SarifLogDatabase.Edge)));
            Properties = AddColumn(nameof(Properties), new DictionaryColumn<String, SerializedPropertyInfo>(new DistinctColumn<string>(new StringColumn()), new SerializedPropertyInfoColumn()));
        }

        public override Graph Get(int index)
        {
            return (index == -1 ? null : new Graph(this, index));
        }
    }
}
