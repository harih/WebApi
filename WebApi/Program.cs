using System.Net;
using System;
using System.Collections.Generic;
using System.IO;

using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/bookingList/", BookingList);
app.MapGet("/masterJenisKonsumsi/", JenisKonsumsi);


app.Run();


//static string BookingList()
//{
//    return TestObject();
//}


static string JenisKonsumsi()
{
    Jenis[] jns;
    
    jns = new Jenis[]
    {
        new Jenis (1, "Snack Siang"),
        new Jenis (2, "Makan Siang"),
        new Jenis (3, "Snack Sore")
    };

    return ConvertArrayToJson(jns);
}


static string ConvertArrayToJson<T>(T[] array)
{
    return JsonSerializer.Serialize(array);
}



static string BookingList()
{
    string _filePath = "data/bookings.json";
    string json =  File.ReadAllText(_filePath);
    return json;
}



public class Jenis
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Jenis() {
        Id = 0;
        Name = "Hari";
    }

    public Jenis(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class TWaktu
{
    public DateOnly Tanggal { get; set; }
    public TimeOnly Jam_1 { get; set; }
    public TimeOnly Jam_2 { get; set; }
}

public class TKonsumsi
{    
    public int Snack_siang { get; set; }
    public int Makan_siang { get; set; }
    public int Snack_sore { get; set; }
}


public class Booking
{
    public int Id { get; set; }
    public DateOnly Tgl_booking { get; set; }
    public required string Unit { get; set; }
    public required string Ruang { get; set; }
    public required TWaktu Waktu { get; set; }

    public required TKonsumsi Konsumsi { get; set; }
}

