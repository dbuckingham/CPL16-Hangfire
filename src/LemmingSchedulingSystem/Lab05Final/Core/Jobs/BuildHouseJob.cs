using Core.Data;

namespace Core.Jobs
{
    public class BuildHouseJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            Logger.Info($"Building a house...");
            UpdateDashboard<BuildHouse>();
        }

        public void BuildHouseWithFriend()
        {
            BuildHouseWithFriendWithName("Default");
        }

        public void BuildHouseWithFriendWithName(string friendName)
        {
            Logger.Info($"Building a house with my friend {friendName}!");
            UpdateDashboard<BuildHouse>();
        }
    }
}
