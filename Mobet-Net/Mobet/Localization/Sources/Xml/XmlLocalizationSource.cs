﻿using System;
using System.IO;
using System.Reflection;
using Mobet.Dependency;
using Mobet.Localization.Dictionaries;
using Mobet.Localization.Dictionaries.Xml;

namespace Mobet.Localization.Sources.Xml
{
    /// <summary>
    /// XML based localization source.
    /// It uses XML files to read localized strings.
    /// </summary>
    public class XmlLocalizationSource : DictionaryBasedLocalizationSource, ISingletonDependency
    {
        internal static string RootDirectoryOfApplication { get; set; } //TODO: Find a better way of passing root directory

        static XmlLocalizationSource()
        {
            RootDirectoryOfApplication = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Creates an Xml based localization source.
        /// </summary>
        /// <param name="name">Unique Name of the source</param>
        /// <param name="directoryPath">Directory path of the localization XML files</param>
        public XmlLocalizationSource(string name, string directoryPath)
            : base(name, new XmlFileLocalizationDictionaryProvider(directoryPath))
        {

        }
    }
}
