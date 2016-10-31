namespace Auxo.Globalization
{
    public interface ILocale
    {
        string this[string path] { get; }
    }
}