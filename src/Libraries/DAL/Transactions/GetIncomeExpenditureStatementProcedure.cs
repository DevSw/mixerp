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
//Resharper disable All
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using PetaPoco;
using MixERP.Net.Entities.Transactions;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Transactions.Data
{
	/// <summary>
	/// Prepares, validates, and executes the function "transactions.get_income_expenditure_statement(_date_from date, _date_to date, _user_id integer, _office_id integer, _compact boolean)" on the database.
	/// </summary>
	public class GetIncomeExpenditureStatementProcedure: DbAccess
	{
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
	    public override string ObjectNamespace => "transactions";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
	    public override string ObjectName => "get_income_expenditure_statement";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
		public long LoginId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string Catalog { get; set; }

		/// <summary>
		/// Maps to "_date_from" argument of the function "transactions.get_income_expenditure_statement".
		/// </summary>
		public DateTime DateFrom { get; set; }
		/// <summary>
		/// Maps to "_date_to" argument of the function "transactions.get_income_expenditure_statement".
		/// </summary>
		public DateTime DateTo { get; set; }
		/// <summary>
		/// Maps to "_user_id" argument of the function "transactions.get_income_expenditure_statement".
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// Maps to "_office_id" argument of the function "transactions.get_income_expenditure_statement".
		/// </summary>
		public int OfficeId { get; set; }
		/// <summary>
		/// Maps to "_compact" argument of the function "transactions.get_income_expenditure_statement".
		/// </summary>
		public bool Compact { get; set; }

		/// <summary>
		/// Prepares, validates, and executes the function "transactions.get_income_expenditure_statement(_date_from date, _date_to date, _user_id integer, _office_id integer, _compact boolean)" on the database.
		/// </summary>
		public GetIncomeExpenditureStatementProcedure()
		{
		}

		/// <summary>
		/// Prepares, validates, and executes the function "transactions.get_income_expenditure_statement(_date_from date, _date_to date, _user_id integer, _office_id integer, _compact boolean)" on the database.
		/// </summary>
		/// <param name="dateFrom">Enter argument value for "_date_from" parameter of the function "transactions.get_income_expenditure_statement".</param>
		/// <param name="dateTo">Enter argument value for "_date_to" parameter of the function "transactions.get_income_expenditure_statement".</param>
		/// <param name="userId">Enter argument value for "_user_id" parameter of the function "transactions.get_income_expenditure_statement".</param>
		/// <param name="officeId">Enter argument value for "_office_id" parameter of the function "transactions.get_income_expenditure_statement".</param>
		/// <param name="compact">Enter argument value for "_compact" parameter of the function "transactions.get_income_expenditure_statement".</param>
		public GetIncomeExpenditureStatementProcedure(DateTime dateFrom,DateTime dateTo,int userId,int officeId,bool compact)
		{
			this.DateFrom = dateFrom;
			this.DateTo = dateTo;
			this.UserId = userId;
			this.OfficeId = officeId;
			this.Compact = compact;
		}
		/// <summary>
		/// Prepares and executes the function "transactions.get_income_expenditure_statement".
		/// </summary>
		public IEnumerable<DbGetIncomeExpenditureStatementResult> Execute()
		{
			if (!this.SkipValidation)
			{
				if (!this.Validated)
				{
					this.Validate(AccessTypeEnum.Execute, this.LoginId, false);
				}
				if (!this.HasAccess)
				{
                    Log.Information("Access to the function \"GetIncomeExpenditureStatementProcedure\" was denied to the user with Login ID {LoginId}.", this.LoginId);
					throw new UnauthorizedException("Access is denied.");
				}
			}
			const string query = "SELECT * FROM transactions.get_income_expenditure_statement(@0::date, @1::date, @2::integer, @3::integer, @4::boolean);";
			return Factory.Get<DbGetIncomeExpenditureStatementResult>(this.Catalog, query, this.DateFrom, this.DateTo, this.UserId, this.OfficeId, this.Compact);
		} 
	}
}