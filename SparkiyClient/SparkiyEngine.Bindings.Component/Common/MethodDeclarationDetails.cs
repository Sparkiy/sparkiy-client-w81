using System;
using System.Collections.Generic;

namespace SparkiyEngine.Bindings.Component.Common
{
	public sealed class MethodDeclarationDetails
	{
		public MethodDeclarationDetails()
		{
			this.Overloads = new List<MethodDeclarationOverloadDetails>();
		}


		public string Name { get; set; }

		public IEnumerable<MethodDeclarationOverloadDetails> Overloads { get; private set; } 
	}
}