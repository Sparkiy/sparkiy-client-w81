﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using SparkiyEngine.Bindings.Component.Common;

namespace SparkiyEngine.Bindings.Component.Language
{
	public interface ILanguageBindings : IBindingsBase
	{
		//
		// Methods
		//
		void MapToGraphicsMethods(IReadOnlyDictionary<string, MethodDeclarationDetails> declarations);
		object CallMethod(string script, string name, MethodDeclarationOverloadDetails declaration, [ReadOnlyArray] object[] paramValues);
		object CallMethod(string name, MethodDeclarationOverloadDetails declaration, [ReadOnlyArray] object[] paramValues);

        //
        // Variables and Constants
        //
	    void SetConstant(string name, object value, DataTypes dataType);
	    void SetVariable(string name, object value, DataTypes dataType);

		//
		// Scripts
		// 
	    bool LoadScript(string id, string content);
	    void StartScript(string id);

		// 
		// Settings
		//
		void Reset();

		//
		// Error
		//
		LanguageScriptError GetError();

        /// <summary>
        /// Gets the language that is implemented with this instance of bindings.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        SupportedLanguages Language { get; }
	}
}
