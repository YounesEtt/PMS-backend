using ProformaInvoiceBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Azure.Core;
namespace ProformaInvoiceBackEnd.Services
{
    public class KPIsService
    {
        private readonly ApplicationDbContext _context;

        public KPIsService(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public Dictionary<int, int> GetRequestCountByAllScenarios()
        {
            return _context.request
                           .Where(r => r.scenarioId.HasValue)  // Filter out null values
                           .GroupBy(r => r.scenarioId.Value)
                           .Select(group => new { ScenarioId = group.Key, Count = group.Count() })
                           .ToDictionary(x => x.ScenarioId, x => x.Count);
        }
        public IEnumerable<request> GetAllRequests()
        {
            return _context.request.ToList();
        }
        public Dictionary<string, Dictionary<DateTime, int>> GetRequestCountByCostCenterPerDay()
        {
            var result = _context.request
                .Where(r => r.created_at.HasValue)
                .SelectMany(r => r.Item, (r, i) => new { Request = r, Item = i })
                .GroupBy(ri => new { ri.Item.COSTCENTER, Date = ri.Request.created_at.Value.Date })
                .Select(group => new
                {
                    group.Key.COSTCENTER,
                    group.Key.Date,
                    Count = group.Count()
                })
                .ToList();

            var dict = new Dictionary<string, Dictionary<DateTime, int>>();

            foreach (var item in result)
            {
                if (!dict.ContainsKey(item.COSTCENTER))
                {
                    dict[item.COSTCENTER] = new Dictionary<DateTime, int>();
                }

                dict[item.COSTCENTER][item.Date] = item.Count;
            }

            return dict;
        }
        public Dictionary<string, Dictionary<int, int>> GetRequestCountByCostCenterPerScenario()
        {
            var result = _context.request
                .SelectMany(r => r.Item, (r, i) => new { Request = r, Item = i })
                .GroupBy(ri => new { ri.Item.COSTCENTER, ri.Request.scenarioId })
                .Select(group => new
                {
                    group.Key.COSTCENTER,
                    group.Key.scenarioId,
                    Count = group.Count()
                })
                .ToList();

            var dict = new Dictionary<string, Dictionary<int, int>>();

            foreach (var item in result)
            {
                if (!dict.ContainsKey(item.COSTCENTER))
                {
                    dict[item.COSTCENTER] = new Dictionary<int, int>();
                }

                dict[item.COSTCENTER][item.scenarioId ?? 0] = item.Count;
            }

            return dict;
        }


        // New method to calculate average flow time
        public Dictionary<int, double> GetAverageFlowTimeForAllRequests()
        {
            var allRequests = _context.request.ToList();
            var averageFlowTimes = new Dictionary<int, double>();

            foreach (var req in allRequests)
            {
                var approverRequests = _context.ApproverRequest
                    .Where(ar => ar.RequestId == req.RequestNumber)
                    .OrderBy(ar => ar.status_datetime)
                    .ToList();

                if (approverRequests.Count < 2)
                {
                    averageFlowTimes[req.RequestNumber] = 0;
                    continue;
                }

                double totalFlowTime = 0;
                int validIntervals = 0;

                for (int i = 1; i < approverRequests.Count; i++)
                {
                    var previous = approverRequests[i - 1];
                    var current = approverRequests[i];

                    if (previous.status_datetime.HasValue && current.status_datetime.HasValue)
                    {
                        totalFlowTime += (current.status_datetime.Value - previous.status_datetime.Value).TotalMinutes;
                        validIntervals++;
                    }
                }

                averageFlowTimes[req.RequestNumber] = validIntervals > 0 ? totalFlowTime / validIntervals : 0;
            }

            return averageFlowTimes;
        }
    }
}
