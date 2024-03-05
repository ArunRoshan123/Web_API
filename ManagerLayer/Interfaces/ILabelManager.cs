﻿using CommonLayer.RequestModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface ILabelManager
    {
        public UserLabelEntity AddLabel(int UserID, int NoteID, AddModel model);
        public List<UserLabelEntity> ReadLabel(int id);
        public UserLabelEntity UpdateLabel(int NoteId, AddModel model);
        public UserLabelEntity DeleteLabel(int NoteId);
    }
}
