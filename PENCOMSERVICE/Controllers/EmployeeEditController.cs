using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PENCOMSERVICE.Extensions.Alerts;
using PENCOMSERVICE.Models.BaseModel;
using PENCOMSERVICE.Models.Interface;

namespace PENCOMSERVICE.Controllers
{
    public class EmployeeEditController : Controller
    {
        private readonly PFAContext _context;
        private IPencomService _pencomService;
        private IMAGESContext _imagesContext;

        public EmployeeEditController(PFAContext context, IPencomService pencomService, IMAGESContext imagesContext)
        {
            _context = context;
            _pencomService = pencomService;
            _imagesContext = imagesContext;
        }

        // GET: EmployeeEdit
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeesRecapture.ToListAsync());
        }

        // GET: EmployeeEdit/Details/5
        public async Task<IActionResult> Details(string pin)
        {
            if (pin == null)
            {
                return NotFound();
            }

            var employeesRecapture = await _context.EmployeesRecapture
                .FirstOrDefaultAsync(m => m.Pin == pin);
            if (employeesRecapture == null)
            {
                return NotFound();
            }

            var setpin = employeesRecapture.SubmitCode;

            //soap call
            //var response = await _pencomService.GetRequestStatus(employeesRecapture.SubmitCode);

            ViewData["ECRmessage"] = employeesRecapture.SubmitResponse;

            return View(employeesRecapture);
        }

        // GET: EmployeeEdit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeEdit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Transid,Pin,Title,Firstname,Othernames,Surname,MaidenName,Gender,MaritalStatusCode,NationalityCode,StateOfOrigin,LgaCode,PlaceOfBirth,Bvn,Ssn,DateOfBirth,PermanentAddressLocation,PermanentAddress,PermanentAddress1,PermCity,PermLga,PermState,PermCountry,PermZip,PermBox,Email,Email1,MobilePhone,MobilePhone1,CorrespondenceAdds,CorrespondenceAdds1,City,State,EmployerType,EmployerName,EmployerRcno,EmployerLocation,EmployerAddress,EmployerAddress1,EmployerCity,EmployerLga,EmployerStatecode,EmployerCountry,EmployerZip,EmployerBox,EmployerPhone,EmployerBusiness,DateOfFirstApppoinment,DateEmployed,DateConfirmed,StateOfPosting,EmployeeId,NokTitle,NokGender,NokName,NokOthername,NokSurname,NokMaidenname,NokDob,NokRelationship,NokLocation,NokAddress,NokAddress1,NokCity,NokLga,NokStatecode,NokCountry,NokZip,NokBox,NokMobilePhone,NokEmailaddress,Nok2Title,Nok2Gender,Nok2Firstname,Nok2Othername,Nok2Surname,Nok2Maidenname,NokDob2,Nok2Relationship,Nok2Location,Nok2Address,Nok2Address1,Nok2City,Nok2Lga,Nok2Statecode,Nok2Countrycode,Nok2Zip,No2kBox,Nok2Mobilephone,Nok2Emailaddress,BranchCode,ClientStatus,Userid,DateCreated,Checked,CheckedBy,CheckedDate,Approved,ApprovedBy,ApprovedDate,FormRefno,RsaStatus,IsSubmitted,SubmitResponse,SubmitCode")] EmployeesRecapture employeesRecapture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeesRecapture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeesRecapture);
        }

        // GET: EmployeeEdit/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesRecapture = await _context.EmployeesRecapture.FindAsync(id);
            if (employeesRecapture == null)
            {
                return NotFound();
            }

            //var response = await _pencomService.GetRequestStatus(employeesRecapture.SubmitCode);

            ViewData["ECRmessage"] = employeesRecapture.SubmitResponse;

            return View(employeesRecapture);
        }

        // POST: EmployeeEdit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Transid,Pin,Title,Firstname,Othernames,Surname,MaidenName,Gender,MaritalStatusCode,NationalityCode,StateOfOrigin,LgaCode,PlaceOfBirth,Bvn,Ssn,DateOfBirth,PermanentAddressLocation,PermanentAddress,PermanentAddress1,PermCity,PermLga,PermState,PermCountry,PermZip,PermBox,Email,Email1,MobilePhone,MobilePhone1,CorrespondenceAdds,CorrespondenceAdds1,City,State,EmployerType,EmployerName,EmployerRcno,EmployerLocation,EmployerAddress,EmployerAddress1,EmployerCity,EmployerLga,EmployerStatecode,EmployerCountry,EmployerZip,EmployerBox,EmployerPhone,EmployerBusiness,DateOfFirstApppoinment,DateEmployed,DateConfirmed,StateOfPosting,EmployeeId,NokTitle,NokGender,NokName,NokOthername,NokSurname,NokMaidenname,NokDob,NokRelationship,NokLocation,NokAddress,NokAddress1,NokCity,NokLga,NokStatecode,NokCountry,NokZip,NokBox,NokMobilePhone,NokEmailaddress,Nok2Title,Nok2Gender,Nok2Firstname,Nok2Othername,Nok2Surname,Nok2Maidenname,NokDob2,Nok2Relationship,Nok2Location,Nok2Address,Nok2Address1,Nok2City,Nok2Lga,Nok2Statecode,Nok2Countrycode,Nok2Zip,No2kBox,Nok2Mobilephone,Nok2Emailaddress,BranchCode,ClientStatus,Userid,DateCreated,Checked,CheckedBy,CheckedDate,Approved,ApprovedBy,ApprovedDate,FormRefno,RsaStatus,IsSubmitted,SubmitResponse,SubmitCode")] EmployeesRecapture employeesRecapture)
        {
            if (id != employeesRecapture.Transid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(employeesRecapture);
                await _context.SaveChangesAsync();
                var res = new ECRDataModel();
                try
                {
                    var imgs = await _imagesContext.EmployeeImagesRecapture.Where(i => i.Pin == employeesRecapture.Pin).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (imgs != null)
                    {
                        res = new ECRDataModel
                        {
                            Bvn = employeesRecapture.Bvn,
                            DateEmployed = employeesRecapture.DateEmployed,
                            DateOfBirth = employeesRecapture.DateOfBirth,
                            DateOfFirstApppoinment = employeesRecapture.DateOfFirstApppoinment,
                            Email = employeesRecapture.Email,
                            Pin = employeesRecapture.Pin,
                            Title = employeesRecapture.Title,
                            Surname = employeesRecapture.Surname,
                            Firstname = employeesRecapture.Firstname,
                            Othernames = employeesRecapture.Othernames,
                            MaidenName = employeesRecapture.MaidenName,
                            Gender = employeesRecapture.Gender,
                            MaritalStatusCode = employeesRecapture.MaritalStatusCode,
                            NationalityCode = employeesRecapture.NationalityCode,
                            StateOfOrigin = employeesRecapture.StateOfOrigin,
                            LgaCode = employeesRecapture.LgaCode,
                            PlaceOfBirth = employeesRecapture.PlaceOfBirth,
                            Ssn = employeesRecapture.Ssn,
                            PermanentAddressLocation = employeesRecapture.PermanentAddressLocation,
                            PermanentAddress = employeesRecapture.PermanentAddress,
                            PermanentAddress1 = employeesRecapture.PermanentAddress1,
                            PermCity = employeesRecapture.PermCity,
                            PermLga = employeesRecapture.PermLga,
                            PermState = employeesRecapture.PermState,
                            PermCountry = employeesRecapture.PermCountry,
                            PermZip = employeesRecapture.PermZip,
                            PermBox = employeesRecapture.PermBox,
                            MobilePhone = employeesRecapture.MobilePhone,
                            State = employeesRecapture.State,
                            EmployerType = employeesRecapture.EmployerType,
                            EmployerRcno = employeesRecapture.EmployerRcno,
                            EmployerLocation = employeesRecapture.EmployerLocation,
                            EmployerAddress = employeesRecapture.EmployerAddress,
                            EmployerAddress1 = employeesRecapture.EmployerAddress1,
                            EmployerCity = employeesRecapture.EmployerCity,
                            EmployerLga = employeesRecapture.EmployerLga,
                            EmployerStatecode = employeesRecapture.EmployerStatecode,
                            EmployerCountry = employeesRecapture.EmployerCountry,
                            EmployerZip = employeesRecapture.EmployerZip,
                            EmployerBox = employeesRecapture.EmployerBox,
                            EmployerPhone = employeesRecapture.EmployerPhone,
                            EmployerBusiness = employeesRecapture.EmployerBusiness,
                            NokTitle = employeesRecapture.NokTitle,
                            NokGender = employeesRecapture.NokGender,
                            NokName = employeesRecapture.NokName,
                            NokOthername = employeesRecapture.NokOthername,
                            NokSurname = employeesRecapture.NokSurname,
                            NokRelationship = employeesRecapture.NokRelationship,
                            NokLocation = employeesRecapture.NokLocation,
                            NokAddress = employeesRecapture.NokAddress,
                            NokAddress1 = employeesRecapture.NokAddress1,
                            NokCity = employeesRecapture.NokCity,
                            NokLga = employeesRecapture.NokLga,
                            NokStatecode = employeesRecapture.NokStatecode,
                            NokCountry = employeesRecapture.NokCountry,
                            NokZip = employeesRecapture.NokZip,
                            NokBox = employeesRecapture.NokBox,
                            NokMobilePhone = employeesRecapture.NokMobilePhone,
                            NokEmailaddress = employeesRecapture.NokEmailaddress,
                            FormRefno = employeesRecapture.FormRefno,
                            RsaStatus = employeesRecapture.RsaStatus,
                            PictureImage = imgs.PictureImage,
                            SignatureImage = imgs.SignatureImage,
                            Thumbprint = imgs.Thumbprint
                        };
                    }
                    await _pencomService.SubmitData(res);


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesRecaptureExists(employeesRecapture.Transid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { pin = employeesRecapture.Pin}).WithSuccess($"{employeesRecapture.Pin} successfully updated","");
            }
            return View(employeesRecapture);
        }

        // GET: EmployeeEdit/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesRecapture = await _context.EmployeesRecapture
                .FirstOrDefaultAsync(m => m.Transid == id);
            if (employeesRecapture == null)
            {
                return NotFound();
            }

            return View(employeesRecapture);
        }

        // POST: EmployeeEdit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var employeesRecapture = await _context.EmployeesRecapture.FindAsync(id);
            _context.EmployeesRecapture.Remove(employeesRecapture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesRecaptureExists(decimal id)
        {
            return _context.EmployeesRecapture.Any(e => e.Transid == id);
        }
    }
}
