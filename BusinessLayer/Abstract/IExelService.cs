namespace BusinessLayer.Abstract
{
    public interface IExelService
    {
        byte[] ExelList<T>(List<T> t) where T : class;
    }
}