﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wpu221_lesson3__LINQ
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
    using System.Configuration;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Geography")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertCountries(Countries instance);
    partial void UpdateCountries(Countries instance);
    partial void DeleteCountries(Countries instance);
    #endregion
		
		public DataClasses1DataContext() : base(ConfigurationManager.ConnectionStrings["SQL_dbGeography"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Countries> Countries
		{
			get
			{
				return this.GetTable<Countries>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Countries")]
	public partial class Countries : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _Сapital;
		
		private string _PartOfTheWorld;
		
		private System.Nullable<float> _Area;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnСapitalChanging(string value);
    partial void OnСapitalChanged();
    partial void OnPartOfTheWorldChanging(string value);
    partial void OnPartOfTheWorldChanged();
    partial void OnAreaChanging(System.Nullable<float> value);
    partial void OnAreaChanged();
    #endregion
		
		public Countries()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Сapital", DbType="NVarChar(50)")]
		public string Сapital
		{
			get
			{
				return this._Сapital;
			}
			set
			{
				if ((this._Сapital != value))
				{
					this.OnСapitalChanging(value);
					this.SendPropertyChanging();
					this._Сapital = value;
					this.SendPropertyChanged("Сapital");
					this.OnСapitalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PartOfTheWorld", DbType="NVarChar(50)")]
		public string PartOfTheWorld
		{
			get
			{
				return this._PartOfTheWorld;
			}
			set
			{
				if ((this._PartOfTheWorld != value))
				{
					this.OnPartOfTheWorldChanging(value);
					this.SendPropertyChanging();
					this._PartOfTheWorld = value;
					this.SendPropertyChanged("PartOfTheWorld");
					this.OnPartOfTheWorldChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Area", DbType="Real")]
		public System.Nullable<float> Area
		{
			get
			{
				return this._Area;
			}
			set
			{
				if ((this._Area != value))
				{
					this.OnAreaChanging(value);
					this.SendPropertyChanging();
					this._Area = value;
					this.SendPropertyChanged("Area");
					this.OnAreaChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
