using CommonLayer.RequestModels;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class LabelRepository : ILabelRepository
    {
        private readonly FunNoteContext context;
        public LabelRepository(FunNoteContext context)
        {
            this.context = context;
        }

        public UserLabelEntity AddLabel(int UserID, int NoteID, AddModel model)
        {
            var add = context.LabelTable.FirstOrDefault(l => ((l.UserId == UserID) && (l.NotesId == NoteID) && (!string.IsNullOrEmpty(l.LabelName))));
            if (add == null)
            {
                UserLabelEntity entity = new UserLabelEntity();
                entity.UserId = UserID;
                entity.NotesId = NoteID;
                entity.LabelName = model.LabelName;
                context.LabelTable.Add(entity);
                context.SaveChanges();
                return entity;
            }
            else
            {
                throw new Exception("Label already added to the Note");
            }
        }

        public List<UserLabelEntity> ReadLabel(int id)
        {
            List<UserLabelEntity>entity = context.LabelTable.Where(x => x.UserId == id).ToList();
            return entity;
        }

        public UserLabelEntity UpdateLabel(int NoteId,  AddModel model)
        {
            var entity = context.LabelTable.FirstOrDefault(x => x.NotesId == NoteId);
            if(entity != null) 
            {
                entity.LabelName = model.LabelName;
                context.SaveChanges();
                return entity;
            }
            else
            {
                throw new Exception("Label not found");
            }
        }

        public UserLabelEntity DeleteLabel(int NoteId)
        {
            var entity = context.LabelTable.FirstOrDefault(x => x.NotesId == NoteId);

            if(entity != null)
            {
                context.LabelTable.Remove(entity);
                context.SaveChanges();
                return entity;
            }
            else
            {
                throw new Exception("Label not found");
            }
        }

        // Collab 

        public ColabEntity AddCollab(int NoteId,string Email,int UserId)
        {
            var collab = context.UserTable.FirstOrDefault(x => x.userEmail == Email);
            if(collab != null)
            {
                ColabEntity entity = new ColabEntity();
                entity.NotesId = NoteId;
                entity.ColabEmail= Email;
                entity.userId = UserId;
                context.ColabTable.Add(entity);
                context.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public ColabEntity DeleteCollab(int CollabId)
        {
            var entity = context.ColabTable.FirstOrDefault(x => x.ColabId == CollabId);

            if (entity != null)
            {
                context.ColabTable.Remove(entity);
                context.SaveChanges();
                return entity;
            }
            else
            {
                throw new Exception("collab not found");
            }
        }

    }
}
