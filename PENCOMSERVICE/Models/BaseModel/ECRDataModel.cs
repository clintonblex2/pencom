using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PENCOMSERVICE.Models.BaseModel
{
    [BindProperties(SupportsGet = true)]
    public class ECRDataModel
    {
        public ECRDataModel()
        {

        }

        public int ID { get; set; }
        public string Pin { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Othernames { get; set; }
        public string Surname { get; set; }
        public string MaidenName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatusCode { get; set; }
        public string NationalityCode { get; set; }
        public string StateOfOrigin { get; set; }
        public string LgaCode { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Bvn { get; set; }
        public string Ssn { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PermanentAddressLocation { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentAddress1 { get; set; }
        public string PermCity { get; set; }
        public string PermLga { get; set; }
        public string PermState { get; set; }
        public string PermCountry { get; set; }
        public string PermZip { get; set; }
        public string PermBox { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string State { get; set; }
        public string EmployerType { get; set; }
        public string EmployerRcno { get; set; }
        public string EmployerLocation { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerAddress1 { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerLga { get; set; }
        public string EmployerStatecode { get; set; }
        public string EmployerCountry { get; set; }
        public string EmployerZip { get; set; }
        public string EmployerBox { get; set; }
        public string EmployerPhone { get; set; }
        public string EmployerBusiness { get; set; }
        public DateTime? DateOfFirstApppoinment { get; set; }
        public DateTime? DateEmployed { get; set; }
        public string NokTitle { get; set; }
        public string NokGender { get; set; }
        public string NokName { get; set; }
        public string NokOthername { get; set; }
        public string NokSurname { get; set; }
        public string NokRelationship { get; set; }
        public string NokLocation { get; set; }
        public string NokAddress { get; set; }
        public string NokAddress1 { get; set; }
        public string NokCity { get; set; }
        public string NokLga { get; set; }
        public string NokStatecode { get; set; }
        public string NokCountry { get; set; }
        public string NokZip { get; set; }
        public string NokBox { get; set; }
        public string NokMobilePhone { get; set; }
        public string NokEmailaddress { get; set; }
        public string FormRefno { get; set; }
        public string RsaStatus { get; set; }

        //Second Table Properties

        public byte[] PictureImage { get; set; }
        public byte[] SignatureImage { get; set; }
        public byte[] Thumbprint { get; set; }


        //App Reliability Property
        public bool IsSubmitted { get; set; }
        public string SubmitResponse { get; set; }
        public string SubmitCode { get; set; }
    }

}
