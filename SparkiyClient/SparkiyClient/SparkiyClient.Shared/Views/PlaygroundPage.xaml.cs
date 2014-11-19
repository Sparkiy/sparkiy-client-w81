﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Prism.PubSubEvents;
using SparkiyClient.UILogic.ViewModels;
using SparkiyEngine.Core;
using SparkiyEngine.Engine.Implementation;
using SparkiyEngine.Graphics.DirectX;
using SparkiyClient.Common;

namespace SparkiyClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlaygroundPage : Page
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PlaygroundPage"/> class.
		/// </summary>
        public PlaygroundPage()
        {
			this.DataContext = ViewModelLocator.GetViewModel(this.GetType());
			this.InitializeComponent();
        }

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			this.ViewModel.AssignGraphicsPanel(this.SwapChainPanel);
			this.CodeEditor.OnCodeChanged += (sender, args) => 
				this.ViewModel.AssignCodeEditor(this.CodeEditor);
		}


	    private IPlaygroundViewModel ViewModel
	    {
			get { return this.DataContext as IPlaygroundViewModel; }
	    }
	}
}
