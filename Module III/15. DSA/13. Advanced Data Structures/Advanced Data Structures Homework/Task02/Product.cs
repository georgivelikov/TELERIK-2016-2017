using System;

public class Product : IComparable<Product>
{
    private string name;

    private decimal price;

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name
    {

        get
        {
            return this.name;
        }

        set
        {
            this.name = value;
        }
    }

    public decimal Price
    {

        get
        {
            return this.price;
        }

        set
        {
            this.price = value;
        }
    }

    public int CompareTo(Product other)
    {
        if (this.Price > other.Price)
        {
            return 1;
        }
        else if (this.Price < other.Price)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public override string ToString()
    {
        return this.Price + " " + this.Name;
    }
}

