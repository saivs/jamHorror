public static class MouseLookLock
{
    public static bool IsLocked { get => _lockAccumulator > 0; }
    private static int _lockAccumulator = 0;

    public static void AddLock()
    {
        _lockAccumulator++;
    }

    public static void RemoveLock()
    {
        _lockAccumulator--;
    }
}
