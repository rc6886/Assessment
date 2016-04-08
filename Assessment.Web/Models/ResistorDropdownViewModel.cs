using System.Collections.Generic;

namespace Assessment.Web.Models
{
    public class ResistorDropdownViewModel
    {
        public IEnumerable<string> BandAValues { get; set; }
        public IEnumerable<string> BandBValues { get; set; }
        public IEnumerable<string> BandCValues { get; set; }
        public IEnumerable<string> BandDValues { get; set; }
    }
}