using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Core.Context;
using Core.Data;
using Web.Models;

namespace Web.Controllers
{

    // refresh a partial view of the dashboard every X seconds
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Dashboard _dashboard;

        public HomeController()
        {
            _dbContext = DependencyResolver.Current.GetService<ApplicationDbContext>();
            _dashboard = _dbContext.Set<Dashboard>().FirstOrDefault() ?? new Dashboard() {Created = DateTime.Now};
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDashboard()
        {
            return PartialView("_DashboardPartial", new DashboardViewModel()
            {
                BuildHouseJobsRun = _dashboard.BuildHouseJobsRun,
                SayHelloJobsRun = _dashboard.SayHelloJobsRun,
                WeldingJobsRun = _dashboard.WeldingJobsRun,
                PaintingJobsRun = _dashboard.PaintingJobsRun,
                SalesJobsRun = _dashboard.SalesJobsRun,
                PlumbingJobsRun = _dashboard.PlumbingJobsRun,
                Id = _dashboard.Id
            });
        }

        [HttpGet]
        public ActionResult Reset()
        {
            var dashboard = _dbContext.Set<Dashboard>().FirstOrDefault();

            if (dashboard != null)
            {
                _dbContext.Set<Dashboard>().Remove(dashboard);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DoSayHelloJob(int? quantity)
        {
            Run<SayHello>(quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DoBuildHouseJob(int? quantity)
        {
            Run<BuildHouse>(quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DoPlumbingJob(int? quantity)
        {
            Run<Plumbing>(quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DoPaintingJob(int? quantity)
        {
            Run<Painting>(quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DoSalesJob(int? quantity)
        {
            Run<Sales>(quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DoWeldingJob(int? quantity)
        {
            Run<Welding>(quantity);

            return RedirectToAction("Index");
        }

        private void Run<T>(int? quantity) where T : BaseEntity, IDashboard, new()
        {
            var timesToRun = quantity ?? 1;

            for (var i = 0; i < timesToRun; i++)
            {
                SleepyTime();
                _dbContext.Set<T>().Add(new T() {Created = DateTime.Now, Dashboard = _dashboard});
                _dbContext.Set<Dashboard>().AddOrUpdate(_dashboard);
                _dbContext.SaveChanges();
            }
        }

        // This helps us simulate a task taking a while to run
        private void SleepyTime()
        {
            var random = new Random();

            Thread.Sleep(random.Next(1000, 10000));
        }
    }
}