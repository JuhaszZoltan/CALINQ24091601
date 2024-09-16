using CALINQ24091601;
using System.Security.Principal;

#region list of pets 
List<Pet> pets = [
    new() //01
    {
        Name = "Wick",
        Species = "Hamster",
        BirthDate = new(2022, 05, 03),
        Sex = true,
    },
    new() //02
    {
        Name = "Dani",
        Species = "Parrot",
        BirthDate = new(2014, 06, 10),
        Sex = true,
    },
    new() //03
    {
        Name = "Szőke Sanyi",
        Species = "Chicken",
        BirthDate = new(2024, 03, 01),
        Sex = false,
    },
    new() //04
    {
        Name = "Nudli",
        Species = "Cat",
        BirthDate = new(2021, 08, 10),
        Sex = true,
    },
    new() //05
    {
        Name = "Gombóc",
        Species = "Dog",
        BirthDate = new(2021, 09, 13),
        Sex = true,
    },
    new() //06
    {
        Name = "Snorlax",
        Species = "Cat",
        BirthDate = new(2024, 05, 20),
        Sex = true,
    },
    new() //07
    {
        Name = "Lajos",
        Species = "Goat",
        BirthDate = new(2022, 06, 21),
        Sex = true,
    },
    new() //08
    {
        Name = "Gábor",
        Species = "Chicken",
        BirthDate = new(2024, 01, 03),
        Sex = false,
    },
    new() //09
    {
        Name = "Rex",
        Species = "Dog",
        BirthDate = new(2019, 07, 11),
        Sex = true,
    },
];
#endregion

Console.WriteLine($"count of pets: {pets.Count}");

/* "ismert" nevezetes algoritmusok 
 * (másolás)
 * sorozatszámítás -> összegzés ==> átlagszámítás
 * megszámlálás
 * szélsőérték meghatározás (min, max)
 * [lineáris] keresés
 * kiválasztás
 * eldöntés
 * ----------------------
 * 'rendezések'
 * kiválogatás
 * szétválogatás
 * 'halmaztételek' (unió, metszet) [... ==> distinct]
*/

////másolás (nem linq, copyto a collections.generic-ben van)
//var petarray = new Pet[pets.Count];
//pets.CopyTo(petarray);
//foreach (var p in petarray) Console.WriteLine(p.Name);

var linqsum = pets.Sum(p => p.Age);
Console.WriteLine($"eddig boldogítottak minket az állatkák: {linqsum} év");

var linqavg = pets.Average(p => p.Age);
Console.WriteLine($"állatkák átlagéletkora: {linqavg:0.00} év");

//a szélsőérték tétel 'idexet' ad vissza...
//van indexof (ez sem linq, hanem collection.generic), de azt majd később
var linqmax = pets.Max(p => p.BirthDate);
Console.WriteLine($"legfiatalabb állatka szülinapja: {linqmax:MMMM dd.}");

var linqminby = pets.MinBy(p => p.BirthDate);
Console.WriteLine($"legöregebb kiskedvenc: {linqminby}");

//find, findall, indexof <-- nem linq
//first, last, single + **ordefault <-- linq

