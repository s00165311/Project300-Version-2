using ClubsAndSocieties.Models;
using System;
using System.Linq;

namespace ClubsAndSocieties.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClubAndSocContext context)
        {
            context.Database.EnsureCreated();

            // Look for any clubs.
            if (context.ClubsAndSocieties.Any())
            {
                return;   // DB has been seeded
            }

            //clubsAndSocieties
            var clubsAndSocieties = new ClubsAndSociety[]
            {
            new ClubsAndSociety{Name="Soccer",Chairperson="Alexander",Treasurer="Mary",Secretary="Tommy",Phone="098-24232",Email="someone@email.com",Description="Two teams of 11 try to scor goals in each others net",AdminID=1},
            new ClubsAndSociety{Name="Rugby",Chairperson="Alexander",Treasurer="Mary",Secretary="Tommy",Phone="098-24232",Email="someone@email.com",Description="Two teams of 11 try to scor goals in each others net",AdminID=1},
            new ClubsAndSociety{Name="Tennis",Chairperson="Alexander",Treasurer="Mary",Secretary="Tommy",Phone="098-24232",Email="someone@email.com",Description="Two teams of 11 try to scor goals in each others net",AdminID=1},

            };
            foreach (ClubsAndSociety c in clubsAndSocieties)
            {
                context.ClubsAndSocieties.Add(c);
            }
            context.SaveChanges();

            //Students
            var students = new Student[]
            {
            new Student{Name="Tom tim",Course="Software", Email="tojf@lk.ie", Password="oooo", },
            new Student{Name="Tammy tim",Course="Systems", Email="tojf@lk.ie", Password="oooo", },
            new Student{Name="Tony tim",Course="Games", Email="tojf@lk.ie", Password="oooo", },

            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            //Members
            var members = new Member[]
            {
            new Member{StudentID=1,ClubID=1},
            new Member{StudentID=1,ClubID=2},
            new Member{StudentID=2,ClubID=2},

            };
            foreach (Member m in members)
            {
                context.Members.Add(m);
            }
            context.SaveChanges();

            //Admin
            var admins = new Administrator[]
            {
            new Administrator{ Name="Holly Hunter", Password="*****"},
            new Administrator{ Name="Martin Foley", Password="*****"},
            new Administrator{ Name="Peter Rabbit", Password="*****"},


            };
            foreach (Administrator a in admins)
            {
                context.Administors.Add(a);
            }
            context.SaveChanges();

            //Club events
            var clubEvents = new ClubEvent[]
            {
            new ClubEvent{ClubID =1, EventID=1},
            new ClubEvent{ClubID =1, EventID=2},
            new ClubEvent{ClubID =2, EventID=3},



            };
            foreach (ClubEvent ce in clubEvents)
            {
                context.ClubEvents.Add(ce);
            }
            context.SaveChanges();

            //Notifications
            var note = new Notification[]
            {
            new Notification{ AdminID =1, Title="No school", Date=DateTime.Parse("2017-09-01"), Message="There will be no school next week"},
            new Notification{ AdminID =2, Title="No school", Date=DateTime.Parse("2017-09-01"), Message="There will be no school the following week"},



            };
            foreach (Notification n in note)
            {
                context.Notifications.Add(n);
            }
            context.SaveChanges();

            //Posts
            var posts = new Post[]
            {
            new Post{StudentID=1, EventID=1, Date=DateTime.Parse("2017-09-15"), PostMessage="hi everyone :-)",Title="Hi"},
            new Post{StudentID=2, EventID=2, Date=DateTime.Parse("2017-09-15"), PostMessage="hi :-)",Title="Hi"},



            };
            foreach (Post p in posts)
            {
                context.Posts.Add(p);
            }
            context.SaveChanges();

            
        }
    }
}

