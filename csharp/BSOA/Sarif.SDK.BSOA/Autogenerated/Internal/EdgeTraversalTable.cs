// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using BSOA.Column;
using BSOA.Model;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    ///  BSOA GENERATED Table for 'EdgeTraversal'
    /// </summary>
    internal partial class EdgeTraversalTable : Table<EdgeTraversal>
    {
        internal SarifLogDatabase Database;

        internal IColumn<String> EdgeId;
        internal RefColumn Message;
        internal IColumn<IDictionary<String, MultiformatMessageString>> FinalState;
        internal IColumn<int> StepOverEdgeCount;
        internal IColumn<IDictionary<String, SerializedPropertyInfo>> Properties;

        internal EdgeTraversalTable(SarifLogDatabase database) : base()
        {
            Database = database;

            EdgeId = AddColumn(nameof(EdgeId), ColumnFactory.Build<String>(default));
            Message = AddColumn(nameof(Message), new RefColumn(nameof(SarifLogDatabase.Message)));
            FinalState = AddColumn(nameof(FinalState), new DictionaryColumn<String, MultiformatMessageString>(new DistinctColumn<string>(new StringColumn()), new MultiformatMessageStringColumn(this.Database)));
            StepOverEdgeCount = AddColumn(nameof(StepOverEdgeCount), ColumnFactory.Build<int>(default));
            Properties = AddColumn(nameof(Properties), new DictionaryColumn<String, SerializedPropertyInfo>(new DistinctColumn<string>(new StringColumn()), new SerializedPropertyInfoColumn()));
        }

        public override EdgeTraversal Get(int index)
        {
            return (index == -1 ? null : new EdgeTraversal(this, index));
        }
    }
}
