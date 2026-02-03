using PfsShared;

namespace PfsApplications.Applications
{
    public abstract class ApplicationBase<T>
    {
        protected abstract Task<Result<T>> Validate(T obj);
    }
}
