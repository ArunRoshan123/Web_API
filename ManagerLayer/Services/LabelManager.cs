using CommonLayer.RequestModels;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository repository;

        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }

        public UserLabelEntity AddLabel(int UserID, int NoteID, AddModel model)
        {
            return repository.AddLabel(UserID, NoteID, model);
        }

        public List<UserLabelEntity> ReadLabel(int id)
        {
            return repository.ReadLabel(id);
        }
        public UserLabelEntity UpdateLabel(int NoteId, AddModel model)
        {
            return repository.UpdateLabel(NoteId, model);
        }
        public UserLabelEntity DeleteLabel(int NoteId)
        {
            return repository.DeleteLabel(NoteId);
        }
    }
}
