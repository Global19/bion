// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using BSOA.IO;
using BSOA.Model;

namespace BSOA.Test.Model.V2
{
    /// <summary>
    ///  BSOA GENERATED Root Entity for 'Community'
    /// </summary>
    public partial class Community : IRow
    {
        private CommunityTable _table;
        private int _index;

        public Community() : this(new PersonDatabase().Community)
        { }
        
        internal Community(CommunityTable table) : this(table, table.Count)
        {
            table.Add();
        }

        internal Community(CommunityTable table, int index)
        {
            this._table = table;
            this._index = index;
        }

        public IList<Person> People
        {
            get => _table.Database.Person.List(_table.People[_index]);
            set => _table.Database.Person.List(_table.People[_index]).SetTo(value);
        }


        #region IEquatable<Community>
        public bool Equals(Community other)
        {
            if (other == null) { return false; }

            if (this.People != other.People) { return false; }

            return true;
        }
        #endregion

        #region Object overrides
        public override int GetHashCode()
        {
            int result = 17;

            unchecked
            {
                if (People != default(IList<Person>))
                {
                    result = (result * 31) + People.GetHashCode();
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Community);
        }

        public static bool operator ==(Community left, Community right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Community left, Community right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return !object.ReferenceEquals(right, null);
            }

            return !left.Equals(right);
        }
        #endregion

        #region IRow
        ITable IRow.Table => _table;
        int IRow.Index => _index;

        void IRow.Reset(ITable table, int index)
        {
            _table = (CommunityTable)table;
            _index = index;
        }
        #endregion

        internal PersonDatabase Database => _table.Database;
        public ITreeSerializable DB => _table.Database;
    }
}