using Dapper;
using System.Data;

namespace Coding_Tracker.Helpers.TypeHandler

{
    internal class TypeHandler : SqlMapper.TypeHandler<TimeSpan>
    {
        public override TimeSpan Parse(object value)
        {
            string? objectString = value.ToString();
            TimeSpan time = TimeSpan.Parse(objectString);

            return time;
        }

        public override void SetValue(IDbDataParameter parameter, TimeSpan value)
        {
            parameter.Value = value.ToString();
        }
    }
}
