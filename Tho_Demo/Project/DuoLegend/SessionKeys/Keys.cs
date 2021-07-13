namespace DuoLegend.SessionKeys
{
    /// <summary>
    /// Provides access to session keys
    /// </summary>
    public static class Keys
    {
        private const string _adminId = "_AdminId" ;
        private const string _visitedToday = "_VisitedToday";   //This one is for persistence cookie
        private const string _visitingSession = "_VisitingSession";
        private const string _rankUpdated = "_RankUpdated";

        public static string AdminId => _adminId;

        public static string VisitedToday => _visitedToday;

        public static string VisitingSession => _visitingSession;

        public static string RankUpdated => _rankUpdated;
    }
}