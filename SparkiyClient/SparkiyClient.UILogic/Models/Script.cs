using System;
using System.Runtime.InteropServices;

namespace SparkiyClient.UILogic.Models
{
	[ComVisible(false)]
	public class Script : CodeFile
	{
		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return String.Format("Script: {0}", this.Name);
		}
	}
}