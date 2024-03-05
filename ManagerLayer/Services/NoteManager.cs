using CommonLayer.RequestModels;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class NoteManager : INoteManager
    {
        private readonly INoteRepository repository;

        public NoteManager(INoteRepository repository)
        {
            this.repository = repository;
        }
        public NoteEntity Creation(CreationModel model,int id)
        {
            return repository.Creation(model, id);
        }
        public List<NoteEntity> Display(int id)
        {
            return repository.Display(id);
        }
        public NoteEntity EditNote(int NotesId, EditModel model)
        {
            return repository.EditNote(NotesId, model);
        }
        public NoteEntity DeleteNote(int NotesId)
        {
            return repository.DeleteNote(NotesId);
        }
        public NoteEntity EditColour(int NotesId, ColourModel model)
        {
            return repository.EditColour(NotesId, model);
        }
        public NoteEntity NotesReminder(int NotesId)
        {
           return repository.NotesReminder(NotesId);
        }
        public NoteEntity PinNotes(int NotesId)
        {
            return repository.PinNotes(NotesId);
        }
        public NoteEntity ArchiveNotes(int NotesId)
        {
            return repository.ArchiveNotes(NotesId);
        }
    }
}
