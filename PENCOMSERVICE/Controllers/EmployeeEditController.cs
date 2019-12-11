using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PENCOMSERVICE.Models.BaseModel;
using PENCOMSERVICE.Models.Interface;

namespace PENCOMSERVICE.Controllers
{
    public class EmployeeEditController : Controller
    {
        private readonly PFAContext _context;
        private IPencomService _pencomService;

        public EmployeeEditController(PFAContext context, IPencomService pencomService)
        {
            _context = context;
            _pencomService = pencomService;
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
            var response = await _pencomService.GetRequestStatus(employeesRecapture.SubmitCode);

            ViewData["ECRmessage"] = response;

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
                try
                {
                    _context.Update(employeesRecapture);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
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
