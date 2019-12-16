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
using System.Text.RegularExpressions;
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

<<<<<<< HEAD
=======
        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count();
        }

        public async Task<int> GetDataByDateCount()
        {
            var data = await GetData();
            return data.Count();
        }


>>>>>>> c637b11... starting dateRange filter
        public async Task<List<ECRDataModel>> GetPaginatedDataResult()
        {
            return await GetData();
            //return data.OrderBy(o => o.ID).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        private async Task<List<ECRDataModel>> GetData()
        {

            var resList = new List<ECRDataModel>();
<<<<<<< HEAD
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && !pfa.IsSubmitted).Take(400).ToListAsync(); // I removed the .where(is approved and issubmitted) please in the db edit the ISsubmitted row to False for all and rerun that should work
=======
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && pfa.IsSubmitted == false).Take(600).ToListAsync(); // I removed the .where(is approved and issubmitted) please in the db edit the ISsubmitted row to False for all and rerun that should work

            var res = new ECRDataModel();

            foreach (var item in pfadata)
            {
                Debug.WriteLine(item.Firstname + " " + item.Pin);
                var imgs = await _imagesContext.EmployeeImagesRecapture.Where(i => i.Pin == item.Pin).FirstOrDefaultAsync().ConfigureAwait(false);
                if (imgs != null)
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

        private async Task<List<ECRDataModel>> GetDataByDate(DateTime startDate, DateTime endDate)
        {
            // return await _dbContext.ECRDataModel.ToListAsync();
            var resList = new List<ECRDataModel>();
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == false && pfa.IsSubmitted == false && pfa.DateCreated < endDate && pfa.DateCreated > startDate).Take(400).ToListAsync(); // I removed the .where(is approved and issubmitted) please in the db edit the ISsubmitted row to False for all and rerun that should work
>>>>>>> c637b11... starting dateRange filter

            var res = new ECRDataModel();

            foreach (var item in pfadata)
            {
                Debug.WriteLine(item.Firstname + " " + item.Pin);
                var imgs = await _imagesContext.EmployeeImagesRecapture.Where(i => i.Pin == item.Pin && i.PictureImage != null && i.SignatureImage != null && i.Thumbprint != null).FirstOrDefaultAsync().ConfigureAwait(false);
                if (imgs != null)
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

            //var residentTownCity = model.PermCity.Trim();
            //var residentStreetName = model.PermanentAddress1.Trim();
            //var residentHouseNameNum = model.PermanentAddress1.Trim();
            //var dateOfFirstAppointment = model.DateOfFirstApppoinment.GetValueOrDefault().ToString("yyyy-MM-dd");
            var formRefNo = model.FormRefno is null ? "" : model.FormRefno.Trim();
            var rsaStatus = model.RsaStatus is null ? "" : model.RsaStatus.Trim();
            var pin = model.Pin is null ? "" : model.Pin.Trim();
            var bvn = model.Bvn is null ? "" : model.Bvn.Trim();
            var nin =model.Ssn is null ? "" : model.Ssn.Trim();
            var title = model.Title is null ? "" : model.Title.Trim();
            var surname = model.Surname is null ? "" : model.Surname.Trim();
            var firstName = model.Firstname is null ? "" : model.Firstname.Trim();
            var otherNames =model.Othernames is null ? "" : model.Othernames.Trim();
            var maidenName = model.MaidenName is null ? "" : model.MaidenName.Trim();
            var gender = model.Gender is null ? "" : model.Gender.Trim();
            var maritalStatus = model.MaritalStatusCode is null ? "" : model.MaritalStatusCode.Trim();
            var nationality = model.NationalityCode is null ? "" : model.NationalityCode.Trim();
            var stateOfOriginCode = model.StateOfOrigin is null ? "" : model.StateOfOrigin.Trim();
            var lgaCode = model.LgaCode is null ? "" : model.LgaCode.Trim();
            var email = model.Email is null ? "" : model.Email.Trim();
            var mobilePhone = model.MobilePhone is null ? "" : model.MobilePhone.Trim();
            var poBox = model.PermBox is null ? "" : model.PermBox.Trim();
            var nigeriaOrAbroad = model.PermanentAddressLocation is null ? "" : model.PermanentAddressLocation.Trim();
            var residencyCountryCode = model.PermCountry is null ? "" : model.PermCountry.Trim();
            var residentStateCode = model.PermState is null ? "" : model.PermState.Trim();
            var residentLgaCode = model.PermLga is null ? "" : model.PermLga.Trim();
            var residentZipCode = model.PermZip is null ? "" : model.PermZip.Trim();
            var sectorClass = model.EmployerType is null ? "" : model.EmployerType.Trim();
            var employerCode = model.EmployerRcno is null ? "" : model.EmployerRcno.Trim();
            var employerLocation = model.EmployerLocation is null ? "" : model.EmployerLocation.Trim();
            var employerCountry = model.EmployerCountry is null ? "" : model.EmployerCountry.Trim();
            var employerStateCode = model.EmployerStatecode is null ? "" : model.EmployerStatecode.Trim();
            var employerLga = model.EmployerLga is null ? "" : model.EmployerLga.Trim();
            var employerCity = model.EmployerCity is null ? "" : model.EmployerCity.Trim();
            var employerZip = model.EmployerZip is null ? "" : model.EmployerZip.Trim();
            var employerPoBox = model.EmployerBox is null ? "" : model.EmployerBox.Trim();
            var employerPhone = model.EmployerPhone is null ? "" : model.EmployerPhone.Trim();
            var nokTitle = model.NokTitle is null ? "" : model.NokTitle.Trim();
            var nokGender = model.NokGender is null ? "" : model.NokGender.Trim();
            var nokSurname = model.NokSurname is null ? "" : model.NokSurname.Trim();
            var nokName = model.NokName is null ? "" : model.NokName.Trim();
            var nokMiddleName = model.NokOthername is null ? "" : model.NokOthername.Trim();
            var nokRelationship = model.NokRelationship is null ? "" : model.NokRelationship.Trim();
            var nokLocation = model.NokLocation is null ? "" : model.NokLocation.Trim();
            var nokCountry = model.NokCountry is null ? "" : model.NokCountry.Trim();
            var nokStateCode = model.NokStatecode is null ? "" : model.NokStatecode.Trim();
            var nokLgaCode = model.NokLga is null ? "" : model.NokLga.Trim();
            var nokZipCode = model.NokZip is null ? "" : model.NokZip.Trim();
            var nokMobile = model.NokMobilePhone is null ? "" : model.NokMobilePhone.Trim();
            var bioPicture = Convert.ToBase64String(model.PictureImage);
            var bioSignature = Convert.ToBase64String(model.SignatureImage);
            var bioThumbprint = Convert.ToBase64String(model.Thumbprint);

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
                "<formNumber>" +  formRefNo + "</formNumber>" +
                "<personalData>" +
                    "<rsaStatus>" + rsaStatus + "</rsaStatus>" +
                    "<rsaPin>" + pin + "</rsaPin>" +
                    "<bvn>" + bvn + "</bvn>" +
                    "<nin>" + nin + "</nin>" +
                    "<title>" + title + "</title>" +
                    "<surname>" + surname + "</surname>" +
                    "<firstName>" + firstName + "</firstName>" +
                    "<middleName>" + otherNames + "</middleName>" +
                    "<maidenOrFormerName>" + maidenName + "</maidenOrFormerName>" +
                    "<gender>" + gender + "</gender>" +
                    "<maritalStatus>" + maritalStatus + "</maritalStatus>" +
                    "<nationality>" + nationality + "</nationality>" +
                    "<stateOfOriginCode>" + stateOfOriginCode + "</stateOfOriginCode>" +
                    "<localGovernmentOfOriginCode>" + lgaCode + "</localGovernmentOfOriginCode>" +
                    "<dateOfBirth>" + dob + "</dateOfBirth>" +
                    "<placeOfBirth>" + model.PlaceOfBirth + "</placeOfBirth>" +
                    "<email>" + email + "</email>" +
                    "<phoneNumber>" + mobilePhone + "</phoneNumber>" +
                    "<poBox>" + poBox + "</poBox>" +
                    "<nigeriaOrAbroad>" + nigeriaOrAbroad + "</nigeriaOrAbroad>" +
                    "<residenceCountryCode>" + residencyCountryCode + "</residenceCountryCode>" +
                    "<residenceStateCode>" + residentStateCode + "</residenceStateCode>" +
                    "<residenceLocalGovernmentCode>" + residentLgaCode + "</residenceLocalGovernmentCode>" +
                    "<residenceTownCity>" + model.PermCity + "</residenceTownCity>" +
                    "<residenceStreetName>" + model.PermanentAddress1 + "</residenceStreetName>" +
                    "<residenceHouseNameOrNumber>" + model.PermanentAddress + "</residenceHouseNameOrNumber>" +
                    "<residenceZipCode>" + residentZipCode + "</residenceZipCode>" +
                "</personalData>" +
                "<employmentRecord>" +
                    "<sectorClass>" + sectorClass + "</sectorClass>" +
                    "<employerCode>" + employerCode + "</employerCode>" +
                    "<nigeriaOrAbroad>" + employerLocation + "</nigeriaOrAbroad>" +
                    "<countryCode>" + employerCountry + "</countryCode>" +
                    "<stateCode>" + employerStateCode + "</stateCode>" +
                    "<localGovernmentCode>" + employerLga + "</localGovernmentCode>" +
                    "<townCity>" + employerCity + "</townCity>" +
                    "<streetName>" + model.EmployerAddress1 + "</streetName>" +
                    "<buildingNameOrNumber>" + model.EmployerAddress + "</buildingNameOrNumber>" +
                    "<zipCode>" + employerZip + "</zipCode>" +
                    "<poBox>" + employerPoBox + "</poBox>" +
                    "<phoneNumber>" + employerPhone + "</phoneNumber>" +
                    "<natureOfBusiness>" + model.EmployerBusiness + "</natureOfBusiness>" +
                    "<dateOfFirstAppointment>" + model.DateOfFirstApppoinment + "</dateOfFirstAppointment>" +
                    "<dateOfCurrentEmployment>" + model.DateEmployed + "</dateOfCurrentEmployment>" +
                "</employmentRecord>" +
                "<nextOfKinDetail>" +
                    "<title>" + nokTitle + "</title>" +
                    "<gender>" + nokGender + "</gender>" +
                    "<surname>" + nokSurname + "</surname>" +
                    "<firstName>" + nokName + "</firstName>" +
                    "<middleName>" + nokMiddleName + "</middleName>" +
                    "<relationship>" + nokRelationship + "</relationship>" +
                    "<nigeriaOrAbroad>" + nokLocation + "</nigeriaOrAbroad>" +
                    "<residenceCountryCode>" + nokCountry + "</residenceCountryCode>" +
                    "<residenceStateCode>" + nokStateCode + "</residenceStateCode>" +
                    "<residenceLocalGovernmentCode>" + nokLgaCode + "</residenceLocalGovernmentCode>" +
                    "<residenceTownCity>" + model.NokCity + "</residenceTownCity>" +
                    "<residenceStreetName>" + model.NokAddress1 + "</residenceStreetName>" +
                    "<residenceHouseNumber>" + model.NokAddress + "</residenceHouseNumber>" +
                    "<zipCode>" + nokZipCode + "</zipCode>" +
                    "<poBox>" + model.NokBox + "</poBox>" +
                    "<email>" + model.NokEmailaddress + "</email>" +
                    "<phoneNumber>" + nokMobile + "</phoneNumber>" +
                "</nextOfKinDetail>" +
                "<biometric>" +
                    "<picture>" + bioPicture + "</picture>" +
                    "<signature>" + bioSignature + "</signature>" +
                    "<consentForm>" + bioThumbprint + "</consentForm>" +
                "</biometric>" +
            "</contributor>" +
            "</body>" +
            "</RecaptureRequestDetail>" +
            "</ws:recaptureRequest></soapenv:Body></soapenv:Envelope>";

            WebClient webClient = new WebClient();
            webClient.Headers["Content-Type"] = "text/xml; charset=utf-8";
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
                var setId = responseArr[1].ToString();
                var responseMessage = responseArr[3];
                emp.IsSubmitted = setId is null || setId == "" || string.IsNullOrEmpty(setId) ? emp.IsSubmitted = false : emp.IsSubmitted = true;
                emp.SubmitResponse = responseMessage;

                emp.SubmitCode = setId;

                try
                {
                    string submissionStatus = "";
                    if (setId is null || setId == "" || string.IsNullOrEmpty(setId))
                    {
                        jResult.Counter = jResult.Counter == 0 ? 0 : jResult.Counter--;
                        return jResult;
                    }

                    submissionStatus = await GetRequestStatus(setId);
                    if (submissionStatus.ToUpper() == "ACCEPTED")
                    {
                        emp.SubmitResponse = submissionStatus;
                        jResult.responsemessage = submissionStatus;
                    }
                    else
                    {
                        emp.SubmitResponse = submissionStatus;
                    }
                }
                catch (Exception ex)
                {
                    return new PencomResponse { responsecode = "", responsemessage = ex.Message };
                }

                jResult.Counter++;
                _pfaContext.EmployeesRecapture.Update(emp);
                await _pfaContext.SaveChangesAsync();

                return jResult;
            }
            catch (WebException ex)
            {
                var errorResponse = new PencomResponse { responsecode = "500", responsemessage = $" An error from Pencom Server says: {ex.Message} " };
                //emp.IsSubmitted = false;
                //emp.SubmitResponse = errorResponse.responsemessage;
                //emp.SubmitCode = errorResponse.responsecode;

                //_pfaContext.EmployeesRecapture.Update(emp);
                //await _pfaContext.SaveChangesAsync();

                return errorResponse;
            }
        }

        public string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public async Task<List<ECRDataModel>> GetAcceptedData(int page, int pageSize)
        {
            var resList = new List<ECRDataModel>();
            var status = " PIN has already been recaptured;";
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && pfa.IsSubmitted && (String.Equals(pfa.SubmitResponse, status) || String.Equals(pfa.SubmitResponse, "Accepted")))
                .Skip((page - 1) * pageSize).Take(pageSize).OrderByDescending(t => t.SubmitCode).ToListAsync().ConfigureAwait(false);

            var res = new ECRDataModel();

            foreach (var item in pfadata)
            {

                Debug.WriteLine(item.Firstname + " " + item.Pin);
                var imgs = await _imagesContext.EmployeeImagesRecapture.Where(i => i.Pin == item.Pin).FirstOrDefaultAsync().ConfigureAwait(false);

                if (imgs != null)
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

        public async Task<int> GetAcceptedCount()
        {
            var status = " PIN has already been recaptured;";
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && pfa.IsSubmitted && (String.Equals(pfa.SubmitResponse, status) || String.Equals(pfa.SubmitResponse, "Accepted")))
                .ToListAsync().ConfigureAwait(false);
            return pfadata.Count();
        }

        public async Task<List<ECRDataModel>> GetSubmittedData(int page, int pageSize)
        {
            var resList = new List<ECRDataModel>();
            var status = " PIN has already been recaptured;";
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && pfa.IsSubmitted && !String.Equals(pfa.SubmitResponse, status) && pfa.SubmitResponse.ToUpper() != "ACCEPTED").Skip((page - 1) * pageSize).Take(pageSize).OrderByDescending(t => t.SubmitCode)
                .ToListAsync().ConfigureAwait(false);
            var res = new ECRDataModel();

            foreach (var item in pfadata)
            {
                //Seeding the data with Get Request Status Response
                //var response = await GetRequestStatus(item.SubmitCode);

                //item.SubmitResponse = response;
                //_pfaContext.EmployeesRecapture.Update(item);
                //await _pfaContext.SaveChangesAsync();

                //Debug.WriteLine(item.Firstname + " " + item.Pin);
                var imgs = await _imagesContext.EmployeeImagesRecapture.Where(i => i.Pin == item.Pin).FirstOrDefaultAsync().ConfigureAwait(false);

                if (imgs != null)
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

        public async Task<int> GetSubmittedCount()
        {
            var status = " PIN has already been recaptured;";
            var pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && pfa.IsSubmitted && !String.Equals(pfa.SubmitResponse, status)).ToListAsync().ConfigureAwait(false);
            return pfadata.Count();
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

                var responseXML = Regex.Replace(xmlOutput, @"\t|\n|\r", "");
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
                return ex.Message;
            }

            // return "";
        }

        public async Task<List<ECRDataModel>> GetXimoData()
        {
            var ximoData = await _dbContext.ECRDataModel.ToListAsync();

            if (ximoData != null)
            {
                IsLoading = false;
            }

            return ximoData;
        }

        
        public async Task<List<ECRDataModel>> GetSearchResult(string searchString)
        {
            var resList = new List<ECRDataModel>();
            var pfadata = new List<EmployeesRecapture>();
            if (!String.IsNullOrEmpty(searchString))
            {
                pfadata = await _pfaContext.EmployeesRecapture.Where(pfa => pfa.Approved == true && pfa.Pin.Contains(searchString)).Take(100).ToListAsync();
            }

            var res = new ECRDataModel();

            foreach (var item in pfadata)
            {
                Debug.WriteLine(item.Firstname + " " + item.Pin);
                var imgs = await _imagesContext.EmployeeImagesRecapture.Where(i => i.Pin == item.Pin).FirstOrDefaultAsync().ConfigureAwait(false);
                if (imgs != null)
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
                        Thumbprint = imgs.Thumbprint
                    };

                    resList.Add(res);
                }

            }

            return resList;
        }
    }
}
