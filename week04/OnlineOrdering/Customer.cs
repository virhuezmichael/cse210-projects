public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        this._name = name;
        this._address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public string GetCustomerInfo()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}