namespace Omadiko.Database.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Omadiko.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Omadiko.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Omadiko.Database.ApplicationDbContext context)
        {

            #region seeding albums
            //=================Seeding Albums====================
            Album al1 = new Album() { Title = "Thriller", PhotoId = "", TotalDuration = new TimeSpan(42, 19, 00), AlbumRealeaseYear = new DateTime(1982, 11, 30) };
            Album al2 = new Album() { Title = "Mi Tierra", PhotoId = "", TotalDuration = new TimeSpan(55, 18, 00), AlbumRealeaseYear = new DateTime(1993, 6, 22) };
            Album al3 = new Album() { Title = "Laundry Service", PhotoId = "", TotalDuration = new TimeSpan(49, 14, 00), AlbumRealeaseYear = new DateTime(2001, 11, 13) };
            Album al4 = new Album() { Title = "Whitney", PhotoId = "", TotalDuration = new TimeSpan(52, 48, 00), AlbumRealeaseYear = new DateTime(1987, 6, 2) };
            Album al5 = new Album() { Title = "Faith", PhotoId = "", TotalDuration = new TimeSpan(58, 04, 00), AlbumRealeaseYear = new DateTime(1987, 10, 30) };
            Album al6 = new Album() { Title = "Falco 3", PhotoId = "", TotalDuration = new TimeSpan(51, 04, 00), AlbumRealeaseYear = new DateTime(1985, 10, 15) };
            Album al7 = new Album() { Title = "Let's Stick Together", PhotoId = "", TotalDuration = new TimeSpan(38, 45, 00), AlbumRealeaseYear = new DateTime(1976, 9, 30) };
            Album al8 = new Album() { Title = "Je dis aime", PhotoId = "", TotalDuration = new TimeSpan(53, 19, 00), AlbumRealeaseYear = new DateTime(1999, 10, 25) };
            Album al9 = new Album() { Title = "Tutte storie", PhotoId = "", TotalDuration = new TimeSpan(42, 19, 00), AlbumRealeaseYear = new DateTime(1993, 8, 10) };
            Album al10 = new Album() { Title = "Vuelve", PhotoId = "", TotalDuration = new TimeSpan(46, 22, 00), AlbumRealeaseYear = new DateTime(1998, 2, 10) };
            Album al11 = new Album() { Title = "Oxygene", PhotoId = "", TotalDuration = new TimeSpan(39, 41, 00), AlbumRealeaseYear = new DateTime(1976, 12, 2) };
            Album al12 = new Album() { Title = "Just Be", PhotoId = "", TotalDuration = new TimeSpan(78, 47, 00), AlbumRealeaseYear = new DateTime(2004, 4, 6) };
            Album al13 = new Album() { Title = "Error in the System", PhotoId = "", TotalDuration = new TimeSpan(37, 54, 00), AlbumRealeaseYear = new DateTime(1982, 7, 3) };
            Album al14 = new Album() { Title = "You've Come a Long Way, Baby", PhotoId = "", TotalDuration = new TimeSpan(62, 00, 00), AlbumRealeaseYear = new DateTime(1998, 10, 19) };
            Album al15 = new Album() { Title = "Shivers", PhotoId = "", TotalDuration = new TimeSpan(72, 48, 00), AlbumRealeaseYear = new DateTime(2005, 8, 8) };
            Album al16 = new Album() { Title = "Play", PhotoId = "", TotalDuration = new TimeSpan(62, 37, 00), AlbumRealeaseYear = new DateTime(1999, 5, 17) };
            Album al17 = new Album() { Title = "Perfecto Fluoro", PhotoId = "", TotalDuration = new TimeSpan(74, 6, 00), AlbumRealeaseYear = new DateTime(1996, 10, 28) };
            Album al18 = new Album() { Title = "Phuture 2000", PhotoId = "", TotalDuration = new TimeSpan(69, 50, 00), AlbumRealeaseYear = new DateTime(1999, 3, 1) };
            Album al19 = new Album() { Title = "Hypnotica", PhotoId = "", TotalDuration = new TimeSpan(61, 27, 00), AlbumRealeaseYear = new DateTime(2003, 8, 19) };
            Album al20 = new Album() { Title = "Are You Experienced", PhotoId = "", TotalDuration = new TimeSpan(38, 34, 00), AlbumRealeaseYear = new DateTime(1967, 5, 12) };
            Album al21 = new Album() { Title = "Diary of a Madman", PhotoId = "", TotalDuration = new TimeSpan(61, 24, 00), AlbumRealeaseYear = new DateTime(1981, 11, 7) };
            Album al22 = new Album() { Title = "Tattoo", PhotoId = "", TotalDuration = new TimeSpan(58, 52, 00), AlbumRealeaseYear = new DateTime(1973, 11, 11) };
            Album al23 = new Album() { Title = "Supernatural", PhotoId = "", TotalDuration = new TimeSpan(74, 59, 00), AlbumRealeaseYear = new DateTime(1999, 6, 15) };
            Album al24 = new Album() { Title = "Stanley Road", PhotoId = "", TotalDuration = new TimeSpan(52, 10, 00), AlbumRealeaseYear = new DateTime(1995, 5, 15) };
            Album al25 = new Album() { Title = "Slowhand", PhotoId = "", TotalDuration = new TimeSpan(39, 8, 00), AlbumRealeaseYear = new DateTime(1977, 11, 25) };
            Album al26 = new Album() { Title = "Pearl", PhotoId = "", TotalDuration = new TimeSpan(34, 10, 00), AlbumRealeaseYear = new DateTime(1971, 1, 11) };
            Album al27 = new Album() { Title = "With a Little Help from My Friends", PhotoId = "", TotalDuration = new TimeSpan(40, 27, 00), AlbumRealeaseYear = new DateTime(1969, 5, 30) };
            Album al28 = new Album() { Title = "The Dream of the Blue Turtles", PhotoId = "", TotalDuration = new TimeSpan(41, 40, 00), AlbumRealeaseYear = new DateTime(1985, 6, 1) };
            Album al29 = new Album() { Title = "Viva Hate", PhotoId = "", TotalDuration = new TimeSpan(42, 16, 00), AlbumRealeaseYear = new DateTime(1988, 3, 14) };
            Album al30 = new Album() { Title = "Darkness on the Edge of Town", PhotoId = "", TotalDuration = new TimeSpan(42, 55, 00), AlbumRealeaseYear = new DateTime(1978, 6, 2) };
            Album al31 = new Album() { Title = "Ethio Jazz", PhotoId = "", TotalDuration = new TimeSpan(54, 8, 00), AlbumRealeaseYear = new DateTime(1974, 1, 1) };
            Album al32 = new Album() { Title = "City lights", PhotoId = "", TotalDuration = new TimeSpan(33, 49, 00), AlbumRealeaseYear = new DateTime(1963, 12, 1) };
            Album al33 = new Album() { Title = "Laughing on the Outside", PhotoId = "", TotalDuration = new TimeSpan(41, 00, 00), AlbumRealeaseYear = new DateTime(1963, 8, 12) };
            Album al34 = new Album() { Title = "The Second Time Around", PhotoId = "", TotalDuration = new TimeSpan(27, 14, 00), AlbumRealeaseYear = new DateTime(1961, 12, 14) };
            Album al35 = new Album() { Title = "Songs in a Mellow Mood", PhotoId = "", TotalDuration = new TimeSpan(38, 20, 00), AlbumRealeaseYear = new DateTime(1954, 3, 30) };
            Album al36 = new Album() { Title = "Let It All Out", PhotoId = "", TotalDuration = new TimeSpan(37, 02, 00), AlbumRealeaseYear = new DateTime(1965, 12, 16) };
            Album al37 = new Album() { Title = "Blue Train", PhotoId = "", TotalDuration = new TimeSpan(42, 50, 00), AlbumRealeaseYear = new DateTime(1958, 1, 20) };
            Album al38 = new Album() { Title = "Hello, Dolly!", PhotoId = "", TotalDuration = new TimeSpan(38, 19, 00), AlbumRealeaseYear = new DateTime(1964, 2, 22) };
            Album al39 = new Album() { Title = "Milestones", PhotoId = "", TotalDuration = new TimeSpan(47, 36, 00), AlbumRealeaseYear = new DateTime(1958, 9, 2) };
            Album al40 = new Album() { Title = "Monk's Music", PhotoId = "", TotalDuration = new TimeSpan(38, 24, 00), AlbumRealeaseYear = new DateTime(1957, 11, 28) };
            Album al41 = new Album() { Title = "Overtures", PhotoId = "", TotalDuration = new TimeSpan(48, 32, 00), AlbumRealeaseYear = new DateTime(1987, 12, 10) };
            Album al42 = new Album() { Title = "Floresta do Amazonas", PhotoId = "", TotalDuration = new TimeSpan(72, 24, 00), AlbumRealeaseYear = new DateTime(2010, 6, 29) };
            Album al43 = new Album() { Title = "Gnossiennes, Gymnopédies", PhotoId = "", TotalDuration = new TimeSpan(62, 19, 00), AlbumRealeaseYear = new DateTime(1969, 6, 11) };
            Album al44 = new Album() { Title = "Symphony in C minor", PhotoId = "", TotalDuration = new TimeSpan(31, 59, 00), AlbumRealeaseYear = new DateTime(1989, 1, 12) };
            Album al45 = new Album() { Title = "Obras para guitarra", PhotoId = "", TotalDuration = new TimeSpan(42, 12, 00), AlbumRealeaseYear = new DateTime(2002, 9, 1) };
            Album al46 = new Album() { Title = "I Walk the Line", PhotoId = "", TotalDuration = new TimeSpan(32, 19, 00), AlbumRealeaseYear = new DateTime(1964, 6, 22) };
            Album al47 = new Album() { Title = "Always on my Mind", PhotoId = "", TotalDuration = new TimeSpan(33, 29, 00), AlbumRealeaseYear = new DateTime(1982, 2, 1) };
            Album al48 = new Album() { Title = "Jolene", PhotoId = "", TotalDuration = new TimeSpan(25, 8, 00), AlbumRealeaseYear = new DateTime(1974, 2, 4) };
            Album al49 = new Album() { Title = "Sentimentally Yours", PhotoId = "", TotalDuration = new TimeSpan(28, 48, 00), AlbumRealeaseYear = new DateTime(1962, 8, 6) };
            Album al50 = new Album() { Title = "Out of a Dream", PhotoId = "", TotalDuration = new TimeSpan(29, 54, 00), AlbumRealeaseYear = new DateTime(1979, 8, 27) };
            Album al51 = new Album() { Title = "Bad Girls", PhotoId = "", TotalDuration = new TimeSpan(71, 27, 00), AlbumRealeaseYear = new DateTime(1979, 4, 25) };
            Album al52 = new Album() { Title = "Let The Sunshine In", PhotoId = "", TotalDuration = new TimeSpan(34, 00, 00), AlbumRealeaseYear = new DateTime(1969, 5, 26) };
            Album al53 = new Album() { Title = "I've Got You", PhotoId = "", TotalDuration = new TimeSpan(34, 12, 00), AlbumRealeaseYear = new DateTime(1976, 7, 20) };
            Album al54 = new Album() { Title = "Let the Music Play", PhotoId = "", TotalDuration = new TimeSpan(31, 21, 00), AlbumRealeaseYear = new DateTime(1976, 1, 2) };
            Album al55 = new Album() { Title = "Nightclubbing", PhotoId = "", TotalDuration = new TimeSpan(38, 40, 00), AlbumRealeaseYear = new DateTime(1981, 4, 29) };
            //=============================================================================================================================================
            #endregion


            #region seeding artists
            //=================Seeding Artists============================================================================================================================
            Artist a1 = new Artist() { Name = "Michael", LastName = "Jackson", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1958,8,29), DateOfDeath = new DateTime(2009,7,25) };
            a1.Albums = new List<Album>() { al1 };
            Artist a2 = new Artist() { Name = "Gloria", LastName = "Estefan", PhotoId = "", Country = "Cuba", DateOfBirth = new DateTime(1957,9,1)};
            a2.Albums = new List<Album>() { al2 };
            Artist a3 = new Artist() { Name = "Shakira", LastName = "", PhotoId = "", Country = "Colombia", DateOfBirth = new DateTime(1977,2,2)};
            a3.Albums = new List<Album>() { al3 };
            Artist a4 = new Artist() { Name = "Whitney ", LastName = "Houston ", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1963,8,9), DateOfDeath=new DateTime(2012,2,11)};
            a4.Albums = new List<Album>() { al4 };
            Artist a5 = new Artist() { Name = "George", LastName = "Michael", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1963,7,25), DateOfDeath=new DateTime(2016,12,25)};
            a5.Albums = new List<Album>() { al5 };
            Artist a6 = new Artist() { Name = "Falco", LastName = "", PhotoId = "", Country = "Austria", DateOfBirth = new DateTime(1957,2,19), DateOfDeath=new DateTime(1998,1,6)};
            a6.Albums = new List<Album>() { al6 };
            Artist a7 = new Artist() { Name = "Bryan", LastName = "Ferry", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1945,10,26)};
            a7.Albums = new List<Album>() { al7 };
            Artist a8 = new Artist() { Name = "Matthieu", LastName = "Chedid", PhotoId = "", Country = "France", DateOfBirth = new DateTime(1971,12,21)};
            a8.Albums = new List<Album>() { al8 };
            Artist a9 = new Artist() { Name = "Eros", LastName = "Ramazzotti", PhotoId = "", Country = "Italy", DateOfBirth = new DateTime(1963,10,28)};
            a9.Albums = new List<Album>() { al9 };
            Artist a10 = new Artist() { Name = "Ricky", LastName = "Martin", PhotoId = "", Country = "Puerto Rico", DateOfBirth = new DateTime(1971,12,24)};
            a10.Albums = new List<Album>() { al10 };
            Artist a11 = new Artist() { Name = "Jean Michel", LastName = "Jarre", PhotoId = "", Country = "France", DateOfBirth = new DateTime(1948,8,24)};
            a11.Albums = new List<Album>() { al11 };
            Artist a12 = new Artist() { Name = "Tiesto", LastName = "", PhotoId = "", Country = "Netherlands", DateOfBirth = new DateTime(1969,1,17)};
            a12.Albums = new List<Album>() { al12 };
            Artist a13 = new Artist() { Name = "Peter", LastName = "Schilling", PhotoId = "", Country = "Germany", DateOfBirth = new DateTime(1956,1,28)};
            a13.Albums = new List<Album>() { al13 };
            Artist a14 = new Artist() { Name = "Fat boy slim", LastName = "", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1963,7,31)};
            a14.Albums = new List<Album>() { al14 };
            Artist a15 = new Artist() { Name = "Armin", LastName = "van Buuren", PhotoId = "", Country = "Netherlands", DateOfBirth = new DateTime(1976,12,25)};
            a15.Albums = new List<Album>() { al15 };
            Artist a16 = new Artist() { Name = "Moby", LastName = "", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1965,9,11)};
            a16.Albums = new List<Album>() { al16 };
            Artist a17 = new Artist() { Name = "Paul", LastName = "Oakenfold", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1963,8,30)};
            a17.Albums = new List<Album>() { al17 };
            Artist a18 = new Artist() { Name = "Carl", LastName = "Cox", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1962,7,29)};
            a18.Albums = new List<Album>() { al18 };
            Artist a19 = new Artist() { Name = "Benny", LastName = "Benassi", PhotoId = "", Country = "Italy", DateOfBirth = new DateTime(1967,7,13)};
            a19.Albums = new List<Album>() { al19 };
            Artist a20 = new Artist() { Name = "Jimmy", LastName = "Hendrix", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1942, 11, 27), DateOfDeath = new DateTime(1970, 9, 18) };
            a20.Albums = new List<Album>() { al20 };
            Artist a21 = new Artist() { Name = "Ozzy", LastName = "Osbourne", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1948,12,3)};
            a21.Albums = new List<Album>() { al21 };
            Artist a22 = new Artist() { Name = "Rory", LastName = "Gallagher ", PhotoId = "", Country = "Ireland", DateOfBirth = new DateTime(1948,12,3)};
            a22.Albums = new List<Album>() { al22 };
            Artist a23 = new Artist() { Name = "Carlos", LastName = "Santana", PhotoId = "", Country = "Mexico", DateOfBirth = new DateTime(1947,7,20)};
            a23.Albums = new List<Album>() { al23 };
            Artist a24 = new Artist() { Name = "Paul", LastName = "Weller", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1958,5,25)};
            a24.Albums = new List<Album>() { al24 };
            Artist a25 = new Artist() { Name = "Eric", LastName = "Clapton", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1945,3,30)};
            a25.Albums = new List<Album>() { al25 };
            Artist a26 = new Artist() { Name = "Janis", LastName = "Joplin", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1943,1,19), DateOfDeath=new DateTime(1970,10,4)};
            a26.Albums = new List<Album>() { al26 };
            Artist a27 = new Artist() { Name = "John", LastName = "Cocker", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1944,5,20), DateOfDeath= new DateTime(2014,12,22)};
            a27.Albums = new List<Album>() { al27 };
            Artist a28 = new Artist() { Name = "Sting", LastName = "", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1951,10,2)};
            a28.Albums = new List<Album>() { al28 };
            Artist a29 = new Artist() { Name = "Morrissey", LastName = "", PhotoId = "", Country = "UK", DateOfBirth = new DateTime(1959,5,22)};
            a29.Albums = new List<Album>() { al29 };
            Artist a30 = new Artist() { Name = "Bruce ", LastName = "Springsteen", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1949,9,23)};
            a30.Albums = new List<Album>() { al30 };
            Artist a31 = new Artist() { Name = "Mulatu", LastName = "Astatke", PhotoId = "", Country = "Ethiopia", DateOfBirth = new DateTime(1943,12,19)};
            a31.Albums = new List<Album>() { al31 };
            Artist a32 = new Artist() { Name = "Gerry", LastName = "Mulligan", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1927,4,6), DateOfDeath=new DateTime(1996,1,20)};
            a32.Albums = new List<Album>() { al32 };
            Artist a33 = new Artist() { Name = "Aretha", LastName = "Franklin", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1942,3,25), DateOfDeath= new DateTime(2018,8,16)};
            a33.Albums = new List<Album>() { al33 };
            Artist a34 = new Artist() { Name = "Etta", LastName = "James", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1938,1,25), DateOfDeath= new DateTime(2012,1,20)};
            a34.Albums = new List<Album>() { al34 };
            Artist a35 = new Artist() { Name = "Ella", LastName = "Fitzgerald", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1917,5,25), DateOfDeath= new DateTime(1996,6,15)};
            a35.Albums = new List<Album>() { al35 };
            Artist a36 = new Artist() { Name = "Nina", LastName = "Simone", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1933,2,21), DateOfDeath=new DateTime(2003,4,21)};
            a36.Albums = new List<Album>() { al36 };
            Artist a37 = new Artist() { Name = "John", LastName = "Coltrane", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1926,10,17),DateOfDeath=new DateTime(1967,7,17)};
            a37.Albums = new List<Album>() { al37 };
            Artist a38 = new Artist() { Name = "Lewis", LastName = "Armstrong", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1901,8,4),DateOfDeath=new DateTime(1971,7,6)};
            a38.Albums = new List<Album>() { al38 };
            Artist a39 = new Artist() { Name = "Miles", LastName = "Davis", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1926,5,26)};
            a39.Albums = new List<Album>() { al39 };
            Artist a40 = new Artist() { Name = "Thelonious", LastName = "Monk", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1917,10,10), DateOfDeath = new DateTime(1982,2,17)};
            a40.Albums = new List<Album>() { al40 };
            Artist a41 = new Artist() { Name = "Gioachino", LastName = "Rossini", PhotoId = "", Country = "Italy", DateOfBirth = new DateTime(1792,2,29),DateOfDeath=new DateTime(1868,11,13)};
            a41.Albums = new List<Album>() { al41 };
            Artist a42 = new Artist() { Name = "Heitor", LastName = "Villa Lobos", PhotoId = "", Country = "Brazil", DateOfBirth = new DateTime(1887,3,5),DateOfDeath=new DateTime(1959,11,17)};
            a42.Albums = new List<Album>() { al42 };
            Artist a43 = new Artist() { Name = "Eric", LastName = "Satie", PhotoId = "", Country = "France", DateOfBirth = new DateTime(1866,5,17), DateOfDeath = new DateTime(1925,7,1) };
            a43.Albums = new List<Album>() { al43 };
            Artist a44 = new Artist() { Name = "Edvard", LastName = "Grieg", PhotoId = "", Country = "Norway", DateOfBirth = new DateTime(1843,7,15),DateOfDeath=new DateTime(1907,9,4)};
            a44.Albums = new List<Album>() { al44 };
            Artist a45 = new Artist() { Name = "Francisco", LastName = "Tarrega", PhotoId = "", Country = "Spain", DateOfBirth = new DateTime(1852,11,21),DateOfDeath=new DateTime(1909,12,15)};
            a45.Albums = new List<Album>() { al45 };
            Artist a46 = new Artist() { Name = "Johnny", LastName = "Cash", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1932,2,26),DateOfDeath=new DateTime(2003,9,12)};
            a46.Albums = new List<Album>() { al46 };
            Artist a47 = new Artist() { Name = "Willie", LastName = "Nelson", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1933,4,29)};
            a47.Albums = new List<Album>() { al47 };
            Artist a48 = new Artist() { Name = "Dolly", LastName = "Parton", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1946,1,19)};
            a48.Albums = new List<Album>() { al48 };
            Artist a49 = new Artist() { Name = "Patsy", LastName = "Cline", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1932,9,8),DateOfDeath=new DateTime(1963,3,5)};
            a49.Albums = new List<Album>() { al49 };
            Artist a50 = new Artist() { Name = "Reba", LastName = "McEntire", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1955,3,28)};
            a50.Albums = new List<Album>() { al50 };
            Artist a51 = new Artist() { Name = "Donna", LastName = "Summer", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1948,12,31), DateOfDeath=new DateTime(2012,5,17)};
            a51.Albums = new List<Album>() { al51 };
            Artist a52 = new Artist() { Name = "Diana", LastName = "Ross", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1944,3,26)};
            a52.Albums = new List<Album>() { al52 };
            Artist a53 = new Artist() { Name = "Gloria", LastName = "Gaynor", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1943,9,7)};
            a53.Albums = new List<Album>() { al53 };
            Artist a54 = new Artist() { Name = "Barry", LastName = "White", PhotoId = "", Country = "USA", DateOfBirth = new DateTime(1944,9,12),DateOfDeath=new DateTime(2003,7,4)};
            a54.Albums = new List<Album>() { al54 };
            Artist a55 = new Artist() { Name = "Grace", LastName = "Jones", PhotoId = "", Country = "Jamaica", DateOfBirth = new DateTime(1948,5,19)};
            a55.Albums = new List<Album>() { al55 };
            //=======================================================================================================================================================================
            #endregion


            #region seeding genres
            //=================Seeding Genres====================
            Genre g1 = new Genre() { GenreKind = "Rock" };            
            Genre g2 = new Genre() { GenreKind = "POP" };           
            Genre g3 = new Genre() { GenreKind = "Classical Music" };            
            Genre g4 = new Genre() { GenreKind = "Country" };            
            Genre g5 = new Genre() { GenreKind = "Jazz" };            
            Genre g6 = new Genre() { GenreKind = "Electronic" };            
            Genre g7 = new Genre() { GenreKind = "Disco" };
            //Genre g = new Genre() { GenreKind = "" };
            #endregion


            #region add albums to genres
            //==========Add Albumss to Genres==================
            g1.Albums = new List<Album>() { al20, al21, al22, al23, al24, al25, al26, al27, al28, al29, al30 };
            g2.Albums = new List<Album>() { al1, al2, al3, al4, al5, al6, al7, al8, al9, al10 };
            g3.Albums = new List<Album>() { al41, al42, al43, al44, al45 };
            g4.Albums = new List<Album>() { al46, al47, al48, al49, al50 };
            g5.Albums = new List<Album>() { al31, al32, al33, al34, al35, al36, al37, al38, al39, al40 };
            g6.Albums = new List<Album>() { al11, al12, al13, al14, al15, al16, al17, al18, al19 };
            g7.Albums = new List<Album>() { al51, al52, al5, al54, al55 };
            //==================================================================
            #endregion


            #region add/update/save context
            //==========Upsert Tables (Artist, Album, Genre -----)
            context.Artists.AddOrUpdate(x => new { x.Name, x.LastName }, a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15,a16,a17,a18,a19,a20,a21,a22,a23,a24,a25,a26,a27,a28,a29,a30,a31,a32,a33,a34,a35,a36,a37,a38,a39,a40,a41,a42,a43,a44,a45,a46,a47,a48,a49,a50,a51,a52,a53,a54,a55 );
            context.Albums.AddOrUpdate(x => new { x.Title, x.Artist }, al1, al2, al3, al4, al5, al6, al7, al8, al9, al10, al11, al12, al13, al14, al15, al16, al17, al18, al19, al20, al21, al22, al23, al24, al25, al26, al27, al28, al29, al30, al31, al32, al33, al34, al35, al36, al37, al38, al39, al40, al41, al42, al43, al44, al45, al46, al47, al48, al49, al50, al51, al52, al53, al54, al55);
            context.Genres.AddOrUpdate(x => new { x.GenreKind }, g1,g2,g3,g4,g5,g6,g7);
            context.SaveChanges();
            //=======================================================
            #endregion



            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }


            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "admin@admin.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@admin.net",
                    Email = "admin@admin.net",
                    PasswordHash = PasswordHash.HashPassword("Admin1!")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");

            }
        }
    }
}