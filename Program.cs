using CALINQ24091601;

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

var linqfirst = pets.First(p => p.Species == "Cat");
Console.WriteLine($"az első cica a listában: {linqfirst}");
//ha van, visszadja a rendre ELSŐ matchy-matchy elementet
//ha nincs "sequence contains no matching element" exception

var linqlast = pets.Last(p => p.Species == "Cat");
Console.WriteLine($"az utolsó cica a listában: {linqlast}");
//ha van, visszadja a rendre UTOLSÓ matchy-matchy elementet
//ha nincs "sequence contains no matching element" exception

var linqsingle = pets.Single(p => p.Species == "Parrot");
Console.WriteLine($"az EGYETLEN papagáj a listában: {linqsingle}");
//ha EGYETLEN matchy-metchy element van, akkor azt visszaadja
//ha TÖBB van "sequence contains more than one matching element" exception
//ha egyáltalán NINCS matchy-metchy element, akkor "sequence contains no matching element" exception

var linqfirstordef = pets.FirstOrDefault(p => p.Species == "Unicorn");
Console.WriteLine($"az első cica a listában: {linqfirstordef}");
//ha van, visszadja a rendre ELSŐ matchy-matchy elementet
//ha nincs, akkor típustól függő default értékkel tér vissza, ami
//referencia-típus esetén null
//érték-típus esetén ÁLTALÁBAN "zéró"
//(custom structnál pedig olyan struct init, aminek nincsenek "kitöltve" a mezői)
//a Find(x => x..) ugyan ezt csinálja

var linqlastordef = pets.LastOrDefault(p => p.Species == "Cat");
Console.WriteLine($"az utolsó cica a listában: {linqlastordef}");
//ha van, visszadja a rendre UTOLSÓ matchy-matchy elementet
//ha nincs, akkor típustól függő default értékkel tér vissza, ami
//referencia-típus esetén null
//érték-típus esetén ÁLTALÁBAN "zéró"
//(custom structnál pedig olyan struct init, aminek nincsenek "kitöltve" a mezői)

//int[] szamok =  [2, 40, 16, 7, 11];
//var res = szamok.FirstOrDefault(e => e % 104 == 0);
//Console.WriteLine(res);

var linqsingleordef = pets.SingleOrDefault(p => p.Species == "Parrot");
Console.WriteLine($"az EGYETLEN papagáj a listában: {linqsingleordef}");
//ha EGYETLEN matchy-matchy element van, akkor azt visszaadja
//ha TÖBB van "sequence contains more than one matching element" exception
//ha NINCS, akkor pedig default értéket, ami
//referencia-típus esetén null
//érték-típus esetén ÁLTALÁBAN "zéró"
//(custom structnál pedig olyan struct init, aminek nincsenek "kitöltve" a mezői)

var firstGirl = pets.FirstOrDefault(p => p.Name == "János");
int firstGirlIndex = pets.IndexOf(firstGirl);
Console.WriteLine($"első kislány a listában: {firstGirl}; indexe: {firstGirlIndex}");
//az indexof ha nincs benne a pred. element a kollekcióban, akkor -1-el tér vissza (NEM hibát dob)

var isThereAnyMaleChicken = pets.Any(p => p.Species == "Chicken" && p.Sex);
Console.WriteLine($"{(isThereAnyMaleChicken ? "van" : "nincs")} fiú csirke a listában");

Console.WriteLine("--------------------------------");

//collection.generic 'sort'-ja helyben rendez ->
//azaz a kollekció elemeinek sorrendjét változtatja meg
//a linq orderby és az orderbydescending pedig létrehiz egy iorderedenumerable kollekciót,
//AMIBEN az elemek sorrendeje eltérő az eredeti kollekcióhoz képest

//olyan propertyk alapján lehet rendezni, amin értelmezett [<, >, ==, <=, >=] 

var linqOreredByName = pets.OrderBy(p => p.Name);
Console.WriteLine("állatkák ábécé rendben:");
foreach (var pet in linqOreredByName)
{
    Console.WriteLine($"\t[{pets.IndexOf(pet):00}.] {pet}");
}

var linqOBDByAge = pets
    .OrderByDescending(p => p.Age)
    .ThenBy(p => p.Name);

Console.WriteLine("állatkák életkor szerint csökkenőben (azon belül név szerint növekvőben):");
foreach (var pet in linqOBDByAge)
{
    Console.WriteLine($"\t[{pets.IndexOf(pet):00}.] {pet}");
}

var linqChickens = pets.Where(p => p.Species == "Chicken");
Console.WriteLine("csirkék:");
foreach (var pet in linqChickens)
{
    Console.WriteLine($"\t[{pets.IndexOf(pet):00}.] {pet}");
}

//FindAll(x => x..) ugyan az, mint a Where, csak listát ad vissza, nem IEnumerable collectiont

var linqBySpecies = pets.GroupBy(p => p.Species);
Console.WriteLine("fajok szerint csopizva");
foreach (var group in linqBySpecies.OrderBy(g => g.Key))
{
    Console.WriteLine($"\t{group.Key} ({group.Count()} db)");
    foreach (var pet in group.OrderBy(p => p.Name))
    {
        Console.WriteLine($"\t\t[{pets.IndexOf(pet):00}.] {pet}");
    }
}

//összes listában lévő faj, de mind csak 1x:
var linqSpecies = pets.Select(p => p.Species).Distinct().Order();

Console.WriteLine("összes állatfaj:");
foreach (var spe in linqSpecies)
{
    Console.WriteLine($"\t{spe}");
}