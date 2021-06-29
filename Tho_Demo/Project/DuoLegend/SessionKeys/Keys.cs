namespace DuoLegend.SessionKeys
{
    /// <summary>
    /// Provides access to session keys
    /// </summary>
    public static class Keys
    {
        private const string _adminId = "_AdminId" ;
        private const string _visitedToday = "_VisitedToday";   //This one is for persistence cookie

        public static string AdminId => _adminId;

        public static string VisitedToday => _visitedToday;
    }
}