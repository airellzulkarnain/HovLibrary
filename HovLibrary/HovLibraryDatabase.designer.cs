﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HovLibrary
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="hov_library")]
	public partial class HovLibraryDatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertbook(book instance);
    partial void Updatebook(book instance);
    partial void Deletebook(book instance);
    partial void Insertbook_detail(book_detail instance);
    partial void Updatebook_detail(book_detail instance);
    partial void Deletebook_detail(book_detail instance);
    partial void Insertbook_location(book_location instance);
    partial void Updatebook_location(book_location instance);
    partial void Deletebook_location(book_location instance);
    partial void Insertemployee(employee instance);
    partial void Updateemployee(employee instance);
    partial void Deleteemployee(employee instance);
    partial void Insertmember(member instance);
    partial void Updatemember(member instance);
    partial void Deletemember(member instance);
    #endregion
		
		public HovLibraryDatabaseDataContext() : 
				base(global::HovLibrary.Properties.Settings.Default.hov_libraryConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public HovLibraryDatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HovLibraryDatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HovLibraryDatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HovLibraryDatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<book> books
		{
			get
			{
				return this.GetTable<book>();
			}
		}
		
		public System.Data.Linq.Table<book_detail> book_details
		{
			get
			{
				return this.GetTable<book_detail>();
			}
		}
		
		public System.Data.Linq.Table<book_location> book_locations
		{
			get
			{
				return this.GetTable<book_location>();
			}
		}
		
		public System.Data.Linq.Table<employee> employees
		{
			get
			{
				return this.GetTable<employee>();
			}
		}
		
		public System.Data.Linq.Table<member> members
		{
			get
			{
				return this.GetTable<member>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.book")]
	public partial class book : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _book_details_id;
		
		private int _book_location_id;
		
		private System.Nullable<int> _member_id;
		
		private System.Nullable<System.DateTime> _borrow_date;
		
		private System.Nullable<System.DateTime> _return_date;
		
		private System.DateTime _created_at;
		
		private System.Nullable<System.DateTime> _updated_at;
		
		private System.Nullable<System.DateTime> _deleted_at;
		
		private EntityRef<book_detail> _book_detail;
		
		private EntityRef<book_location> _book_location;
		
		private EntityRef<member> _member;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onbook_details_idChanging(int value);
    partial void Onbook_details_idChanged();
    partial void Onbook_location_idChanging(int value);
    partial void Onbook_location_idChanged();
    partial void Onmember_idChanging(System.Nullable<int> value);
    partial void Onmember_idChanged();
    partial void Onborrow_dateChanging(System.Nullable<System.DateTime> value);
    partial void Onborrow_dateChanged();
    partial void Onreturn_dateChanging(System.Nullable<System.DateTime> value);
    partial void Onreturn_dateChanged();
    partial void Oncreated_atChanging(System.DateTime value);
    partial void Oncreated_atChanged();
    partial void Onupdated_atChanging(System.Nullable<System.DateTime> value);
    partial void Onupdated_atChanged();
    partial void Ondeleted_atChanging(System.Nullable<System.DateTime> value);
    partial void Ondeleted_atChanged();
    #endregion
		
		public book()
		{
			this._book_detail = default(EntityRef<book_detail>);
			this._book_location = default(EntityRef<book_location>);
			this._member = default(EntityRef<member>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_book_details_id", DbType="Int NOT NULL")]
		public int book_details_id
		{
			get
			{
				return this._book_details_id;
			}
			set
			{
				if ((this._book_details_id != value))
				{
					if (this._book_detail.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onbook_details_idChanging(value);
					this.SendPropertyChanging();
					this._book_details_id = value;
					this.SendPropertyChanged("book_details_id");
					this.Onbook_details_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_book_location_id", DbType="Int NOT NULL")]
		public int book_location_id
		{
			get
			{
				return this._book_location_id;
			}
			set
			{
				if ((this._book_location_id != value))
				{
					if (this._book_location.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onbook_location_idChanging(value);
					this.SendPropertyChanging();
					this._book_location_id = value;
					this.SendPropertyChanged("book_location_id");
					this.Onbook_location_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_member_id", DbType="Int")]
		public System.Nullable<int> member_id
		{
			get
			{
				return this._member_id;
			}
			set
			{
				if ((this._member_id != value))
				{
					if (this._member.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onmember_idChanging(value);
					this.SendPropertyChanging();
					this._member_id = value;
					this.SendPropertyChanged("member_id");
					this.Onmember_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_borrow_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> borrow_date
		{
			get
			{
				return this._borrow_date;
			}
			set
			{
				if ((this._borrow_date != value))
				{
					this.Onborrow_dateChanging(value);
					this.SendPropertyChanging();
					this._borrow_date = value;
					this.SendPropertyChanged("borrow_date");
					this.Onborrow_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_return_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> return_date
		{
			get
			{
				return this._return_date;
			}
			set
			{
				if ((this._return_date != value))
				{
					this.Onreturn_dateChanging(value);
					this.SendPropertyChanging();
					this._return_date = value;
					this.SendPropertyChanged("return_date");
					this.Onreturn_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="DateTime NOT NULL")]
		public System.DateTime created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> updated_at
		{
			get
			{
				return this._updated_at;
			}
			set
			{
				if ((this._updated_at != value))
				{
					this.Onupdated_atChanging(value);
					this.SendPropertyChanging();
					this._updated_at = value;
					this.SendPropertyChanged("updated_at");
					this.Onupdated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> deleted_at
		{
			get
			{
				return this._deleted_at;
			}
			set
			{
				if ((this._deleted_at != value))
				{
					this.Ondeleted_atChanging(value);
					this.SendPropertyChanging();
					this._deleted_at = value;
					this.SendPropertyChanged("deleted_at");
					this.Ondeleted_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="book_detail_book", Storage="_book_detail", ThisKey="book_details_id", OtherKey="id", IsForeignKey=true)]
		public book_detail book_detail
		{
			get
			{
				return this._book_detail.Entity;
			}
			set
			{
				book_detail previousValue = this._book_detail.Entity;
				if (((previousValue != value) 
							|| (this._book_detail.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._book_detail.Entity = null;
						previousValue.books.Remove(this);
					}
					this._book_detail.Entity = value;
					if ((value != null))
					{
						value.books.Add(this);
						this._book_details_id = value.id;
					}
					else
					{
						this._book_details_id = default(int);
					}
					this.SendPropertyChanged("book_detail");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="book_location_book", Storage="_book_location", ThisKey="book_location_id", OtherKey="id", IsForeignKey=true)]
		public book_location book_location
		{
			get
			{
				return this._book_location.Entity;
			}
			set
			{
				book_location previousValue = this._book_location.Entity;
				if (((previousValue != value) 
							|| (this._book_location.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._book_location.Entity = null;
						previousValue.books.Remove(this);
					}
					this._book_location.Entity = value;
					if ((value != null))
					{
						value.books.Add(this);
						this._book_location_id = value.id;
					}
					else
					{
						this._book_location_id = default(int);
					}
					this.SendPropertyChanged("book_location");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="member_book", Storage="_member", ThisKey="member_id", OtherKey="id", IsForeignKey=true)]
		public member member
		{
			get
			{
				return this._member.Entity;
			}
			set
			{
				member previousValue = this._member.Entity;
				if (((previousValue != value) 
							|| (this._member.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._member.Entity = null;
						previousValue.books.Remove(this);
					}
					this._member.Entity = value;
					if ((value != null))
					{
						value.books.Add(this);
						this._member_id = value.id;
					}
					else
					{
						this._member_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("member");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.book_details")]
	public partial class book_detail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _language;
		
		private string _title;
		
		private string _isbn;
		
		private string _isbn13;
		
		private string _authors;
		
		private string _publisher;
		
		private System.DateTime _publish_date;
		
		private int _page_count;
		
		private decimal _ratings;
		
		private int _rating_count;
		
		private System.DateTime _created_at;
		
		private System.Nullable<System.DateTime> _updated_at;
		
		private System.Nullable<System.DateTime> _deleted_at;
		
		private EntitySet<book> _books;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnlanguageChanging(string value);
    partial void OnlanguageChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OnisbnChanging(string value);
    partial void OnisbnChanged();
    partial void Onisbn13Changing(string value);
    partial void Onisbn13Changed();
    partial void OnauthorsChanging(string value);
    partial void OnauthorsChanged();
    partial void OnpublisherChanging(string value);
    partial void OnpublisherChanged();
    partial void Onpublish_dateChanging(System.DateTime value);
    partial void Onpublish_dateChanged();
    partial void Onpage_countChanging(int value);
    partial void Onpage_countChanged();
    partial void OnratingsChanging(decimal value);
    partial void OnratingsChanged();
    partial void Onrating_countChanging(int value);
    partial void Onrating_countChanged();
    partial void Oncreated_atChanging(System.DateTime value);
    partial void Oncreated_atChanged();
    partial void Onupdated_atChanging(System.Nullable<System.DateTime> value);
    partial void Onupdated_atChanged();
    partial void Ondeleted_atChanging(System.Nullable<System.DateTime> value);
    partial void Ondeleted_atChanged();
    #endregion
		
		public book_detail()
		{
			this._books = new EntitySet<book>(new Action<book>(this.attach_books), new Action<book>(this.detach_books));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_language", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string language
		{
			get
			{
				return this._language;
			}
			set
			{
				if ((this._language != value))
				{
					this.OnlanguageChanging(value);
					this.SendPropertyChanging();
					this._language = value;
					this.SendPropertyChanged("language");
					this.OnlanguageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isbn", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string isbn
		{
			get
			{
				return this._isbn;
			}
			set
			{
				if ((this._isbn != value))
				{
					this.OnisbnChanging(value);
					this.SendPropertyChanging();
					this._isbn = value;
					this.SendPropertyChanged("isbn");
					this.OnisbnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isbn13", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string isbn13
		{
			get
			{
				return this._isbn13;
			}
			set
			{
				if ((this._isbn13 != value))
				{
					this.Onisbn13Changing(value);
					this.SendPropertyChanging();
					this._isbn13 = value;
					this.SendPropertyChanged("isbn13");
					this.Onisbn13Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_authors", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string authors
		{
			get
			{
				return this._authors;
			}
			set
			{
				if ((this._authors != value))
				{
					this.OnauthorsChanging(value);
					this.SendPropertyChanging();
					this._authors = value;
					this.SendPropertyChanged("authors");
					this.OnauthorsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_publisher", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string publisher
		{
			get
			{
				return this._publisher;
			}
			set
			{
				if ((this._publisher != value))
				{
					this.OnpublisherChanging(value);
					this.SendPropertyChanging();
					this._publisher = value;
					this.SendPropertyChanged("publisher");
					this.OnpublisherChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_publish_date", DbType="DateTime NOT NULL")]
		public System.DateTime publish_date
		{
			get
			{
				return this._publish_date;
			}
			set
			{
				if ((this._publish_date != value))
				{
					this.Onpublish_dateChanging(value);
					this.SendPropertyChanging();
					this._publish_date = value;
					this.SendPropertyChanged("publish_date");
					this.Onpublish_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_page_count", DbType="Int NOT NULL")]
		public int page_count
		{
			get
			{
				return this._page_count;
			}
			set
			{
				if ((this._page_count != value))
				{
					this.Onpage_countChanging(value);
					this.SendPropertyChanging();
					this._page_count = value;
					this.SendPropertyChanged("page_count");
					this.Onpage_countChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ratings", DbType="Decimal(3,2) NOT NULL")]
		public decimal ratings
		{
			get
			{
				return this._ratings;
			}
			set
			{
				if ((this._ratings != value))
				{
					this.OnratingsChanging(value);
					this.SendPropertyChanging();
					this._ratings = value;
					this.SendPropertyChanged("ratings");
					this.OnratingsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rating_count", DbType="Int NOT NULL")]
		public int rating_count
		{
			get
			{
				return this._rating_count;
			}
			set
			{
				if ((this._rating_count != value))
				{
					this.Onrating_countChanging(value);
					this.SendPropertyChanging();
					this._rating_count = value;
					this.SendPropertyChanged("rating_count");
					this.Onrating_countChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="DateTime NOT NULL")]
		public System.DateTime created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> updated_at
		{
			get
			{
				return this._updated_at;
			}
			set
			{
				if ((this._updated_at != value))
				{
					this.Onupdated_atChanging(value);
					this.SendPropertyChanging();
					this._updated_at = value;
					this.SendPropertyChanged("updated_at");
					this.Onupdated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> deleted_at
		{
			get
			{
				return this._deleted_at;
			}
			set
			{
				if ((this._deleted_at != value))
				{
					this.Ondeleted_atChanging(value);
					this.SendPropertyChanging();
					this._deleted_at = value;
					this.SendPropertyChanged("deleted_at");
					this.Ondeleted_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="book_detail_book", Storage="_books", ThisKey="id", OtherKey="book_details_id")]
		public EntitySet<book> books
		{
			get
			{
				return this._books;
			}
			set
			{
				this._books.Assign(value);
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
		
		private void attach_books(book entity)
		{
			this.SendPropertyChanging();
			entity.book_detail = this;
		}
		
		private void detach_books(book entity)
		{
			this.SendPropertyChanging();
			entity.book_detail = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.book_location")]
	public partial class book_location : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private System.DateTime _created_at;
		
		private System.Nullable<System.DateTime> _updated_at;
		
		private System.Nullable<System.DateTime> _deleted_at;
		
		private EntitySet<book> _books;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void Oncreated_atChanging(System.DateTime value);
    partial void Oncreated_atChanged();
    partial void Onupdated_atChanging(System.Nullable<System.DateTime> value);
    partial void Onupdated_atChanged();
    partial void Ondeleted_atChanging(System.Nullable<System.DateTime> value);
    partial void Ondeleted_atChanged();
    #endregion
		
		public book_location()
		{
			this._books = new EntitySet<book>(new Action<book>(this.attach_books), new Action<book>(this.detach_books));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="DateTime NOT NULL")]
		public System.DateTime created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> updated_at
		{
			get
			{
				return this._updated_at;
			}
			set
			{
				if ((this._updated_at != value))
				{
					this.Onupdated_atChanging(value);
					this.SendPropertyChanging();
					this._updated_at = value;
					this.SendPropertyChanged("updated_at");
					this.Onupdated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> deleted_at
		{
			get
			{
				return this._deleted_at;
			}
			set
			{
				if ((this._deleted_at != value))
				{
					this.Ondeleted_atChanging(value);
					this.SendPropertyChanging();
					this._deleted_at = value;
					this.SendPropertyChanged("deleted_at");
					this.Ondeleted_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="book_location_book", Storage="_books", ThisKey="id", OtherKey="book_location_id")]
		public EntitySet<book> books
		{
			get
			{
				return this._books;
			}
			set
			{
				this._books.Assign(value);
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
		
		private void attach_books(book entity)
		{
			this.SendPropertyChanging();
			entity.book_location = this;
		}
		
		private void detach_books(book entity)
		{
			this.SendPropertyChanging();
			entity.book_location = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.employee")]
	public partial class employee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _email;
		
		private string _password;
		
		private System.DateTime _created_at;
		
		private System.Nullable<System.DateTime> _updated_at;
		
		private System.Nullable<System.DateTime> _deleted_at;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void Oncreated_atChanging(System.DateTime value);
    partial void Oncreated_atChanged();
    partial void Onupdated_atChanging(System.Nullable<System.DateTime> value);
    partial void Onupdated_atChanged();
    partial void Ondeleted_atChanging(System.Nullable<System.DateTime> value);
    partial void Ondeleted_atChanged();
    #endregion
		
		public employee()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="DateTime NOT NULL")]
		public System.DateTime created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> updated_at
		{
			get
			{
				return this._updated_at;
			}
			set
			{
				if ((this._updated_at != value))
				{
					this.Onupdated_atChanging(value);
					this.SendPropertyChanging();
					this._updated_at = value;
					this.SendPropertyChanged("updated_at");
					this.Onupdated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> deleted_at
		{
			get
			{
				return this._deleted_at;
			}
			set
			{
				if ((this._deleted_at != value))
				{
					this.Ondeleted_atChanging(value);
					this.SendPropertyChanging();
					this._deleted_at = value;
					this.SendPropertyChanged("deleted_at");
					this.Ondeleted_atChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.member")]
	public partial class member : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _phone;
		
		private string _email;
		
		private string _city_of_birth;
		
		private System.DateTime _date_of_birth;
		
		private string _gender;
		
		private System.DateTime _created_at;
		
		private System.Nullable<System.DateTime> _updated_at;
		
		private System.Nullable<System.DateTime> _deleted_at;
		
		private EntitySet<book> _books;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void Oncity_of_birthChanging(string value);
    partial void Oncity_of_birthChanged();
    partial void Ondate_of_birthChanging(System.DateTime value);
    partial void Ondate_of_birthChanged();
    partial void OngenderChanging(string value);
    partial void OngenderChanged();
    partial void Oncreated_atChanging(System.DateTime value);
    partial void Oncreated_atChanged();
    partial void Onupdated_atChanging(System.Nullable<System.DateTime> value);
    partial void Onupdated_atChanged();
    partial void Ondeleted_atChanging(System.Nullable<System.DateTime> value);
    partial void Ondeleted_atChanged();
    #endregion
		
		public member()
		{
			this._books = new EntitySet<book>(new Action<book>(this.attach_books), new Action<book>(this.detach_books));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this.OnphoneChanging(value);
					this.SendPropertyChanging();
					this._phone = value;
					this.SendPropertyChanged("phone");
					this.OnphoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city_of_birth", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string city_of_birth
		{
			get
			{
				return this._city_of_birth;
			}
			set
			{
				if ((this._city_of_birth != value))
				{
					this.Oncity_of_birthChanging(value);
					this.SendPropertyChanging();
					this._city_of_birth = value;
					this.SendPropertyChanged("city_of_birth");
					this.Oncity_of_birthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_of_birth", DbType="DateTime NOT NULL")]
		public System.DateTime date_of_birth
		{
			get
			{
				return this._date_of_birth;
			}
			set
			{
				if ((this._date_of_birth != value))
				{
					this.Ondate_of_birthChanging(value);
					this.SendPropertyChanging();
					this._date_of_birth = value;
					this.SendPropertyChanged("date_of_birth");
					this.Ondate_of_birthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gender", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				if ((this._gender != value))
				{
					this.OngenderChanging(value);
					this.SendPropertyChanging();
					this._gender = value;
					this.SendPropertyChanged("gender");
					this.OngenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="DateTime NOT NULL")]
		public System.DateTime created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> updated_at
		{
			get
			{
				return this._updated_at;
			}
			set
			{
				if ((this._updated_at != value))
				{
					this.Onupdated_atChanging(value);
					this.SendPropertyChanging();
					this._updated_at = value;
					this.SendPropertyChanged("updated_at");
					this.Onupdated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted_at", DbType="DateTime")]
		public System.Nullable<System.DateTime> deleted_at
		{
			get
			{
				return this._deleted_at;
			}
			set
			{
				if ((this._deleted_at != value))
				{
					this.Ondeleted_atChanging(value);
					this.SendPropertyChanging();
					this._deleted_at = value;
					this.SendPropertyChanged("deleted_at");
					this.Ondeleted_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="member_book", Storage="_books", ThisKey="id", OtherKey="member_id")]
		public EntitySet<book> books
		{
			get
			{
				return this._books;
			}
			set
			{
				this._books.Assign(value);
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
		
		private void attach_books(book entity)
		{
			this.SendPropertyChanging();
			entity.member = this;
		}
		
		private void detach_books(book entity)
		{
			this.SendPropertyChanging();
			entity.member = null;
		}
	}
}
#pragma warning restore 1591