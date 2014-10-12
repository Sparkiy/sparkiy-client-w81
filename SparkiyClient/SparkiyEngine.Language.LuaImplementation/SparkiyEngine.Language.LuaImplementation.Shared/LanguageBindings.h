#pragma once

#include "pch.h"
#include <LuaImplementation.h>


namespace SparkiyEngine_Language_LuaImplementation
{
	private ref class LanguageBindings : SparkiyEngine::Bindings::Language::ILanguageBindings
	{
	public:
		virtual void LoadScript(Platform::String ^id, Platform::String ^content);

	internal:
		LanguageBindings(LuaImplementation ^impl);

	private:
		LuaImplementation							^luaImpl;
	};
}
