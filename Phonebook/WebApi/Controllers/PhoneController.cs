using System;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        public ActionResult Get(PhoneRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var phone = _phoneService.GetPhoneByPhoneId(request.PhoneId);

                if (phone != null)
                {
                    return Ok(new ResponseModel<Phones> { Status = true, Message = "Operation successfully.", Object = phone });
                }

                return Ok(new ResponseModel<Phones> { Status = false, Message = "Phone couldn't found.", Object = null });
            }

            return ValidationProblem();
        }

        [HttpPost]
        public ActionResult Post([FromBody] PhoneModel request)
        {
            if (ModelState.IsValid)
            {
                _phoneService.Update(new Phones
                {
                    UserId = request.UserId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Organization = request.Organization,
                    Title = request.Title,
                    MobilePhone = request.MobilePhone,
                    HomePhone = request.HomePhone,
                    Notes = request.Notes,
                    HomeAddress = request.HomeAddress,
                    NickName = request.NickName,
                    WebSite = request.WebSite,
                    BirthDay = request.BirthDay,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = true
                });

                return Ok(new ResponseModel<Phones> { Status = true, Message = "Phone updated.", Object = null });
            }

            return ValidationProblem();
        }

        [HttpPut]
        public ActionResult Put([FromBody] PhoneModel request)
        {
            if (ModelState.IsValid)
            {
                _phoneService.Add(new Phones
                {
                    UserId = request.UserId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Organization = request.Organization,
                    Title = request.Title,
                    MobilePhone = request.MobilePhone,
                    HomePhone = request.HomePhone,
                    Notes = request.Notes,
                    HomeAddress = request.HomeAddress,
                    NickName = request.NickName,
                    WebSite = request.WebSite,
                    BirthDay = request.BirthDay,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = true
                });

                return Ok(new ResponseModel<Phones> { Status = true, Message = "Phone updated.", Object = null });
            }

            return ValidationProblem();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                var phone = _phoneService.GetPhoneByPhoneId(id);

                if (phone != null)
                {
                    _phoneService.Delete(new Phones
                    {
                        UserId = phone.UserId,
                        FirstName = phone.FirstName,
                        LastName = phone.LastName,
                        Organization = phone.Organization,
                        Title = phone.Title,
                        MobilePhone = phone.MobilePhone,
                        HomePhone = phone.HomePhone,
                        Notes = phone.Notes,
                        HomeAddress = phone.HomeAddress,
                        NickName = phone.NickName,
                        WebSite = phone.WebSite,
                        BirthDay = phone.BirthDay,
                        CreatedDate = phone.CreatedDate,
                        ModifiedDate = phone.ModifiedDate,
                        Status = true
                    });

                    return Ok(new ResponseModel<Phones> { Status = true, Message = "Phone deleted.", Object = null });
                }

                return Ok(new ResponseModel<Phones> { Status = false, Message = "Phone couldn't found.", Object = null });
            }

            return ValidationProblem();
        }
    }
}
