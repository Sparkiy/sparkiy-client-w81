﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SparkiyEngine.Bindings.Component.Common;

namespace SparkiyEngine.Bindings.Common.Test.Windows
{
	[TestClass]
	public class BindingVersionTest
	{
		[TestMethod]
		public void EqualsTest()
		{
			var versionA1 = new BindingsVersion()
			{
				Major = 1,
				Minor = 84,
				Revision = 3
			};
			var versionB1 = new BindingsVersion()
			{
				Major = 3,
				Minor = 84,
				Revision = 3
			};
			var versionB2 = new BindingsVersion()
			{
				Major = 1,
				Minor = 84,
				Revision = 3
			};

			versionA1.Should().Be(versionB2);
			versionA1.Should().NotBe(versionB1);
		}

		[TestMethod]
		public void EqualsAnyTest()
		{
			var versionA1 = new BindingsVersion()
			{
				Major = 1,
				Minor = 84,
				Revision = 3
			};
			var versionB1 = new BindingsVersion()
			{
				Major = 0,
				Minor = 0,
				Revision = 0
			};

			versionA1.Should().Be(versionB1);
			versionB1.Should().Be(versionA1);
		}
	}
}
