namespace System.Collections.Generic;

public interface ICollection<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
{
    bool IsReadOnly { get; }

    void Add(T item);

    void Clear();

    bool Contains(T item);

    void CopyTo(T[] array, int arrayIndex);

    bool Remove(T item);
}

public interface IReadOnlyCollection<out T> : IEnumerable<T>, IEnumerable
{
    int Count { get; }
}