using Client.WcfDataService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            WSSDAEntities entities = new WSSDAEntities(new Uri("http://localhost:50620/WcfDataService.svc/"));
            foreach (var student in entities.Students)
            {
                Console.WriteLine(student.id + " " + student.name);
                List<Note> notes = entities.Notes.Where(p => p.studentId == student.id).ToList();
                foreach (var note in notes)
                {
                    Console.WriteLine("\t" + note.subject + ": " + note.note1);
                }
            }
        }
    }
}