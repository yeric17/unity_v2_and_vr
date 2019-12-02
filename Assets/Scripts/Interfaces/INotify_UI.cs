using System;
public interface INotify_UI<T>
{
    event Action<T> OnChange;
}
