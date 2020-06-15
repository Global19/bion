// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

using BSOA.IO;
using BSOA.Model;

using Microsoft.CodeAnalysis.Sarif;
using Microsoft.CodeAnalysis.Sarif.Readers;

using Newtonsoft.Json;

namespace BSOA.Generator.Templates
{
    /// <summary>
    ///  GENERATED: BSOA Root Entity for 'Company'
    /// </summary>
    [DataContract]
    [GeneratedCode("BSOA.Generator", "0.5.0")]
    public partial class Company : PropertyBagHolder, ISarifNode, IRow
    {
        private CompanyTable _table;
        private int _index;

        public Company() : this(new CompanyDatabase().Company)
        { }
        
        internal Company(CompanyTable table) : this(table, table.Count)
        {
            table.Add();
        }

        internal Company(CompanyTable table, int index)
        {
            this._table = table;
            this._index = index;
        }

        public Company(
            // <ArgumentList>
            //  <Argument>
            long id,
            //  </Argument>
            SecurityPolicy joinPolicy,
            Employee owner,
            IList<Employee> members
        // </ArgumentList>
        ) : this()
        {
            // <AssignmentList>
            //  <Assignment>
            Id = id;
            //  </Assignment>
            WhenFormed = whenFormed;
            JoinPolicy = joinPolicy;
            Attributes = attributes;
            Owner = owner;
            Members = members;
            // </AssignmentList>
        }

        public Company(Company other)
            : this()
        {
            // <OtherAssignmentList>
            //  <OtherAssignment>
            Id = other.Id;
            //  </OtherAssignment>
            JoinPolicy = other.JoinPolicy;
            Owner = other.Owner;
            Members = other.Members;
            // </OtherAssignmentList>
        }

        // <ColumnList>
        //   <SimpleColumn>
        [DataMember(Name = "id", IsRequired = false, EmitDefaultValue = false)]
        [DefaultValue(99)]
        public long Id
        {
            get => _table.Id[_index];
            set => _table.Id[_index] = value;
        }

        //   </SimpleColumn>
        //   <EnumColumn>
        [DataMember(Name = "joinPolicy", IsRequired = false, EmitDefaultValue = false)]
        [JsonConverter(typeof(Microsoft.CodeAnalysis.Sarif.Readers.EnumConverter))]
        public SecurityPolicy JoinPolicy
        {
            get => (SecurityPolicy)_table.JoinPolicy[_index];
            set => _table.JoinPolicy[_index] = (byte)value;
        }

        //   </EnumColumn>
        //   <RefColumn>
        [DataMember(Name = "owner", IsRequired = false, EmitDefaultValue = false)]
        public Employee Owner
        {
            get => _table.Database.Employee.Get(_table.Owner[_index]);
            set => _table.Manager[_index] = _table.Database.Employee.LocalIndex(value);
        }

        //   </RefColumn>
        //   <RefListColumn>
        [DataMember(Name = "members", IsRequired = false, EmitDefaultValue = false)]
        public IList<Employee> Members
        {
            get => _table.Database.Employee.List(_table.Members[_index]);
            set => _table.Database.Employee.List(_table.Members[_index]).SetTo(value);
        }

        //   </RefListColumn>
        // </ColumnList>

        #region IEquatable<Company>
        public bool Equals(Company other)
        {
            if (other == null) { return false; }

            // <EqualsList>
            //  <Equals>
            if (this.Id != other.Id) { return false; }
            //  </Equals>
            if (this.JoinPolicy != other.JoinPolicy) { return false; }
            if (this.Owner != other.Owner) { return false; }
            if (this.Members != other.Members) { return false; }
            // </EqualsList>

            return true;
        }
        #endregion

        #region Object overrides
        public override int GetHashCode()
        {
            int result = 17;

            unchecked
            {
                // <GetHashCodeList>
                //  <GetHashCode>
                if (Id != default(long))
                {
                    result = (result * 31) + Id.GetHashCode();
                }

                //  </GetHashCode>

                if (JoinPolicy != default(SecurityPolicy))
                {
                    result = (result * 31) + JoinPolicy.GetHashCode();
                }

                if (Owner != default(Employee))
                {
                    result = (result * 31) + Owner.GetHashCode();
                }

                if (Members != default(IList<Employee>))
                {
                    result = (result * 31) + Members.GetHashCode();
                }
                // </GetHashCodeList>
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Company);
        }

        public static bool operator ==(Company left, Company right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Company left, Company right)
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
            _table = (CompanyTable)table;
            _index = index;
        }
        #endregion

        #region ISarifNode
        public SarifNodeKind SarifNodeKind => SarifNodeKind.Company;

        ISarifNode ISarifNode.DeepClone()
        {
            return DeepCloneCore();
        }

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        public Company DeepClone()
        {
            return (Company)DeepCloneCore();
        }

        private ISarifNode DeepCloneCore()
        {
            return new Company(this);
        }
        #endregion

        public static IEqualityComparer<Company> ValueComparer => EqualityComparer<Company>.Default;
        public bool ValueEquals(Company other) => Equals(other);
        public int ValueGetHashCode() => GetHashCode();

        internal CompanyDatabase Database => _table.Database;
        public ITreeSerializable DB => _table.Database;
    }
}