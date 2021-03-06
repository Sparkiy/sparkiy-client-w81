using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SparkiyClient.Views;

namespace SparkiyClient.Common
{
	public class PageBase : Page, IPageBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PageBase"/> class.
		/// </summary>
		public PageBase()
		{
		}


		///// <summary>
		///// Saves the state during page navigation. Save any data that can be used
		///// </summary>
		///// <param name="sender">The sender.</param>
		///// <param name="e">The <see cref="SaveStateEventArgs"/> instance containing the event data.</param>
		//protected virtual void SaveState(object sender, SaveStateEventArgs e)
		//{
		//}

		///// <summary>
		///// Populates the page with content passed during navigation.  Any saved state is also
		///// provided when recreating a page from a prior session.
		///// </summary>
		///// <param name="sender">
		///// The source of the event; typically <see cref="NavigationHelper"/>
		///// </param>
		///// <param name="e">Event data that provides both the navigation parameter passed to
		///// <see cref="Frame.Navigate(Type, object)"/> when this page was initially requested and
		///// a dictionary of state preserved by this page during an earlier
		///// session.  The state will be null the first time a page is visited.</param>
		//protected virtual void LoadState(object sender, LoadStateEventArgs e)
		//{
		//}

		#region NavigationHelper registration

		/// The methods provided in this section are simply used to allow
		/// NavigationHelper to respond to the page's navigation methods.
		/// 
		/// Page specific logic should be placed in event handlers for the  
		/// <see cref="Views.NavigationHelper.LoadState"/>
		/// and <see cref="Views.NavigationHelper.SaveState"/>.
		/// The navigation parameter is available in the LoadState method 
		/// in addition to page state preserved during an earlier session.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			this.ViewModel.OnNavigatedTo(e);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			this.ViewModel.OnNavigatedFrom(e);
		}

		#endregion

		/// <summary>
		/// View Model
		/// </summary>
		protected ExtendedViewModel ViewModel { get { return this.DataContext as ExtendedViewModel; } }
	}
}