using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Game
{

    enum Rooms
    {
        NoRoom,
        ElevatorRoom,
        DeadlockRoom,
        CodeRoom,
        DieRoom,
        FourWaysRoom,
        AllyRoom,
        OfficerIdRoom,
        ExitRoom
    }

    class FirstFloorClass
    {
        private char[] PlayerWay = new char[0];
        private Choice choice = GetChoice();
        private FirstFloorRooms location;

        private enum FirstFloorRooms
        {
            NoRoom,
            ExitRoom
        }

        private enum Choice
        {
            NoChoice,
            GoMid,
            GoBack,
            GoRigth,
            GoLeft
        }

        private static Choice GetChoice()
        {
            Console.WriteLine("Куда вы хотите пойти?(Вперёд, Назад, Вправо, Влево)");
            string Choice = Console.ReadLine();
            if (Choice == "Вперёд")
                return (Choice)1;
            if (Choice == "Назад")
                return (Choice)2;
            if (Choice == "Вправо")
                return (Choice)3;
            if (Choice == "Влево")
                return (Choice)4;
            Console.WriteLine("Такого пути не существует. Выберите правильный путь(Press ENTER to continue).");
            Console.ReadLine();
            return (Choice)0;
        }

        private char[] GoAhead(ref char[] Way, in Choice PlayersChoice)
        {
            if ((Way.Length == 0 && PlayersChoice == Choice.GoMid) || (Way.Length == 1 && PlayersChoice == Choice.GoRigth) || (Way.Length == 2 && PlayersChoice == Choice.GoMid) || (Way.Length == 3 && PlayersChoice == Choice.GoLeft))
            {
                char[] NewWay = new char[Way.Length + 1];
                int i = 0;
                for (; i < Way.Length; i++)
                    NewWay[i] = Way[i];
                switch (PlayersChoice)
                {
                    case Choice.GoMid:
                        Console.WriteLine("Вы прошли прямо(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'M';
                        break;
                    case Choice.GoRigth:
                        Console.WriteLine("Вы прошли вправо(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'R';
                        break;
                    case Choice.GoLeft:
                        Console.WriteLine("Вы прошли влево(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'L';
                        break;
                }
                return NewWay;
            }
            else
            {
                Console.WriteLine("Движение по заданной траектории невозможно. Выберите другое направление(Press ENTER to continue).");
                Console.ReadLine();
                return Way;
            }
        }

        private char[] GoBack(ref char[] Way)
        {
            if (Way.Length >= 1)
            {
                char[] NewWay = new char[Way.Length - 1];
                for (int i = 0; i < NewWay.Length; i++)
                    NewWay[i] = Way[i];
                Console.WriteLine("Вы прошли назад(Press ENTER to continue).");
                Console.ReadLine();
                return NewWay;
            }
            else
            {
                Console.WriteLine("Вы находитесь в начале своего пути. Движение назад невозможно(Press ENTER to continue).");
                Console.ReadLine();
                return Way;
            }
        }

        private FirstFloorRooms CheckWay(char[] PlayerWay)
        {

            if (PlayerWay.Length == 4 && PlayerWay[0] == 'M' && PlayerWay[1] == 'R' && PlayerWay[2] == 'M' && PlayerWay[3] == 'L')
            {
                Console.WriteLine("Вы нашли выход! Однако на двери висит замок, который можно открыть с помощью найденных подсказок. \nПри малейшей ошибке, активируется тревога, и игра будет окончена(Press ENTER to continue).");
                Console.ReadLine();
                return FirstFloorRooms.ExitRoom;
            }
            return FirstFloorRooms.NoRoom;
        }

        public Rooms GetOutFromFirstFloor()
        {
            while (true)
            {
                if ((int)choice == 0)
                {
                    Console.Clear();
                    choice = GetChoice();
                    continue;
                }
                else
                {
                    if ((int)choice == 1 || (int)choice == 3 || (int)choice == 4)
                    {
                        PlayerWay = GoAhead(ref PlayerWay, choice);
                    }
                    else
                    {
                        PlayerWay = GoBack(ref PlayerWay);
                    }
                }
                location = CheckWay(PlayerWay);
                if (location == FirstFloorRooms.NoRoom)
                {
                    choice = Choice.NoChoice;
                    continue;
                }
                if (location == FirstFloorRooms.ExitRoom)
                {
                        return Rooms.ExitRoom;
                }
            }
        }
    }

    class SecondFloorClass
    {
        private Guid officerId;

        public Guid SetId
        {
            set { officerId = value; }
        }

        private char[] PlayerWay = new char[0];
        private Choice choice = GetChoice();
        private SecondFloorRooms location;

        private enum SecondFloorRooms
        {
            NoRoom,
            ElevatorRoom,
            DeadlockRoom,
            OfficerIdRoom
        }

        private enum Choice
        {
            NoChoice,
            GoMid,
            GoBack,
            GoRigth,
            GoLeft
        }

        private static Choice GetChoice()
        {
            Console.WriteLine("Куда вы хотите пойти?(Вперёд, Назад, Вправо, Влево)");
            string Choice = Console.ReadLine();
            if (Choice == "Вперёд")
                return (Choice)1;
            if (Choice == "Назад")
                return (Choice)2;
            if (Choice == "Вправо")
                return (Choice)3;
            if (Choice == "Влево")
                return (Choice)4;
            Console.WriteLine("Такого пути не существует. Выберите правильный путь(Press ENTER to continue).");
            Console.ReadLine();
            return (Choice)0;
        }

        private char[] GoAhead(ref char[] Way, in Choice PlayersChoice)
        {
            if ((Way.Length == 0 && PlayersChoice == Choice.GoMid) || (Way.Length == 1 && PlayersChoice == Choice.GoRigth) || (Way.Length == 2 && (PlayersChoice == Choice.GoMid || PlayersChoice == Choice.GoRigth)) || (Way.Length == 3 && PlayersChoice == Choice.GoMid) || (Way.Length == 4 && (PlayersChoice == Choice.GoLeft || PlayersChoice == Choice.GoRigth)))
            {
                char[] NewWay = new char[Way.Length + 1];
                int i = 0;
                for (; i < Way.Length; i++)
                    NewWay[i] = Way[i];
                switch (PlayersChoice)
                {
                    case Choice.GoMid:
                        Console.WriteLine("Вы прошли прямо(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'M';
                        break;
                    case Choice.GoRigth:
                        Console.WriteLine("Вы прошли вправо(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'R';
                        break;
                    case Choice.GoLeft:
                        Console.WriteLine("Вы прошли влево(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'L';
                        break;
                }
                return NewWay;
            }
            else
            {
                Console.WriteLine("Движение по заданной траектории невозможно. Выберите другое направление(Press ENTER to continue).");
                Console.ReadLine();
                return Way;
            }
        }

        private char[] GoBack(ref char[] Way)
        {
            if (Way.Length >= 1)
            {
                char[] NewWay = new char[Way.Length - 1];
                for (int i = 0; i < NewWay.Length; i++)
                    NewWay[i] = Way[i];
                Console.WriteLine("Вы прошли назад(Press ENTER to continue).");
                Console.ReadLine();
                return NewWay;
            }
            else
            {
                Console.WriteLine("Вы находитесь в начале своего пути. Движение назад невозможно(Press ENTER to continue).");
                Console.ReadLine();
                return Way;
            }
        }

        private SecondFloorRooms CheckWay(char[] PlayerWay)
        {

            if (PlayerWay.Length == 3 && PlayerWay[0] == 'M' && PlayerWay[1] == 'R' && PlayerWay[2] == 'M')
            {
                Console.WriteLine("Вы нашли лифт. У вас есть выбор, остаться на текущем этаже или поехать на этаж ниже(Press ENTER to continue).");
                Console.ReadLine();
                return SecondFloorRooms.ElevatorRoom;
            }
            if (PlayerWay.Length == 5 && PlayerWay[0] == 'M' && PlayerWay[1] == 'R' && PlayerWay[2] == 'R' && PlayerWay[3] == 'M' && PlayerWay[4] == 'R')
            {
                Console.WriteLine("Вы попали в тупик. Пути вперёд нет, только назад(Press ENTER to continue).");
                Console.ReadLine();
                return SecondFloorRooms.DeadlockRoom;
            }
            if (PlayerWay.Length == 5 && PlayerWay[0] == 'M' && PlayerWay[1] == 'R' && PlayerWay[2] == 'R' && PlayerWay[3] == 'M' && PlayerWay[4] == 'L')
            {
                Console.WriteLine($"Вы находите комнату, где нет ничего, кроме бэйджика одного из охранников.\nНа нём выделен ID: {officerId} \nВозможно, стоит его запомнить(Press ENTER to continue).");
                Console.ReadLine();
                return SecondFloorRooms.OfficerIdRoom;
            }
            return SecondFloorRooms.NoRoom;
        }

        public Rooms GetOutFromSecondFloor()
        {
            while (true)
            {
                if ((int)choice == 0)
                {
                    Console.Clear();
                    choice = GetChoice();
                    continue;
                }
                else
                {
                    if ((int)choice == 1 || (int)choice == 3 || (int)choice == 4)
                    {
                        PlayerWay = GoAhead(ref PlayerWay, choice);
                    }
                    else
                    {
                        PlayerWay = GoBack(ref PlayerWay);
                    }
                }
                location = CheckWay(PlayerWay);
                if (location == SecondFloorRooms.NoRoom || location == SecondFloorRooms.OfficerIdRoom || location == SecondFloorRooms.DeadlockRoom)
                {
                    choice = Choice.NoChoice;
                    continue;
                }
                if (location == SecondFloorRooms.ElevatorRoom)
                {
                    Console.WriteLine("Какой ваш дальнейший план?(Спуститься или Остаться)\nВернуться обратно будет невозможно.");
                    string ElevatorChoice = Console.ReadLine();
                    if (ElevatorChoice == "Спуститься")
                    {
                        return Rooms.ElevatorRoom;
                    }
                    if (ElevatorChoice == "Остаться")
                    {
                        Console.WriteLine("Вами было принято решение остаться.(Press ENTER to continue)");
                        Console.ReadLine();
                        choice = Choice.NoChoice;
                        continue;
                    }
                    Console.WriteLine("Лифт не смог распознать ваш запрос. Было принято решение оставить вас на текущем этаже(Press ENTER to continue).");
                    Console.ReadLine();
                    choice = Choice.NoChoice;
                    continue;
                }
            }
        }

    }

    class ThirdFloorClass
    {
        private bool foundAlly = false;

        public bool GetAllyState
        {
            get { return foundAlly; }
        }


        private char[] PlayerWay = new char[0];
        private Choice choice = GetChoice();
        private ThirdFloorRooms location;

        private enum ThirdFloorRooms
        {
            NoRoom,
            ElevatorRoom,
            DieRoom,
            AllyRoom
        }

        private enum Choice
        {
            NoChoice,
            GoMid,
            GoBack,
            GoRigth,
            GoLeft
        }

        private static Choice GetChoice()
        {
            Console.WriteLine("Куда вы хотите пойти?(Вперёд, Назад, Вправо, Влево)");
            string Choice = Console.ReadLine();
            if (Choice == "Вперёд")
                return (Choice)1;
            if (Choice == "Назад")
                return (Choice)2;
            if (Choice == "Вправо")
                return (Choice)3;
            if (Choice == "Влево")
                return (Choice)4;
            Console.WriteLine("Такого пути не существует. Выберите правильный путь(Press ENTER to continue).");
            Console.ReadLine();
            return (Choice)0;
        }

        private char[] GoAhead(ref char[] Way, in Choice PlayersChoice)
        {
            if ((Way.Length == 0 && PlayersChoice == Choice.GoMid) || (Way.Length == 1 && (PlayersChoice == Choice.GoLeft || PlayersChoice == Choice.GoRigth)) || (Way.Length == 2 && PlayersChoice == Choice.GoMid) || (Way.Length == 3 && Way[1] == 'R' && (PlayersChoice == Choice.GoRigth  || PlayersChoice == Choice.GoRigth)) || (Way.Length == 4 && PlayersChoice == Choice.GoLeft && Way[1] == 'R'))
            {
                char[] NewWay = new char[Way.Length + 1];
                int i = 0;
                for (; i < Way.Length; i++)
                    NewWay[i] = Way[i];
                switch (PlayersChoice)
                {
                    case Choice.GoMid:
                        Console.WriteLine("Вы прошли прямо(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'M';
                        break;
                    case Choice.GoRigth:
                        Console.WriteLine("Вы прошли вправо(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'R';
                        break;
                    case Choice.GoLeft:
                        Console.WriteLine("Вы прошли влево(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'L';
                        break;
                }
                return NewWay;
            }
            else
            {
                Console.WriteLine("Движение по заданной траектории невозможно. Выберите другое направление(Press ENTER to continue).");
                Console.ReadLine();
                return Way;
            }
        }

        private char[] GoBack(ref char[] Way)
        {
            if (Way.Length >= 1)
            {
                char[] NewWay = new char[Way.Length - 1];
                for (int i = 0; i < NewWay.Length; i++)
                    NewWay[i] = Way[i];
                Console.WriteLine("Вы прошли назад(Press ENTER to continue).");
                Console.ReadLine();
                return NewWay;
            }
            else
            {
                Console.WriteLine("Вы находитесь в начале своего пути. Движение назад невозможно(Press ENTER to continue).");
                Console.ReadLine();
                return Way;
            }
        }

        private ThirdFloorRooms CheckWay(char[] PlayerWay)
        {

            if (PlayerWay.Length == 4 && PlayerWay[0] == 'M' && PlayerWay[1] == 'R' && PlayerWay[2] == 'M' && PlayerWay[3] == 'R')
            {
                Console.WriteLine("Вы нашли лифт. У вас есть выбор, остаться на текущем этаже или поехать на этаж ниже(Press ENTER to continue).");
                Console.ReadLine();
                return ThirdFloorRooms.ElevatorRoom;
            }
            if (PlayerWay.Length == 5 && PlayerWay[0] == 'M' && PlayerWay[1] == 'R' && PlayerWay[2] == 'M' && PlayerWay[3] == 'M' && PlayerWay[4] == 'L')
            {
                Console.WriteLine("Как только вы входите в комнату, двери неожиданно закрываются.\nВы слышите какоё-то писк, как в комнате сразу же появляются лазеры \nкоторые убивают вас за считанные секунды. Вы погибаете(Press ENTER to continue).");
                Console.ReadLine();
                return ThirdFloorRooms.DieRoom;
            }
            if (PlayerWay.Length == 3 && PlayerWay[0] == 'M' && PlayerWay[1] == 'L' && PlayerWay[2] == 'M')
            {
                Console.WriteLine("Вы находите комнату, где располагается ваш напарник.\nВы продолжаете приключение, но уже не один(Press ENTER to continue).");
                Console.ReadLine();
                return ThirdFloorRooms.AllyRoom;
            }
            return ThirdFloorRooms.NoRoom;
        }

        public Rooms GetOutFromThirdFloor()
        {
            while (true)
            {
                if ((int)choice == 0)
                {
                    Console.Clear();
                    choice = GetChoice();
                    continue;
                }
                else
                {
                    if ((int)choice == 1 || (int)choice == 3 || (int)choice == 4)
                    {
                        PlayerWay = GoAhead(ref PlayerWay, choice);
                    }
                    else
                    {
                        PlayerWay = GoBack(ref PlayerWay);
                    }
                }
                location = CheckWay(PlayerWay);
                if (location == ThirdFloorRooms.NoRoom)
                {
                    choice = Choice.NoChoice;
                    continue;
                }
                if (location == ThirdFloorRooms.AllyRoom)
                {
                    foundAlly = true;
                    choice = Choice.NoChoice;
                    continue;
                }
                if (location == ThirdFloorRooms.ElevatorRoom)
                {
                    Console.WriteLine("Какой ваш дальнейший план?(Спуститься или Остаться)\nВернуться обратно будет невозможно.");
                    string ElevatorChoice = Console.ReadLine();
                    if (ElevatorChoice == "Спуститься")
                    {
                        return Rooms.ElevatorRoom;
                    }
                    if (ElevatorChoice == "Остаться")
                    {
                        Console.WriteLine("Вами было принято решение остаться.(Press ENTER to continue)");
                        Console.ReadLine();
                        choice = Choice.NoChoice;
                        continue;
                    }
                    Console.WriteLine("Лифт не смог распознать ваш запрос. Было принято решение оставить вас на текущем этаже(Press ENTER to continue).");
                    Console.ReadLine();
                    choice = Choice.NoChoice;
                    continue;
                }
                if (location == ThirdFloorRooms.DieRoom)
                    return Rooms.DieRoom;
            }
        }
    }

    class ForthFloorClass
    {
        private int code;

        public int GetCode
        {
            set { code = value; }
        }


        private char[] PlayerWay = new char[0];
        private Choice choice = GetChoice();
        private ForthFloorRooms location;

        private enum ForthFloorRooms
        {
            NoRoom,
            ElevatorRoom,
            DeadlockRoom,
            CodeRoom,
            DieRoom,
            FourWaysRoom
        }

        private enum Choice
        {
            NoChoice,
            GoMid,
            GoBack,
            GoRigth,
            GoLeft
        }

        private static Choice GetChoice()
        {
            Console.WriteLine("Куда вы хотите пойти?(Вперёд, Назад, Вправо, Влево)");
            string Choice = Console.ReadLine();
            if (Choice == "Вперёд")
                return (Choice)1;
            if (Choice == "Назад")
                return (Choice)2;
            if (Choice == "Вправо")
                return (Choice)3;
            if (Choice == "Влево")
                return (Choice)4;
            Console.WriteLine("Такого пути не существует. Выберите правильный путь(Press ENTER to continue).");
            Console.ReadLine();
            return (Choice)0;
        }

        private char[] GoAhead(ref char[] Way, in Choice PlayersChoice)
        {
            if ((Way.Length == 0 && PlayersChoice == Choice.GoMid) || (Way.Length == 1 && (PlayersChoice == Choice.GoLeft || PlayersChoice == Choice.GoRigth)) || (Way.Length == 2 && PlayersChoice == Choice.GoMid) || (Way.Length == 3 && Way[1] == 'R' && PlayersChoice == Choice.GoRigth) || (Way.Length == 3 && Way[1] == 'L') || (Way.Length == 4 && PlayersChoice == Choice.GoMid && Way[1] == 'L' && Way[3] == 'R'))
            {
                char[] NewWay = new char[Way.Length + 1];
                int i = 0;
                for (; i < Way.Length; i++)
                    NewWay[i] = Way[i];
                switch (PlayersChoice)
                {
                    case Choice.GoMid:
                        Console.WriteLine("Вы прошли прямо(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'M';
                        break;
                    case Choice.GoRigth:
                        Console.WriteLine("Вы прошли вправо(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'R';
                        break;
                    case Choice.GoLeft:
                        Console.WriteLine("Вы прошли влево(Press ENTER to continue).");
                        Console.ReadLine();
                        NewWay[i] = 'L';
                        break;
                }
                return NewWay;
            }
            else
            {
                Console.WriteLine("Движение по заданной траектории невозможно. Выберите другое направление(Press ENTER to continue).");
                Console.ReadLine();
                return Way;
            }


        }

        private char[] GoBack(ref char[] Way)     //static char[] GoBack(ref char[] Way, in Choice PlayerChoice)
        {
            if (Way.Length >= 1)
            {
                char[] NewWay = new char[Way.Length - 1];
                for (int i = 0; i < NewWay.Length; i++)
                    NewWay[i] = Way[i];
                Console.WriteLine("Вы прошли назад(Press ENTER to continue).");
                Console.ReadLine();
                return NewWay;
            }
            else
            {
                Console.WriteLine("Вы находитесь в начале своего пути. Движение назад невозможно(Press ENTER to continue).");
                Console.ReadLine();
                return Way;
            }
        }

        private ForthFloorRooms CheckWay(char[] PlayerWay)
        {
            //char[] Elevator = new char[] { 'M', 'R', 'M', 'R' };
            //char[] Deadlock = new char[] { 'M', 'L', 'M', 'R', 'M' };
            //char[] RoomWithCode = new char[] { 'M', 'L', 'M', 'M' };
            //char[] Die = new char[] { 'M', 'L', 'M', 'L' };
            //char[] FourWays = new char[] { 'M', 'L', 'M'};

            if (PlayerWay.Length == 4 && PlayerWay[0] == 'M' && PlayerWay[1] == 'R' && PlayerWay[2] == 'M' && PlayerWay[3] == 'R')
            {
                Console.WriteLine("Вы нашли лифт. У вас есть выбор, остаться на текущем этаже или поехать на этаж ниже(Press ENTER to continue).");
                //    Array.Resize(ref PlayerWay, PlayerWay.Length - 1);
                Console.ReadLine();
                return ForthFloorRooms.ElevatorRoom;
            }
            if (PlayerWay.Length == 5 && PlayerWay[0] == 'M' && PlayerWay[1] == 'L' && PlayerWay[2] == 'M' && PlayerWay[3] == 'R' && PlayerWay[4] == 'M')
            {
                Console.WriteLine("Вы попали в тупик. Пути вперёд нет, только назад(Press ENTER to continue).");
                //    Array.Resize(ref PlayerWay, PlayerWay.Length - 1);
                Console.ReadLine();
                return ForthFloorRooms.DeadlockRoom;
            }
            if (PlayerWay.Length == 4 && PlayerWay[0] == 'M' && PlayerWay[1] == 'L' && PlayerWay[2] == 'M' && PlayerWay[3] == 'M')
            {
                Console.WriteLine($"Вы нашли пустую комнату. В ней никого нет, но вы, обыскав всё, находите кусок бумаги с цифрами {code}. \nЧто бы это могло значить?(Press ENTER to continue)");
                //      Array.Resize(ref PlayerWay, PlayerWay.Length - 1);
                Console.ReadLine();
                return ForthFloorRooms.CodeRoom;
            }
            if (PlayerWay.Length == 4 && PlayerWay[0] == 'M' && PlayerWay[1] == 'L' && PlayerWay[2] == 'M' && PlayerWay[3] == 'L')
            {
                Console.WriteLine("В комнате оказалась охрана. Вы были убиты на месте(Press ENTER to continue).");
                Console.ReadLine();
                return ForthFloorRooms.DieRoom;
            }
            if (PlayerWay.Length == 3 && PlayerWay[0] == 'M' && PlayerWay[1] == 'L' && PlayerWay[2] == 'M')
            {
                Console.WriteLine("Вы попали на пересечении дорог. У вас есть 4 выбора, куда пойти(Press ENTER to continue).");
                Console.ReadLine();
                return ForthFloorRooms.FourWaysRoom;
            }
            return ForthFloorRooms.NoRoom;
        }

        public Rooms GetOutFromForthFloor()
        {
            while (true)
            {
                if ((int)choice == 0)
                {
                    Console.Clear();
                    choice = GetChoice();
                    continue;
                }
                else
                {
                    if ((int)choice == 1 || (int)choice == 3 || (int)choice == 4)
                    {
                        PlayerWay = GoAhead(ref PlayerWay, choice);
                    }
                    else
                    {
                        PlayerWay = GoBack(ref PlayerWay);
                    }
                }
                location = CheckWay(PlayerWay);
                if (location == ForthFloorRooms.NoRoom || location == ForthFloorRooms.CodeRoom || location == ForthFloorRooms.DeadlockRoom || location == ForthFloorRooms.FourWaysRoom)
                {
                    choice = Choice.NoChoice;
                    continue;
                }
                if (location == ForthFloorRooms.ElevatorRoom)
                {
                    Console.WriteLine("Какой ваш дальнейший план?(Спуститься или Остаться)\nВернуться обратно будет невозможно.");
                    string ElevatorChoice = Console.ReadLine();
                    if (ElevatorChoice == "Спуститься")
                    {
                        return Rooms.ElevatorRoom;
                    }
                    if (ElevatorChoice == "Остаться")
                    {
                        Console.WriteLine("Вами было принято решение остаться.(Press ENTER to continue)");
                        Console.ReadLine();
                        choice = Choice.NoChoice;
                        continue;
                    }
                    Console.WriteLine("Лифт не смог распознать ваш запрос. Было принято решение оставить вас на текущем этаже(Press ENTER to continue).");
                    Console.ReadLine();
                    choice = Choice.NoChoice;
                    continue;
                }
                if (location == ForthFloorRooms.DieRoom)
                    return Rooms.DieRoom;
            }
        }

    }

    class Program
    {

        enum Color
        {
            NoColor,
            Green,
            Yellow,
            Red,
            Blue
        }

        static Color GetColor()
        {
            Console.WriteLine("Вы заперты в комнате. К вам просвечивается свет. Какой цвет вы видите?(Зелёный, Жёлтый, Красный, Голубой)");
            string Color = Console.ReadLine();
            if (Color == "Зелёный")
                return (Color)1;
            if (Color == "Жёлтый")
                return (Color)2;
            if (Color == "Красный")
                return (Color)3;
            if (Color == "Голубой")
                return (Color)4;
            Console.WriteLine("Такого цвета на коробле нет. Присмотритесь внимательней(Press ENTER to continue).");
            Console.ReadLine();
            return (Color)0;
        }

        static Color GenerateNewFloorColor(Color nextFloorColor, int previousFloor, Color[] colorCodeArray)
        {
            Random random = new Random();
            if (previousFloor == 4)
            {
                while (nextFloorColor == colorCodeArray[3])
                    nextFloorColor = (Color)random.Next(1, 4);
                colorCodeArray[2] = nextFloorColor;
            }
            if (previousFloor == 3)
            {
                while (nextFloorColor == colorCodeArray[3] || nextFloorColor == colorCodeArray[2])
                    nextFloorColor = (Color)random.Next(1, 4);
                colorCodeArray[1] = nextFloorColor;
            }
            if (previousFloor == 2)
            {
                while (nextFloorColor == colorCodeArray[3] || nextFloorColor == colorCodeArray[2] || nextFloorColor == colorCodeArray[1])
                    nextFloorColor = (Color)random.Next(1, 4);
                colorCodeArray[0] = nextFloorColor;
            }
            return nextFloorColor;
        }

        static void FinalQuiz(in int doorExitCode, in bool ally, in Guid doorExitId, Color[] exitColorCode)
        {
            Console.WriteLine("Итак, приступим. Первое, что нужно сделать - ввести 4-х значный код(Введите код для продолжения): ");
            int code = int.Parse(Console.ReadLine());
            if (code != doorExitCode)
            {
                Console.WriteLine("Неверный код. Была активирована тревога. Вы были схвачены охранниками.\nИгра закончена. Вы проиграли.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("Верно. Что ж, дальше нужно приложить 2 руки к сканеру(Press ENTER to continue).");
            if (!ally)
            {
                Console.WriteLine("Вы пытаетесь приложить обе руки, как сразу же активируется тревога.\nВы были схвачены охранниками. Игра закончена. Вы проиграли.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Вы и ваш спасённый напарник прикладывайте по одой руке к сканеру. Сканирование проходит успешно.(Press ENTER)");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Теперь вам необходимо ввести уникальный ID одного из охранников(Введите ID для продолжения):");
            string ID = Console.ReadLine();
            if (ID != Convert.ToString(doorExitId))
            {
                Console.WriteLine("Неверный ID. Была активирована тревога. Вы были схвачены охранниками.\nИгра закончена. Вы проиграли.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("Неплохо. Остаётся всего ничего - Необходимо вводить код цвета этажа в порядке от нижнего к верхнему, по одному.");
            Console.WriteLine("1 - Зелёный \n2 - Жёлтый \n3 - Красный \n4 - Голубой");
            int Num = int.Parse(Console.ReadLine());
            if ((int)exitColorCode[0] != Num)
            {
                Console.WriteLine("Неверно! Была активирована тревога. Вы были схвачены охранниками.\nИгра закончена. Вы проиграли.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Верно, теперь цвет 2-го этажа:");
            Num = int.Parse(Console.ReadLine());
            if ((int)exitColorCode[1] != Num)
            {
                Console.WriteLine("Неверно! Была активирована тревога. Вы были схвачены охранниками.\nИгра закончена. Вы проиграли.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Неплохо, теперь цвет 3-го этажа:");
            Num = int.Parse(Console.ReadLine());
            if ((int)exitColorCode[2] != Num)
            {
                Console.WriteLine("Неверно! Была активирована тревога. Вы были схвачены охранниками.\nИгра закончена. Вы проиграли.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Прекрасно, остаётся назвать последний цвет - 4-го этажа:");
            Num = int.Parse(Console.ReadLine());
            if ((int)exitColorCode[3] != Num)
            {
                Console.WriteLine("Неверно! Была активирована тревога. Вы были схвачены охранниками.\nИгра закончена. Вы проиграли.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Дверь открыта, вы выбрались! \nПобеда!");
            Console.ReadLine();
            return;
        }

        static void Main(string[] args)
        {

            Color roomColor = GetColor();   //Узнаём цвет(этаж)
            while (true)
            {
                if ((int)roomColor == 0)
                {
                    Console.Clear();
                    roomColor = GetColor();
                    continue;
                }
                else
                {
                    Console.WriteLine("По распознанному главным героем цвету, он понимает, что заперт на 4 этаже. \nНеожиданно дверь открывается, и наш герой принимается за поиски выхода(Press ENTER to continue).") ;
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
            }
            Color[] exitColorCode = new Color[4];
            exitColorCode[3] = roomColor;

            var forthFloor = new ForthFloorClass();

            Random random = new Random();
            int doorCode = random.Next(1000, 9999);

            forthFloor.GetCode = doorCode;

            Rooms escapedRoom = forthFloor.GetOutFromForthFloor();

            if (escapedRoom == Rooms.DieRoom)
            {
                Console.WriteLine("Игра закончена из-за смерти.");
                Console.ReadLine();
                return;
            }

            roomColor = GenerateNewFloorColor(roomColor, 4, exitColorCode);
            string newFloorColor = "";
            if (roomColor == Color.Blue)
                newFloorColor = "Голубой";
            if (roomColor == Color.Green)
                newFloorColor = "Зелёный";
            if (roomColor == Color.Red)
                newFloorColor = "Красный";
            if (roomColor == Color.Yellow)
                newFloorColor = "Жёлтый";

            Console.WriteLine($"Лифт доставил вас на 3 этаж. Вы замечаете, что цвет нового этажа - {newFloorColor} (Press ENTER to continue).");
            Console.ReadLine();
            Console.Clear();

            var thirdFloor = new ThirdFloorClass();

            escapedRoom = thirdFloor.GetOutFromThirdFloor();
            bool allyState = thirdFloor.GetAllyState;

            if (escapedRoom == Rooms.DieRoom)
            {
                Console.WriteLine("Игра закончена из-за смерти.");
                Console.ReadLine();
                return;
            }

            roomColor = GenerateNewFloorColor(roomColor, 3, exitColorCode);
            newFloorColor = "";
            if (roomColor == Color.Blue)
                newFloorColor = "Голубой";
            if (roomColor == Color.Green)
                newFloorColor = "Зелёный";
            if (roomColor == Color.Red)
                newFloorColor = "Красный";
            if (roomColor == Color.Yellow)
                newFloorColor = "Жёлтый";

            Console.WriteLine($"Лифт доставил вас на 2 этаж. Вы замечаете, что цвет нового этажа - {newFloorColor} (Press ENTER to continue).");
            Console.ReadLine();
            Console.Clear();

            var secondFloor = new SecondFloorClass();

            Guid id = Guid.NewGuid();
            secondFloor.SetId = id;

            escapedRoom = secondFloor.GetOutFromSecondFloor();

            roomColor = GenerateNewFloorColor(roomColor, 2, exitColorCode);
            newFloorColor = "";
            if (roomColor == Color.Blue)
                newFloorColor = "Голубой";
            if (roomColor == Color.Green)
                newFloorColor = "Зелёный";
            if (roomColor == Color.Red)
                newFloorColor = "Красный";
            if (roomColor == Color.Yellow)
                newFloorColor = "Жёлтый";

            Console.WriteLine($"Лифт доставил вас на 1 этаж. Вы замечаете, что цвет последнего этажа - {newFloorColor} (Press ENTER to continue).");
            Console.ReadLine();
            Console.Clear();

            var firstFloor = new FirstFloorClass();

            escapedRoom = firstFloor.GetOutFromFirstFloor();

            FinalQuiz(in doorCode, in allyState, in id, exitColorCode);

        }
    }
}
