using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;


namespace VS.Api.Controllers
{
    [Route("VS.Api/[controller]/[action]")]
    [ApiController]
    public class SupportController : ControllerBase
    {

        #region spSupport
        [HttpGet] //@iLoai = 1
        public ActionResult<IEnumerable<RequestType>> GetRequestType(int iNNgu = 0)
        {
            try
            {
                List<RequestType> list = new List<RequestType>();
                //list = DBUtils.ExecuteQueryList<RequestType>("SELECT [ID],[Name],[Name_E]  FROM [VS_Support_Center].[dbo].[RequestType] ORDER BY ID");
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt64(1)));
                lPar.Add(new SqlParameter("@NNgu", Convert.ToInt64(iNNgu)));
                list = DBUtils.ExecuteSPList<RequestType>("spSupport", lPar);
                return list;
            }
            catch
            { return null; }
        }

        [HttpGet]  //@iLoai = 2
        public ActionResult<IEnumerable<Priority>> GetPriority(int iNNgu = 0)
        {
            try
            {
                List<Priority> list = new List<Priority>();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt64(2)));
                lPar.Add(new SqlParameter("@NNgu", Convert.ToInt64(iNNgu)));
                list = DBUtils.ExecuteSPList<Priority>("spSupport", lPar);
                return list;
            }
            catch { return null; }
        }

        [HttpGet] //@iLoai = 4
        public ActionResult<IEnumerable<ServiceRequest>> GetServiceRequest(Int64 CustomerID)
        {
            try
            {
                List<ServiceRequest> list = new List<ServiceRequest>();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt32(4)));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                list = DBUtils.ExecuteSPList<ServiceRequest>("spSupport", lPar);
                return list;
            }
            catch
            { return null; }
        }

        [HttpPost] //@iLoai = 3
        public void PostData_Support(Data_Support dtsp)
        {
            try
            {
                //Data_Support lstRequest = JsonConvert.DeserializeObject<Data_Support>("");
                List<Data_Support> list = new List<Data_Support>();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt32(3)));
                lPar.Add(new SqlParameter("@iIDSRQ", dtsp.iIDSRQ));
                lPar.Add(new SqlParameter("@TINHTRANG", dtsp.TTUpdate));
                lPar.Add(new SqlParameter("@CustomerID", dtsp.CustomerID));
                lPar.Add(new SqlParameter("@RqUser", dtsp.UName));
                lPar.Add(new SqlParameter("@RqFullName", dtsp.FullName));
                lPar.Add(new SqlParameter("@RqName", dtsp.rqName));
                lPar.Add(new SqlParameter("@Email", dtsp.mail));
                lPar.Add(new SqlParameter("@PHONE", dtsp.phone));
                lPar.Add(new SqlParameter("@ZALO", dtsp.zalo));
                lPar.Add(new SqlParameter("@RequestTypeID", dtsp.rqTypeID));
                lPar.Add(new SqlParameter("@PriorityID", dtsp.rqPrioID));
                lPar.Add(new SqlParameter("@Description", dtsp.description));
                lPar.Add(new SqlParameter("@Requestcontent", dtsp.RequestContent));
                lPar.Add(new SqlParameter("@FlieLink_1", dtsp.duongDan));
                lPar.Add(new SqlParameter("@FlieLink_2", dtsp.Link_TL));
                lPar.Add(new SqlParameter("@PriorIDCtn", dtsp.PriorIDCnt));
                lPar.Add(new SqlParameter("@SentTime", dtsp.sentTime));
                lPar.Add(new SqlParameter("@VietStaffID", dtsp.VSStaffID));
                lPar.Add(new SqlParameter("@VietStaffName", dtsp.VSStaffName));
                lPar.Add(new SqlParameter("@RlContent", dtsp.RelContent));
                lPar.Add(new SqlParameter("@Finish", dtsp.Finish));
                lPar.Add(new SqlParameter("@Rating", dtsp.Rating));
                lPar.Add(new SqlParameter("@ContractID", dtsp.ContractID));
                DBUtils.ExecNonQuerySP("spSupport", lPar);
            }
            catch
            { }
        }

        [HttpGet] //@iLoai = 5
        public JsonResult GeteLearning(int CustomerID = 1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                dt = DBUtils.MGetDatatable("spSupport", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);

            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 6
        public JsonResult GetVSReply(DateTime TNgay, DateTime DNgay, Int64 ContractID = -1, int finished = -1, Int64 CustomerID = 1, int VSStaffID = 7, int VSSDept = 2)
        {
            try
            {
                DataTable dt = new DataTable();                
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai",  6));
                lPar.Add(new SqlParameter("@TNgay",  TNgay));
                lPar.Add(new SqlParameter("@DNgay",  DNgay));
                lPar.Add(new SqlParameter("@ContractID", ContractID));
                lPar.Add(new SqlParameter("@iFinish", finished));
                lPar.Add(new SqlParameter("CustomerID",  CustomerID));
                lPar.Add(new SqlParameter("@VietStaffID",  VSStaffID));
                lPar.Add(new SqlParameter("@VSSDept",  VSSDept));
                dt = DBUtils.MGetDatatable("spSupport", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);
                return new JsonResult(JSONresult);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 7 getRating 
        public JsonResult GetRating()
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 7));
                dt = DBUtils.MGetDatatable("spSupport", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);
                return new JsonResult(JSONresult);

            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 8
        public JsonResult GetCHUOI_CHA(Int64 iIDRq = 3)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 8));
                lPar.Add(new SqlParameter("@iIDRq", iIDRq));

                dt = DBUtils.MGetDatatable("spSupport", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 9
        public JsonResult GetVSReplyDetail(string CHUOI_CHA)
        {
            try
            {

                DataTable dt = new DataTable();                
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 9));
                lPar.Add(new SqlParameter("@CHUOI_CHA", CHUOI_CHA));
                dt = DBUtils.MGetDatatable("spSupport", lPar);


                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);

            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 10
        public JsonResult GetViewDetail(Int64 iIDSRQ = 1)
        {
            try
            {
                
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 10));
                lPar.Add(new SqlParameter("@iIDSRQ", iIDSRQ));
                dt = DBUtils.MGetDatatable("spSupport", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);


                return new JsonResult(JSONresult);

            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 11, Get thông tin User Login 
        public JsonResult getVietStaff(string username)
        {
            try
            {
                
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 11));
                lPar.Add(new SqlParameter("@UserName", username));
                dt = DBUtils.MGetDatatable("spSupport", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 12, Get Menu 
        public JsonResult getMenu(string sUName, int iNNgu = 0)
        {
            try
            {
                
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 12));
                lPar.Add(new SqlParameter("@UserName", sUName));
                lPar.Add(new SqlParameter("@NNgu", iNNgu));
                dt = DBUtils.MGetDatatable("spSupport", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 13, get Email Customer 
        public JsonResult getEmailCustomer(Int64 CustomerID)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 13));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                dt = DBUtils.MGetDatatable("spSupport", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region spSupport_VS
        [HttpGet] // @iLoai = 1, spSupport_VS, getDSCustomer
        public JsonResult getCustomer()
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 2,spSupport_VS, getCustomerContract
        public JsonResult getCTMContract(int NNgu = 0, Int64 CustomerID = 1, int Temp = -1)
        {
            try
            {
                
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@NNgu", NNgu));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                lPar.Add(new SqlParameter("@TEMP", Temp));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 3 ,spSupport_VS, Load cboNameType frmCustomerContract_View
        public JsonResult getContractType()
        {
            try
            {
                
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost] // @iLoai = 4, spSupport_VS
        public Int64 Post_CustomerContract(CustomerContract CTMC)
        {
            try
            {
                List<CustomerContract> list = new List<CustomerContract>();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt32(4)));
                lPar.Add(new SqlParameter("@iIDCTMC", CTMC.ID));
                lPar.Add(new SqlParameter("@ContractNo", CTMC.ContractNo));
                lPar.Add(new SqlParameter("@NumberofLicense", CTMC.NumberofLicense));
                lPar.Add(new SqlParameter("@License",  DBUtils.Encrypt(CTMC.NumberofLicense.ToString(), true)));
                lPar.Add(new SqlParameter("@MainContractID", CTMC.MainContractID));
                lPar.Add(new SqlParameter("@SignedDate", CTMC.SignedDate));
                lPar.Add(new SqlParameter("@TypeID", CTMC.TypeID));
                lPar.Add(new SqlParameter("@SoftwareProductID", CTMC.SoftwareProductID));
                lPar.Add(new SqlParameter("@AcceptanceDate", CTMC.AcceptanceDate));
                lPar.Add(new SqlParameter("@ValidUntil", CTMC.ValidUntil));
                lPar.Add(new SqlParameter("@CustomerID", CTMC.CustomerID));
                lPar.Add(new SqlParameter("@Note", CTMC.Note));
                return Convert.ToInt64(DBUtils.ExecNonQueryScalar("spSupport_VS", lPar));
            }
            catch
            {
                return 0;
            }
        }

        [HttpGet] //@iLoai = 5, spSupport_VS
        public JsonResult KiemTrung(string ContractNo = "", Int64 iID = 1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 5));
                lPar.Add(new SqlParameter("@ContractNo", ContractNo));
                lPar.Add(new SqlParameter("@iID", iID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost] //  @iLoai = 6, spSupport_VS, InserttContractVSSTaff
        public void Post_ContractVSStaff(ContractVSStaff CTVSS)
        {
            try
            {
                List<ContractVSStaff> list = new List<ContractVSStaff>();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt32(6)));
                lPar.Add(new SqlParameter("@iID1", CTVSS.iID1));
                lPar.Add(new SqlParameter("@ContractID", CTVSS.ContractID));
                lPar.Add(new SqlParameter("@VietStaffID", CTVSS.VSStaffID));
                lPar.Add(new SqlParameter("@Note", CTVSS.Note));
                lPar.Add(new SqlParameter("@Valid", CTVSS.Valid));
                DBUtils.ExecNonQuerySP("spSupport_VS", lPar);
            }
            catch
            {
            }
        }

        [HttpGet] // @iLoai = 7, spSupport_VS
        public JsonResult getCustomerContact(Int64 CustomerID = 1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 7));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch 
            {
                return null;
            }
        }

        [HttpPost] // @iLoai = 8 , spSupport_VS
        public Int64 Post_Customer(Customer CTM)
        {
            try
            {
                List<Customer> list = new List<Customer>();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt32(8)));
                lPar.Add(new SqlParameter("@CustomerID", CTM.CustomerID));
                lPar.Add(new SqlParameter("@TenCTYFull", CTM.CompanyFullName));
                lPar.Add(new SqlParameter("@ShortName", CTM.ShortName));
                lPar.Add(new SqlParameter("@Address", CTM.Address));
                lPar.Add(new SqlParameter("@CEO", CTM.CEO));
                lPar.Add(new SqlParameter("@Email", CTM.Email));
                lPar.Add(new SqlParameter("@PHONE", CTM.Phone));
                lPar.Add(new SqlParameter("@HDBT_DA_KY", CTM.HDBT_DA_KY));
                lPar.Add(new SqlParameter("@GHI_CHU", CTM.Ghi_Chu));
                return Convert.ToInt64(DBUtils.ExecNonQueryScalar("spSupport_VS", lPar));
            }
            catch
            {
                return 0;
            }
        }

        [HttpPost] // @iLoai = 9 , spSupport_VS
        public void Post_CustomerContact(CustomerContact CTMContact)
        {
            try
            {
                List<CustomerContact> list = new List<CustomerContact>();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt32(9)));
                lPar.Add(new SqlParameter("@iID", CTMContact.ID));
                lPar.Add(new SqlParameter("@CustomerID", CTMContact.CustomerID));
                lPar.Add(new SqlParameter("@Position", CTMContact.Position));
                lPar.Add(new SqlParameter("@ContactName", CTMContact.ContactName));
                lPar.Add(new SqlParameter("@PhoneNo", CTMContact.PhoneNo));
                lPar.Add(new SqlParameter("@EmailCT", CTMContact.Email));
                DBUtils.ExecNonQuerySP("spSupport_VS", lPar);
            }
            catch
            {
            }
        }

        [HttpGet] // @iLoai = 10, spSupport_VS, Check login
        public JsonResult CheckEmpty(string username = "admin")
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 10));
                lPar.Add(new SqlParameter("@UserName", username));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 11,spSupport_VS ,Check Password 
        public JsonResult CheckPassword(string username = "admin")
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 11));
                lPar.Add(new SqlParameter("@UserName", username));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 12,spSupport_VS Check Inactive
        public JsonResult CheckInactive(string username = "admin")
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 12));
                lPar.Add(new SqlParameter("@UserName", username));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 13, getDatabase, spSupport_VS
        public JsonResult getDatabase()
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 13));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 14,spSupport_VS Load cboNameSP frmCustomerContract_View 
        public JsonResult getSoftwareProducts(int NNgu = 0)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 14));
                lPar.Add(new SqlParameter("@NNgu", NNgu));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);


                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 15,spSupport_VS, Load cboMainContract frmCustomerContract_View
        public JsonResult getMainContract(Int64 CustomerID = 1)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 15));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 16,spSupport_VS Loadcbo
        public JsonResult GetVietsoftStaff()
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 16));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 17,spSupport_VS Loadcbo
        public JsonResult GetCustomerContract(Int64 CustomerID = -1)
        {
            try
            {
 
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 17));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 18, SentMail, spSupport_VS
        public JsonResult GetContractVSStaff(Int64 ContractID = 2)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 18));
                lPar.Add(new SqlParameter("@ContractID", ContractID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 19, spSupport_VS
        public JsonResult EmptyContractID(Int64 ContractID)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 19));
                lPar.Add(new SqlParameter("@ContractID", ContractID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 20, spSupport_VS
        public JsonResult ReportContract(DateTime TNgay, DateTime DNgay, Int64 CustomerID = 1, int TypeID = 1, int NNgu = 0)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 20));
                lPar.Add(new SqlParameter("@NNgu", NNgu));
                lPar.Add(new SqlParameter("@TNgay", TNgay));
                lPar.Add(new SqlParameter("@DNgay", DNgay));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                lPar.Add(new SqlParameter("@TypeID", TypeID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 21, spSupport_VS
        public JsonResult Report_NV(Int64 CustomerID = 1, Int64 ContractID = 2)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 21));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                lPar.Add(new SqlParameter("@ContractID", ContractID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 22, spSupport_VS
        public JsonResult SumNumberlicense(Int64 SoftwareProductID = 1, Int64 CustomerID = 2)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 22));
                lPar.Add(new SqlParameter("@SoftwareProductID", SoftwareProductID));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 23, spSupport_VS
        public JsonResult getContractVStaff(Int64 ContractID = 1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 23));
                lPar.Add(new SqlParameter("@ContractID", ContractID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 24, spSupport_VS
        public JsonResult delCustomer(Int64 CustomerID = -1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 24));
                lPar.Add(new SqlParameter("@CustomerID", CustomerID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 25, spSupport_VS
        public JsonResult delContract(Int64 ContractID = -1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 25));
                lPar.Add(new SqlParameter("@ContractID", ContractID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 26, spSupport_VS
        public JsonResult delContact(Int64 iID = -1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 26));
                lPar.Add(new SqlParameter("@iID", iID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] // @iLoai = 27, spSupport_VS
        public JsonResult delContractVSStaff(Int64 iID = -1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 27));
                lPar.Add(new SqlParameter("@iID", iID));
                dt = DBUtils.MGetDatatable("spSupport_VS", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        #endregion


        #region Get Ngon Ngu
        [HttpGet] //@iLoai = 12, Get Menu 
        public JsonResult getNNgu(string AppName, string FormName, string Keyword, int TypeLanguage)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@ModuleName", AppName));
                lPar.Add(new SqlParameter("@FormName", FormName));
                lPar.Add(new SqlParameter("@Keyword", Keyword));
                lPar.Add(new SqlParameter("@NNgu", TypeLanguage));
                dt = DBUtils.MGetDatatable("spGetNN", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 12, Get Menu 
        public JsonResult getDataNNgu(string AppName, string FormName, int TypeLanguage)
        {
            try
            {

                //System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Startup.vscnn);
                //conn.Open();
                //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spGetNN", conn);
                //cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
                //cmd.Parameters.Add("@ModuleName", SqlDbType.NVarChar).Value = AppName;
                //cmd.Parameters.Add("@FormName", SqlDbType.NVarChar).Value = FormName;
                //cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = null;
                //cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = TypeLanguage;
                //cmd.CommandType = CommandType.StoredProcedure;
                //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //DataTable dt = new DataTable();
                //dt = ds.Tables[0].Copy();

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                lPar.Add(new SqlParameter("@ModuleName", AppName));
                lPar.Add(new SqlParameter("@FormName", FormName));
                lPar.Add(new SqlParameter("@Keyword", null));
                lPar.Add(new SqlParameter("@NNgu", TypeLanguage));
                dt = DBUtils.MGetDatatable("spGetNN", lPar);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);

                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        #endregion\\

        #region spUser
        [HttpGet] //@iLoai = 1, get VietsoftDept
        public JsonResult getVietsoftDept()
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 1));
                dt = DBUtils.MGetDatatable("spUser", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);
                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 2, get View VietsoftStaff
        public JsonResult getViewVietSoftStaff(int iID = 1)
        {
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 2));
                lPar.Add(new SqlParameter("@iID", iID));
                dt = DBUtils.MGetDatatable("spUser", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);
                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet] //@iLoai = 3, kiemtrung Username
        public JsonResult kiemTrungUName(string Uname = "",int iID = 1)
        {
            try
            {

                DataTable dt = new DataTable();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", 3));
                lPar.Add(new SqlParameter("@UName", Uname));
                lPar.Add(new SqlParameter("@iID", iID));
                dt = DBUtils.MGetDatatable("spUser", lPar);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dt);
                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }
        
        [HttpPost] // Insert VietsoftStaff
        public void PostVietsoftStaff(VietsoftStaff VSS)
        {
            try
            {
                List<CustomerContact> list = new List<CustomerContact>();
                List<SqlParameter> lPar = new List<SqlParameter>();
                lPar.Add(new SqlParameter("@iLoai", Convert.ToInt32(4)));
                lPar.Add(new SqlParameter("@iID", VSS.ID));
                lPar.Add(new SqlParameter("@FullName", VSS.FullName));
                lPar.Add(new SqlParameter("@ShortName", VSS.ShortName));
                lPar.Add(new SqlParameter("@Email", VSS.Email));
                lPar.Add(new SqlParameter("@Phone", VSS.Phone));
                lPar.Add(new SqlParameter("@Zalo", VSS.Zalo));
                lPar.Add(new SqlParameter("@VSDept", VSS.VSDeptID));
                lPar.Add(new SqlParameter("@UName", VSS.UserName));
                lPar.Add(new SqlParameter("@Password", VSS.Password));
                lPar.Add(new SqlParameter("@Inactive", VSS.InActive));
                lPar.Add(new SqlParameter("@MainService", VSS.MainService));
                DBUtils.ExecNonQuerySP("spUser", lPar);
            }
            catch
            {
            }
        }
        #endregion

        #region MaHoa
        [HttpGet] // @iLoai = 2,spSupport_VS, getCustomerContract
        public JsonResult Encrypt(string sValue, bool agree = true)
        {
            try
            {
                string JSONresult;
                string s = DBUtils.Encrypt(sValue.Replace(' ', '+'), true);
                JSONresult = JsonConvert.SerializeObject(s);
                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }
        [HttpGet] // @iLoai = 2,spSupport_VS, getCustomerContract
        public JsonResult Decrypt(string sValue, bool agree = true)
        {
            try
            {
                string JSONresult;
                string s = DBUtils.Decrypt(sValue, true);
                JSONresult = JsonConvert.SerializeObject(s);
                return new JsonResult(JSONresult);
            }
            catch
            {
                return null;
            }
        }

        
        #endregion
    }
    public class RequestType
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Priority
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sign { get; set; }
    }
    public class ServiceRequest
    {
        public Int64 ID { get; set; }
        public string RequestName { get; set; }
    }
    public class Data_Support
    {
        public Int64 iIDSRQ { get; set; }
        public Int64 CustomerID { get; set; }
        public string tenCTY { get; set; }
        public string UName { get; set; }
        public string FullName { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string zalo { get; set; }
        public string rqName { get; set; }
        public int rqTypeID { get; set; }
        public string rqTypeName { get; set; }
        public int rqPrioID { get; set; }
        public string rqPrioName { get; set; }
        public string sign { get; set; }
        public string description { get; set; }
        public string RequestContent { get; set; }
        public string duongDan { get; set; }
        public Int64? PriorIDCnt { get; set; }
        public string rqNamecnt { get; set; }
        public DateTime? sentTime { get; set; }
        public int VSStaffID { get; set; }
        public string VSStaffName { get; set; }
        public string RelContent { get; set; }
        public Boolean Finish { get; set; }
        public int Rating { get; set; }
        public int TTUpdate { get; set; }
        public string Link_TL { get; set; }
        public Int64 ContractID { get; set; }

    }
    public class eLearning
    {
        public string Description { get; set; }
        public string VideoName { get; set; }
        public string VideoLink { get; set; }
    }
    public class CustomerContract
    {
        public Int64 ID { get; set; }
        public string ContractNo { get; set; }
        public DateTime SignedDate { get; set; }
        public int TypeID { get; set; }
        public int SoftwareProductID { get; set; }
        public int NumberofLicense { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public Int64? MainContractID { get; set; }
        public DateTime? ValidUntil { get; set; }
        public Int64 CustomerID { get; set; }
        public string Note { get; set; }

    }
    public class Customer
    {
        public Int64 ID { get; set; }
        public Int64 CustomerID { get; set; }
        public string CompanyFullName { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string CEO { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HDBT_DA_KY { get; set; }
        public string Ghi_Chu { get; set; }
        public Int64 CustomerID_TMP { get; set; }
    }
    public class CustomerContact
    {
        public Int64 ID { get; set; }
        public Int64 CustomerID { get; set; }
        public string Position { get; set; }
        public string ContactName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
    public class ContractVSStaff
    {
        public Int64 ID { get; set; }
        public Int64 ContractID { get; set; }
        public int iID1 { get; set; } // iID VSSTaff kiem tra trung
        public int VSStaffID { get; set; } // ID them moi
        public Boolean Valid { get; set; }
        public string Note { get; set; }
    }
    public class VietsoftStaff
    {
        public Int64 ID { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Zalo { get; set; }
        public int? VSDeptID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean InActive { get; set; }
        public Boolean MainService { get; set; }


    }
}

