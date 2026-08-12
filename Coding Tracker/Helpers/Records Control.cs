using Coding_Tracker;

namespace Coding_Tracker.Helpers
{
    internal class Records_Control
    {
        internal string? ConnectionString { get; set; }

        internal Records_Control(string stringConnection) 
        {
            this.ConnectionString = stringConnection; // "this" is to apoint that ConnectionString is the propertie
        }










    }

}
