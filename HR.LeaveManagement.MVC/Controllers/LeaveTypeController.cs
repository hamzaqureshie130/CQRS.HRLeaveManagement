using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;
        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;

        }
        // GET: LeaveTypeController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);

        }

        // GET: LeaveTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveType);
        }

        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(leaveType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(leaveType);
        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _leaveTypeService.GetLeaveTypeDetails(id);

            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(id, leaveType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(leaveType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLeaveType(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Allocate(int id)
        //{
        //    try
        //    {
        //        var response = await _leaveAllocationService.CreateLeaveAllocations(id);
        //        if (response.Success)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }

        //    return BadRequest();
        //}
    }
}
