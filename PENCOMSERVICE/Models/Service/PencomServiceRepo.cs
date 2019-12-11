using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PENCOMSERVICE.Models.BaseModel;
using PENCOMSERVICE.Models.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace PENCOMSERVICE.Models.Service
{
    public class PencomServiceRepo : IPencomService
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly PencomDbContext _dbContext;
        private PFAContext _pfaContext;
        private IMAGESContext _imagesContext;
        public bool IsLoading { get; set; } = true;

        public PencomServiceRepo(IWebHostEnvironment env, PencomDbContext db, PFAContext pfaContext, IMAGESContext imagesContext)
        {
            _hostingEnvironment = env;

            _dbContext = db;
            _pfaContext = pfaContext;
            _imagesContext = imagesContext;
        }

        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count();
        }

        public async Task<List<ECRDataModel>> GetPaginatedDataResult()
        {
            return await GetData();
            //return data.OrderBy(o => o.ID).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        private async Task<List<ECRDataModel>> GetData()
        {
            // return await _dbContext.ECRDataModel.ToListAsync();
            var resList = new List<ECRDataModel>();
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && pfa.IsSubmitted == false).Take(500).ToListAsync(); // I removed the .where(is approved and issubmitted) please in the db edit the ISsubmitted row to False for all and rerun that should work

            var res = new ECRDataModel();

            foreach (var item in pfadata)
            {
                Debug.WriteLine(item.Firstname + " " + item.Pin);
                var imgs = await _imagesContext.EmployeeImagesRecapture.Where(i => i.Pin == item.Pin).FirstOrDefaultAsync().ConfigureAwait(false);
                if (imgs == null)
                {
                    res = new ECRDataModel
                    {
                        Bvn = item.Bvn,
                        DateEmployed = item.DateEmployed,
                        DateOfBirth = item.DateOfBirth,
                        DateOfFirstApppoinment = item.DateOfFirstApppoinment,
                        Email = item.Email,
                        Pin = item.Pin,
                        Title = item.Title,
                        Surname = item.Surname,
                        Firstname = item.Firstname,
                        Othernames = item.Othernames,
                        MaidenName = item.MaidenName,
                        Gender = item.Gender,
                        MaritalStatusCode = item.MaritalStatusCode,
                        NationalityCode = item.NationalityCode,
                        StateOfOrigin = item.StateOfOrigin,
                        LgaCode = item.LgaCode,
                        PlaceOfBirth = item.PlaceOfBirth,
                        Ssn = item.Ssn,
                        PermanentAddressLocation = item.PermanentAddressLocation,
                        PermanentAddress = item.PermanentAddress,
                        PermanentAddress1 = item.PermanentAddress1,
                        PermCity = item.PermCity,
                        PermLga = item.PermLga,
                        PermState = item.PermState,
                        PermCountry = item.PermCountry,
                        PermZip = item.PermZip,
                        PermBox = item.PermBox,
                        MobilePhone = item.MobilePhone,
                        State = item.State,
                        EmployerType = item.EmployerType,
                        EmployerRcno = item.EmployerRcno,
                        EmployerLocation = item.EmployerLocation,
                        EmployerAddress = item.EmployerAddress,
                        EmployerAddress1 = item.EmployerAddress1,
                        EmployerCity = item.EmployerCity,
                        EmployerLga = item.EmployerLga,
                        EmployerStatecode = item.EmployerStatecode,
                        EmployerCountry = item.EmployerCountry,
                        EmployerZip = item.EmployerZip,
                        EmployerBox = item.EmployerBox,
                        EmployerPhone = item.EmployerPhone,
                        EmployerBusiness = item.EmployerBusiness,
                        NokTitle = item.NokTitle,
                        NokGender = item.NokGender,
                        NokName = item.NokName,
                        NokOthername = item.NokOthername,
                        NokSurname = item.NokSurname,
                        NokRelationship = item.NokRelationship,
                        NokLocation = item.NokLocation,
                        NokAddress = item.NokAddress,
                        NokAddress1 = item.NokAddress1,
                        NokCity = item.NokCity,
                        NokLga = item.NokLga,
                        NokStatecode = item.NokStatecode,
                        NokCountry = item.NokCountry,
                        NokZip = item.NokZip,
                        NokBox = item.NokBox,
                        NokMobilePhone = item.NokMobilePhone,
                        NokEmailaddress = item.NokEmailaddress,
                        FormRefno = item.FormRefno,
                        RsaStatus = item.RsaStatus,
                        IsSubmitted = false,
                        SubmitResponse = "Could not find images for this record"
                    };

                    resList.Add(res);
                }
                else
                {
                    res = new ECRDataModel
                    {
                        Bvn = item.Bvn,
                        DateEmployed = item.DateEmployed,
                        DateOfBirth = item.DateOfBirth,
                        DateOfFirstApppoinment = item.DateOfFirstApppoinment,
                        Email = item.Email,
                        Pin = item.Pin,
                        Title = item.Title,
                        Surname = item.Surname,
                        Firstname = item.Firstname,
                        Othernames = item.Othernames,
                        MaidenName = item.MaidenName,
                        Gender = item.Gender,
                        MaritalStatusCode = item.MaritalStatusCode,
                        NationalityCode = item.NationalityCode,
                        StateOfOrigin = item.StateOfOrigin,
                        LgaCode = item.LgaCode,
                        PlaceOfBirth = item.PlaceOfBirth,
                        Ssn = item.Ssn,
                        PermanentAddressLocation = item.PermanentAddressLocation,
                        PermanentAddress = item.PermanentAddress,
                        PermanentAddress1 = item.PermanentAddress1,
                        PermCity = item.PermCity,
                        PermLga = item.PermLga,
                        PermState = item.PermState,
                        PermCountry = item.PermCountry,
                        PermZip = item.PermZip,
                        PermBox = item.PermBox,
                        MobilePhone = item.MobilePhone,
                        State = item.State,
                        EmployerType = item.EmployerType,
                        EmployerRcno = item.EmployerRcno,
                        EmployerLocation = item.EmployerLocation,
                        EmployerAddress = item.EmployerAddress,
                        EmployerAddress1 = item.EmployerAddress1,
                        EmployerCity = item.EmployerCity,
                        EmployerLga = item.EmployerLga,
                        EmployerStatecode = item.EmployerStatecode,
                        EmployerCountry = item.EmployerCountry,
                        EmployerZip = item.EmployerZip,
                        EmployerBox = item.EmployerBox,
                        EmployerPhone = item.EmployerPhone,
                        EmployerBusiness = item.EmployerBusiness,
                        NokTitle = item.NokTitle,
                        NokGender = item.NokGender,
                        NokName = item.NokName,
                        NokOthername = item.NokOthername,
                        NokSurname = item.NokSurname,
                        NokRelationship = item.NokRelationship,
                        NokLocation = item.NokLocation,
                        NokAddress = item.NokAddress,
                        NokAddress1 = item.NokAddress1,
                        NokCity = item.NokCity,
                        NokLga = item.NokLga,
                        NokStatecode = item.NokStatecode,
                        NokCountry = item.NokCountry,
                        NokZip = item.NokZip,
                        NokBox = item.NokBox,
                        NokMobilePhone = item.NokMobilePhone,
                        NokEmailaddress = item.NokEmailaddress,
                        FormRefno = item.FormRefno,
                        RsaStatus = item.RsaStatus,
                        PictureImage = imgs.PictureImage,
                        SignatureImage = imgs.SignatureImage,
                        Thumbprint = imgs.Thumbprint
                    };

                    resList.Add(res);
                }
            }

            return resList;
        }

        public async Task<PencomResponse> SubmitData(ECRDataModel model)
        {
            var baseuri = "http://ecrs.pencom.gov.ng:7009/ECRS/RequestSubmissionWS";
            var username = "TRUSTFUND";
            var password = "79afc84196e3cd3f9e5b49eff4c17f790a9d2b13666e113bff7848f389559ebf";
            var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var dob = model.DateOfBirth.GetValueOrDefault().ToString("yyyy-MM-dd");

            if (model.SignatureImage is null)
            {
                return new PencomResponse { responsecode = "", responsemessage = "no image found" };
            }

            var payload = @"<?xml version=""1.0"" encoding=""utf-8""?><soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://ws.services.model.ecrs.pencom.gov.ng/""><soapenv:Header/>
<soapenv:Body>
            <ws:recaptureRequest><UserId>" + username + "</UserId>" + "<Password>" + password + "</Password>" +
            "<RecaptureRequestDetail>" +
            "<header>" +
                "<pfaCode>" + "028" + "</pfaCode>" +
                "<requestCode>" + "ECRSRR01" + "</requestCode>" +
            "</header>" +
            "<body>" +
            "<contributor>" +
                "<dateOfRecapture>" + today + "</dateOfRecapture>" +
                "<formNumber>" + model.FormRefno + "</formNumber>" +
                "<personalData>" +
                    "<rsaStatus>" + model.RsaStatus + "</rsaStatus>" +
                    "<rsaPin>" + model.Pin + "</rsaPin>" +
                    "<bvn>" + model.Bvn + "</bvn>" +
                    "<nin>" + model.Ssn + "</nin>" +
                    "<title>" + model.Title + "</title>" +
                    "<surname>" + model.Surname + "</surname>" +
                    "<firstName>" + model.Firstname + "</firstName>" +
                    "<middleName>" + model.Othernames + "</middleName>" +
                    "<maidenOrFormerName>" + model.MaidenName + "</maidenOrFormerName>" +
                    "<gender>" + model.Gender + "</gender>" +
                    "<maritalStatus>" + model.MaritalStatusCode + "</maritalStatus>" +
                    "<nationality>" + model.NationalityCode + "</nationality>" +
                    "<stateOfOriginCode>" + model.State + "</stateOfOriginCode>" +
                    "<localGovernmentOfOriginCode>" + model.LgaCode + "</localGovernmentOfOriginCode>" +
                    "<dateOfBirth>" + dob + "</dateOfBirth>" +
                    "<placeOfBirth>" + model.PlaceOfBirth + "</placeOfBirth>" +
                    "<email>" + model.Email + "</email>" +
                    "<phoneNumber>" + model.MobilePhone + "</phoneNumber>" +
                    "<poBox>" + model.PermBox + "</poBox>" +
                    "<nigeriaOrAbroad>" + model.PermanentAddressLocation + "</nigeriaOrAbroad>" +
                    "<residenceCountryCode>" + model.PermCountry + "</residenceCountryCode>" +
                    "<residenceStateCode>" + model.PermState + "</residenceStateCode>" +
                    "<residenceLocalGovernmentCode>" + model.PermLga + "</residenceLocalGovernmentCode>" +
                    "<residenceTownCity>" + model.PermCity + "</residenceTownCity>" +
                    "<residenceStreetName>" + model.PermanentAddress1 + "</residenceStreetName>" +
                    "<residenceHouseNameOrNumber>" + model.PermanentAddress + "</residenceHouseNameOrNumber>" +
                    "<residenceZipCode>" + model.PermZip + "</residenceZipCode>" +
                "</personalData>" +
                "<employmentRecord>" +
                    "<sectorClass>" + model.EmployerType + "</sectorClass>" +
                    "<employerCode>" + model.EmployerRcno + "</employerCode>" +
                    "<nigeriaOrAbroad>" + model.EmployerLocation + "</nigeriaOrAbroad>" +
                    "<countryCode>" + model.EmployerCountry + "</countryCode>" +
                    "<stateCode>" + model.EmployerStatecode + "</stateCode>" +
                    "<localGovernmentCode>" + model.EmployerLga + "</localGovernmentCode>" +
                    "<townCity>" + model.EmployerCity + "</townCity>" +
                    "<streetName>" + model.EmployerAddress1 + "</streetName>" +
                    "<buildingNameOrNumber>" + model.EmployerAddress + "</buildingNameOrNumber>" +
                    "<zipCode>" + model.EmployerZip + "</zipCode>" +
                    "<poBox>" + model.EmployerBox + "</poBox>" +
                    "<phoneNumber>" + model.EmployerPhone + "</phoneNumber>" +
                    "<natureOfBusiness>" + model.EmployerBusiness + "</natureOfBusiness>" +
                    "<dateOfFirstAppointment>" + model.DateOfFirstApppoinment + "</dateOfFirstAppointment>" +
                    "<dateOfCurrentEmployment>" + model.DateEmployed + "</dateOfCurrentEmployment>" +
                "</employmentRecord>" +
                "<nextOfKinDetail>" +
                    "<title>" + model.NokTitle + "</title>" +
                    "<gender>" + model.NokGender + "</gender>" +
                    "<surname>" + model.NokSurname + "</surname>" +
                    "<firstName>" + model.NokName + "</firstName>" +
                    "<middleName>" + model.NokOthername + "</middleName>" +
                    "<relationship>" + model.NokRelationship + "</relationship>" +
                    "<nigeriaOrAbroad>" + model.NokLocation + "</nigeriaOrAbroad>" +
                    "<residenceCountryCode>" + model.NokCountry + "</residenceCountryCode>" +
                    "<residenceStateCode>" + model.NokStatecode + "</residenceStateCode>" +
                    "<residenceLocalGovernmentCode>" + model.NokLga + "</residenceLocalGovernmentCode>" +
                    "<residenceTownCity>" + model.NokCity + "</residenceTownCity>" +
                    "<residenceStreetName>" + model.NokAddress1 + "</residenceStreetName>" +
                    "<residenceHouseNumber>" + model.NokAddress + "</residenceHouseNumber>" +
                    "<zipCode>" + model.NokZip + "</zipCode>" +
                    "<poBox>" + model.NokBox + "</poBox>" +
                    "<email>" + model.NokEmailaddress + "</email>" +
                    "<phoneNumber>" + model.NokMobilePhone + "</phoneNumber>" +
                "</nextOfKinDetail>" +
                "<biometric>" +
                    "<picture>" + Convert.ToBase64String(model.PictureImage) + "</picture>" +
                    "<signature>" + Convert.ToBase64String(model.SignatureImage) + "</signature>" +
                    "<consentForm>" + Convert.ToBase64String(model.Thumbprint) + "</consentForm>" +
                "</biometric>" +
            "</contributor>" +
            "</body>" +
            "</RecaptureRequestDetail>" +
            "</ws:recaptureRequest></soapenv:Body></soapenv:Envelope>";

            WebClient webClient = new WebClient();
            var jResult = new PencomResponse();
            var xmlOutput = "";

            var emp = await _pfaContext.EmployeesRecapture.Where(e => e.Pin.Equals(model.Pin)).FirstOrDefaultAsync();

            try
            {
                var response = webClient.UploadString(baseuri, payload);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    // loop through its children as well
                    xmlOutput = node.InnerText;
                }
                var responseXML = xmlOutput.Replace("<setId>", "_");
                responseXML = responseXML.Replace("</setId>", "");
                responseXML = responseXML.Replace("<responseCode>", "_");
                responseXML = responseXML.Replace("</responseCode>", "");
                responseXML = responseXML.Replace("<responseMessage>", "_");
                responseXML = responseXML.Replace("</responseMessage>", "");
                var responseArr = responseXML.Split("_");

                //var xDoc = XDocument.Parse(xmlOutput);
                //var setId = xDoc.Root.Element("setId");
                //var setIdValue = setId.Value;
                var setId = responseArr[1];
                var responseMessage = responseArr[3];
                emp.IsSubmitted = setId is null || setId == "" || string.IsNullOrEmpty(setId) ? emp.IsSubmitted = false : emp.IsSubmitted = true;
                emp.SubmitResponse = responseMessage;
               
                emp.SubmitCode = setId;

                _pfaContext.EmployeesRecapture.Update(emp);
                await _pfaContext.SaveChangesAsync();

                return jResult;
            }
            catch (WebException ex)
            {
                var errorResponse = new PencomResponse { responsecode = "500", responsemessage = $" An error from Pencom Server says: {ex.Message} " };
                emp.IsSubmitted = false;
                emp.SubmitResponse = errorResponse.responsemessage;
                emp.SubmitCode = errorResponse.responsecode;

                //_pfaContext.EmployeesRecapture.Update(emp);
                //await _pfaContext.SaveChangesAsync();

                using (StreamReader r = new StreamReader(
                    ex.Response.GetResponseStream()))
                {

                    string responseContent = r.ReadToEnd();

                    //jResult = JsonConvert.DeserializeObject<PencomResponse>(responseContent); //this may not work as response might also be xml
                }
                return errorResponse;
            }
        }

        public string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public async Task<List<ECRDataModel>> GetSubmittedData()
        {
            var resList = new List<ECRDataModel>();
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && pfa.IsSubmitted).ToListAsync().ConfigureAwait(false);
            var res = new ECRDataModel();

            foreach (var item in pfadata)
            {
                Debug.WriteLine(item.Firstname + " " + item.Pin);
                var imgs = await _imagesContext.EmployeeImagesRecapture.Where(i => i.Pin == item.Pin).FirstOrDefaultAsync().ConfigureAwait(false);
                if (imgs == null)
                {
                    res = new ECRDataModel
                    {
                        Bvn = item.Bvn,
                        DateEmployed = item.DateEmployed,
                        DateOfBirth = item.DateOfBirth,
                        DateOfFirstApppoinment = item.DateOfFirstApppoinment,
                        Email = item.Email,
                        Pin = item.Pin,
                        Title = item.Title,
                        Surname = item.Surname,
                        Firstname = item.Firstname,
                        Othernames = item.Othernames,
                        MaidenName = item.MaidenName,
                        Gender = item.Gender,
                        MaritalStatusCode = item.MaritalStatusCode,
                        NationalityCode = item.NationalityCode,
                        StateOfOrigin = item.StateOfOrigin,
                        LgaCode = item.LgaCode,
                        PlaceOfBirth = item.PlaceOfBirth,
                        Ssn = item.Ssn,
                        PermanentAddressLocation = item.PermanentAddressLocation,
                        PermanentAddress = item.PermanentAddress,
                        PermanentAddress1 = item.PermanentAddress1,
                        PermCity = item.PermCity,
                        PermLga = item.PermLga,
                        PermState = item.PermState,
                        PermCountry = item.PermCountry,
                        PermZip = item.PermZip,
                        PermBox = item.PermBox,
                        MobilePhone = item.MobilePhone,
                        State = item.State,
                        EmployerType = item.EmployerType,
                        EmployerRcno = item.EmployerRcno,
                        EmployerLocation = item.EmployerLocation,
                        EmployerAddress = item.EmployerAddress,
                        EmployerAddress1 = item.EmployerAddress1,
                        EmployerCity = item.EmployerCity,
                        EmployerLga = item.EmployerLga,
                        EmployerStatecode = item.EmployerStatecode,
                        EmployerCountry = item.EmployerCountry,
                        EmployerZip = item.EmployerZip,
                        EmployerBox = item.EmployerBox,
                        EmployerPhone = item.EmployerPhone,
                        EmployerBusiness = item.EmployerBusiness,
                        NokTitle = item.NokTitle,
                        NokGender = item.NokGender,
                        NokName = item.NokName,
                        NokOthername = item.NokOthername,
                        NokSurname = item.NokSurname,
                        NokRelationship = item.NokRelationship,
                        NokLocation = item.NokLocation,
                        NokAddress = item.NokAddress,
                        NokAddress1 = item.NokAddress1,
                        NokCity = item.NokCity,
                        NokLga = item.NokLga,
                        NokStatecode = item.NokStatecode,
                        NokCountry = item.NokCountry,
                        NokZip = item.NokZip,
                        NokBox = item.NokBox,
                        NokMobilePhone = item.NokMobilePhone,
                        NokEmailaddress = item.NokEmailaddress,
                        FormRefno = item.FormRefno,
                        RsaStatus = item.RsaStatus,
                        IsSubmitted = item.IsSubmitted,
                        SubmitResponse = item.SubmitResponse,
                        SubmitCode = item.SubmitCode
                    };

                    resList.Add(res);
                }
                else
                {
                    res = new ECRDataModel
                    {
                        Bvn = item.Bvn,
                        DateEmployed = item.DateEmployed,
                        DateOfBirth = item.DateOfBirth,
                        DateOfFirstApppoinment = item.DateOfFirstApppoinment,
                        Email = item.Email,
                        Pin = item.Pin,
                        Title = item.Title,
                        Surname = item.Surname,
                        Firstname = item.Firstname,
                        Othernames = item.Othernames,
                        MaidenName = item.MaidenName,
                        Gender = item.Gender,
                        MaritalStatusCode = item.MaritalStatusCode,
                        NationalityCode = item.NationalityCode,
                        StateOfOrigin = item.StateOfOrigin,
                        LgaCode = item.LgaCode,
                        PlaceOfBirth = item.PlaceOfBirth,
                        Ssn = item.Ssn,
                        PermanentAddressLocation = item.PermanentAddressLocation,
                        PermanentAddress = item.PermanentAddress,
                        PermanentAddress1 = item.PermanentAddress1,
                        PermCity = item.PermCity,
                        PermLga = item.PermLga,
                        PermState = item.PermState,
                        PermCountry = item.PermCountry,
                        PermZip = item.PermZip,
                        PermBox = item.PermBox,
                        MobilePhone = item.MobilePhone,
                        State = item.State,
                        EmployerType = item.EmployerType,
                        EmployerRcno = item.EmployerRcno,
                        EmployerLocation = item.EmployerLocation,
                        EmployerAddress = item.EmployerAddress,
                        EmployerAddress1 = item.EmployerAddress1,
                        EmployerCity = item.EmployerCity,
                        EmployerLga = item.EmployerLga,
                        EmployerStatecode = item.EmployerStatecode,
                        EmployerCountry = item.EmployerCountry,
                        EmployerZip = item.EmployerZip,
                        EmployerBox = item.EmployerBox,
                        EmployerPhone = item.EmployerPhone,
                        EmployerBusiness = item.EmployerBusiness,
                        IsSubmitted = item.IsSubmitted,
                        NokTitle = item.NokTitle,
                        NokGender = item.NokGender,
                        NokName = item.NokName,
                        NokOthername = item.NokOthername,
                        NokSurname = item.NokSurname,
                        NokRelationship = item.NokRelationship,
                        NokLocation = item.NokLocation,
                        NokAddress = item.NokAddress,
                        NokAddress1 = item.NokAddress1,
                        NokCity = item.NokCity,
                        NokLga = item.NokLga,
                        NokStatecode = item.NokStatecode,
                        NokCountry = item.NokCountry,
                        NokZip = item.NokZip,
                        NokBox = item.NokBox,
                        NokMobilePhone = item.NokMobilePhone,
                        NokEmailaddress = item.NokEmailaddress,
                        FormRefno = item.FormRefno,
                        RsaStatus = item.RsaStatus,
                        PictureImage = imgs.PictureImage,
                        SignatureImage = imgs.SignatureImage,
                        SubmitResponse = item.SubmitResponse,
                        SubmitCode = item.SubmitCode,
                        Thumbprint = imgs.Thumbprint
                    };

                    resList.Add(res);
                }
            }

            return resList;
        }

        public async Task<string> GetRequestStatus(string setId)
        {
            var baseuri = "http://ecrs.pencom.gov.ng:7009/ECRS/RequestSubmissionWS";
            var username = "TRUSTFUND";
            var password = "79afc84196e3cd3f9e5b49eff4c17f790a9d2b13666e113bff7848f389559ebf";

            if (setId is null)
            {
                return null;
            }

            var payload = @"<?xml version=""1.0"" encoding=""utf-8""?><soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://ws.services.model.ecrs.pencom.gov.ng/""><soapenv:Header/>
<soapenv:Body>
            <ws:getRequestStatus><UserId>" + username + "</UserId>" +
            "<Password>" + password + "</Password>" +
            "<setId>" + setId + "</setId>" +
            "</ws:getRequestStatus></soapenv:Body></soapenv:Envelope>";

            WebClient webClient = new WebClient();
            var jResult = new PencomResponse();
            var xmlOutput = "";



            try
            {
                var response = webClient.UploadString(baseuri, payload);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    // loop through its children as well
                    xmlOutput = node.InnerText;
                }

                var responseXML = xmlOutput.Replace("\\n", "_");
                responseXML = responseXML.Replace("<RequestStatusResult>", "_");
                responseXML = responseXML.Replace("</RequestStatusResult>", "");
                responseXML = responseXML.Replace("<responseCode>", "_");
                responseXML = responseXML.Replace("</responseCode>", "");
                responseXML = responseXML.Replace("<result>", "_");
                responseXML = responseXML.Replace("</result>", "");
                responseXML = responseXML.Replace("<resultList>", "_");
                responseXML = responseXML.Replace("</resultList>", "");
                responseXML = responseXML.Replace("<responseMessage>", "_");
                responseXML = responseXML.Replace("</responseMessage>", "");
                var responseArr = responseXML.Split("_");

                return responseArr[5];

                //_pfaContext.EmployeesRecapture.Update(emp);
                //await _pfaContext.SaveChangesAsync();

            }
            catch (WebException ex)
            {
                var errorResponse = new PencomResponse { responsecode = "500", responsemessage = $" An error from Pencom Server says: {ex.Message} " };


                using (StreamReader r = new StreamReader(
                    ex.Response.GetResponseStream()))
                {

                    string responseContent = r.ReadToEnd();

                    //jResult = JsonConvert.DeserializeObject<PencomResponse>(responseContent); //this may not work as response might also be xml
                }
                return ex.Message;
            }

            return "";
        }
    }
}
