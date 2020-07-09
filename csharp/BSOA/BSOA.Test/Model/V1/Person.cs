// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using BSOA.Collections;
using BSOA.Model;

namespace BSOA.Test.Model.V1
{
    /// <summary>
    ///  BSOA GENERATED Entity for 'Person'
    /// </summary>
    public partial class Person : IRow<Person>, IEquatable<Person>
    {
        private readonly PersonTable _table;
        private readonly int _index;

        public Person() : this(PersonDatabase.Current.Person)
        { }

        public Person(Community root) : this(root.Database.Person)
        { }

        public Person(Community root, Person other) : this(root.Database.Person)
        {
            CopyFrom(other);
        }

        internal Person(PersonTable table) : this(table, table.Add()._index)
        {
            Init();
        }

        internal Person(PersonTable table, int index)
        {
            this._table = table;
            this._index = index;
        }

        partial void Init();

        public byte Age
        {
            get => _table.Age[_index];
            set => _table.Age[_index] = value;
        }

        public string Name
        {
            get => _table.Name[_index];
            set => _table.Name[_index] = value;
        }

        #region IEquatable<Person>
        public bool Equals(Person other)
        {
            if (other == null) { return false; }

            if (!object.Equals(this.Age, other.Age)) { return false; }
            if (!object.Equals(this.Name, other.Name)) { return false; }

            return true;
        }
        #endregion

        #region Object overrides
        public override int GetHashCode()
        {
            int result = 17;

            unchecked
            {
                if (Age != default(byte))
                {
                    result = (result * 31) + Age.GetHashCode();
                }

                if (Name != default(string))
                {
                    result = (result * 31) + Name.GetHashCode();
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public static bool operator ==(Person left, Person right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return !object.ReferenceEquals(right, null);
            }

            return !left.Equals(right);
        }
        #endregion

        #region IRow
        ITable IRow<Person>.Table => _table;
        int IRow<Person>.Index => _index;

        public void CopyFrom(Person other)
        {
            Age = other.Age;
            Name = other.Name;
        }
        #endregion
    }
}
