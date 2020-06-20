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
    ///  GENERATED: BSOA Entity for 'Run'
    /// </summary>
    [GeneratedCode("BSOA.Generator", "0.5.0")]
    public partial class Run : PropertyBagHolder, ISarifNode, IRow
    {
        private RunTable _table;
        private int _index;

        public Run() : this(SarifLogDatabase.Current.Run)
        { }

        public Run(SarifLog root) : this(root.Database.Run)
        { }

        internal Run(RunTable table) : this(table, table.Count)
        {
            table.Add();
            Init();
        }

        internal Run(RunTable table, int index)
        {
            this._table = table;
            this._index = index;
        }

        public Run(
            Tool tool,
            IList<Invocation> invocations,
            Conversion conversion,
            String language,
            IList<VersionControlDetails> versionControlProvenance,
            IDictionary<String, ArtifactLocation> originalUriBaseIds,
            IList<Artifact> artifacts,
            IList<LogicalLocation> logicalLocations,
            IList<Graph> graphs,
            IList<Result> results,
            RunAutomationDetails automationDetails,
            IList<RunAutomationDetails> runAggregates,
            String baselineGuid,
            IList<String> redactionTokens,
            String defaultEncoding,
            String defaultSourceLanguage,
            IList<String> newlineSequences,
            ColumnKind columnKind,
            ExternalPropertyFileReferences externalPropertyFileReferences,
            IList<ThreadFlowLocation> threadFlowLocations,
            IList<ToolComponent> taxonomies,
            IList<Address> addresses,
            IList<ToolComponent> translations,
            IList<ToolComponent> policies,
            IList<WebRequest> webRequests,
            IList<WebResponse> webResponses,
            SpecialLocations specialLocations,
            IDictionary<String, SerializedPropertyInfo> properties
        ) 
            : this(SarifLogDatabase.Current.Run)
        {
            Tool = tool;
            Invocations = invocations;
            Conversion = conversion;
            Language = language;
            VersionControlProvenance = versionControlProvenance;
            OriginalUriBaseIds = originalUriBaseIds;
            Artifacts = artifacts;
            LogicalLocations = logicalLocations;
            Graphs = graphs;
            Results = results;
            AutomationDetails = automationDetails;
            RunAggregates = runAggregates;
            BaselineGuid = baselineGuid;
            RedactionTokens = redactionTokens;
            DefaultEncoding = defaultEncoding;
            DefaultSourceLanguage = defaultSourceLanguage;
            NewlineSequences = newlineSequences;
            ColumnKind = columnKind;
            ExternalPropertyFileReferences = externalPropertyFileReferences;
            ThreadFlowLocations = threadFlowLocations;
            Taxonomies = taxonomies;
            Addresses = addresses;
            Translations = translations;
            Policies = policies;
            WebRequests = webRequests;
            WebResponses = webResponses;
            SpecialLocations = specialLocations;
            Properties = properties;
        }

        public Run(Run other) 
            : this(SarifLogDatabase.Current.Run)
        {
            Tool = other.Tool;
            Invocations = other.Invocations;
            Conversion = other.Conversion;
            Language = other.Language;
            VersionControlProvenance = other.VersionControlProvenance;
            OriginalUriBaseIds = other.OriginalUriBaseIds;
            Artifacts = other.Artifacts;
            LogicalLocations = other.LogicalLocations;
            Graphs = other.Graphs;
            Results = other.Results;
            AutomationDetails = other.AutomationDetails;
            RunAggregates = other.RunAggregates;
            BaselineGuid = other.BaselineGuid;
            RedactionTokens = other.RedactionTokens;
            DefaultEncoding = other.DefaultEncoding;
            DefaultSourceLanguage = other.DefaultSourceLanguage;
            NewlineSequences = other.NewlineSequences;
            ColumnKind = other.ColumnKind;
            ExternalPropertyFileReferences = other.ExternalPropertyFileReferences;
            ThreadFlowLocations = other.ThreadFlowLocations;
            Taxonomies = other.Taxonomies;
            Addresses = other.Addresses;
            Translations = other.Translations;
            Policies = other.Policies;
            WebRequests = other.WebRequests;
            WebResponses = other.WebResponses;
            SpecialLocations = other.SpecialLocations;
            Properties = other.Properties;
        }

        partial void Init();

        public Tool Tool
        {
            get => _table.Database.Tool.Get(_table.Tool[_index]);
            set => _table.Tool[_index] = _table.Database.Tool.LocalIndex(value);
        }

        public IList<Invocation> Invocations
        {
            get => _table.Database.Invocation.List(_table.Invocations[_index]);
            set => _table.Database.Invocation.List(_table.Invocations[_index]).SetTo(value);
        }

        public Conversion Conversion
        {
            get => _table.Database.Conversion.Get(_table.Conversion[_index]);
            set => _table.Conversion[_index] = _table.Database.Conversion.LocalIndex(value);
        }

        public String Language
        {
            get => _table.Language[_index];
            set => _table.Language[_index] = value;
        }

        public IList<VersionControlDetails> VersionControlProvenance
        {
            get => _table.Database.VersionControlDetails.List(_table.VersionControlProvenance[_index]);
            set => _table.Database.VersionControlDetails.List(_table.VersionControlProvenance[_index]).SetTo(value);
        }

        public IDictionary<String, ArtifactLocation> OriginalUriBaseIds
        {
            get => _table.OriginalUriBaseIds[_index];
            set => _table.OriginalUriBaseIds[_index] = value;
        }

        public IList<Artifact> Artifacts
        {
            get => _table.Database.Artifact.List(_table.Artifacts[_index]);
            set => _table.Database.Artifact.List(_table.Artifacts[_index]).SetTo(value);
        }

        public IList<LogicalLocation> LogicalLocations
        {
            get => _table.Database.LogicalLocation.List(_table.LogicalLocations[_index]);
            set => _table.Database.LogicalLocation.List(_table.LogicalLocations[_index]).SetTo(value);
        }

        public IList<Graph> Graphs
        {
            get => _table.Database.Graph.List(_table.Graphs[_index]);
            set => _table.Database.Graph.List(_table.Graphs[_index]).SetTo(value);
        }

        public IList<Result> Results
        {
            get => _table.Database.Result.List(_table.Results[_index]);
            set => _table.Database.Result.List(_table.Results[_index]).SetTo(value);
        }

        public RunAutomationDetails AutomationDetails
        {
            get => _table.Database.RunAutomationDetails.Get(_table.AutomationDetails[_index]);
            set => _table.AutomationDetails[_index] = _table.Database.RunAutomationDetails.LocalIndex(value);
        }

        public IList<RunAutomationDetails> RunAggregates
        {
            get => _table.Database.RunAutomationDetails.List(_table.RunAggregates[_index]);
            set => _table.Database.RunAutomationDetails.List(_table.RunAggregates[_index]).SetTo(value);
        }

        public String BaselineGuid
        {
            get => _table.BaselineGuid[_index];
            set => _table.BaselineGuid[_index] = value;
        }

        public IList<String> RedactionTokens
        {
            get => _table.RedactionTokens[_index];
            set => _table.RedactionTokens[_index] = value;
        }

        public String DefaultEncoding
        {
            get => _table.DefaultEncoding[_index];
            set => _table.DefaultEncoding[_index] = value;
        }

        public String DefaultSourceLanguage
        {
            get => _table.DefaultSourceLanguage[_index];
            set => _table.DefaultSourceLanguage[_index] = value;
        }

        public IList<String> NewlineSequences
        {
            get => _table.NewlineSequences[_index];
            set => _table.NewlineSequences[_index] = value;
        }

        public ColumnKind ColumnKind
        {
            get => (ColumnKind)_table.ColumnKind[_index];
            set => _table.ColumnKind[_index] = (int)value;
        }

        public ExternalPropertyFileReferences ExternalPropertyFileReferences
        {
            get => _table.Database.ExternalPropertyFileReferences.Get(_table.ExternalPropertyFileReferences[_index]);
            set => _table.ExternalPropertyFileReferences[_index] = _table.Database.ExternalPropertyFileReferences.LocalIndex(value);
        }

        public IList<ThreadFlowLocation> ThreadFlowLocations
        {
            get => _table.Database.ThreadFlowLocation.List(_table.ThreadFlowLocations[_index]);
            set => _table.Database.ThreadFlowLocation.List(_table.ThreadFlowLocations[_index]).SetTo(value);
        }

        public IList<ToolComponent> Taxonomies
        {
            get => _table.Database.ToolComponent.List(_table.Taxonomies[_index]);
            set => _table.Database.ToolComponent.List(_table.Taxonomies[_index]).SetTo(value);
        }

        public IList<Address> Addresses
        {
            get => _table.Database.Address.List(_table.Addresses[_index]);
            set => _table.Database.Address.List(_table.Addresses[_index]).SetTo(value);
        }

        public IList<ToolComponent> Translations
        {
            get => _table.Database.ToolComponent.List(_table.Translations[_index]);
            set => _table.Database.ToolComponent.List(_table.Translations[_index]).SetTo(value);
        }

        public IList<ToolComponent> Policies
        {
            get => _table.Database.ToolComponent.List(_table.Policies[_index]);
            set => _table.Database.ToolComponent.List(_table.Policies[_index]).SetTo(value);
        }

        public IList<WebRequest> WebRequests
        {
            get => _table.Database.WebRequest.List(_table.WebRequests[_index]);
            set => _table.Database.WebRequest.List(_table.WebRequests[_index]).SetTo(value);
        }

        public IList<WebResponse> WebResponses
        {
            get => _table.Database.WebResponse.List(_table.WebResponses[_index]);
            set => _table.Database.WebResponse.List(_table.WebResponses[_index]).SetTo(value);
        }

        public SpecialLocations SpecialLocations
        {
            get => _table.Database.SpecialLocations.Get(_table.SpecialLocations[_index]);
            set => _table.SpecialLocations[_index] = _table.Database.SpecialLocations.LocalIndex(value);
        }

        internal override IDictionary<String, SerializedPropertyInfo> Properties
        {
            get => _table.Properties[_index];
            set => _table.Properties[_index] = value;
        }

        #region IEquatable<Run>
        public bool Equals(Run other)
        {
            if (other == null) { return false; }

            if (this.Tool != other.Tool) { return false; }
            if (this.Invocations != other.Invocations) { return false; }
            if (this.Conversion != other.Conversion) { return false; }
            if (this.Language != other.Language) { return false; }
            if (this.VersionControlProvenance != other.VersionControlProvenance) { return false; }
            if (this.OriginalUriBaseIds != other.OriginalUriBaseIds) { return false; }
            if (this.Artifacts != other.Artifacts) { return false; }
            if (this.LogicalLocations != other.LogicalLocations) { return false; }
            if (this.Graphs != other.Graphs) { return false; }
            if (this.Results != other.Results) { return false; }
            if (this.AutomationDetails != other.AutomationDetails) { return false; }
            if (this.RunAggregates != other.RunAggregates) { return false; }
            if (this.BaselineGuid != other.BaselineGuid) { return false; }
            if (this.RedactionTokens != other.RedactionTokens) { return false; }
            if (this.DefaultEncoding != other.DefaultEncoding) { return false; }
            if (this.DefaultSourceLanguage != other.DefaultSourceLanguage) { return false; }
            if (this.NewlineSequences != other.NewlineSequences) { return false; }
            if (this.ColumnKind != other.ColumnKind) { return false; }
            if (this.ExternalPropertyFileReferences != other.ExternalPropertyFileReferences) { return false; }
            if (this.ThreadFlowLocations != other.ThreadFlowLocations) { return false; }
            if (this.Taxonomies != other.Taxonomies) { return false; }
            if (this.Addresses != other.Addresses) { return false; }
            if (this.Translations != other.Translations) { return false; }
            if (this.Policies != other.Policies) { return false; }
            if (this.WebRequests != other.WebRequests) { return false; }
            if (this.WebResponses != other.WebResponses) { return false; }
            if (this.SpecialLocations != other.SpecialLocations) { return false; }
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
                if (Tool != default(Tool))
                {
                    result = (result * 31) + Tool.GetHashCode();
                }

                if (Invocations != default(IList<Invocation>))
                {
                    result = (result * 31) + Invocations.GetHashCode();
                }

                if (Conversion != default(Conversion))
                {
                    result = (result * 31) + Conversion.GetHashCode();
                }

                if (Language != default(String))
                {
                    result = (result * 31) + Language.GetHashCode();
                }

                if (VersionControlProvenance != default(IList<VersionControlDetails>))
                {
                    result = (result * 31) + VersionControlProvenance.GetHashCode();
                }

                if (OriginalUriBaseIds != default(IDictionary<String, ArtifactLocation>))
                {
                    result = (result * 31) + OriginalUriBaseIds.GetHashCode();
                }

                if (Artifacts != default(IList<Artifact>))
                {
                    result = (result * 31) + Artifacts.GetHashCode();
                }

                if (LogicalLocations != default(IList<LogicalLocation>))
                {
                    result = (result * 31) + LogicalLocations.GetHashCode();
                }

                if (Graphs != default(IList<Graph>))
                {
                    result = (result * 31) + Graphs.GetHashCode();
                }

                if (Results != default(IList<Result>))
                {
                    result = (result * 31) + Results.GetHashCode();
                }

                if (AutomationDetails != default(RunAutomationDetails))
                {
                    result = (result * 31) + AutomationDetails.GetHashCode();
                }

                if (RunAggregates != default(IList<RunAutomationDetails>))
                {
                    result = (result * 31) + RunAggregates.GetHashCode();
                }

                if (BaselineGuid != default(String))
                {
                    result = (result * 31) + BaselineGuid.GetHashCode();
                }

                if (RedactionTokens != default(IList<String>))
                {
                    result = (result * 31) + RedactionTokens.GetHashCode();
                }

                if (DefaultEncoding != default(String))
                {
                    result = (result * 31) + DefaultEncoding.GetHashCode();
                }

                if (DefaultSourceLanguage != default(String))
                {
                    result = (result * 31) + DefaultSourceLanguage.GetHashCode();
                }

                if (NewlineSequences != default(IList<String>))
                {
                    result = (result * 31) + NewlineSequences.GetHashCode();
                }

                if (ColumnKind != default(ColumnKind))
                {
                    result = (result * 31) + ColumnKind.GetHashCode();
                }

                if (ExternalPropertyFileReferences != default(ExternalPropertyFileReferences))
                {
                    result = (result * 31) + ExternalPropertyFileReferences.GetHashCode();
                }

                if (ThreadFlowLocations != default(IList<ThreadFlowLocation>))
                {
                    result = (result * 31) + ThreadFlowLocations.GetHashCode();
                }

                if (Taxonomies != default(IList<ToolComponent>))
                {
                    result = (result * 31) + Taxonomies.GetHashCode();
                }

                if (Addresses != default(IList<Address>))
                {
                    result = (result * 31) + Addresses.GetHashCode();
                }

                if (Translations != default(IList<ToolComponent>))
                {
                    result = (result * 31) + Translations.GetHashCode();
                }

                if (Policies != default(IList<ToolComponent>))
                {
                    result = (result * 31) + Policies.GetHashCode();
                }

                if (WebRequests != default(IList<WebRequest>))
                {
                    result = (result * 31) + WebRequests.GetHashCode();
                }

                if (WebResponses != default(IList<WebResponse>))
                {
                    result = (result * 31) + WebResponses.GetHashCode();
                }

                if (SpecialLocations != default(SpecialLocations))
                {
                    result = (result * 31) + SpecialLocations.GetHashCode();
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
            return Equals(obj as Run);
        }

        public static bool operator ==(Run left, Run right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Run left, Run right)
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
        public SarifNodeKind SarifNodeKind => SarifNodeKind.Run;

        ISarifNode ISarifNode.DeepClone()
        {
            return DeepCloneCore();
        }

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        public Run DeepClone()
        {
            return (Run)DeepCloneCore();
        }

        private ISarifNode DeepCloneCore()
        {
            return new Run(this);
        }
        #endregion

        public static IEqualityComparer<Run> ValueComparer => EqualityComparer<Run>.Default;
        public bool ValueEquals(Run other) => Equals(other);
        public int ValueGetHashCode() => GetHashCode();
    }
}
