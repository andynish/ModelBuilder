﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelBuilder.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ModelBuilder.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No public constructor is available for type {0}..
        /// </summary>
        internal static string ConstructorResolver_NoPublicConstructorFound {
            get {
                return ResourceManager.GetString("ConstructorResolver_NoPublicConstructorFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expression &apos;{0}&apos; does not refer to a property..
        /// </summary>
        internal static string Error_ExpressionNotPropertyFormat {
            get {
                return ResourceManager.GetString("Error_ExpressionNotPropertyFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} does not support the {1} type..
        /// </summary>
        internal static string Error_TypeNotSupportedFormat {
            get {
                return ResourceManager.GetString("Error_TypeNotSupportedFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No supporting ITypeCreator or IValueGenerator was found to build the type &apos;{0}&apos;..
        /// </summary>
        internal static string NoMatchingCreatorOrGeneratorFound {
            get {
                return ResourceManager.GetString("NoMatchingCreatorOrGeneratorFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No supporting ITypeCreator or IValueGenerator was found to build the type &apos;{0}&apos; for &apos;{1}&apos;..
        /// </summary>
        internal static string NoMatchingCreatorOrGeneratorFoundWithName {
            get {
                return ResourceManager.GetString("NoMatchingCreatorOrGeneratorFoundWithName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No supporting ITypeCreator or IValueGenerator was found to build the type &apos;{0}&apos; for &apos;{1}&apos; on type &apos;{2}&apos;..
        /// </summary>
        internal static string NoMatchingCreatorOrGeneratorFoundWithNameAndContext {
            get {
                return ResourceManager.GetString("NoMatchingCreatorOrGeneratorFoundWithNameAndContext", resourceCulture);
            }
        }
    }
}
