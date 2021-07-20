﻿namespace Omadiko.Database.Migrations
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

            /* Seeding Albums:
             *                 - add PhotoUrl links
             *                
             
             * Seeding Songs:
             *                 - add AudioUrl links
             *                 - add VideoUrl links (just a few)
             * 
             */

            #region SEEDING SONGS   
            Song s1 = new Song() { Title = "Billie Jean", Duration = 273, ReleaseDate = new DateTime(1983, 1, 2), PhotoUrl= "~/Content/images/ArtistImages/michael_jackson400x410.jpg" };
            Song s2 = new Song() { Title = "Beat It", Duration = 251, ReleaseDate = new DateTime(1983, 2, 14), PhotoUrl= "~/Content/images/ArtistImages/michael_jackson400x410.jpg" };
            Song s3 = new Song() { Title = "Thriller", Duration = 334, ReleaseDate = new DateTime(1983, 11, 2), PhotoUrl= "~/Content/images/ArtistImages/michael_jackson400x410.jpg" };
            Song s4 = new Song() { Title = "The Girl Is Mine", Duration = 206, ReleaseDate = new DateTime(1982, 10, 18), PhotoUrl= "~/Content/images/ArtistImages/michael_jackson400x410.jpg" };
            Song s5 = new Song() { Title = "Mi Tierra", Duration = 263, ReleaseDate = new DateTime(1993, 7, 3), PhotoUrl= "~/Content/images/ArtistImages/gloria_estefan400x410.jpg" };
            Song s6 = new Song() { Title = "Whenever, Wherever", Duration = 190, ReleaseDate = new DateTime(2001, 8, 27), PhotoUrl = "~/Content/images/ArtistImages/shakira400x410.jpg" };
            Song s7 = new Song() { Title = "Underneath Your Clothes", Duration = 267, ReleaseDate = new DateTime(2002, 2, 11), PhotoUrl = "~/Content/images/ArtistImages/shakira400x410.jpg" };
            Song s8 = new Song() { Title = "Objection(Tango)", Duration = 298, ReleaseDate = new DateTime(2002, 7, 17), PhotoUrl = "~/Content/images/ArtistImages/shakira400x410.jpg" };
            Song s9 = new Song() { Title = "Te Dejo Madrid", Duration = 178, ReleaseDate = new DateTime(2002, 8, 15), PhotoUrl = "~/Content/images/ArtistImages/shakira400x410.jpg" };
            Song s10 = new Song() { Title = "Que Me Quedes Tu", Duration = 363, ReleaseDate = new DateTime(2002, 12, 1), PhotoUrl = "~/Content/images/ArtistImages/shakira400x410.jpg" };
            Song s11 = new Song() { Title = "I Wanna Dance with Somebody", Duration = 310, ReleaseDate = new DateTime(1987, 5, 2), PhotoUrl = "~/Content/images/ArtistImages/whitney_houston400x410.jpg" };
            Song s12 = new Song() { Title = "Didn't We Almost Have It All", Duration = 315, ReleaseDate = new DateTime(1987, 8, 13), PhotoUrl = "~/Content/images/ArtistImages/whitney_houston400x410.jpg" };
            Song s13 = new Song() { Title = "So Emotional", Duration = 305, ReleaseDate = new DateTime(1987, 10, 12), PhotoUrl = "~/Content/images/ArtistImages/whitney_houston400x410.jpg" };
            Song s14 = new Song() { Title = "Where Do Broken Hearts Go", Duration = 329, ReleaseDate = new DateTime(1988, 2, 25), PhotoUrl = "~/Content/images/ArtistImages/whitney_houston400x410.jpg" };
            Song s15 = new Song() { Title = "Love Will Save the Day", Duration = 330, ReleaseDate = new DateTime(1988, 7, 5), PhotoUrl = "~/Content/images/ArtistImages/whitney_houston400x410.jpg" };
            Song s16 = new Song() { Title = "I Want Your Sex", Duration = 287, ReleaseDate = new DateTime(1987, 6, 1), PhotoUrl = "~/Content/images/ArtistImages/george_michael400x410.jpg" };
            Song s17 = new Song() { Title = "Faith", Duration = 286, ReleaseDate = new DateTime(1987, 10, 12), PhotoUrl = "~/Content/images/ArtistImages/george_michael400x410.jpg" };
            Song s18 = new Song() { Title = "Hard Day", Duration = 263, ReleaseDate = new DateTime(1987, 10, 30), PhotoUrl = "~/Content/images/ArtistImages/george_michael400x410.jpg" };
            Song s19 = new Song() { Title = "Father Figure", Duration = 241, ReleaseDate = new DateTime(1987, 12, 28), PhotoUrl = "~/Content/images/ArtistImages/george_michael400x410.jpg" };
            Song s20 = new Song() { Title = "One More Try", Duration = 271, ReleaseDate = new DateTime(1988, 4, 11), PhotoUrl = "~/Content/images/ArtistImages/george_michael400x410.jpg" };
            Song s21 = new Song() { Title = "Rock Me Amadeus", Duration = 150, ReleaseDate = new DateTime(1985, 10, 15), PhotoUrl = "~/Content/images/ArtistImages/falco400x410.jpg" };
            Song s22 = new Song() { Title = "Vienna Calling", Duration = 134, ReleaseDate = new DateTime(1985, 10, 15), PhotoUrl = "~/Content/images/ArtistImages/falco400x410.jpg" };
            Song s23 = new Song() { Title = "Jeanny", Duration = 391, ReleaseDate = new DateTime(1985, 10, 15), PhotoUrl = "~/Content/images/ArtistImages/falco400x410.jpg" };
            Song s24 = new Song() { Title = "Macho Macho", Duration = 345, ReleaseDate = new DateTime(1985, 10, 15), PhotoUrl = "~/Content/images/ArtistImages/falco400x410.jpg" };
            Song s25 = new Song() { Title = "Tango the Night", Duration = 199, ReleaseDate = new DateTime(1985, 10, 15), PhotoUrl = "~/Content/images/ArtistImages/falco400x410.jpg" };
            Song s26 = new Song() { Title = "Let's Stick Together", Duration = 167, ReleaseDate = new DateTime(1976, 9, 30), PhotoUrl = "~/Content/images/ArtistImages/bryan_ferry400x410.jpg" };
            Song s27 = new Song() { Title = "Casanova", Duration = 142, ReleaseDate = new DateTime(1976, 9, 30), PhotoUrl = "~/Content/images/ArtistImages/bryan_ferry400x410.jpg" };
            Song s28 = new Song() { Title = "Sea Breezes", Duration = 275, ReleaseDate = new DateTime(1976, 9, 30), PhotoUrl = "~/Content/images/ArtistImages/bryan_ferry400x410.jpg" };
            Song s29 = new Song() { Title = "Shame, Shame, Shame", Duration = 211, ReleaseDate = new DateTime(1976, 9, 30), PhotoUrl = "~/Content/images/ArtistImages/bryan_ferry400x410.jpg" };
            Song s30 = new Song() { Title = "2HB", Duration = 212, ReleaseDate = new DateTime(1976, 9, 30), PhotoUrl = "~/Content/images/ArtistImages/bryan_ferry400x410.jpg" };
            Song s31 = new Song() { Title = "Je Dis Aime", Duration = 235, ReleaseDate = new DateTime(1999, 10, 25), PhotoUrl = "~/Content/images/ArtistImages/matthieu_chedid400x410.jpg" };
            Song s32 = new Song() { Title = "Cosa Della Vita", Duration = 299, ReleaseDate = new DateTime(1993, 4, 19), PhotoUrl = "~/Content/images/ArtistImages/eros_ramazzotti400x410.jpg" };
            Song s33 = new Song() { Title = "La Copa de la Vida", Duration = 276, ReleaseDate = new DateTime(1998, 2, 12), PhotoUrl = "~/Content/images/ArtistImages/ricky_martin400x410.jpg" };
            Song s34 = new Song() { Title = "Oxygene (Part I)", Duration = 483, ReleaseDate = new DateTime(1976, 12, 2), PhotoUrl = "~/Content/images/ArtistImages/jeanmichel_jarre400x410.jpg" };
            Song s35 = new Song() { Title = "Oxygene (Part II)", Duration = 191, ReleaseDate = new DateTime(1976, 12, 2), PhotoUrl = "~/Content/images/ArtistImages/jeanmichel_jarre400x410.jpg" };
            Song s36 = new Song() { Title = "Oxygene (Part II)", Duration = 151, ReleaseDate = new DateTime(1976, 12, 2), PhotoUrl = "~/Content/images/ArtistImages/jeanmichel_jarre400x410.jpg" };
            Song s37 = new Song() { Title = "Oxygene (Part IV)", Duration = 243, ReleaseDate = new DateTime(1976, 12, 2), PhotoUrl = "~/Content/images/ArtistImages/jeanmichel_jarre400x410.jpg" };
            Song s38 = new Song() { Title = "Traffic", Duration = 367, ReleaseDate = new DateTime(2004, 4, 6), PhotoUrl = "~/Content/images/ArtistImages/tiesto400x410.jpg" };
            Song s39 = new Song() { Title = "Adagio for Strings", Duration = 482, ReleaseDate = new DateTime(2004, 4, 6), PhotoUrl = "~/Content/images/ArtistImages/tiesto400x410.jpg" };
            Song s40 = new Song() { Title = "Forever Today", Duration = 654, ReleaseDate = new DateTime(2004, 4, 6), PhotoUrl = "~/Content/images/ArtistImages/tiesto400x410.jpg" };
            Song s41 = new Song() { Title = "Just Be", Duration = 559, ReleaseDate = new DateTime(2004, 4, 6), PhotoUrl = "~/Content/images/ArtistImages/tiesto400x410.jpg" };
            Song s42 = new Song() { Title = "Nyana", Duration = 493, ReleaseDate = new DateTime(2004, 4, 6), PhotoUrl = "~/Content/images/ArtistImages/tiesto400x410.jpg" };
            Song s43 = new Song() { Title = "Major Tom (Coming Home)", Duration = 302, ReleaseDate = new DateTime(1982, 7, 3), PhotoUrl = "~/Content/images/ArtistImages/peter_schilling400x410.jpg" };
            Song s44 = new Song() { Title = "Right Here, Right Now", Duration = 364, ReleaseDate = new DateTime(1998, 10, 19), PhotoUrl = "~/Content/images/ArtistImages/fatboyslim400x410.jpg" };
            Song s45 = new Song() { Title = "The Rockafeller Skank", Duration = 325, ReleaseDate = new DateTime(1998, 10, 19), PhotoUrl = "~/Content/images/ArtistImages/fatboyslim400x410.jpg" };
            Song s46 = new Song() { Title = "Gangster Tripping", Duration = 306, ReleaseDate = new DateTime(1998, 10, 19), PhotoUrl = "~/Content/images/ArtistImages/fatboyslim400x410.jpg" };
            Song s47 = new Song() { Title = "Build It Up-Tear It Down", Duration = 297, ReleaseDate = new DateTime(1998, 10, 19), PhotoUrl = "~/Content/images/ArtistImages/fatboyslim400x410.jpg" };
            Song s48 = new Song() { Title = "Praise You", Duration = 293, ReleaseDate = new DateTime(1998, 10, 19), PhotoUrl = "~/Content/images/ArtistImages/fatboyslim400x410.jpg" };
            Song s49 = new Song() { Title = "Shivers", Duration = 357, ReleaseDate = new DateTime(2005, 8, 8), PhotoUrl = "~/Content/images/ArtistImages/armin_vanbuuren400x410.jpg" };
            Song s50 = new Song() { Title = "Honey", Duration = 239, ReleaseDate = new DateTime(1998, 8, 24), PhotoUrl = "~/Content/images/ArtistImages/moby400x410.jpg" };
            Song s51 = new Song() { Title = "Run On", Duration = 245, ReleaseDate = new DateTime(1999, 4, 26), PhotoUrl = "~/Content/images/ArtistImages/moby400x410.jpg" };
            Song s52 = new Song() { Title = "Bodyrock", Duration = 241, ReleaseDate = new DateTime(1999, 7, 12), PhotoUrl = "~/Content/images/ArtistImages/moby400x410.jpg" };
            Song s53 = new Song() { Title = "Natural Blues", Duration = 243, ReleaseDate = new DateTime(2000, 3, 6), PhotoUrl = "~/Content/images/ArtistImages/moby400x410.jpg" };
            Song s54 = new Song() { Title = "Porcelain", Duration = 244, ReleaseDate = new DateTime(2000, 10, 10), PhotoUrl = "~/Content/images/ArtistImages/moby400x410.jpg" };
            Song s55 = new Song() { Title = "Teleport", Duration = 361, ReleaseDate = new DateTime(1996, 10, 28), PhotoUrl = "~/Content/images/ArtistImages/paul_oakenfold400x410.jpg" };
            Song s56 = new Song() { Title = "Phuture 2000", Duration = 387, ReleaseDate = new DateTime(1999, 3, 1), PhotoUrl = "~/Content/images/ArtistImages/carl_cox400x410.jpg" };
            Song s57 = new Song() { Title = "Children", Duration = 333, ReleaseDate = new DateTime(1996, 6, 7), PhotoUrl = "~/Content/images/ArtistImages/robert_miles400x410.jpg" };
            Song s58 = new Song() { Title = "Purple Haze", Duration = 188, ReleaseDate = new DateTime(1967, 5, 12), PhotoUrl = "~/Content/images/ArtistImages/jimmy_hendrix400x410.jpg" };
            Song s59 = new Song() { Title = "Hey Joe", Duration = 185, ReleaseDate = new DateTime(1967, 5, 12), PhotoUrl = "~/Content/images/ArtistImages/jimmy_hendrix400x410.jpg" };
            Song s60 = new Song() { Title = "The Wind Cries Mary", Duration = 183, ReleaseDate = new DateTime(1967, 5, 12), PhotoUrl = "~/Content/images/ArtistImages/jimmy_hendrix400x410.jpg" };
            Song s61 = new Song() { Title = "Foxey Lady", Duration = 176, ReleaseDate = new DateTime(1967, 5, 12), PhotoUrl = "~/Content/images/ArtistImages/jimmy_hendrix400x410.jpg" };
            Song s62 = new Song() { Title = "Diary of a Madman", Duration = 356, ReleaseDate = new DateTime(1981, 11, 7), PhotoUrl = "~/Content/images/ArtistImages/ozzy_osbourne400x410.jpg" };
            Song s63 = new Song() { Title = "A Million Miles Away", Duration = 345, ReleaseDate = new DateTime(1973, 11, 11), PhotoUrl = "~/Content/images/ArtistImages/rory_gallagher400x410.jpg" };
            Song s64 = new Song() { Title = "Smooth", Duration = 311, ReleaseDate = new DateTime(1999, 6, 15), PhotoUrl = "~/Content/images/ArtistImages/carlos_santana400x410.jpg" };
            Song s65 = new Song() { Title = "Corazon Espinado", Duration = 175, ReleaseDate = new DateTime(1999, 6, 15), PhotoUrl = "~/Content/images/ArtistImages/carlos_santana400x410.jpg" };
            Song s66 = new Song() { Title = "Maria Maria", Duration = 250, ReleaseDate = new DateTime(1999, 6, 15), PhotoUrl = "~/Content/images/ArtistImages/carlos_santana400x410.jpg" };
            Song s67 = new Song() { Title = "You Do Something To Me", Duration = 247, ReleaseDate = new DateTime(1995, 5, 15), PhotoUrl = "~/Content/images/ArtistImages/paul_weller400x410.jpg" };
            Song s68 = new Song() { Title = "Cocaine", Duration = 280, ReleaseDate = new DateTime(1977, 11, 25), PhotoUrl = "~/Content/images/ArtistImages/eric_clapton400x410.jpg" };
            Song s69 = new Song() { Title = "Lay Down Sally", Duration = 243, ReleaseDate = new DateTime(1977, 11, 25), PhotoUrl = "~/Content/images/ArtistImages/eric_clapton400x410.jpg" };
            Song s70 = new Song() { Title = "We're All the Way", Duration = 185, ReleaseDate = new DateTime(1977, 11, 25), PhotoUrl = "~/Content/images/ArtistImages/eric_clapton400x410.jpg" };
            Song s71 = new Song() { Title = "Mean Old Frissco", Duration = 297, ReleaseDate = new DateTime(1977, 11, 25), PhotoUrl = "~/Content/images/ArtistImages/eric_clapton400x410.jpg" };
            Song s72 = new Song() { Title = "Cry Baby", Duration = 248, ReleaseDate = new DateTime(1971, 1, 11), PhotoUrl = "~/Content/images/ArtistImages/janis_joplin400x410.jpg" };
            Song s73 = new Song() { Title = "With a Little Help from My Friends", Duration = 308, ReleaseDate = new DateTime(1969, 5, 30), PhotoUrl = "~/Content/images/ArtistImages/joe_cocker400x410.jpg" };
            Song s74 = new Song() { Title = "Just Like a Woman", Duration = 299, ReleaseDate = new DateTime(1969, 5, 30), PhotoUrl = "~/Content/images/ArtistImages/joe_cocker400x410.jpg" };
            Song s75 = new Song() { Title = "Moon Over Bourbon Street", Duration = 289, ReleaseDate = new DateTime(1985, 6, 1), PhotoUrl = "~/Content/images/ArtistImages/sting400x410.jpg" };
            Song s76 = new Song() { Title = "Margaret on the Guillotine", Duration = 239, ReleaseDate = new DateTime(1988, 3, 14), PhotoUrl = "~/Content/images/ArtistImages/morrissey400x410.jpg" };
            Song s77 = new Song() { Title = "BadLands", Duration = 243, ReleaseDate = new DateTime(1978, 6, 2), PhotoUrl = "~/Content/images/ArtistImages/bruce_springsteen400x410.jpg" };
            Song s78 = new Song() { Title = "Adam Raised a Cain", Duration = 348, ReleaseDate = new DateTime(1978, 6, 2), PhotoUrl = "~/Content/images/ArtistImages/bruce_springsteen400x410.jpg" };
            Song s79 = new Song() { Title = "Something in the Night", Duration = 308, ReleaseDate = new DateTime(1978, 6, 2), PhotoUrl = "~/Content/images/ArtistImages/bruce_springsteen400x410.jpg" };
            Song s80 = new Song() { Title = "Racing in the Street", Duration = 417, ReleaseDate = new DateTime(1978, 6, 2), PhotoUrl = "~/Content/images/ArtistImages/bruce_springsteen400x410.jpg" };
            Song s81 = new Song() { Title = "The Promised Land", Duration = 312, ReleaseDate = new DateTime(1978, 6, 2), PhotoUrl = "~/Content/images/ArtistImages/bruce_springsteen400x410.jpg" };
            Song s82 = new Song() { Title = "Yegelle Tezeta", Duration = 182, ReleaseDate = new DateTime(1974, 1, 1), PhotoUrl = "~/Content/images/ArtistImages/mulatu_astatke400x410.jpg" };
            Song s83 = new Song() { Title = "Yekermo Sew", Duration = 239, ReleaseDate = new DateTime(1974, 1, 1), PhotoUrl = "~/Content/images/ArtistImages/mulatu_astatke400x410.jpg" };
            Song s84 = new Song() { Title = "Gubèlyé (My Gubel)", Duration = 329, ReleaseDate = new DateTime(1974, 1, 1), PhotoUrl = "~/Content/images/ArtistImages/mulatu_astatke400x410.jpg" };
            Song s85 = new Song() { Title = "Munayé (My Muna)", Duration = 352, ReleaseDate = new DateTime(1974, 1, 1), PhotoUrl = "~/Content/images/ArtistImages/mulatu_astatke400x410.jpg" };
            Song s86 = new Song() { Title = "Ené Alantchie Alnorem", Duration = 325, ReleaseDate = new DateTime(1974, 1, 1), PhotoUrl = "~/Content/images/ArtistImages/mulatu_astatke400x410.jpg" };
            Song s87 = new Song() { Title = "Night Lights", Duration = 311, ReleaseDate = new DateTime(1963, 12, 1), PhotoUrl = "~/Content/images/ArtistImages/gerry_mulligan400x410.jpg" };
            Song s88 = new Song() { Title = "Morning of the Carnival", Duration = 305, ReleaseDate = new DateTime(1963, 12, 1), PhotoUrl = "~/Content/images/ArtistImages/gerry_mulligan400x410.jpg" };
            Song s89 = new Song() { Title = "In the Wee Small Hours of the Morning", Duration = 245, ReleaseDate = new DateTime(1963, 12, 1), PhotoUrl = "~/Content/images/ArtistImages/gerry_mulligan400x410.jpg" };
            Song s90 = new Song() { Title = "Skylark", Duration = 184, ReleaseDate = new DateTime(1963, 8, 12), PhotoUrl = "~/Content/images/ArtistImages/aretha_franklin400x410.jpg" };
            Song s91 = new Song() { Title = "For All We Know", Duration = 173, ReleaseDate = new DateTime(1963, 8, 12), PhotoUrl = "~/Content/images/ArtistImages/aretha_franklin400x410.jpg" };
            Song s92 = new Song() { Title = "Make Someone Happy", Duration = 239, ReleaseDate = new DateTime(1963, 8, 12), PhotoUrl = "~/Content/images/ArtistImages/aretha_franklin400x410.jpg" };
            Song s93 = new Song() { Title = "Don't Cry Baby", Duration = 178, ReleaseDate = new DateTime(1961, 12, 14), PhotoUrl = "~/Content/images/ArtistImages/etta_james400x410.jpg" };
            Song s94 = new Song() { Title = "Fool That I Am", Duration = 186, ReleaseDate = new DateTime(1961, 12, 14), PhotoUrl = "~/Content/images/ArtistImages/etta_james400x410.jpg" };
            Song s95 = new Song() { Title = "One for My Baby(and One More for the Road)", Duration = 178, ReleaseDate = new DateTime(1961, 12, 14), PhotoUrl = "~/Content/images/ArtistImages/etta_james400x410.jpg" };
            Song s96 = new Song() { Title = "I'm Glad There Is You", Duration = 185, ReleaseDate = new DateTime(1954, 3, 30), PhotoUrl = "~/Content/images/ArtistImages/ella_fitzgerald400x410.jpg" };
            Song s97 = new Song() { Title = "Stardust", Duration = 234, ReleaseDate = new DateTime(1954, 3, 30), PhotoUrl = "~/Content/images/ArtistImages/ella_fitzgerald400x410.jpg" };
            Song s98 = new Song() { Title = "Imagination", Duration = 186, ReleaseDate = new DateTime(1954, 3, 30), PhotoUrl = "~/Content/images/ArtistImages/ella_fitzgerald400x410.jpg" };
            Song s99 = new Song() { Title = "Mood Indigo", Duration = 247, ReleaseDate = new DateTime(1965, 12, 16), PhotoUrl = "~/Content/images/ArtistImages/nina_simone400x410.jpg" };
            Song s100 = new Song() { Title = "Love Me or Leave Me", Duration = 184, ReleaseDate = new DateTime(1965, 12, 16), PhotoUrl = "~/Content/images/ArtistImages/nina_simone400x410.jpg" };
            Song s101 = new Song() { Title = "Blue Train", Duration = 667, ReleaseDate = new DateTime(1958, 1, 20), PhotoUrl = "~/Content/images/ArtistImages/john_coltrane400x410.jpg" };
            Song s102 = new Song() { Title = "Moment's Notice", Duration = 543, ReleaseDate = new DateTime(1958, 1, 20), PhotoUrl = "~/Content/images/ArtistImages/john_coltrane400x410.jpg" };
            Song s103 = new Song() { Title = "I'm Old Fashioned", Duration = 482, ReleaseDate = new DateTime(1958, 1, 20), PhotoUrl = "~/Content/images/ArtistImages/john_coltrane400x410.jpg" };
            Song s104 = new Song() { Title = "Hello, Dolly!", Duration = 187, ReleaseDate = new DateTime(1964, 2, 22), PhotoUrl = "~/Content/images/ArtistImages/lewis_armstrong400x410.jpg" };
            Song s105 = new Song() { Title = "It's Been a Long, Long Time", Duration = 176, ReleaseDate = new DateTime(1964, 2, 22), PhotoUrl = "~/Content/images/ArtistImages/lewis_armstrong400x410.jpg" };
            Song s106 = new Song() { Title = "Moon River", Duration = 174, ReleaseDate = new DateTime(1964, 2, 22), PhotoUrl = "~/Content/images/ArtistImages/lewis_armstrong400x410.jpg" };
            Song s107 = new Song() { Title = "Two Base Hit", Duration = 302, ReleaseDate = new DateTime(1958, 12, 2), PhotoUrl = "~/Content/images/ArtistImages/miles_davis400x410.jpg" };
            Song s108 = new Song() { Title = "Straigh, No Chaser", Duration = 663, ReleaseDate = new DateTime(1958, 12, 2), PhotoUrl = "~/Content/images/ArtistImages/miles_davis400x410.jpg" };
            Song s109 = new Song() { Title = "Abide With Me", Duration = 63, ReleaseDate = new DateTime(1957, 11, 28), PhotoUrl = "~/Content/images/ArtistImages/thelonious_monk400x410.jpg" };
            Song s110 = new Song() { Title = "Well, You Needn't", Duration = 667, ReleaseDate = new DateTime(1957, 11, 28), PhotoUrl = "~/Content/images/ArtistImages/thelonious_monk400x410.jpg" };
            Song s111 = new Song() { Title = "Ruby, My Dear", Duration = 305, ReleaseDate = new DateTime(1957, 11, 28), PhotoUrl = "~/Content/images/ArtistImages/thelonious_monk400x410.jpg" };
            Song s112 = new Song() { Title = "Off Minor", Duration = 304, ReleaseDate = new DateTime(1957, 11, 28), PhotoUrl = "~/Content/images/ArtistImages/thelonious_monk400x410.jpg" };
            Song s113 = new Song() { Title = "Epistrophy", Duration = 696, ReleaseDate = new DateTime(1957, 11, 28), PhotoUrl = "~/Content/images/ArtistImages/thelonious_monk400x410.jpg" };
            Song s114 = new Song() { Title = "Il Barbiere di Siviglia", Duration = 421, ReleaseDate = new DateTime(1987, 12, 10), PhotoUrl = "~/Content/images/ArtistImages/gioachino_rossini400x410.jpg" };
            Song s115 = new Song() { Title = "La Cenerentola", Duration = 487, ReleaseDate = new DateTime(1987, 12, 10), PhotoUrl = "~/Content/images/ArtistImages/gioachino_rossini400x410.jpg" };
            Song s116 = new Song() { Title = "La gazza ladra", Duration = 541, ReleaseDate = new DateTime(1987, 12, 10), PhotoUrl = "~/Content/images/ArtistImages/gioachino_rossini400x410.jpg" };
            Song s117 = new Song() { Title = "Overture", Duration = 169, ReleaseDate = new DateTime(2010, 6, 29), PhotoUrl = "~/Content/images/ArtistImages/heitor_villalobos400x410.jpg" };
            Song s118 = new Song() { Title = "Danca dos Indios", Duration = 169, ReleaseDate = new DateTime(2010, 6, 29), PhotoUrl = "~/Content/images/ArtistImages/heitor_villalobos400x410.jpg" };
            Song s119 = new Song() { Title = "Gnossienne No.1", Duration = 169, ReleaseDate = new DateTime(1996, 6, 11), PhotoUrl = "~/Content/images/ArtistImages/erik_satie400x410.jpg" };
            Song s120 = new Song() { Title = "Gnossienne No.3", Duration = 178, ReleaseDate = new DateTime(1996, 6, 11), PhotoUrl = "~/Content/images/ArtistImages/erik_satie400x410.jpg" };
            Song s121 = new Song() { Title = "Gnossienne No.4", Duration = 175, ReleaseDate = new DateTime(1996, 6, 11), PhotoUrl = "~/Content/images/ArtistImages/erik_satie400x410.jpg" };
            Song s122 = new Song() { Title = "Gymnopedie No.1", Duration = 364, ReleaseDate = new DateTime(1996, 6, 11), PhotoUrl = "~/Content/images/ArtistImages/erik_satie400x410.jpg" };
            Song s123 = new Song() { Title = "Gymnopedie No.2", Duration = 158, ReleaseDate = new DateTime(1996, 6, 11), PhotoUrl = "~/Content/images/ArtistImages/erik_satie400x410.jpg" };
            Song s124 = new Song() { Title = "In the Hall of the Mountain King", Duration = 158, ReleaseDate = new DateTime(2008, 9, 13), PhotoUrl = "~/Content/images/ArtistImages/edvard_grieg400x410.jpg" };
            Song s125 = new Song() { Title = "Tango", Duration = 158, ReleaseDate = new DateTime(2002, 9, 1), PhotoUrl = "~/Content/images/ArtistImages/francisco_tarrega400x410.jpg" };
            Song s126 = new Song() { Title = "Capricho Arabe", Duration = 158, ReleaseDate = new DateTime(2002, 9, 1), PhotoUrl = "~/Content/images/ArtistImages/francisco_tarrega400x410.jpg" };
            Song s127 = new Song() { Title = "Recuerdos de la Alhambra", Duration = 158, ReleaseDate = new DateTime(2002, 9, 1), PhotoUrl = "~/Content/images/ArtistImages/francisco_tarrega400x410.jpg" };
            Song s128 = new Song() { Title = "I Walk the Line", Duration = 158, ReleaseDate = new DateTime(1964, 6,22), PhotoUrl = "~/Content/images/ArtistImages/johnny_cash400x410.jpg" };
            Song s129 = new Song() { Title = "Falsom Prison Blues", Duration = 158, ReleaseDate = new DateTime(1964, 6, 22), PhotoUrl = "~/Content/images/ArtistImages/johnny_cash400x410.jpg" };
            Song s130 = new Song() { Title = "Give my Love to Rose", Duration = 158, ReleaseDate = new DateTime(1964, 6, 22), PhotoUrl = "~/Content/images/ArtistImages/johnny_cash400x410.jpg" };
            Song s131 = new Song() { Title = "Black or White", Duration = 249, ReleaseDate = new DateTime(1991, 11, 11), PhotoUrl = "" };
            Song s132 = new Song() { Title = "In the Closet", Duration = 379, ReleaseDate = new DateTime(1991, 04, 09), PhotoUrl = "" };
            #endregion

            #region SEEDING ALBUMS
            Album al1 = new Album() { Title = "Thriller", PhotoUrl = "~/Content/images/AlbumImages/thriller400x410.jpg", ReleaseDate = new DateTime(1982, 11, 30) };
            al1.Songs = new List<Song> {s1,s2,s3,s4};
            Album al2 = new Album() { Title = "Mi Tierra", PhotoUrl = "~/Content/images/AlbumImages/mitierra400x410.jpg", ReleaseDate = new DateTime(1993, 6, 22) };
            al2.Songs = new List<Song> { s5 };
            Album al3 = new Album() { Title = "Laundry Service", PhotoUrl = "~/Content/images/AlbumImages/laundryservice400x410.jpg", ReleaseDate = new DateTime(2001, 11, 13) };
            al3.Songs = new List<Song> { s6,s7,s8,s9,s10 };
            Album al4 = new Album() { Title = "Whitney", PhotoUrl = "~/Content/images/AlbumImages/whitney400x410.jpg", ReleaseDate = new DateTime(1987, 6, 2) };
            al4.Songs = new List<Song> { s11,s12,s13,s14,s15 };
            Album al5 = new Album() { Title = "Faith", PhotoUrl = "~/Content/images/AlbumImages/faith400x410.jpg", ReleaseDate = new DateTime(1987, 10, 30) };
            al5.Songs = new List<Song> { s16,s17,s18,s19,s20 };
            Album al6 = new Album() { Title = "Falco 3", PhotoUrl = "~/Content/images/AlbumImages/falco3400x410.jpg", ReleaseDate = new DateTime(1985, 10, 15) };
            al6.Songs = new List<Song> { s21, s22, s23,s24,s25 };
            Album al7 = new Album() { Title = "Let's Stick Together", PhotoUrl = "~/Content/images/AlbumImages/letssticktogether400x410.jpg", ReleaseDate = new DateTime(1976, 9, 30) };
            al7.Songs = new List<Song> { s26, s27, s28,s29,s30 };
            Album al8 = new Album() { Title = "Je dis aime", PhotoUrl = "~/Content/images/AlbumImages/jedisaime400x410.jpg", ReleaseDate = new DateTime(1999, 10, 25) };
            al8.Songs = new List<Song> { s31 };
            Album al9 = new Album() { Title = "Tutte storie", PhotoUrl = "~/Content/images/AlbumImages/tuttestorie400x410.jpg", ReleaseDate = new DateTime(1993, 8, 10) };
            al9.Songs = new List<Song> { s32 };
            Album al10 = new Album() { Title = "Vuelve", PhotoUrl = "~/Content/images/AlbumImages/vuelve400x410.jpg", ReleaseDate = new DateTime(1998, 2, 10) };
            al10.Songs = new List<Song> { s33 };
            Album al11 = new Album() { Title = "Oxygene", PhotoUrl = "~/Content/images/AlbumImages/oxygene400x410.jpg", ReleaseDate = new DateTime(1976, 12, 2) };
            al11.Songs = new List<Song> { s34, s35, s36,s37 };
            Album al12 = new Album() { Title = "Just Be", PhotoUrl = "~/Content/images/AlbumImages/justbe400x410.jpg", ReleaseDate = new DateTime(2004, 4, 6) };
            al12.Songs = new List<Song> { s38, s39, s40, s41, s42 };
            Album al13 = new Album() { Title = "Error in the System", PhotoUrl = "~/Content/images/AlbumImages/errorinthesystem400x410.jpg", ReleaseDate = new DateTime(1982, 7, 3) };
            al3.Songs = new List<Song> { s43 };
            Album al14 = new Album() { Title = "You've Come a Long Way, Baby", PhotoUrl = "~/Content/images/AlbumImages/youvecomealongwaybaby400x410.jpg", ReleaseDate = new DateTime(1998, 10, 19) };
            al4.Songs = new List<Song> { s44,s45,s46,s47,s48 };
            Album al15 = new Album() { Title = "Shivers", PhotoUrl = "~/Content/images/AlbumImages/shivers400x410.jpg", ReleaseDate = new DateTime(2005, 8, 8) };
            al15.Songs = new List<Song> { s49 };
            Album al16 = new Album() { Title = "Play", PhotoUrl = "~/Content/images/AlbumImages/play400x410.jpg", ReleaseDate = new DateTime(1999, 5, 17) };
            al16.Songs = new List<Song> { s50,s51,s52,s53,s54 };
            Album al17 = new Album() { Title = "Perfecto Fluoro", PhotoUrl = "~/Content/images/AlbumImages/perfectofluoro400x410.jpg", ReleaseDate = new DateTime(1996, 10, 28) };
            al17.Songs = new List<Song> { s55 };
            Album al18 = new Album() { Title = "Phuture 2000", PhotoUrl = "~/Content/images/AlbumImages/phuture2000400x410.jpg", ReleaseDate = new DateTime(1999, 3, 1) };
            al18.Songs = new List<Song> { s56 };
            Album al19 = new Album() { Title = "Dreamland", PhotoUrl = "~/Content/images/AlbumImages/dreamland400x410.jpg", ReleaseDate = new DateTime(1996, 6, 7) };
            al19.Songs = new List<Song> { s57 };
            Album al20 = new Album() { Title = "Are You Experienced", PhotoUrl = "~/Content/images/AlbumImages/areyouexperienced400x410.jpg", ReleaseDate = new DateTime(1967, 5, 12) };
            al20.Songs = new List<Song> { s58, s59, s60, s61 };
            Album al21 = new Album() { Title = "Diary of a Madman", PhotoUrl = "~/Content/images/AlbumImages/diaryofamadman400x410.jpg", ReleaseDate = new DateTime(1981, 11, 7) };
            al21.Songs = new List<Song> { s62 };
            Album al22 = new Album() { Title = "Tattoo", PhotoUrl = "~/Content/images/AlbumImages/tattoo400x410.jpg", ReleaseDate = new DateTime(1973, 11, 11) };
            al22.Songs = new List<Song> { s63 };
            Album al23 = new Album() { Title = "Supernatural", PhotoUrl = "~/Content/images/AlbumImages/supernatural400x410.jpg", ReleaseDate = new DateTime(1999, 6, 15) };
            al23.Songs = new List<Song> { s64,s65,s66 };
            Album al24 = new Album() { Title = "Stanley Road", PhotoUrl = "~/Content/images/AlbumImages/stanleyroad400x410.jpg", ReleaseDate = new DateTime(1995, 5, 15) };
            al24.Songs = new List<Song> { s67 };
            Album al25 = new Album() { Title = "Slowhand", PhotoUrl = "~/Content/images/AlbumImages/slowhand400x410.jpg", ReleaseDate = new DateTime(1977, 11, 25) };
            al25.Songs = new List<Song> { s68,s69,s70,s71 };
            Album al26 = new Album() { Title = "Pearl", PhotoUrl = "~/Content/images/AlbumImages/pearl400x410.jpg", ReleaseDate = new DateTime(1971, 1, 11) };
            al26.Songs = new List<Song> { s72 };
            Album al27 = new Album() { Title = "With a Little Help from My Friends", PhotoUrl = "~/Content/images/AlbumImages/withalittlehelpfrommyfriends400x410.jpg", ReleaseDate = new DateTime(1969, 5, 30) };
            al27.Songs = new List<Song> { s73,s74 };
            Album al28 = new Album() { Title = "The Dream of the Blue Turtles", PhotoUrl = "~/Content/images/AlbumImages/thedreamoftheblueturtles400x410.jpg", ReleaseDate = new DateTime(1985, 6, 1) };
            al28.Songs = new List<Song> { s75};
            Album al29 = new Album() { Title = "Viva Hate", PhotoUrl = "~/Content/images/AlbumImages/vivahate400x410.jpg", ReleaseDate = new DateTime(1988, 3, 14) };
            al29.Songs = new List<Song> { s76 };
            Album al30 = new Album() { Title = "Darkness on the Edge of Town", PhotoUrl = "~/Content/images/AlbumImages/darknessontheedgeoftown400x410.jpg", ReleaseDate = new DateTime(1978, 6, 2) };
            al30.Songs = new List<Song> { s77,s78,s79,s80,s81 };
            Album al31 = new Album() { Title = "Ethio Jazz", PhotoUrl = "~/Content/images/AlbumImages/ethiojazz400x410.jpg", ReleaseDate = new DateTime(1974, 1, 1) };
            al31.Songs = new List<Song> { s82,s83,s84,s85,s86 };
            Album al32 = new Album() { Title = "City lights", PhotoUrl = "~/Content/images/AlbumImages/citylights400x410.jpg", ReleaseDate = new DateTime(1963, 12, 1) };
            al32.Songs = new List<Song> { s87,s88,s89 };
            Album al33 = new Album() { Title = "Laughing on the Outside", PhotoUrl = "~/Content/images/AlbumImages/laughingontheoutside400x410.jpg", ReleaseDate = new DateTime(1963, 8, 12) };
            al33.Songs = new List<Song> { s90, s91,s92 };
            Album al34 = new Album() { Title = "The Second Time Around", PhotoUrl = "~/Content/images/AlbumImages/thesecondtimearound400x410.jpg", ReleaseDate = new DateTime(1961, 12, 14) };
            al34.Songs = new List<Song> { s93,s94,s95 };
            Album al35 = new Album() { Title = "Songs in a Mellow Mood", PhotoUrl = "~/Content/images/AlbumImages/songsinamellowmood400x410.jpg", ReleaseDate = new DateTime(1954, 3, 30) };
            al35.Songs = new List<Song> { s96,s97,s98 };
            Album al36 = new Album() { Title = "Let It All Out", PhotoUrl = "~/Content/images/AlbumImages/letitallout400x410.jpg", ReleaseDate = new DateTime(1965, 12, 16) };
            al36.Songs = new List<Song> { s99, s100};
            Album al37 = new Album() { Title = "Blue Train", PhotoUrl = "~/Content/images/AlbumImages/bluetrain400x410.jpg", ReleaseDate = new DateTime(1958, 1, 20) };
            al37.Songs = new List<Song> { s101,s102,s103 };
            Album al38 = new Album() { Title = "Hello, Dolly!", PhotoUrl = "~/Content/images/AlbumImages/hellodolly400x410.jpg", ReleaseDate = new DateTime(1964, 2, 22) };
            al38.Songs = new List<Song> { s104,s105,s106 };
            Album al39 = new Album() { Title = "Milestones", PhotoUrl = "~/Content/images/AlbumImages/milestones400x410.jpg", ReleaseDate = new DateTime(1958, 9, 2) };
            al39.Songs = new List<Song> { s107,s108 };
            Album al40 = new Album() { Title = "Monk's Music", PhotoUrl = "~/Content/images/AlbumImages/monksmusic400x410.jpg", ReleaseDate = new DateTime(1957, 11, 28) };
            al40.Songs = new List<Song> { s109,s110,s111,s112,s113 };
            Album al41 = new Album() { Title = "Overtures", PhotoUrl = "~/Content/images/AlbumImages/overtures400x410.jpg", ReleaseDate = new DateTime(1987, 12, 10) };
            al41.Songs = new List<Song> { s114,s115,s116 };
            Album al42 = new Album() { Title = "Floresta do Amazonas", PhotoUrl = "~/Content/images/AlbumImages/florestadoamazonas400x410.jpg", ReleaseDate = new DateTime(2010, 6, 29) };
            al42.Songs = new List<Song> { s117,s118 };
            Album al43 = new Album() { Title = "Gnossiennes, Gymnopιdies", PhotoUrl = "~/Content/images/AlbumImages/gnossiennesgymnopidies400x410.jpg", ReleaseDate = new DateTime(1969, 6, 11) };
            al43.Songs = new List<Song> { s119, s120,s121,s122,s123 };
            Album al44 = new Album() { Title = "Peer Gynt (Complete Incidental Music)", PhotoUrl = "~/Content/images/AlbumImages/peergynt400x410.jpg", ReleaseDate = new DateTime(2008, 9, 13) };
            al44.Songs = new List<Song> { s124 };
            Album al45 = new Album() { Title = "Obras para guitarra", PhotoUrl = "~/Content/images/AlbumImages/obrasparaguitarra400x410.jpg", ReleaseDate = new DateTime(2002, 9, 1) };
            al45.Songs = new List<Song> { s125, s126, s127 };
            Album al46 = new Album() { Title = "I Walk the Line", PhotoUrl = "~/Content/images/AlbumImages/iwalktheline400x410.jpg", ReleaseDate = new DateTime(1964, 6, 22) };
            al46.Songs = new List<Song>() {s128,s129,s130 };
            Album al47 = new Album() { Title = "Always on my Mind", PhotoUrl = "~/Content/images/AlbumImages/alwaysonmymind400x410.jpg", ReleaseDate = new DateTime(1982, 2, 1) };
            Album al48 = new Album() { Title = "Jolene", PhotoUrl = "~/Content/images/AlbumImages/jolene400x410.jpg", ReleaseDate = new DateTime(1974, 2, 4) };
            Album al49 = new Album() { Title = "Sentimentally Yours", PhotoUrl = "~/Content/images/AlbumImages/sentimentallyyours400x410.jpg", ReleaseDate = new DateTime(1962, 8, 6) };
            Album al50 = new Album() { Title = "Out of a Dream", PhotoUrl = "~/Content/images/AlbumImages/outofadream400x410.jpg", ReleaseDate = new DateTime(1979, 8, 27) };
            Album al51 = new Album() { Title = "Bad Girls", PhotoUrl = "~/Content/images/AlbumImages/badgirls400x410.jpg", ReleaseDate = new DateTime(1979, 4, 25) };
            Album al52 = new Album() { Title = "Let The Sunshine In", PhotoUrl = "~/Content/images/AlbumImages/letthesunshinein400x410.jpg", ReleaseDate = new DateTime(1969, 5, 26) };
            Album al53 = new Album() { Title = "I've Got You", PhotoUrl = "~/Content/images/AlbumImages/ivegotyou400x410.jpg", ReleaseDate = new DateTime(1976, 7, 20) };
            Album al54 = new Album() { Title = "Let the Music Play", PhotoUrl = "~/Content/images/AlbumImages/letthemusicplay400x410.jpg", ReleaseDate = new DateTime(1976, 1, 2) };
            Album al55 = new Album() { Title = "Nightclubbing", PhotoUrl = "~/Content/images/AlbumImages/nightclubbing400x410.jpg", ReleaseDate = new DateTime(1981, 4, 29) };
            Album al56 = new Album() { Title = "Dangerous", PhotoUrl = "~/Content/images/AlbumImages/dangerous400x410.jpg", ReleaseDate = new DateTime(1991, 11, 26) };
            al56.Songs = new List<Song>() { s131, s132 };
            #endregion

            #region SEEDING ARTISTS
            Artist a1 = new Artist() { Name = "Michael", LastName = "Jackson", PhotoUrl = "~/Content/images/ArtistImages/michael_jackson400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1958, 8, 29), DateOfDeath = new DateTime(2009, 7, 25) };
            a1.Albums = new List<Album>() { al1, al56 };
            Artist a2 = new Artist() { Name = "Gloria", LastName = "Estefan", PhotoUrl = "~/Content/images/ArtistImages/gloria_estefan400x410.jpg", Country = "Cuba", DateOfBirth = new DateTime(1957, 9, 1) };
            a2.Albums = new List<Album>() { al2 };
            Artist a3 = new Artist() { Name = "Shakira", LastName = "", PhotoUrl = "~/Content/images/ArtistImages/shakira400x410.jpg", Country = "Colombia", DateOfBirth = new DateTime(1977, 2, 2) };
            a3.Albums = new List<Album>() { al3 };
            Artist a4 = new Artist() { Name = "Whitney ", LastName = "Houston ", PhotoUrl = "~/Content/images/ArtistImages/whitney_houston400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1963, 8, 9), DateOfDeath = new DateTime(2012, 2, 11) };
            a4.Albums = new List<Album>() { al4 };
            Artist a5 = new Artist() { Name = "George", LastName = "Michael", PhotoUrl = "~/Content/images/ArtistImages/george_michael400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1963, 7, 25), DateOfDeath = new DateTime(2016, 12, 25) };
            a5.Albums = new List<Album>() { al5 };
            Artist a6 = new Artist() { Name = "Falco", LastName = "", PhotoUrl = "~/Content/images/ArtistImages/falco400x410.jpg", Country = "Austria", DateOfBirth = new DateTime(1957, 2, 19), DateOfDeath = new DateTime(1998, 1, 6) };
            a6.Albums = new List<Album>() { al6 };
            Artist a7 = new Artist() { Name = "Bryan", LastName = "Ferry", PhotoUrl = "~/Content/images/ArtistImages/bryan_ferry400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1945, 10, 26) };
            a7.Albums = new List<Album>() { al7 };
            Artist a8 = new Artist() { Name = "Matthieu", LastName = "Chedid", PhotoUrl = "~/Content/images/ArtistImages/matthieu_chedid400x410.jpg", Country = "France", DateOfBirth = new DateTime(1971, 12, 21) };
            a8.Albums = new List<Album>() { al8 };
            Artist a9 = new Artist() { Name = "Eros", LastName = "Ramazzotti", PhotoUrl = "~/Content/images/ArtistImages/eros_ramazzotti400x410.jpg", Country = "Italy", DateOfBirth = new DateTime(1963, 10, 28) };
            a9.Albums = new List<Album>() { al9 };
            Artist a10 = new Artist() { Name = "Ricky", LastName = "Martin", PhotoUrl = "~/Content/images/ArtistImages/ricky_martin400x410.jpg", Country = "Puerto Rico", DateOfBirth = new DateTime(1971, 12, 24) };
            a10.Albums = new List<Album>() { al10 };
            Artist a11 = new Artist() { Name = "Jean Michel", LastName = "Jarre", PhotoUrl = "~/Content/images/ArtistImages/jeanmichel_jarre400x410.jpg", Country = "France", DateOfBirth = new DateTime(1948, 8, 24) };
            a11.Albums = new List<Album>() { al11 };
            Artist a12 = new Artist() { Name = "Tiesto", LastName = "", PhotoUrl = "~/Content/images/ArtistImages/tiesto400x410.jpg", Country = "Netherlands", DateOfBirth = new DateTime(1969, 1, 17) };
            a12.Albums = new List<Album>() { al12 };
            Artist a13 = new Artist() { Name = "Peter", LastName = "Schilling", PhotoUrl = "~/Content/images/ArtistImages/peter_schilling400x410.jpg", Country = "Germany", DateOfBirth = new DateTime(1956, 1, 28) };
            a13.Albums = new List<Album>() { al13 };
            Artist a14 = new Artist() { Name = "Fat boy slim", LastName = "", PhotoUrl = "~/Content/images/ArtistImages/fatboyslim400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1963, 7, 31) };
            a14.Albums = new List<Album>() { al14 };
            Artist a15 = new Artist() { Name = "Armin", LastName = "van Buuren", PhotoUrl = "~/Content/images/ArtistImages/armin_vanbuuren400x410.jpg", Country = "Netherlands", DateOfBirth = new DateTime(1976, 12, 25) };
            a15.Albums = new List<Album>() { al15 };
            Artist a16 = new Artist() { Name = "Moby", LastName = "", PhotoUrl = "~/Content/images/ArtistImages/moby400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1965, 9, 11) };
            a16.Albums = new List<Album>() { al16 };
            Artist a17 = new Artist() { Name = "Paul", LastName = "Oakenfold", PhotoUrl = "~/Content/images/ArtistImages/paul_oakenfold400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1963, 8, 30) };
            a17.Albums = new List<Album>() { al17 };
            Artist a18 = new Artist() { Name = "Carl", LastName = "Cox", PhotoUrl = "~/Content/images/ArtistImages/carl_cox400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1962, 7, 29) };
            a18.Albums = new List<Album>() { al18 };
            Artist a19 = new Artist() { Name = "Robert", LastName = "Miles", PhotoUrl = "~/Content/images/ArtistImages/robert_miles400x410.jpg", Country = "Italy", DateOfBirth = new DateTime(1969, 11, 3), DateOfDeath = new DateTime(2017, 5, 9) };
            a19.Albums = new List<Album>() { al19 };
            Artist a20 = new Artist() { Name = "Jimmy", LastName = "Hendrix", PhotoUrl = "~/Content/images/ArtistImages/jimmy_hendrix400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1942, 11, 27), DateOfDeath = new DateTime(1970, 9, 18) };
            a20.Albums = new List<Album>() { al20 };
            Artist a21 = new Artist() { Name = "Ozzy", LastName = "Osbourne", PhotoUrl = "~/Content/images/ArtistImages/ozzy_osbourne400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1948, 12, 3) };
            a21.Albums = new List<Album>() { al21 };
            Artist a22 = new Artist() { Name = "Rory", LastName = "Gallagher ", PhotoUrl = "~/Content/images/ArtistImages/rory_gallagher400x410.jpg", Country = "Ireland", DateOfBirth = new DateTime(1948, 12, 3) };
            a22.Albums = new List<Album>() { al22 };
            Artist a23 = new Artist() { Name = "Carlos", LastName = "Santana", PhotoUrl = "~/Content/images/ArtistImages/carlos_santana400x410.jpg", Country = "Mexico", DateOfBirth = new DateTime(1947, 7, 20) };
            a23.Albums = new List<Album>() { al23 };
            Artist a24 = new Artist() { Name = "Paul", LastName = "Weller", PhotoUrl = "~/Content/images/ArtistImages/paul_weller400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1958, 5, 25) };
            a24.Albums = new List<Album>() { al24 };
            Artist a25 = new Artist() { Name = "Eric", LastName = "Clapton", PhotoUrl = "~/Content/images/ArtistImages/eric_clapton400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1945, 3, 30) };
            a25.Albums = new List<Album>() { al25 };
            Artist a26 = new Artist() { Name = "Janis", LastName = "Joplin", PhotoUrl = "~/Content/images/ArtistImages/janis_joplin400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1943, 1, 19), DateOfDeath = new DateTime(1970, 10, 4) };
            a26.Albums = new List<Album>() { al26 };
            Artist a27 = new Artist() { Name = "Joe", LastName = "Cocker", PhotoUrl = "~/Content/images/ArtistImages/joe_cocker400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1944, 5, 20), DateOfDeath = new DateTime(2014, 12, 22) };
            a27.Albums = new List<Album>() { al27 };
            Artist a28 = new Artist() { Name = "Sting", LastName = "", PhotoUrl = "~/Content/images/ArtistImages/sting400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1951, 10, 2) };
            a28.Albums = new List<Album>() { al28 };
            Artist a29 = new Artist() { Name = "Morrissey", LastName = "", PhotoUrl = "~/Content/images/ArtistImages/morrissey400x410.jpg", Country = "UK", DateOfBirth = new DateTime(1959, 5, 22) };
            a29.Albums = new List<Album>() { al29 };
            Artist a30 = new Artist() { Name = "Bruce ", LastName = "Springsteen", PhotoUrl = "~/Content/images/ArtistImages/bruce_springsteen400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1949, 9, 23) };
            a30.Albums = new List<Album>() { al30 };
            Artist a31 = new Artist() { Name = "Mulatu", LastName = "Astatke", PhotoUrl = "~/Content/images/ArtistImages/mulatu_astatke400x410.jpg", Country = "Ethiopia", DateOfBirth = new DateTime(1943, 12, 19) };
            a31.Albums = new List<Album>() { al31 };
            Artist a32 = new Artist() { Name = "Gerry", LastName = "Mulligan", PhotoUrl = "~/Content/images/ArtistImages/gerry_mulligan400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1927, 4, 6), DateOfDeath = new DateTime(1996, 1, 20) };
            a32.Albums = new List<Album>() { al32 };
            Artist a33 = new Artist() { Name = "Aretha", LastName = "Franklin", PhotoUrl = "~/Content/images/ArtistImages/aretha_franklin400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1942, 3, 25), DateOfDeath = new DateTime(2018, 8, 16) };
            a33.Albums = new List<Album>() { al33 };
            Artist a34 = new Artist() { Name = "Etta", LastName = "James", PhotoUrl = "~/Content/images/ArtistImages/etta_james400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1938, 1, 25), DateOfDeath = new DateTime(2012, 1, 20) };
            a34.Albums = new List<Album>() { al34 };
            Artist a35 = new Artist() { Name = "Ella", LastName = "Fitzgerald", PhotoUrl = "~/Content/images/ArtistImages/ella_fitzgerald400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1917, 5, 25), DateOfDeath = new DateTime(1996, 6, 15) };
            a35.Albums = new List<Album>() { al35 };
            Artist a36 = new Artist() { Name = "Nina", LastName = "Simone", PhotoUrl = "~/Content/images/ArtistImages/nina_simone400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1933, 2, 21), DateOfDeath = new DateTime(2003, 4, 21) };
            a36.Albums = new List<Album>() { al36 };
            Artist a37 = new Artist() { Name = "John", LastName = "Coltrane", PhotoUrl = "~/Content/images/ArtistImages/john_coltrane400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1926, 10, 17), DateOfDeath = new DateTime(1967, 7, 17) };
            a37.Albums = new List<Album>() { al37 };
            Artist a38 = new Artist() { Name = "Lewis", LastName = "Armstrong", PhotoUrl = "~/Content/images/ArtistImages/lewis_armstrong400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1901, 8, 4), DateOfDeath = new DateTime(1971, 7, 6) };
            a38.Albums = new List<Album>() { al38 };
            Artist a39 = new Artist() { Name = "Miles", LastName = "Davis", PhotoUrl = "~/Content/images/ArtistImages/miles_davis400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1926, 5, 26) };
            a39.Albums = new List<Album>() { al39 };
            Artist a40 = new Artist() { Name = "Thelonious", LastName = "Monk", PhotoUrl = "~/Content/images/ArtistImages/thelonious_monk400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1917, 10, 10), DateOfDeath = new DateTime(1982, 2, 17) };
            a40.Albums = new List<Album>() { al40 };
            Artist a41 = new Artist() { Name = "Gioachino", LastName = "Rossini", PhotoUrl = "~/Content/images/ArtistImages/gioachino_rossini400x410.jpg", Country = "Italy", DateOfBirth = new DateTime(1792, 2, 29), DateOfDeath = new DateTime(1868, 11, 13) };
            a41.Albums = new List<Album>() { al41 };
            Artist a42 = new Artist() { Name = "Heitor", LastName = "Villa Lobos", PhotoUrl = "~/Content/images/ArtistImages/heitor_villalobos400x410.jpg", Country = "Brazil", DateOfBirth = new DateTime(1887, 3, 5), DateOfDeath = new DateTime(1959, 11, 17) };
            a42.Albums = new List<Album>() { al42 };
            Artist a43 = new Artist() { Name = "Erik", LastName = "Satie", PhotoUrl = "~/Content/images/ArtistImages/erik_satie400x410.jpg", Country = "France", DateOfBirth = new DateTime(1866, 5, 17), DateOfDeath = new DateTime(1925, 7, 1) };
            a43.Albums = new List<Album>() { al43 };
            Artist a44 = new Artist() { Name = "Edvard", LastName = "Grieg", PhotoUrl = "~/Content/images/ArtistImages/edvard_grieg400x410.jpg", Country = "Norway", DateOfBirth = new DateTime(1843, 7, 15), DateOfDeath = new DateTime(1907, 9, 4) };
            a44.Albums = new List<Album>() { al44 };
            Artist a45 = new Artist() { Name = "Francisco", LastName = "Tarrega", PhotoUrl = "~/Content/images/ArtistImages/francisco_tarrega400x410.jpg", Country = "Spain", DateOfBirth = new DateTime(1852, 11, 21), DateOfDeath = new DateTime(1909, 12, 15) };
            a45.Albums = new List<Album>() { al45 };
            Artist a46 = new Artist() { Name = "Johnny", LastName = "Cash", PhotoUrl = "~/Content/images/ArtistImages/johnny_cash400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1932, 2, 26), DateOfDeath = new DateTime(2003, 9, 12) };
            a46.Albums = new List<Album>() { al46 };
            Artist a47 = new Artist() { Name = "Willie", LastName = "Nelson", PhotoUrl = "~/Content/images/ArtistImages/willie_nelson400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1933, 4, 29) };
            a47.Albums = new List<Album>() { al47 };
            Artist a48 = new Artist() { Name = "Dolly", LastName = "Parton", PhotoUrl = "~/Content/images/ArtistImages/dolly_parton400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1946, 1, 19) };
            a48.Albums = new List<Album>() { al48 };
            Artist a49 = new Artist() { Name = "Patsy", LastName = "Cline", PhotoUrl = "~/Content/images/ArtistImages/patsy_cline400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1932, 9, 8), DateOfDeath = new DateTime(1963, 3, 5) };
            a49.Albums = new List<Album>() { al49 };
            Artist a50 = new Artist() { Name = "Reba", LastName = "McEntire", PhotoUrl = "~/Content/images/ArtistImages/reba_mcentire400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1955, 3, 28) };
            a50.Albums = new List<Album>() { al50 };
            Artist a51 = new Artist() { Name = "Donna", LastName = "Summer", PhotoUrl = "~/Content/images/ArtistImages/donna_summer400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1948, 12, 31), DateOfDeath = new DateTime(2012, 5, 17) };
            a51.Albums = new List<Album>() { al51 };
            Artist a52 = new Artist() { Name = "Diana", LastName = "Ross", PhotoUrl = "~/Content/images/ArtistImages/diana_ross400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1944, 3, 26) };
            a52.Albums = new List<Album>() { al52 };
            Artist a53 = new Artist() { Name = "Gloria", LastName = "Gaynor", PhotoUrl = "~/Content/images/ArtistImages/gloria_gaynor400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1943, 9, 7) };
            a53.Albums = new List<Album>() { al53 };
            Artist a54 = new Artist() { Name = "Barry", LastName = "White", PhotoUrl = "~/Content/images/ArtistImages/barry_white400x410.jpg", Country = "USA", DateOfBirth = new DateTime(1944, 9, 12), DateOfDeath = new DateTime(2003, 7, 4) };
            a54.Albums = new List<Album>() { al54 };
            Artist a55 = new Artist() { Name = "Grace", LastName = "Jones", PhotoUrl = "~/Content/images/ArtistImages/grace_jones400x410.jpg", Country = "Jamaica", DateOfBirth = new DateTime(1948, 5, 19) };
            a55.Albums = new List<Album>() { al55 };
            #endregion

            #region SEEDING GENRES
            Genre g1 = new Genre() { Kind = "Rock" };
            g1.Albums = new List<Album>() { al20, al21, al22, al23, al24, al25, al26, al27, al28, al29, al30 };
            Genre g2 = new Genre() { Kind = "POP" };
            g2.Albums = new List<Album>() { al1, al2, al3, al4, al5, al6, al7, al8, al9, al10 };
            Genre g3 = new Genre() { Kind = "Classical Music" };
            g3.Albums = new List<Album>() { al41, al42, al43, al44, al45 };
            Genre g4 = new Genre() { Kind = "Country" };
            g4.Albums = new List<Album>() { al46, al47, al48, al49, al50 };
            Genre g5 = new Genre() { Kind = "Jazz" };
            g5.Albums = new List<Album>() { al31, al32, al33, al34, al35, al36, al37, al38, al39, al40 };
            Genre g6 = new Genre() { Kind = "Electronic" };
            g6.Albums = new List<Album>() { al11, al12, al13, al14, al15, al16, al17, al18, al19 };
            Genre g7 = new Genre() { Kind = "Disco" };
            g7.Albums = new List<Album>() { al51, al52, al53, al54, al55 };
            #endregion

         
            context.Artists.AddOrUpdate(x => new { x.Name, x.LastName }, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25, a26, a27, a28, a29, a30, a31, a32, a33, a34, a35, a36, a37, a38, a39, a40, a41, a42, a43, a44, a45, a46, a47, a48, a49, a50, a51, a52, a53, a54, a55);
            context.Genres.AddOrUpdate(x => x.Kind, g1, g2, g3, g4, g5, g6, g7);
            context.Songs.AddOrUpdate(x => new { x.Title, x.Duration, x.ReleaseDate }, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26, s27, s28, s29, s30, s31, s32, s33, s34, s35, s36, s37, s38, s39, s40, s41, s42, s43, s44, s45, s46, s47, s48, s49, s50, s51, s52, s53, s54, s55, s56, s57, s58, s59, s60, s61, s62, s63, s64, s65, s66, s67, s68, s69, s70, s71, s72, s73, s74, s75, s76, s77, s78, s79, s80, s81, s82, s83, s84, s85, s86, s87, s88, s89, s90, s91, s92, s93, s94, s95, s96, s97, s98, s99, s100, s101, s102, s103, s104, s105, s106, s107, s108, s109, s110, s111, s112, s113, s114, s115, s116, s117, s118, s119, s120, s121, s122, s123, s124, s125, s126, s127, s128, s129, s130, s131, s132);
            
            context.SaveChanges();




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