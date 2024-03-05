using CommonLayer.RequestModels;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NoteRepository : INoteRepository
    {
        private readonly FunNoteContext context;

        public NoteRepository(FunNoteContext context)
        {
            this.context = context;
        }

        public NoteEntity Creation(CreationModel model,int userId)
        {
            NoteEntity entity = new NoteEntity();   
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.Reminder = model.Reminder;
            entity.colour = model.colour;
            entity.Image = model.Image;
            entity.IsArchive = model.IsArchive;
            entity.IsPin = model.IsPin;
            entity.UserId = userId;
            entity.IsTrash = model.IsTrash;
            entity.CreatedAt = model.CreatedAt;
            entity.UpdatedAt = model.UpdatedAt;
            context.NoteTable.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public List<NoteEntity> Display(int id)
        {
            return context.NoteTable.Where(x => x.UserId == id).ToList();
        }
        public NoteEntity EditNote(int NotesId, EditModel model)
        {
            var noteEdit = context.NoteTable.FirstOrDefault(x => x.NotesId == NotesId);
            if (noteEdit != null)
            {
                noteEdit.Description = model.Description;
                noteEdit.colour = model.colour;
                noteEdit.UpdatedAt = DateTime.UtcNow;
                context.SaveChanges();
                return noteEdit;
            }
            else
            {
                return null;
            }
        }
        public NoteEntity DeleteNote(int NotesId)
        {
            var noteDelete = context.NoteTable.FirstOrDefault(x => x.NotesId == NotesId);
            if(noteDelete != null)
            {
                context.NoteTable.Remove(noteDelete);
                context.SaveChanges();
                return noteDelete;
            }
            else
            {
                return null;
            }
        }
        public NoteEntity EditColour(int NotesId, ColourModel model)
        {
            var col = context.NoteTable.FirstOrDefault(x => x.NotesId == NotesId);
            if(col != null)
            { 
                col.colour = model.colour;
                context.SaveChanges();
            }
            return col;
        }
        public NoteEntity NotesReminder(int NotesId)
        {
            var rem = context.NoteTable.FirstOrDefault(x => x.NotesId == NotesId);
            if(rem != null)
            { 
                rem.Reminder = DateTime.UtcNow;
                context.SaveChanges();
            }
            return rem;
        }
        public NoteEntity PinNotes(int NotesId)
        {
            var pin = context.NoteTable.FirstOrDefault(x => x.NotesId == NotesId);
            if(pin != null)
            {
                if(pin.IsPin)
                {
                    pin.IsPin = false;
                    context.SaveChanges();
                }
                else
                {
                    pin.IsPin = true;
                    context.SaveChanges();
                }
                return pin;
            }
            else
            {
                return null;
            }
        }
        public NoteEntity ArchiveNotes(int NotesId)
        {
            var archive = context.NoteTable.FirstOrDefault(x => x.NotesId == NotesId);
            if (archive != null)
            {
                if (archive.IsArchive)
                {
                    archive.IsArchive = false;
                    context.SaveChanges();
                }
                else
                {
                    archive.IsArchive = true;
                    context.SaveChanges();
                }
                return archive;
            }
            else
            {
                return null;
            }
        }
    }
}
