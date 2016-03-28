using System.Collections.Generic;

namespace Core.Data
{
    public class Dashboard : BaseEntity
    {
        public virtual ICollection<SayHello> HellosSaid { get; set; }
        public virtual ICollection<BuildHouse> HousesBuilt { get; set; }
        public virtual ICollection<Painting> PaintingsPainted { get; set; }
        public virtual ICollection<Plumbing> ToiletsPlumbed { get; set; }
        public virtual ICollection<Sales> SalesMade { get; set; }
        public virtual ICollection<Welding> WidgetsWelded { get; set; }

        public int SayHelloJobsRun => HellosSaid?.Count ?? 0;
        public int BuildHouseJobsRun => HousesBuilt?.Count ?? 0;
        public int PaintingJobsRun => PaintingsPainted?.Count ?? 0;
        public int PlumbingJobsRun => ToiletsPlumbed?.Count ?? 0;
        public int SalesJobsRun => SalesMade?.Count ?? 0;
        public int WeldingJobsRun => WidgetsWelded?.Count ?? 0;
    }
}