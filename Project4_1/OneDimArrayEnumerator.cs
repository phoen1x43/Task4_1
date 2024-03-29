using System.Collections;

namespace Project_4_1;

public class OneDimArrayEnumerator<T> : IEnumerator<T> where T : IComparable<T>
{
    private readonly OneDimArray<T> _array;
    private int _position = -1;

    public OneDimArrayEnumerator(OneDimArray<T> array)
    {
        _array = array;
    }

    public T Current
    {
        get
        {
            if (_position == -1 || _position >= _array.Elements)
                throw new ArgumentException();
            return _array.GetElement(_position);
        }
    }
    
    public bool MoveNext()
    {
        if (_position < _array.Elements - 1)
        {
            _position++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public void Dispose() { }
}