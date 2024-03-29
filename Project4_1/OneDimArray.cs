using System.Collections;
using System.Data;

namespace Project_4_1;

public class OneDimArray<T> : IEnumerable<T> where T: IComparable<T>
{
    private T[] _array;
    private int _elements;
    
    public delegate bool Condition(T element);

    public delegate T Action(T element);

    public OneDimArray(int size = 10)
    {
        _array = new T[size];
        _elements = 0;
    }

    public int Elements
    {
        get
        {
            return _elements;
        }
    }
    
    public void AddElement(T element)
    {
        if (_elements == _array.Length)
            Array.Resize(ref _array, 2 * _array.Length + 1);

        _array[_elements] = element;
        _elements++;
    }

    public T GetElement(int index)
    {
        if (index < 0 || index > _elements)
            throw new ArgumentOutOfRangeException($"Element with index: {index} does not exist");

        return _array[index];
    }
    
    public void DeleteElement(int index)
    {
        if (index < 0 || index > _elements)
            throw new ArgumentOutOfRangeException($"Element with index: {index} does not exist");

        for (int i = index; i < _elements - 1; ++i)
            _array[i] = _array[i + 1];
        _elements--;
    }

    public int Count()
    {
        return Elements;
    }

    public void Sort()
    {
        for (int i = 0; i < _elements; ++i)
        {
            for (int j = 0; j < _elements - i - 1; ++j)
            {
                if (_array[j].CompareTo(_array[j + 1]) > 0)
                {
                    T temp = _array[j]; 
                    _array[j] = _array[j + 1]; 
                    _array[j + 1] = temp;
                }
            }
        }
    }

    public int CountByCondition(Condition condition)
    {
        int counter = 0;
        
        for (int i = 0; i < _elements; ++i)
            if (condition(_array[i]))
                ++counter;

        return counter;
    }

    public bool ConditionForAny(Condition condition)
    {
        for (int i = 0; i < _elements; ++i)
            if (condition(_array[i]))
                return true;

        return false;
    }

    public bool ConditionForAll(Condition condition)
    {
        for (int i = 0; i < _elements; ++i)
            if (!condition(_array[i]))
                return false;

        return true;
    }
    public bool Find(T elemToFind)
    {
        for (int i = 0; i < _elements; ++i)
            if (_array[i].CompareTo(elemToFind) == 0)
                return true;
    
        return false;
    }

    public T ConditionGetFirst(Condition condition)
    {
        for (int i = 0; i < _elements; ++i)
            if (condition(_array[i]))
                return _array[i];

        throw new InvalidExpressionException("There is not such an element");
    }

    public List<T> ActionForAll(Action action)
    {
        List<T> result = new List<T>();
        
        for (int i = 0; i < _elements; ++i)
            result.Add(action(_array[i]));

        return result;
    }

    public List<T> ConditionGetAll(Condition condition)
    {
        List<T> result = new List<T>();
        
        for (int i = 0; i < _elements; ++i)
            if (condition(_array[i]))
                result.Add(_array[i]);

        return result;
    }
    
    public void ReverseArray()
    {
        for (int i = 0; i < _elements / 2; ++i)
        {
            T temp;
            temp = _array[i];
            _array[i] = _array[_elements - 1 - i];
            _array[_elements - 1 - i] = temp;
        }
    }

    public T GetMin()
    {
        if (_elements == 0)
            throw new Exception();
        
        T min = _array[0];
        for (int i = 0; i < _elements; ++i)
            if (_array[i].CompareTo(min) < 0)
                min = _array[i];

        return min;
    }
    
    public T GetMax()
    {
        if (_elements == 0)
            throw new Exception();
        
        T max = _array[0];
        for (int i = 0; i < _elements; ++i)
            if (_array[i].CompareTo(max) > 0)
                max = _array[i];

        return max;
    }
    
    public List<T> GetRange(int fromIndex, int howMany)
    {
        if (fromIndex < 0 || fromIndex > _elements)
            throw new ArgumentOutOfRangeException($"Element with index: {fromIndex} does not exist");
        if (howMany < 0)
            throw new ArgumentException($"Incorrect index");
        
        List<T> result = new List<T>();

        for (int i = fromIndex; i < _elements && result.Count() < howMany; ++i)
            result.Add(_array[i]);

        return result;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return new OneDimArrayEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}