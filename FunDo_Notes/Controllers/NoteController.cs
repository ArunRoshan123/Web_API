using CommonLayer.RequestModels;
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
    public class NoteController : ControllerBase
    {
        private readonly INoteManager manager;

        public NoteController(INoteManager manager)
        {
            this.manager = manager;
        }
        [Authorize]
        [HttpPost]
        [Route("add")]

        public ActionResult Creation(CreationModel model)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                var response = manager.Creation(model, id);
                if (response != null)
                {
                    return Ok(new ResModel<NoteEntity> { Success = true, Message = "Creation Passed", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<NoteEntity> { Success = false, Message = "Creation Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<NoteEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("display")]

        public ActionResult Display()
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst("userId").Value);
                List<NoteEntity> response = manager.Display(id);
                if (response != null)
                {
                    return Ok(new ResModel<List<NoteEntity>> { Success = true, Message = "Creation Passed", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<List<NoteEntity>> { Success = false, Message = "Creation Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<List<NoteEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("edit")]
        public ActionResult editNote(int NotesId, EditModel model)
        {
            var response = manager.EditNote(NotesId, model);
            if(response != null)
            {
                return Ok(new ResModel<NoteEntity> { Success = true, Message = "Edit Success", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<NoteEntity> { Success = false, Message = "Edit Failure", Data = response });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]

        public ActionResult Delete(int NotesId)
        {
            var response = manager.DeleteNote(NotesId);
            if (response != null)
            {
                return Ok(new ResModel<NoteEntity> { Success = true, Message = "delete Success", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<NoteEntity> { Success = false, Message = "delete Failure", Data = null });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("colour")]
        public ActionResult EditColour(int NotesId, ColourModel model)
        {
            var response = manager.EditColour(NotesId, model);
            if( response != null )
            {
                return Ok(new ResModel<NoteEntity> { Success = true, Message = "Edit success", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<NoteEntity> { Success = false, Message = "Edit failure", Data = response });
            }
        }
        
        [Authorize]
        [HttpPut]
        [Route("reminder")]
        public ActionResult notesreminder(int NotesId)
        {
            var response = manager.NotesReminder(NotesId);
            if( response != null )
            {
                return Ok(new ResModel<NoteEntity> { Success = true, Message = "Reminder success", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<NoteEntity> { Success = false, Message = "Reminder failure", Data = response });
            }
        }
        
        [Authorize]
        [HttpPut]
        [Route("pin")]
        public ActionResult NotesPin(int NotesId)
        {
            var response = manager.PinNotes(NotesId);
            if( response != null )
            {
                return Ok(new ResModel<NoteEntity> { Success = true, Message = "Pin success", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<NoteEntity> { Success = false, Message = "Pin failure", Data = response });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("archive")]
        public ActionResult NotesArchive(int NotesId)
        {
            var response = manager.ArchiveNotes(NotesId);
            if (response != null)
            {
                return Ok(new ResModel<NoteEntity> { Success = true, Message = "Archive success", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<NoteEntity> { Success = false, Message = "Archive failure", Data = response });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("image")]
        public ActionResult UploadImage(int NotesId, string image)
        {
            var response = manager.ImageNotes(image,NotesId);
            if (response != null)
            {
                return Ok(new ResModel<NoteEntity> { Success = true, Message = "image uploded", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<NoteEntity> { Success = false, Message = "image upload failed", Data = response });
            }
        }
    }
}


