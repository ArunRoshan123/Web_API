﻿using CommonLayer.RequestModels;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace FunDo_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager manager;

        public LabelController(ILabelManager manager)
        {
            this.manager = manager;
        }

        [Authorize]
        [HttpPost]
        [Route("add")]

        public ActionResult Add(int NoteID, AddModel model)
        {
            try
            {
                int UserId = Convert.ToInt32(User.FindFirst("userId").Value);
                var response = manager.AddLabel(UserId, NoteID, model);
                if(response != null)
                {
                    return Ok(new ResModel<UserLabelEntity> { Success = true, Message = "Creation Passed", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserLabelEntity> { Success = false, Message = "Creation failed", Data = response });        
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<UserLabelEntity> { Success = false, Message = ex.Message, Data = null });        
            }
        }

        [Authorize]
        [HttpGet]
        [Route("read")]
        public ActionResult ReadLabel()
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                List<UserLabelEntity> response = manager.ReadLabel(id);
                if (response != null)
                {
                    return Ok(new ResModel<List<UserLabelEntity>> { Success = true, Message = "Read Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<List<UserLabelEntity>> { Success = false, Message = "Read Failure", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<List<UserLabelEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("update")]

        public ActionResult UpdateLabel(int NoteId, AddModel model)
        {
            var response = manager.UpdateLabel(NoteId, model);
            try
            {
                if (response != null)
                {
                    return Ok(new ResModel<UserLabelEntity> { Success = true, Message = "Update Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserLabelEntity> { Success = false, Message = "Update Failure", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<UserLabelEntity> { Success= false, Message = ex.Message,Data = null});
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteLabel(int NoteId)
        {
            var response = manager.DeleteLabel(NoteId);
            try
            {
                if (response != null)
                {
                    return Ok(new ResModel<UserLabelEntity> { Success = true, Message = "Delete Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserLabelEntity> { Success = false, Message = "Delete Failure", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<UserLabelEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}
