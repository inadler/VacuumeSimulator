namespace VacuumeSimulator
{
    public interface ICleanable
    {
        void Clean(Battery battery);
        bool IsDirty { get; }
    }
}