// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;

using BSOA.IO;

using Microsoft.CodeAnalysis.Sarif.Readers;

using Newtonsoft.Json;

namespace Microsoft.CodeAnalysis.Sarif
{
    public enum SarifFormat
    {
        JSON,
        BSOA
    }

    public partial class SarifLog
    {
        public override string ToString()
        {
            return $"{Runs.Sum((run) => run?.Results?.Count ?? 0):n0} {nameof(Result)}s";
        }

        internal static SarifFormat FormatForFileName(string filePath)
        {
            return (Path.GetExtension(filePath).ToLowerInvariant() == ".bsoa" ? SarifFormat.BSOA : SarifFormat.JSON);
        }

        /// <summary>
        ///  Load a SARIF file into a SarifLog object model instance using deferred loading.
        ///  [Less memory use, but slower; safe for large Sarif]
        /// </summary>
        /// <param name="sarifFilePath">File Path to Sarif file to load</param>
        /// <returns>SarifLog instance for file</returns>
        public static SarifLog LoadDeferred(string sarifFilePath)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.ContractResolver = new SarifDeferredContractResolver();

            using (JsonPositionedTextReader jptr = new JsonPositionedTextReader(sarifFilePath))
            {
                return serializer.Deserialize<SarifLog>(jptr);
            }
        }

        /// <summary>
        ///  Load a SARIF file into a SarifLog object model instance.
        ///  [File is fully loaded; more RAM but faster]
        /// </summary>
        /// <param name="sarifFilePath">File Path to Sarif file to load</param>
        /// <returns>SarifLog instance for file</returns>
        public static SarifLog Load(string sarifFilePath)
        {
            using (Stream stream = File.OpenRead(sarifFilePath))
            {
                return Load(stream, FormatForFileName(sarifFilePath));
            }
        }

        /// <summary>
        ///  Load a SARIF stream into a SarifLog object model instance.
        ///  [File is fully loaded; more RAM but faster]
        /// </summary>
        /// <param name="source">Stream with SARIF to load</param>
        /// <returns>SarifLog instance for file</returns>
        public static SarifLog Load(Stream source, SarifFormat format = SarifFormat.JSON)
        {
            if (format == SarifFormat.BSOA)
            {
                using (BinaryTreeReader reader = new BinaryTreeReader(source))
                {
                    SarifLog log = new SarifLog();
                    log.DB.Read(reader);
                    return log;
                }
            }
            else
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader sr = new StreamReader(source))
                using (JsonTextReader jtr = new JsonTextReader(sr))
                {
                    // NOTE: Load with JsonSerializer.Deserialize, not JsonConvert.DeserializeObject, to avoid a string of the whole file in memory.
                    return serializer.Deserialize<SarifLog>(jtr);
                }
            }
        }

        /// <summary>
        ///  Write a SARIF log to disk as a file.
        /// </summary>
        /// <param name="sarifFilePath">File Path to Sarif file to write to</param>
        public void Save(string sarifFilePath)
        {
            using (FileStream stream = File.Create(sarifFilePath))
            {
                this.Save(stream, FormatForFileName(sarifFilePath));
            }
        }

        /// <summary>
        ///  Write a SARIF log to a destination stream.
        /// </summary>
        /// <param name="streamWriter">Stream to write SARIF to</param>
        public void Save(Stream stream, SarifFormat format = SarifFormat.JSON)
        {
            if (format == SarifFormat.BSOA)
            {
                using (BinaryTreeWriter writer = new BinaryTreeWriter(stream))
                {
                    this.DB.Write(writer);
                }
            }
            else
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter(stream))
                using (JsonTextWriter jtw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jtw, this);
                }
            }
        }
    }
}