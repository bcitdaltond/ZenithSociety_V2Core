using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithSocietyCore.Models
{
    public class SeedData
    {
        public static void Initialize(ZenithContext db)
        {
            if (!db.Activities.Any())
            {
                //...................................................
                // Activity Seed Data
                db.Activities.Add(new Activity
                {
                    Description = "Intro to HTML 5",
                    CreationDate = Convert.ToDateTime("2017/01/01")
                });
                db.Activities.Add(new Activity
                {
                    Description = "Intro to CSS 3",
                    CreationDate = Convert.ToDateTime("2017/01/02")
                });
                db.Activities.Add(new Activity
                {
                    Description = "Intro to Javascript",
                    CreationDate = Convert.ToDateTime("2017/01/03")
                });
                db.Activities.Add(new Activity
                {
                    Description = "Intro to UX/UI",
                    CreationDate = Convert.ToDateTime("2017/01/04")
                });
                db.SaveChanges();
                //...................................................
                // Events Seed Data
                db.Events.Add(new Event
                {
                    Start = new DateTime(2017, 3, 14, 6, 30, 0),
                    End = new DateTime(2017, 3, 14, 8, 30, 0),
                    CreatedBy = "a",

                    ActivityId = db.Activities.FirstOrDefault(
                        a => a.Description == "Intro to HTML 5")
                        .ActivityId,
                    CreationDate = Convert.ToDateTime("2017/01/04"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    Start = new DateTime(2017, 3, 15, 6, 30, 0),
                    End = new DateTime(2017, 3, 15, 8, 30, 0),
                    CreatedBy = "a",

                    ActivityId = db.Activities.FirstOrDefault(
                         a => a.Description == "Intro to Javascript")
                        .ActivityId,
                    CreationDate = Convert.ToDateTime("2017/01/04"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    Start = new DateTime(2017, 3, 16, 6, 30, 0),
                    End = new DateTime(2017, 3, 16, 8, 30, 0),
                    CreatedBy = "a",

                    ActivityId = db.Activities.FirstOrDefault(
                        a => a.Description == "Intro to CSS 3")
                        .ActivityId,
                    CreationDate = Convert.ToDateTime("2017/01/04"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    Start = new DateTime(2017, 3, 13, 7, 00, 0),
                    End = new DateTime(2017, 3, 13, 8, 30, 0),
                    CreatedBy = "a",

                    ActivityId = db.Activities.FirstOrDefault(
                        a => a.Description == "Intro to UX/UI")
                        .ActivityId,
                    CreationDate = Convert.ToDateTime("2017/01/04"),
                    IsActive = true
                });
                db.SaveChanges();
            }
        }
    }
}