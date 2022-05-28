using System;

public static class EventManager
{
    public static event Action OnclockWise;
    public static event Action OncounterClockWise;
    public static event Action OnFire;
    

    public static void ClockWiseEvent() => OnclockWise?.Invoke();
    public static void CounterClockWiseEvent() => OncounterClockWise?.Invoke();
    public static void FireEvent() => OnFire?.Invoke();
}