using System.Collections;

namespace SoCraDev.Lab.HelloWorld.Test.Common.Data;

public class BaseData : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _data;

    public BaseData(IEnumerable<object[]> data)
    {
        _data = data;
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        return _data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}