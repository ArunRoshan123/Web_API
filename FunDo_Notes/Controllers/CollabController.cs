using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using MassTransit.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;

namespace FunDo_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        private readonly ILabelManager manager;
        private readonly FunNoteContext context;

        public CollabController(ILabelManager manager, FunNoteContext context)
        {
            this.manager = manager;
            this.context = context;
        }

        [Authorize]
        [HttpPost]
        [Route("add")]
        public ActionResult AddCollab(int NoteId, string Email)

        {
            int userId  = Convert.ToInt32(User.FindFirst("userId").Value);
            var response = manager.AddCollab(NoteId, Email,userId);
            if(response != null)
            {
                return Ok(new ResModel<ColabEntity> { Success = true, Message = "Collab Added", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<ColabEntity> { Success = true, Message = "Collab Added", Data = response });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteCollab(int CollabId)

        {
            var response = manager.DeleteCollab(CollabId);
            try
            {
                if (response != null)
                {
                    return Ok(new ResModel<ColabEntity> { Success = true, Message = "Collab Deleted Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<ColabEntity> { Success = true, Message = "Collab Deleted Failed", Data = response });
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(new ResModel<ColabEntity> { Success = true, Message = ex.Message, Data = null });
            }
        }
    }
}
