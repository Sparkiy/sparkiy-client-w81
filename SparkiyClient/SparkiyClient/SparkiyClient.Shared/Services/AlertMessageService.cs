﻿using SparkiyClient.UILogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace SparkiyClient.Services
{
	public class AlertMessageService : IAlertMessageService
	{
		private static bool isShowing = false;

		public async Task ShowAsync(string message, string title)
		{
			await ShowAsync(message, title, null);
		}

		public async Task ShowAsync(string message, string title, IEnumerable<DialogCommand> dialogCommands)
		{
			// Only show one dialog at a time.
			if (!isShowing)
			{
				var messageDialog = new MessageDialog(message, title);

				if (dialogCommands != null)
				{
					var commands = dialogCommands.Select(c => new UICommand(c.Label, (command) => c.Invoked(), c.Id));

					foreach (var command in commands)
					{
						messageDialog.Commands.Add(command);
					}
				}

				isShowing = true;
				await messageDialog.ShowAsync();
				isShowing = false;
			}
		}
	}
}
