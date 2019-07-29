using MyNotes.DataAccessLayer.EntityFramework;
using MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.BusinessLayer
{
    public class NoteManager
    {
        private Repository<Note> repo_note = new Repository<Note>();

        public List<Note> GetNotes()
        {
            return repo_note.List();
        }

        public List<Note> GetNotesParam(int? id)
        {
            return repo_note.List(x => x.Category.Id == id);
        }

    }
}
