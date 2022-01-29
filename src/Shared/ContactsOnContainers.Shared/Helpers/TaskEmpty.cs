namespace ContactsOnContainers.Shared.Helpers
{
  public static class TaskEmpty<T>
  {
    private static readonly Task<T> _task = System.Threading.Tasks.Task.FromResult(default(T));

    public static Task<T> Task { get { return _task; } }
  }
}
