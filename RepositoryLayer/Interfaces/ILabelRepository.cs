using CommonLayer.RequestModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRepository
    {
        public UserLabelEntity AddLabel(int UserID, int NoteID, AddLabel model);
        public List<UserLabelEntity> ReadLabel(int id);

    }
}
