using JSONMinMax.Model;

namespace JSONMinMax.IServices
{
    public interface IResultService
    {
        public ResultValues FindMinMaxIds(string url);
    }
}
