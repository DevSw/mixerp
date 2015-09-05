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

namespace MixERP.Net.Core.Modules.HRM.Data
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "hrm.education_levels".
    /// </summary>
    public class EducationLevel : DbAccess
    {
        /// <summary>
        /// The schema of this table. Returns literal "hrm".
        /// </summary>
	    public override string ObjectNamespace => "hrm";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "education_levels".
        /// </summary>
	    public override string ObjectName => "education_levels";

        /// <summary>
        /// Login id of application user accessing this table.
        /// </summary>
		public long LoginId { get; set; }

        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string Catalog { get; set; }

		/// <summary>
		/// Performs SQL count on the table "hrm.education_levels".
		/// </summary>
		/// <returns>Returns the number of rows of the table "hrm.education_levels".</returns>
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
                    Log.Information("Access to count entity \"EducationLevel\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT COUNT(*) FROM hrm.education_levels;";
			return Factory.Scalar<long>(this.Catalog, sql);
		}

		/// <summary>
		/// Executes a select query on the table "hrm.education_levels" with a where filter on the column "education_level_id" to return a single instance of the "EducationLevel" class. 
		/// </summary>
		/// <param name="educationLevelId">The column "education_level_id" parameter used on where filter.</param>
		/// <returns>Returns a non-live, non-mapped instance of "EducationLevel" class mapped to the database row.</returns>
		public MixERP.Net.Entities.HRM.EducationLevel Get(int educationLevelId)
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
                    Log.Information("Access to the get entity \"EducationLevel\" filtered by \"EducationLevelId\" with value {EducationLevelId} was denied to the user with Login ID {LoginId}", educationLevelId, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT * FROM hrm.education_levels WHERE education_level_id=@0;";
			return Factory.Get<MixERP.Net.Entities.HRM.EducationLevel>(this.Catalog, sql, educationLevelId).FirstOrDefault();
		}

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of hrm.education_levels.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table hrm.education_levels</returns>
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
                    Log.Information("Access to get display field for entity \"EducationLevel\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT education_level_id AS key, education_level_name as value FROM hrm.education_levels;";
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
		/// Inserts the instance of EducationLevel class on the database table "hrm.education_levels".
		/// </summary>
		/// <param name="educationLevel">The instance of "EducationLevel" class to insert.</param>
		public void Add(MixERP.Net.Entities.HRM.EducationLevel educationLevel)
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
                    Log.Information("Access to add entity \"EducationLevel\" was denied to the user with Login ID {LoginId}. {EducationLevel}", this.LoginId, educationLevel);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			Factory.Insert(this.Catalog, educationLevel);
		}

		/// <summary>
		/// Updates the row of the table "hrm.education_levels" with an instance of "EducationLevel" class against the primary key value.
		/// </summary>
		/// <param name="educationLevel">The instance of "EducationLevel" class to update.</param>
		/// <param name="educationLevelId">The value of the column "education_level_id" which will be updated.</param>
		public void Update(MixERP.Net.Entities.HRM.EducationLevel educationLevel, int educationLevelId)
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
                    Log.Information("Access to edit entity \"EducationLevel\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {EducationLevel}", educationLevelId, this.LoginId, educationLevel);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			Factory.Update(this.Catalog, educationLevel, educationLevelId);
		}

		/// <summary>
		/// Deletes the row of the table "hrm.education_levels" against the primary key value.
		/// </summary>
		/// <param name="educationLevelId">The value of the column "education_level_id" which will be deleted.</param>
		public void Delete(int educationLevelId)
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
                    Log.Information("Access to delete entity \"EducationLevel\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", educationLevelId, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "DELETE FROM hrm.education_levels WHERE education_level_id=@0;";
			Factory.NonQuery(this.Catalog, sql, educationLevelId);
		}

		/// <summary>
		/// Performs a select statement on table "hrm.education_levels" producing a paged result of 25.
		/// </summary>
		/// <returns>Returns the first page of collection of "EducationLevel" class.</returns>
		public IEnumerable<MixERP.Net.Entities.HRM.EducationLevel> GetPagedResult()
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
                    Log.Information("Access to the first page of the entity \"EducationLevel\" was denied to the user with Login ID {LoginId}.", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT * FROM hrm.education_levels ORDER BY education_level_id LIMIT 25 OFFSET 0;";
			return Factory.Get<MixERP.Net.Entities.HRM.EducationLevel>(this.Catalog, sql);
		}

		/// <summary>
		/// Performs a select statement on table "hrm.education_levels" producing a paged result of 25.
		/// </summary>
		/// <param name="pageNumber">Enter the page number to produce the paged result.</param>
		/// <returns>Returns collection of "EducationLevel" class.</returns>
		public IEnumerable<MixERP.Net.Entities.HRM.EducationLevel> GetPagedResult(long pageNumber)
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
                    Log.Information("Access to Page #{Page} of the entity \"EducationLevel\" was denied to the user with Login ID {LoginId}.", pageNumber, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			long offset = (pageNumber -1) * 25;
			const string sql = "SELECT * FROM hrm.education_levels ORDER BY education_level_id LIMIT 25 OFFSET @0;";
				
			return Factory.Get<MixERP.Net.Entities.HRM.EducationLevel>(this.Catalog, sql, offset);
		}
	}
}