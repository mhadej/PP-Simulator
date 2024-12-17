using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        public required SimulationHistory SimulHis { get; set; }
        public int Counter { get; private set; }

        public void OnGet()
        {
            SimulHis = App._simHis;
            Counter = HttpContext.Session.GetInt32("Counter") ?? 0;
        }

        public void OnPostPrevious()
        {
            Counter = HttpContext.Session.GetInt32("Counter") ?? 1;
            SimulHis = App._simHis;

            if (Counter > 0)
            {
                Counter--;
            }

            HttpContext.Session.SetInt32("Counter", Counter);
        }
        public void OnPostNext()
        {
            SimulHis = App._simHis;
            Counter = HttpContext.Session.GetInt32("Counter") ?? 1;

            if (Counter < SimulHis.TurnLogs.Count - 1)
            {
                Counter++;
            }
            HttpContext.Session.SetInt32("Counter", Counter);
        }

        public string DirTracker(char a)
        {
            switch (a)
            {
                case 'u': return "up";
                case 'd': return "down";
                case 'r': return "right";
                case 'l': return "left";
                default: return "N/A";
            }
        }
    }
}
