namespace Iso8583;

public class IsoField
{
    #region Field Map

    protected static readonly SortedDictionary<int, IsoField> _map = new();

    protected string _name;
    protected int _key;

    public IsoField(string name, int no)
    {
        _name = name;
        _key = no;
        _map.Add(no, this);
    }


    public static IsoField ValueOf(int no)
    {
        IsoField value;
        _map.TryGetValue(no, out value);
        return value;
    }

    protected IsoField()
    {
    }

    #endregion

    public object Value { get; private set; }
    public int Key => _key;
    public string Name => _name;


    public static IsoField Create(int key, byte[] value)
    {
        IsoField field = ValueOf(key);
        field.Value = value;
        return field;
    }

    // Todo: should change it to object value
    public static IsoField Create(int key, string value)
    {
        IsoField field = ValueOf(key);
        field.Value = IsoCharset.ISO_8859_1.GetBytes(value);
        return field;
    }

    public IsoField WithValue(object value)
    {
        this.Value = value;
        return this;
    }

    public T GetValue<T>()
    {
        if (Value is T value)
            return value;

        throw new IsoException("value is not of type: " + typeof(T));
    }
}