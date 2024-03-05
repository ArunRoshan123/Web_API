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

        public UserLabelEntity AddLabel(int UserID, int NoteID, AddLabel model)
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
    }
}
