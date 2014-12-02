﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GalaSoft.MvvmLight;

namespace SparkiyClient.Common
{
    [ComVisible(false)]
	public class ExtendedViewModel : ViewModelBase, IPropertyManagerImplementer, INotifyPropertyChangedTrigger
    {
	    private readonly PropertyManager propertyManager;


		public ExtendedViewModel()
		{
			this.propertyManager = new PropertyManager(this);
		}


		public void SetProperty<T>(T value = default(T), string propertyName = "")
		{
			// ReSharper disable once ExplicitCallerInfoArgument
			this.propertyManager.SetProperty(value, propertyName);
		}

		public T GetProperty<T>([CallerMemberName] string propertyName = "", T defaultValue = default(T))
		{
			// ReSharper disable once ExplicitCallerInfoArgument
			return this.propertyManager.GetProperty(propertyName, defaultValue);
		}

		public new void RaisePropertyChanged(string propertyName = null)
		{
			// ReSharper disable once ExplicitCallerInfoArgument
			base.RaisePropertyChanged(propertyName);
		}
	}

	[ComVisible(false)]
	public class ExtendedObservableObject : ObservableObject, IPropertyManagerImplementer, INotifyPropertyChangedTrigger
	{
		private readonly PropertyManager propertyManager;


		public ExtendedObservableObject()
		{
			this.propertyManager = new PropertyManager(this);
		}


		public void SetProperty<T>(T value = default(T), string propertyName = "")
		{
			// ReSharper disable once ExplicitCallerInfoArgument
			this.propertyManager.SetProperty(value, propertyName);
		}

		public T GetProperty<T>([CallerMemberName] string propertyName = "", T defaultValue = default(T))
		{
			// ReSharper disable once ExplicitCallerInfoArgument
			return this.propertyManager.GetProperty(propertyName, defaultValue);
		}

		public new void RaisePropertyChanged(string propertyName = null)
		{
			// ReSharper disable once ExplicitCallerInfoArgument
			base.RaisePropertyChanged(propertyName);
		}
	}

	[ComVisible(false)]
	internal interface IPropertyDirtyManager
	{
		bool IsDirty { get; }

		void MarkAsClean();
	}

	[ComVisible(false)]
	internal interface IPropertyManagerImplementer
	{
		void SetProperty<T>(T value = default(T), [CallerMemberName] string propertyName = "");

		T GetProperty<T>([CallerMemberName] string propertyName = "", T defaultValue = default(T));
	}

	internal interface INotifyPropertyChangedTrigger : INotifyPropertyChanged
	{
		void RaisePropertyChanged([CallerMemberName] string propertyName = null);
	}

	[ComVisible(false)]
	internal class PropertyManager : IPropertyManagerImplementer, IPropertyDirtyManager
	{
		private bool isDirty;
		private readonly INotifyPropertyChangedTrigger trigger;
		private readonly Dictionary<string, object> propertyValues = new Dictionary<string, object>();


		public PropertyManager(INotifyPropertyChangedTrigger trigger)
		{
			this.trigger = trigger;
		}


		public void SetProperty<T>(T value = default(T), [CallerMemberName] string propertyName = "")
		{
			// Trigger all properties if null or empty string is passed
			if (String.IsNullOrEmpty(propertyName))
			{
				// ReSharper disable once ExplicitCallerInfoArgument
				this.trigger.RaisePropertyChanged(String.Empty);
				return;
			}

			// Check if value changed
			if (this.propertyValues.ContainsKey(propertyName))
			{
				// ReSharper disable once ExplicitCallerInfoArgument
				T oldValue = this.GetProperty<T>(propertyName);
				if (value.Equals(oldValue))
					return;
			}

			// Set value
			this.propertyValues[propertyName] = value;

			// ReSharper disable once ExplicitCallerInfoArgument
			this.trigger.RaisePropertyChanged(propertyName);
		}

		public T GetProperty<T>([CallerMemberName] string propertyName = "", T defaultValue = default(T))
		{
			if (!this.propertyValues.ContainsKey(propertyName))
				return defaultValue;
			return (T)this.propertyValues[propertyName];
		}
		
		public bool IsDirty => this.isDirty;

		public void MarkAsClean()
		{
			this.isDirty = false;
		}
	}
}
