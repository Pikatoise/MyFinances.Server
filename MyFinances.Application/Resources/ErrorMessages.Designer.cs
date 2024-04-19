﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyFinances.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyFinances.Application.Resources.ErrorMessages", typeof(ErrorMessages).Assembly);
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
        ///   Looks up a localized string similar to The request could not be sent.
        /// </summary>
        internal static string Api_Fixer_BadRequest {
            get {
                return ResourceManager.GetString("Api.Fixer.BadRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Currency value was expired and need to refresh.
        /// </summary>
        internal static string Currency_Expired {
            get {
                return ResourceManager.GetString("Currency.Expired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requested currency not supported or not loaded yet.
        /// </summary>
        internal static string Currency_NotFound {
            get {
                return ResourceManager.GetString("Currency.NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Field was empty.
        /// </summary>
        internal static string Dto_EmptyField {
            get {
                return ResourceManager.GetString("Dto.EmptyField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value was incorrect.
        /// </summary>
        internal static string Dto_IncorrectValue {
            get {
                return ResourceManager.GetString("Dto.IncorrectValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value was too big.
        /// </summary>
        internal static string Dto_TooBigValue {
            get {
                return ResourceManager.GetString("Dto.TooBigValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value was too low.
        /// </summary>
        internal static string Dto_TooLowValue {
            get {
                return ResourceManager.GetString("Dto.TooLowValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requested operation not found.
        /// </summary>
        internal static string Operation_NotFound {
            get {
                return ResourceManager.GetString("Operation.NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requested operation type not found.
        /// </summary>
        internal static string OperationType_NotFound {
            get {
                return ResourceManager.GetString("OperationType.NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect sorting order.
        /// </summary>
        internal static string Period_IncorrectOrder {
            get {
                return ResourceManager.GetString("Period.IncorrectOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requested period not found.
        /// </summary>
        internal static string Period_NotFound {
            get {
                return ResourceManager.GetString("Period.NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requested amout of periods out of range.
        /// </summary>
        internal static string Period_OutOfRange {
            get {
                return ResourceManager.GetString("Period.OutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requested plan not found.
        /// </summary>
        internal static string Plan_NotFound {
            get {
                return ResourceManager.GetString("Plan.NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Association with that name already exist.
        /// </summary>
        internal static string TypeAssociation_AlreadyExist {
            get {
                return ResourceManager.GetString("TypeAssociation.AlreadyExist", resourceCulture);
            }
        }
    }
}
