using CommonLayer.RequestModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRepository
    {
        public UserLabelEntity AddLabel(int UserID, int NoteID, AddModel model);
        public List<UserLabelEntity> ReadLabel(int id);
        public UserLabelEntity UpdateLabel(int NoteId, AddModel model);
        public UserLabelEntity DeleteLabel(int NoteId);
    }
}
