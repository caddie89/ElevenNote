using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        // POST service method
        public bool CreateNote(NoteCreate model)
        {
            //var category = _context
            //   .Categories
               //.Where(e => e.CategoryId == model.CategoryId)
               //.Include(e => e.CategoryId);

            var entity =

            new Note()
            {
                OwnerId = _userId,
                CategoryId = model.CategoryId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET all service method
        public IEnumerable<NoteListItem> GetNotes()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Notes
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new NoteListItem
                            {
                                NoteId = e.NoteId,
                                CategoryId = e.CategoryId,
                                Title = e.Title,
                                CreatedUtc = e.CreatedUtc
                            }
                    );
                return query.ToArray();
            }
        }
        // GET by Id service method
        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == id && e.OwnerId == _userId);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        CategoryId = entity.CategoryId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        CategoryName = entity.Category.CategoryName,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        // PUT service method
        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.CategoryId = model.CategoryId;
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }
        // DELETE service method
        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
