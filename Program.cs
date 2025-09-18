using System;
using System.Collections.Generic;

// =================== CLASS PERSON ===================
public class Person
{
    private string nama; // Encapsulation (data hiding)
    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public Person(string nama) // Constructor
    {
        Nama = nama;
    }

    public virtual void Perkenalan() // virtual -> bisa di override
    {
        Console.WriteLine($"Halo, saya {Nama}");
    }
}
