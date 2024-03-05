using CommonLayer.RequestModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRepository
    {
        public NoteEntity Creation(CreationModel model, int userId);
        public List<NoteEntity> Display(int id);
        public NoteEntity EditNote(int NotesId, EditModel model);
        public NoteEntity DeleteNote(int NotesId);
        public NoteEntity EditColour(int NotesId, ColourModel model);
        public NoteEntity NotesReminder(int NotesId);
        public NoteEntity PinNotes(int NotesId);
        public NoteEntity ArchiveNotes(int NotesId);
        public NoteEntity ImageNotes(string image, int NoteId);


    }
}
