/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using Npgsql;
using PetaPoco;
using Serilog;

namespace MixERP.Net.Schemas.Transactions.Data
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "transactions.stock_return".
    /// </summary>
    public class StockReturn : DbAccess
    {
        /// <summary>
        /// The schema of this table. Returns literal "transactions".
        /// </summary>
	    public override string ObjectNamespace => "transactions";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "stock_return".
        /// </summary>
	    public override string ObjectName => "stock_return";

        /// <summary>
        /// Login id of application user accessing this table.
        /// </summary>
		public long LoginId { get; set; }

        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string Catalog { get; set; }

		/// <summary>
		/// Performs SQL count on the table "transactions.stock_return".
		/// </summary>
		/// <returns>Returns the number of rows of the table "transactions.stock_return".</returns>
		public long Count()
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return 0;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"StockReturn\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT COUNT(*) FROM transactions.stock_return;";
			return Factory.Scalar<long>(this.Catalog, sql);
		}

		/// <summary>
		/// Executes a select query on the table "transactions.stock_return" with a where filter on the column "sales_return_id" to return a single instance of the "StockReturn" class. 
		/// </summary>
		/// <param name="salesReturnId">The column "sales_return_id" parameter used on where filter.</param>
		/// <returns>Returns a non-live, non-mapped instance of "StockReturn" class mapped to the database row.</returns>
		public MixERP.Net.Entities.Transactions.StockReturn Get(long salesReturnId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get entity \"StockReturn\" filtered by \"SalesReturnId\" with value {SalesReturnId} was denied to the user with Login ID {LoginId}", salesReturnId, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT * FROM transactions.stock_return WHERE sales_return_id=@0;";
			return Factory.Get<MixERP.Net.Entities.Transactions.StockReturn>(this.Catalog, sql, salesReturnId).FirstOrDefault();
		}

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of transactions.stock_return.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table transactions.stock_return</returns>
		public IEnumerable<DisplayField> GetDisplayFields()
		{
			List<DisplayField> displayFields = new List<DisplayField>();

			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return displayFields;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get display field for entity \"StockReturn\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT sales_return_id AS key, sales_return_id as value FROM transactions.stock_return;";
			using (NpgsqlCommand command = new NpgsqlCommand(sql))
			{
				using (DataTable table = DbOperation.GetDataTable(this.Catalog, command))
				{
					if (table?.Rows == null || table.Rows.Count == 0)
					{
						return displayFields;
					}

					foreach (DataRow row in table.Rows)
					{
						if (row != null)
						{
							DisplayField displayField = new DisplayField
							{
								Key = row["key"].ToString(),
								Value = row["value"].ToString()
							};

							displayFields.Add(displayField);
						}
					}
				}
			}

			return displayFields;
		}

		/// <summary>
		/// Inserts the instance of StockReturn class on the database table "transactions.stock_return".
		/// </summary>
		/// <param name="stockReturn">The instance of "StockReturn" class to insert.</param>
		public void Add(MixERP.Net.Entities.Transactions.StockReturn stockReturn)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Create, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to add entity \"StockReturn\" was denied to the user with Login ID {LoginId}. {StockReturn}", this.LoginId, stockReturn);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			Factory.Insert(this.Catalog, stockReturn);
		}

		/// <summary>
		/// Updates the row of the table "transactions.stock_return" with an instance of "StockReturn" class against the primary key value.
		/// </summary>
		/// <param name="stockReturn">The instance of "StockReturn" class to update.</param>
		/// <param name="salesReturnId">The value of the column "sales_return_id" which will be updated.</param>
		public void Update(MixERP.Net.Entities.Transactions.StockReturn stockReturn, long salesReturnId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Edit, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to edit entity \"StockReturn\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {StockReturn}", salesReturnId, this.LoginId, stockReturn);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			Factory.Update(this.Catalog, stockReturn, salesReturnId);
		}

		/// <summary>
		/// Deletes the row of the table "transactions.stock_return" against the primary key value.
		/// </summary>
		/// <param name="salesReturnId">The value of the column "sales_return_id" which will be deleted.</param>
		public void Delete(long salesReturnId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Delete, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to delete entity \"StockReturn\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", salesReturnId, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "DELETE FROM transactions.stock_return WHERE sales_return_id=@0;";
			Factory.NonQuery(this.Catalog, sql, salesReturnId);
		}

		/// <summary>
		/// Performs a select statement on table "transactions.stock_return" producing a paged result of 25.
		/// </summary>
		/// <returns>Returns the first page of collection of "StockReturn" class.</returns>
		public IEnumerable<MixERP.Net.Entities.Transactions.StockReturn> GetPagedResult()
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the first page of the entity \"StockReturn\" was denied to the user with Login ID {LoginId}.", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT * FROM transactions.stock_return ORDER BY sales_return_id LIMIT 25 OFFSET 0;";
			return Factory.Get<MixERP.Net.Entities.Transactions.StockReturn>(this.Catalog, sql);
		}

		/// <summary>
		/// Performs a select statement on table "transactions.stock_return" producing a paged result of 25.
		/// </summary>
		/// <param name="pageNumber">Enter the page number to produce the paged result.</param>
		/// <returns>Returns collection of "StockReturn" class.</returns>
		public IEnumerable<MixERP.Net.Entities.Transactions.StockReturn> GetPagedResult(long pageNumber)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the entity \"StockReturn\" was denied to the user with Login ID {LoginId}.", pageNumber, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			long offset = (pageNumber -1) * 25;
			const string sql = "SELECT * FROM transactions.stock_return ORDER BY sales_return_id LIMIT 25 OFFSET @0;";
				
			return Factory.Get<MixERP.Net.Entities.Transactions.StockReturn>(this.Catalog, sql, offset);
		}
	}
}