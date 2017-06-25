using System.Collections.Generic;

namespace LastTest.Models
{
    /// <summary>
    /// Класс для сбора информации о боксере. 
    /// </summary>
    public class BoxerInfo
    {
        public string BoxerName { get; set; }
        public string CountryShortName { get; set; }
        public List<RoundResult> RoundResults { get; set; }
    }

    public struct RoundResult
    {
        public string RoundName { get; set; }
        public string ResultName { get; set; }
    }
}