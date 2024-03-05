using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class ColabEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColabId { get; set; }
        public string ColabEmail { get; set; }
        public bool ColabTrash { get; set; }
        [ForeignKey("NoteUser")]
        public int userId { get; set; }
        [JsonIgnore]
        public virtual UserEntity NoteUser { get; set; }
        [ForeignKey("NoteEntity")]
        public int NotesId { get; set; }
        public virtual NoteEntity NoteEntity { get; set; }

    }
}
