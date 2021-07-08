using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//                  MySQL Table
// use DB_A7168B_kuvaevsql;
// drop table Game_Shop;
// create table Game_Shop(
// [id] int identity primary key,
// [Game] nvarchar(30) not null,
// [Studio] nvarchar(30) not null,
// [Year] int not null,
// [Style] nvarchar(20) not null,
// [Sold] int not null,
// [User Type] nvarchar(30) not null);
// insert into Game_Shop values(
// 'Battlefield', 'Electronic Arts', 2002, 'Tactical strategy', 1500000, 'Singleplayer'),
// ('Crysis', 'Crytek', 2007, 'Shooter', 2000000, 'Singleplayer'),
// ('CS:GO', 'Valve', 2012, 'Shooter', 10000000, 'Multiplayer'),
// ('Far Cry', 'Ubisoft', 2008, 'Shooter', 300000, 'Multiplayer'),
// ('Metro 2033', '4A Games', 2010, 'Shooter', 700000, 'Singleplayer');
// select* from Game_Shop;
//

namespace AdoNet_HW_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("0. Показать все данные из таблицы.");
            Console.WriteLine("1. Поиск информации по названию игры.");
            Console.WriteLine("2. Поиск игр по названию студии.");
            Console.WriteLine("3. Поиск информации по названию студии и игры.");
            Console.WriteLine("4. Поиск игр по стилю.");
            Console.WriteLine("5. Поиск игр по году релиза.");
            Console.WriteLine("==============================================");
            Console.WriteLine("6. Отображение информации обо всех однопользовательских играх.");
            Console.WriteLine("7. Отображение информации обо всех многопользовательских играх.");
            Console.WriteLine("8. Показать игру с максимальным количеством проданных игр.");
            Console.WriteLine("9. Показать игру с минимальным количеством проданных игр.");
            Console.WriteLine("10. Отображение топ-3 самых продаваемых игр.");
            Console.WriteLine("11. Отображение топ-3 самых непродаваемых игр.");
            Console.WriteLine("==============================================");
            Console.WriteLine("12. Добавить новую игру.");
            Console.WriteLine("13. Изменить данные игры.");
            Console.WriteLine("14. Удалить игру.");
            Console.Write("Ваш выбор: ");
            int sw = int.Parse(Console.ReadLine());
            if (sw == 0)
            {
                using (Model1 myModel = new Model1())
                {
                    myModel.Game_Shops.ToList().ForEach(Console.WriteLine);
                }
                Console.ReadKey();
            }
            #region Задание 1
            // Поиск информации по названию игры
            if (sw == 1)
            {
                string gameSearch;
                Console.Write("Введите название игры: ");
                gameSearch = Console.ReadLine();
                Console.WriteLine("Информация об игре:");
                using (Model1 db = new Model1())
                {
                    var info = db.Game_Shops.Where(p => p.Game == gameSearch);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Sold}, {gh.Studio}, {gh.Style}, {gh.User_Type}, {gh.Year}");
                    }
                }
                Console.ReadKey();
            }
            // Поиск игр по названию студии
            if (sw == 2)
            {
                string myStudio;
                Console.Write("Введите название студии: ");
                myStudio = Console.ReadLine();
                Console.WriteLine("Информация об игре:");
                using (Model1 db = new Model1())
                {
                    var info = db.Game_Shops.Where(p => p.Studio == myStudio);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Game}, {gh.Sold}, {gh.Studio}, {gh.Style}, {gh.User_Type}, {gh.Year}");
                    }
                }
                Console.ReadKey();
            }
            // Поиск информации по названию студии и игры
            if (sw == 3)
            {
                string myStudio, myGame;
                Console.Write("Введите название студии: ");
                myStudio = Console.ReadLine();
                Console.Write("Введите название игры: ");
                myGame = Console.ReadLine();
                Console.WriteLine("Информация об игре:");
                using (Model1 db = new Model1())
                {
                    var info = db.Game_Shops.Where(p => p.Studio == myStudio && p.Game == myGame);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Game}, {gh.Sold}, {gh.Studio}, {gh.Style}, {gh.User_Type}, {gh.Year}");
                    }
                }
                Console.ReadKey();
            }
            // Поиск игр по стилю
            if (sw == 4)
            {
                string myStyle;
                Console.Write("Введите ваш стиль: ");
                myStyle = Console.ReadLine();
                using (Model1 db = new Model1())
                {
                    var info = db.Game_Shops.Where(p => p.Style == myStyle);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Game}");
                    }
                }
                Console.ReadKey();
            }
            // Поиск игр по году релиза
            if (sw == 5)
            {
                int myYear;
                Console.Write("Введите год релиза: ");
                myYear = int.Parse(Console.ReadLine());
                using (Model1 db = new Model1())
                {
                    var info = db.Game_Shops.Where(p => p.Year == myYear);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Game}");
                    }
                }
                Console.ReadKey();
            }
            #endregion
            #region Задание 2
            // Отображение информации обо всех однопользовательских играх
            if (sw == 6)
            {
                string gameType = "Singleplayer";
                using (Model1 db = new Model1())
                {
                    var info = db.Game_Shops.Where(p => p.User_Type == gameType);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Game}, {gh.Sold}, {gh.Studio}, {gh.Style}, {gh.User_Type}, {gh.Year}");
                    }
                }
                Console.ReadKey();
            }
            // Отображение информации обо всех многопользовательских играх
            if (sw == 7)
            {
                string gameType = "Multiplayer";
                using (Model1 db = new Model1())
                {
                    var info = db.Game_Shops.Where(p => p.User_Type == gameType);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Game}, {gh.Sold}, {gh.Studio}, {gh.Style}, {gh.User_Type}, {gh.Year}");
                    }
                }
                Console.ReadKey();
            }
            // Показать игру с максимальным количеством проданных игр
            if (sw == 8)
            {
                using (Model1 db = new Model1())
                {
                    var maxV = db.Game_Shops.Max(p => p.Sold);
                    var info = db.Game_Shops.Where(p => p.Sold == maxV);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Game}, {gh.Sold}, {gh.Studio}, {gh.Style}, {gh.User_Type}, {gh.Year}");
                    }
                }
                Console.ReadKey();
            }
            // Показать игру с минимальным количеством проданных игр
            if (sw == 9)
            {
                using (Model1 db = new Model1())
                {
                    var minV = db.Game_Shops.Min(p => p.Sold);
                    var info = db.Game_Shops.Where(p => p.Sold == minV);
                    foreach (Game_Shop gh in info)
                    {
                        Console.WriteLine($"{gh.Game}, {gh.Sold}, {gh.Studio}, {gh.Style}, {gh.User_Type}, {gh.Year}");
                    }
                }
                Console.ReadKey();
            }
            // Отображение топ-3 самых продаваемых игр
            if (sw == 10)
            {
                using (Model1 db = new Model1())
                {
                    var items = db.Game_Shops.OrderByDescending(p => p.Sold).Take(3);
                    foreach (Game_Shop gh in items)
                    {
                        Console.WriteLine($"{gh.Game}");
                    }
                }
                Console.ReadKey();
            }
            // Отображение топ-3 самых непродаваемых игр
            if (sw == 11)
            {
                using (Model1 db = new Model1())
                {
                    var query = db.Game_Shops.GroupBy(s => s.Sold).Select(s => new {Name = s.Key, Min = s.Min(m => m.Sold),}).ToList();
                }
                Console.ReadKey();
            }
            #endregion
            #region Задание 3
            // Добавление новой игры
            if (sw == 12)
            {
                string newGame, newStudio, newStyle, newUserType;
                int newSold, newYear;
                Console.Write("Введите название игры: ");
                newGame = Console.ReadLine();
                Console.Write("Введите название студии: ");
                newStudio = Console.ReadLine();
                Console.Write("Введите год выпуска: ");
                newYear = int.Parse(Console.ReadLine());
                Console.Write("Введите стиль: ");
                newStyle = Console.ReadLine();
                Console.Write("Введите количество проданных копий: ");
                newSold = int.Parse(Console.ReadLine());
                Console.Write("Введите тип игры: ");
                newUserType = Console.ReadLine();
                
                using (Model1 db = new Model1())
                {
                    Game_Shop game_Shop = new Game_Shop()
                    {
                        Game = newGame,
                        Studio = newStudio,
                        Year = newYear,
                        Style = newStyle,
                        Sold = newSold,
                        User_Type = newUserType
                    };
                    if (game_Shop.Game != newGame)
                    {
                        db.Game_Shops.Add(game_Shop);
                        db.SaveChanges();
                        Console.WriteLine("Новая игра добавлена");
                    }
                    
                }
                Console.ReadKey();
            }
            // Изменение данных существующей игры
            if (sw == 13)
            {
                Game_Shop game = new Game_Shop();
                string newGame, newStudio, newStyle, newUserType;
                string myGame, myStudio, myStyle, myUserType;
                int newSold, newYear;
                int mySold, myYear;
                using (Model1 db = new Model1())
                {
                    Console.WriteLine("Выберите параметр для изменения:");
                    Console.WriteLine("1. Изменить название игры.");
                    Console.WriteLine("2. Изменить название студии.");
                    Console.WriteLine("3. Изменить год выпуска.");
                    Console.WriteLine("4. Изменить стиль игры.");
                    Console.WriteLine("5. Изменить количетсво проданных игр.");
                    Console.WriteLine("6. Изменить тип игры.");
                    Console.Write("Ваш выбор: ");
                    int operation = int.Parse(Console.ReadLine());

                    if (operation == 1)
                    {
                        Console.Write("Введите название игры: ");
                        myGame = Console.ReadLine();
                        if (myGame == game.Game)
                        {
                            Console.Write("Введите изменённое название игры: ");
                            newGame = Console.ReadLine();
                            var _game = db.Game_Shops.Where(c => c.Game == myGame).FirstOrDefault();
                            _game.Game = newGame;
                            Console.WriteLine("Параметр изменён");
                            db.SaveChanges();
                        }
                        else if (myGame != game.Game)
                        {
                            Console.WriteLine("Error data input.");
                            Console.ReadKey();
                        }
                    }
                    if (operation == 2)
                    {
                        Console.Write("Введите название студии: ");
                        myStudio = Console.ReadLine();
                        if (myStudio == game.Studio)
                        {
                            Console.Write("Введите изменённое название студии: ");
                            newStudio = Console.ReadLine();
                            var _studio = db.Game_Shops.Where(c => c.Studio == newStudio).FirstOrDefault();
                            _studio.Studio = newStudio;
                            Console.WriteLine("Параметр изменён");
                            db.SaveChanges();
                        }
                        else if (myStudio != game.Studio)
                        {
                            Console.WriteLine("Error data input.");
                            Console.ReadKey();
                        }
                    }
                    if (operation == 3)
                    {
                        Console.Write("Введите год выпуска: ");
                        myYear = int.Parse(Console.ReadLine());
                        if (myYear == game.Year)
                        {
                            Console.Write("Введите изменённый год выпуска: ");
                            newYear = int.Parse(Console.ReadLine());
                            var _year = db.Game_Shops.Where(c => c.Year == myYear).FirstOrDefault();
                            _year.Year = newYear;
                            Console.WriteLine("Параметр изменён");
                            db.SaveChanges();
                        }
                        else if (myYear != game.Year)
                        {
                            Console.WriteLine("Error data input.");
                            Console.ReadKey();
                        }
                    }
                    if (operation == 4)
                    {
                        Console.Write("Введите стиль игры: ");
                        myStyle = Console.ReadLine();
                        if (myStyle == game.Style)
                        {
                            Console.Write("Введите изменённый стиль игры: ");
                            newStyle = Console.ReadLine();
                            var _style = db.Game_Shops.Where(c => c.Style == myStyle).FirstOrDefault();
                            _style.Style = newStyle;
                            Console.WriteLine("Параметр изменён");
                            db.SaveChanges();
                        }
                        else if (myStyle != game.Style)
                        {
                            Console.WriteLine("Error data input.");
                            Console.ReadKey();
                        }
                    }
                    if (operation == 5)
                    {
                        Console.Write("Введите количество проданных игр: ");
                        mySold = int.Parse(Console.ReadLine());
                        if (mySold == game.Sold)
                        {
                            Console.Write("Введите изменённое количетсво: ");
                            newSold = int.Parse(Console.ReadLine());
                            var _sold = db.Game_Shops.Where(c => c.Sold == mySold).FirstOrDefault();
                            _sold.Sold = newSold;
                            Console.WriteLine("Параметр изменён");
                            db.SaveChanges();
                        }
                        else if (mySold != game.Sold)
                        {
                            Console.WriteLine("Error data input.");
                            Console.ReadKey();
                        }
                    }
                    if (operation == 6)
                    {
                        Console.Write("Введите тип игры: ");
                        myUserType = Console.ReadLine();
                        if (myUserType == game.User_Type)
                        {
                            Console.Write("Введите изменённый тип игры: ");
                            newUserType = Console.ReadLine();
                            var _userType = db.Game_Shops.Where(c => c.User_Type == myUserType).FirstOrDefault();
                            _userType.User_Type = newUserType;
                            Console.WriteLine("Параметр изменён");
                            db.SaveChanges();
                        }
                        else if (myUserType != game.User_Type)
                        {
                            Console.WriteLine("Error data input.");
                            Console.ReadKey();
                        }
                    }

                }
                Console.ReadKey();
            }
            // Удаление игры
            if (sw == 14)
            {
                string myStudio, myGame;
                Console.Write("Введите название игры: ");
                myStudio = Console.ReadLine();
                Console.Write("Введите название студии: ");
                myGame = Console.ReadLine();
                Game_Shop game = new Game_Shop();
                Console.WriteLine("Хотите ли вы удалить игру?");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Нет");
                int del_sw = int.Parse(Console.ReadLine());
                using (Model1 db = new Model1())
                {
                    if (del_sw == 1 && myGame == game.Game && myStudio == game.Studio)
                    {
                        Game_Shop del_query = db.Game_Shops.Where(d => d.Studio == myStudio && d.Game == myGame).FirstOrDefault();
                        db.Game_Shops.Remove(del_query);
                        db.SaveChanges();
                    }
                }
                Console.ReadKey();
            }
            #endregion

        }
    }
}
