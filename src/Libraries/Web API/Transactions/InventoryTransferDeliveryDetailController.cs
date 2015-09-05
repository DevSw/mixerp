using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using PetaPoco;

namespace MixERP.Net.Api.Transactions
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Inventory Transfer Delivery Details.
    /// </summary>
    [RoutePrefix("api/v1.5/transactions/inventory-transfer-delivery-detail")]
    public class InventoryTransferDeliveryDetailController : ApiController
    {
        /// <summary>
        ///     The InventoryTransferDeliveryDetail data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Transactions.Data.InventoryTransferDeliveryDetail InventoryTransferDeliveryDetailContext;

        public InventoryTransferDeliveryDetailController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.InventoryTransferDeliveryDetailContext = new MixERP.Net.Schemas.Transactions.Data.InventoryTransferDeliveryDetail
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
        ///     Counts the number of inventory transfer delivery details.
        /// </summary>
        /// <returns>Returns the count of the inventory transfer delivery details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        public long Count()
        {
            try
            {
                return this.InventoryTransferDeliveryDetailContext.Count();
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
        ///     Returns an instance of inventory transfer delivery detail.
        /// </summary>
        /// <param name="inventoryTransferDeliveryDetailId">Enter InventoryTransferDeliveryDetailId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{inventoryTransferDeliveryDetailId}")]
        public MixERP.Net.Entities.Transactions.InventoryTransferDeliveryDetail Get(long inventoryTransferDeliveryDetailId)
        {
            try
            {
                return this.InventoryTransferDeliveryDetailContext.Get(inventoryTransferDeliveryDetailId);
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
        ///     Creates a paginated collection containing 25 inventory transfer delivery details on each page, sorted by the property InventoryTransferDeliveryDetailId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        public IEnumerable<MixERP.Net.Entities.Transactions.InventoryTransferDeliveryDetail> GetPagedResult()
        {
            try
            {
                return this.InventoryTransferDeliveryDetailContext.GetPagedResult();
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
        ///     Creates a paginated collection containing 25 inventory transfer delivery details on each page, sorted by the property InventoryTransferDeliveryDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Transactions.InventoryTransferDeliveryDetail> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.InventoryTransferDeliveryDetailContext.GetPagedResult(pageNumber);
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
        ///     Displayfields is a lightweight key/value collection of inventory transfer delivery details.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of inventory transfer delivery details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.InventoryTransferDeliveryDetailContext.GetDisplayFields();
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
        /// <param name="inventoryTransferDeliveryDetail">Your instance of inventory transfer delivery details class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{inventoryTransferDeliveryDetail}")]
        public void Add(MixERP.Net.Entities.Transactions.InventoryTransferDeliveryDetail inventoryTransferDeliveryDetail)
        {
            if (inventoryTransferDeliveryDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.InventoryTransferDeliveryDetailContext.Add(inventoryTransferDeliveryDetail);
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
        /// <param name="inventoryTransferDeliveryDetail">Your instance of Account class to edit.</param>
        /// <param name="inventoryTransferDeliveryDetailId">Enter the value for InventoryTransferDeliveryDetailId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{inventoryTransferDeliveryDetailId}/{inventoryTransferDeliveryDetail}")]
        public void Edit(long inventoryTransferDeliveryDetailId, MixERP.Net.Entities.Transactions.InventoryTransferDeliveryDetail inventoryTransferDeliveryDetail)
        {
            if (inventoryTransferDeliveryDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.InventoryTransferDeliveryDetailContext.Update(inventoryTransferDeliveryDetail, inventoryTransferDeliveryDetailId);
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
        ///     Deletes an existing instance of Account class via InventoryTransferDeliveryDetailId.
        /// </summary>
        /// <param name="inventoryTransferDeliveryDetailId">Enter the value for InventoryTransferDeliveryDetailId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{inventoryTransferDeliveryDetailId}")]
        public void Delete(long inventoryTransferDeliveryDetailId)
        {
            try
            {
                this.InventoryTransferDeliveryDetailContext.Delete(inventoryTransferDeliveryDetailId);
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