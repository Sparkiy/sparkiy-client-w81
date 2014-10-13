#include "pch.h"
#include "LuaImplementation.h"
#include "LanguageBindings.h"

using namespace SparkiyEngine_Language_LuaImplementation;


// Constructor
LuaImplementation::LuaImplementation()
{
	this->Initialize();
}

//
// Initialize
//
void LuaImplementation::Initialize()
{
	// Create language bindings 
	this->m_languageBindings = ref new LanguageBindings(this);
}

// 
// GetLanguageBindings
//
SparkiyEngine::Bindings::Language::ILanguageBindings^ LuaImplementation::GetLanguageBindings()
{
	return this->m_languageBindings;
}

//
// AddScript
//
void LuaImplementation::AddScript(const char * id, LuaScript *script)
{
	this->m_scripts[id] = script;

	OutputDebugStringW(GetWString("Added script with id(" + GetString(id) + ")\n").c_str());
}

// 
// GetScript
//
LuaScript* LuaImplementation::GetScript(const char * id)
{
	return this->m_scripts[id];
}
