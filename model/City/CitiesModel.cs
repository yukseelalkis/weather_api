using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.model.City;

namespace WeatherApi.model.City
{
    public class CitiesModel
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Population { get; set; }
    public int Area { get; set; }
    public int Altitude { get; set; }
    public List<int> AreaCode { get; set; }
    public bool IsCoastal { get; set; }
    public bool IsMetropolitan { get; set; }
    public Nuts Nuts { get; set; }
    public Coordinates Coordinates { get; set; }
    public Maps Maps { get; set; }
    public Region Region { get; set; }
    public List<District> Districts { get; set; }
    }
}

public class Nuts1
{
    public string Code { get; set; }
    public Name Name { get; set; }
}

public class Name
{
    public string En { get; set; }
    public string Tr { get; set; }
}

public class Nuts2
{
    public string Code { get; set; }
    public string Name { get; set; }
}

public class Nuts
{
    public Nuts1 Nuts1 { get; set; }
    public Nuts2 Nuts2 { get; set; }
    public string Nuts3 { get; set; }
}

public class Coordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class Maps
{
    public string GoogleMaps { get; set; }
    public string OpenStreetMap { get; set; }
}

public class Region
{
    public string En { get; set; }
    public string Tr { get; set; }
}

public class District
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Population { get; set; }
    public int Area { get; set; }
}



public class ApiResponse
{
    public string Status { get; set; }
    public List<CitiesModel> Data { get; set; }
}
