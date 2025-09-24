using System;
using System.Collections.Generic;

// CLASS PERSON
public class Person
{
    private string nama; 
    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public Person(string nama) 
    {
        Nama = nama;
    }

    public virtual void Perkenalan() 
    {
        Console.WriteLine($"Halo, saya {Nama}");
    }
}

// CLASS PELANGGAN 
public class Pelanggan : Person
{
    public string IdPelanggan { get; set; }

    public Pelanggan(string nama, string id) : base(nama)
    {
        IdPelanggan = id;
    }

    public override void Perkenalan()
    {
        Console.WriteLine($"Saya pelanggan bernama {Nama}, ID {IdPelanggan}");
    }
}

// CLASS PEGAWAI
public class Pegawai : Person
{
    public string IdPegawai { get; set; }

    public Pegawai(string nama, string id) : base(nama)
    {
        IdPegawai = id;
    }

    public override void Perkenalan()
    {
        Console.WriteLine($"Saya pegawai bernama {Nama}, ID {IdPegawai}");
    }
}

// CLASS PS 
public class PS
{
    public string Tipe { get; set; }
    public int HargaPerJam { get; set; }

    public PS(string tipe, int harga)
    {
        Tipe = tipe;
        HargaPerJam = harga;
    }
}

// CLASS RENTAL 
public class Rental
{
    public List<PS> DaftarPS = new List<PS>();

    public void TambahPS(PS ps)
    {
        DaftarPS.Add(ps);
    }

    public void TambahPS(string tipe, int harga)
    {
        DaftarPS.Add(new PS(tipe, harga));
    }

    public void LihatDaftarPS()
    {
        Console.WriteLine("\nDaftar PS yang tersedia:");
        for (int i = 0; i < DaftarPS.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DaftarPS[i].Tipe} : Rp{DaftarPS[i].HargaPerJam}/jam");
        }
    }

    public PS PilihPS(int pilihan)
    {
        if (pilihan > 0 && pilihan <= DaftarPS.Count)
        {
            return DaftarPS[pilihan - 1];
        }
        return null;
    }
}

// MAIN 
class Program
{
    static void Main(string[] args)
    {
        // Input data pegawai
        Console.Write("Masukkan nama pegawai: ");
        string namaPegawai = Console.ReadLine();
        Pegawai pegawai1 = new Pegawai(namaPegawai, "PG01");

        // Input data pelanggan
        Console.Write("Masukkan nama pelanggan: ");
        string namaPelanggan = Console.ReadLine();
        Pelanggan pelanggan1 = new Pelanggan(namaPelanggan, "P001");

        pegawai1.Perkenalan();
        pelanggan1.Perkenalan();

        // object Rental
        Rental rental = new Rental();

        // tmbah PS
        rental.TambahPS("PS3", 7000);
        rental.TambahPS("PS4", 10000);
        rental.TambahPS("PS5", 20000);

        // Tampilkan daftar PS
        rental.LihatDaftarPS();

        // Pilih PS
        Console.Write("\nPilih PS (nomor): ");
        int pilihan = int.Parse(Console.ReadLine());

        PS psDipilih = rental.PilihPS(pilihan);
        if (psDipilih != null)
        {
            Console.WriteLine($"\n{pelanggan1.Nama} memilih {psDipilih.Tipe} dengan harga Rp{psDipilih.HargaPerJam}/jam");
        }
        else
        {
            Console.WriteLine("\nPilihan tidak valid.");
        }

        Console.ReadKey();
    }
}
