// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

using BSOA.Model;

using Microsoft.CodeAnalysis.Sarif;
using Microsoft.CodeAnalysis.Sarif.Readers;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    ///  GENERATED: BSOA Entity for 'ExceptionData'
    /// </summary>
    [GeneratedCode("BSOA.Generator", "0.5.0")]
    public partial class ExceptionData : PropertyBagHolder, ISarifNode, IRow
    {
        private ExceptionDataTable _table;
        private int _index;

        public ExceptionData() : this(SarifLogDatabase.Current.ExceptionData)
        { }

        public ExceptionData(SarifLog root) : this(root.Database.ExceptionData)
        { }

        internal ExceptionData(ExceptionDataTable table) : this(table, table.Count)
        {
            table.Add();
            Init();
        }

        internal ExceptionData(ExceptionDataTable table, int index)
        {
            this._table = table;
            this._index = index;
        }

        public ExceptionData(
            String kind,
            String message,
            Stack stack,
            IList<ExceptionData> innerExceptions,
            IDictionary<String, SerializedPropertyInfo> properties
        ) 
            : this(SarifLogDatabase.Current.ExceptionData)
        {
            Kind = kind;
            Message = message;
            Stack = stack;
            InnerExceptions = innerExceptions;
            Properties = properties;
        }

        public ExceptionData(ExceptionData other) 
            : this(SarifLogDatabase.Current.ExceptionData)
        {
            Kind = other.Kind;
            Message = other.Message;
            Stack = other.Stack;
            InnerExceptions = other.InnerExceptions;
            Properties = other.Properties;
        }

        partial void Init();

        public String Kind
        {
            get => _table.Kind[_index];
            set => _table.Kind[_index] = value;
        }

        public String Message
        {
            get => _table.Message[_index];
            set => _table.Message[_index] = value;
        }

        public Stack Stack
        {
            get => _table.Database.Stack.Get(_table.Stack[_index]);
            set => _table.Stack[_index] = _table.Database.Stack.LocalIndex(value);
        }

        public IList<ExceptionData> InnerExceptions
        {
            get => _table.Database.ExceptionData.List(_table.InnerExceptions[_index]);
            set => _table.Database.ExceptionData.List(_table.InnerExceptions[_index]).SetTo(value);
        }

        internal override IDictionary<String, SerializedPropertyInfo> Properties
        {
            get => _table.Properties[_index];
            set => _table.Properties[_index] = value;
        }

        #region IEquatable<ExceptionData>
        public bool Equals(ExceptionData other)
        {
            if (other == null) { return false; }

            if (this.Kind != other.Kind) { return false; }
            if (this.Message != other.Message) { return false; }
            if (this.Stack != other.Stack) { return false; }
            if (this.InnerExceptions != other.InnerExceptions) { return false; }
            if (this.Properties != other.Properties) { return false; }

            return true;
        }
        #endregion

        #region Object overrides
        public override int GetHashCode()
        {
            int result = 17;

            unchecked
            {
                if (Kind != default(String))
                {
                    result = (result * 31) + Kind.GetHashCode();
                }

                if (Message != default(String))
                {
                    result = (result * 31) + Message.GetHashCode();
                }

                if (Stack != default(Stack))
                {
                    result = (result * 31) + Stack.GetHashCode();
                }

                if (InnerExceptions != default(IList<ExceptionData>))
                {
                    result = (result * 31) + InnerExceptions.GetHashCode();
                }

                if (Properties != default(IDictionary<String, SerializedPropertyInfo>))
                {
                    result = (result * 31) + Properties.GetHashCode();
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ExceptionData);
        }

        public static bool operator ==(ExceptionData left, ExceptionData right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(ExceptionData left, ExceptionData right)
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

        void IRow.Next()
        {
            _index++;
        }
        #endregion

        #region ISarifNode
        public SarifNodeKind SarifNodeKind => SarifNodeKind.ExceptionData;

        ISarifNode ISarifNode.DeepClone()
        {
            return DeepCloneCore();
        }

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        public ExceptionData DeepClone()
        {
            return (ExceptionData)DeepCloneCore();
        }

        private ISarifNode DeepCloneCore()
        {
            return new ExceptionData(this);
        }
        #endregion

        public static IEqualityComparer<ExceptionData> ValueComparer => EqualityComparer<ExceptionData>.Default;
        public bool ValueEquals(ExceptionData other) => Equals(other);
        public int ValueGetHashCode() => GetHashCode();
    }
}
