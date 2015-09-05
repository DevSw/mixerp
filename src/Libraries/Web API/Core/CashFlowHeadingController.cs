using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using PetaPoco;

namespace MixERP.Net.Api.Core
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Cash Flow Headings.
    /// </summary>
    [RoutePrefix("api/v1.5/core/cash-flow-heading")]
    public class CashFlowHeadingController : ApiController
    {
        /// <summary>
        ///     The CashFlowHeading data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Core.Data.CashFlowHeading CashFlowHeadingContext;

        public CashFlowHeadingController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.CashFlowHeadingContext = new MixERP.Net.Schemas.Core.Data.CashFlowHeading
            {
                Catalog = this.Catalog,
                LoginId = this.LoginId
            };
        }

        public long LoginId { get; }
        public int UserId { get; private set; }
        public int OfficeId { get; private set; }
        public string Catalog { get; }

        /// <summary>
        ///     Counts the number of cash flow headings.
        /// </summary>
        /// <returns>Returns the count of the cash flow headings.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        public long Count()
        {
            try
            {
                return this.CashFlowHeadingContext.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Returns an instance of cash flow heading.
        /// </summary>
        /// <param name="cashFlowHeadingId">Enter CashFlowHeadingId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{cashFlowHeadingId}")]
        public MixERP.Net.Entities.Core.CashFlowHeading Get(int cashFlowHeadingId)
        {
            try
            {
                return this.CashFlowHeadingContext.Get(cashFlowHeadingId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 cash flow headings on each page, sorted by the property CashFlowHeadingId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        public IEnumerable<MixERP.Net.Entities.Core.CashFlowHeading> GetPagedResult()
        {
            try
            {
                return this.CashFlowHeadingContext.GetPagedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 cash flow headings on each page, sorted by the property CashFlowHeadingId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Core.CashFlowHeading> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.CashFlowHeadingContext.GetPagedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Displayfields is a lightweight key/value collection of cash flow headings.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of cash flow headings.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.CashFlowHeadingContext.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds your instance of Account class.
        /// </summary>
        /// <param name="cashFlowHeading">Your instance of cash flow headings class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{cashFlowHeading}")]
        public void Add(MixERP.Net.Entities.Core.CashFlowHeading cashFlowHeading)
        {
            if (cashFlowHeading == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.CashFlowHeadingContext.Add(cashFlowHeading);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Edits existing record with your instance of Account class.
        /// </summary>
        /// <param name="cashFlowHeading">Your instance of Account class to edit.</param>
        /// <param name="cashFlowHeadingId">Enter the value for CashFlowHeadingId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{cashFlowHeadingId}/{cashFlowHeading}")]
        public void Edit(int cashFlowHeadingId, MixERP.Net.Entities.Core.CashFlowHeading cashFlowHeading)
        {
            if (cashFlowHeading == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.CashFlowHeadingContext.Update(cashFlowHeading, cashFlowHeadingId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Deletes an existing instance of Account class via CashFlowHeadingId.
        /// </summary>
        /// <param name="cashFlowHeadingId">Enter the value for CashFlowHeadingId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{cashFlowHeadingId}")]
        public void Delete(int cashFlowHeadingId)
        {
            try
            {
                this.CashFlowHeadingContext.Delete(cashFlowHeadingId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}