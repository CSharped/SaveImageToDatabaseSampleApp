﻿using System;
using System.IO;

using SQLite;

using Xamarin.Forms;

using SaveImageToDatabaseSampleApp.iOS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace SaveImageToDatabaseSampleApp.iOS
{
	public class SQLite_iOS : ISQLite
	{
		
		#region ISQLite implementation
		public SQLiteAsyncConnection GetConnection()
		{
			var sqliteFilename = "ImageDatabaseModelSQLite.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

			var conn = new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}

