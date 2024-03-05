using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class UserLabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LabelID { get; set; }
        public string LabelName { get; set; }

        [ForeignKey("Users")] 
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual UserEntity Users { get; set; }

        [ForeignKey("Notes")]
        public int NotesId { get; set; }
        [JsonIgnore]
        public virtual NoteEntity Notes { get; set; }
    }
}
