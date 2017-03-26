using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSocietyCore.Models;
using ZenithSocietyCore.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithSocietyCore.Controllers
{
    public class HomeController : Controller
    {
        private ZenithContext db;

        //private string dateFormat = "MMMM dd yyyy";

        public HomeController(ZenithContext context)
        {
            db = context;

        }

        public ActionResult Index()
        {
            // used to limit the range of events in current week
            // Monday to Sunday
            DateTime today = DateTime.Today;
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            // This gets all the activities with events in this week
            // but also gets events that are outside the week range (over pull)
            var activities = db.Activities.Include(a => a.Events)
                                .Where(a => a.Events
                                             .Any(e => e.Start >= startOfWeek &&
                                                  e.End <= endOfWeek &&
                                                  e.IsActive == true))
                                .Select(a => a).ToList();

            // Custom structure to re-organize the presentation 
            // of data to the homepage index view
            // This allows the controller to do the "heavy lifting"
            // and the view to do minimal logic 
            var WeekInfo = new List<DayInfo>();

            // populate the custom structure 
            foreach (var a in activities)
            {
                foreach (var e in a.Events)
                {
                    var valid = e.Start >= startOfWeek && e.End <= endOfWeek && e.IsActive == true;
                    // skip events outside of week range 
                    // remedy to the over pull of events
                    if (!valid)
                        continue;
                    var day = e.Start.Date;
                    var dayInfo = WeekInfo.FirstOrDefault(d => d.Day == day);
                    // need to create a day if it doesn't exist
                    if (dayInfo == null)
                    {
                        dayInfo = new DayInfo { Day = day, Events = new List<EventInfo>() };

                        WeekInfo.Add(dayInfo);
                    }
                    dayInfo.Events.Add(new EventInfo { Start = e.Start, End = e.End, Description = a.Description });
                }
            }
            // need to sort by day
            WeekInfo = WeekInfo.OrderBy(w => w.Day).ToList();

            foreach (var day in WeekInfo)
            {
                // need to also sort by start time in each day
                day.Events = day.Events.OrderBy(e => e.Start).ToList();
            }

            return View(WeekInfo);
        }
        // represents a day with a list of events 
        public class DayInfo
        {
            public DateTime Day { get; set; }
            public List<EventInfo> Events { get; set; }
        }
        // represents an event with a start, end, and description 
        public class EventInfo
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public String Description { get; set; }
        }


        public ActionResult About()
        {
            ViewBag.Message = "The Zenith Society is a place to live and grow - together.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Say hi to Zenith.";

            return View();
        }
    }
}
