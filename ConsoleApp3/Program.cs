using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using static ConsoleApp4.ProgramA.labar.Dispatcher;


namespace ConsoleApp4
{
    internal class ProgramA
    {
        abstract class Aircraft
        {
            abstract public void changespeed();
            abstract public void quit();
            abstract public void changeflightaltitude();
            public virtual void Info() { Console.WriteLine("It's Aircraft"); }

        }

        class Armyplane : Aircraft
        {
            public float amountengines;
            public float currspeed;
            public const float maxspeed = 5000;
            public const float maxloadpeople = 30;
            public float currloadpeople;
            public float curramountammo;
            public const float maxamountammo = 600;
            public float curraltitflight;

            public Armyplane()
                => amountengines = 4;

            override public void changespeed()
            {
                Console.WriteLine("enter current speed of copter - ");
                if (!float.TryParse(Console.ReadLine(), out currspeed))
                    Console.WriteLine("Not valid");
                else if (currspeed < 0)
                    Console.WriteLine("speed cannot be less than 0");
                else if (currspeed > maxspeed)
                    Console.WriteLine("enter please correct speed");
            }
            public void changeloadpeople()
            {
                Console.WriteLine("Enter current load of copter - ");
                float a = currloadpeople;
                if (!float.TryParse(Console.ReadLine(), out currloadpeople))
                    Console.WriteLine("Not valid");
                else if (curraltitflight > 0)
                {
                    Console.WriteLine("You cannot load while flying");
                    currloadpeople = a;
                    Console.WriteLine(currloadpeople);
                }
                else if (currloadpeople < 0)
                    Console.WriteLine("Load cannot be less than 0");
                else if (currloadpeople > maxloadpeople)
                {
                    Console.WriteLine("Enter please correct weight");
                    currloadpeople = 0;
                }
            }
            override public void changeflightaltitude()
            {
                Console.WriteLine("Enter current flight altitude of armyplane - ");
                if (!float.TryParse(Console.ReadLine(), out curraltitflight))
                    throw new EmergencyException();
                else if (curraltitflight < 0)
                    Console.WriteLine("Altitude cannot be less than 0");
                else if (curraltitflight > maxloadpeople)
                    Console.WriteLine("Enter please correct height");
            }
            public void changeamountammo()
            {
                Console.WriteLine("Enter amount of ammo - ");
                if (!float.TryParse(Console.ReadLine(), out curramountammo))
                throw new EmergencyException();

                else if (curramountammo < 0)
                    Console.WriteLine("Ammo cannot be less than 0");
                else if (curramountammo > maxamountammo && curramountammo >= 0)
                    Console.WriteLine("Enter please correct amount");
            }
            override public void quit()
                => Console.WriteLine("Good bye");
            public override void Info()
            {
                Console.WriteLine("Army Plane");
                Console.WriteLine("Amount of engines = 4");
                Console.WriteLine("Max speed = 5000");
                Console.WriteLine("Current speed = " + currspeed);
                Console.WriteLine("Max load people = 30");
                Console.WriteLine("Current amount of people = " + currloadpeople);
                Console.WriteLine("Current flight altitude = " + curraltitflight);
                Console.WriteLine("Max amount of ammo = 600");
                Console.WriteLine("Current amount of ammo = " + curramountammo);
            }
            public void MakeALanding()
            {
                curraltitflight = 0;
                currspeed = 0;
                Console.WriteLine("Army plane landed succesfully");
            }
            public void MakeATakeOff()
            {
                curraltitflight = 800;
                currspeed = 300;
                Console.WriteLine("Army plane took off out of Aircraft");
            }


        }
        internal class EmergencyException : Exception
        {
            public EmergencyException() { }
            public EmergencyException(string message) : base(message) { }
            public EmergencyException(string message, Exception innerException) : base(message, innerException) { }
            protected EmergencyException(SerializationInfo info, StreamingContext context) : base(info, context)
            { }
        }

        class MyCopter : Aircraft
        {
            public float screws;
            public float currspeed;
            public float maxspeed;
            public float curraltitflight;
            public float maxaltitflight;
            public float maxloadcap;
            public float currload;

            public MyCopter()
            {
                screws = 3;
                maxspeed = 320;
                maxaltitflight = 4000;
                maxloadcap = 4500;
            }

            public void changeload()
            {
                Console.WriteLine("Enter current load of copter - ");
                float a = currload;
                if (!float.TryParse(Console.ReadLine(), out currload))
                    Console.WriteLine("Not valid");
                else if (curraltitflight > 0)
                {
                    Console.WriteLine("You cannot load while flying");
                    currload = a;
                    Console.WriteLine(currload);
                }
                else if (currload < 0)
                    Console.WriteLine("Load cannot be less than 0");
                else if (currload > maxloadcap)
                {
                    Console.WriteLine("Enter please correct weight");
                    currload = 0;
                }
            }
            override public void changeflightaltitude()
            {
                Console.WriteLine("Enter current flight altitude of copter - ");
                if (!float.TryParse(Console.ReadLine(), out curraltitflight))
                    Console.WriteLine("Not valid");
                else if (curraltitflight < 0)
                    Console.WriteLine("Altitude cannot be less than 0");
                else if (curraltitflight > maxaltitflight)
                    Console.WriteLine("Enter please correct height");
            }
            override public void changespeed()
            {
                Console.WriteLine("Enter current speed of copter - ");
                if (!float.TryParse(Console.ReadLine(), out currspeed))
                    Console.WriteLine("Not valid");
                else if (currspeed < 0)
                    Console.WriteLine("Speed cannot be less than 0");
                else if (currspeed > maxspeed)
                    Console.WriteLine("Enter please correct speed");
            }
            public void dropload()
            {
                if (currload == 0)
                    Console.WriteLine("You didn't load your copter");
                else
                {
                    currload = 0;
                    Console.WriteLine("Dropped =)");
                }
            }
            override public void quit()
                => Console.WriteLine("Good bye");
            public override void Info()
            {
                Console.WriteLine("Helicopter");
                Console.WriteLine("screws = 3");
                Console.WriteLine("maxspeed = 320");
                Console.WriteLine("maxaltitflight = 4000");
                Console.WriteLine("maxloadcap = 4500");
                Console.WriteLine("Current speed = " + currspeed);
                Console.WriteLine("Current load = " + currload);
                Console.WriteLine("Current flight altitude = " + curraltitflight);
            }
            public void MakeALanding()
            {
                curraltitflight = 0;
                currspeed = 0;
                Console.WriteLine("Copter landed succesfully");
            }
            public void MakeATakeOff()
            {
                curraltitflight = 800;
                currspeed = 300;
                Console.WriteLine("Copter took off out of Aircraft");
            }

        }
        public class labar
        {
            static void Main(string[] args)
            {
                MyCopter copter = new MyCopter();
                Armyplane armyplane = new Armyplane();
                int ch = 0;
                Console.WriteLine("Max speed {0}", copter.maxspeed);
                Console.WriteLine("Max altitude {0}", copter.maxaltitflight);
                Console.WriteLine("Max load {0}", copter.maxloadcap);
                copter.Info();
                armyplane.Info();

                Dispatcher d = new Dispatcher();
                


                do
                {
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine("(1)Choise of load");
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine("(2)Choise of altitude");
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine("(3)Choise of speed");
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine("(4)Drop load");
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine("(5)Make a take off Copter");
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine("(6)Make a landing Copter");
                    Console.WriteLine("+-------------------------+");
                    Console.WriteLine("(7)Next plane");
                    Console.WriteLine("+-------------------------+");

                    if (!int.TryParse(Console.ReadLine(), out ch)) { }
                    switch (ch)
                    {
                        case 1:
                            copter.changeload();
                            break;
                        case 2:
                            copter.changeflightaltitude();
                            break;
                        case 3:
                            copter.changespeed();
                            break;
                        case 4:
                            copter.dropload();
                            break;
                        case 5:
                            d.TakeOffEvent += new AircraftsHandler(copter.MakeATakeOff);
                            d.TakeOffCommand();
                            break;
                        case 6:
                            d.LandingEvent += new AircraftsHandler(copter.MakeALanding);
                            d.LandingCommand();
                            break;
                        case 7:
                            copter.quit();
                            break;
                        default:
                            Console.WriteLine("Type correct number");
                            break;
                    }
                }
                while (ch != 7);
                do
                {
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("(1)Choose amount of people");
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("(2)Choise of altitude");
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("(3)Choise of speed");
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("(4)Load ammo");
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("(5)Make a take off Army plane");
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("(6)Make a landing Army plane");
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("(7)Quit");
                    Console.WriteLine("+---------------------------+");

                    if (!int.TryParse(Console.ReadLine(), out ch)) { }
                    switch (ch)
                    {
                        case 1:
                            armyplane.changeloadpeople();
                            break;
                        case 2:
                            try
                            {
                                armyplane.changeflightaltitude();
                            }
                            catch (EmergencyException ef)
                            {
                                Console.WriteLine(ef);
                            }
                            finally
                            {
                                Console.WriteLine("Ef: You couln't change altitude by words");
                            }
                            break;
                        case 3:
                            try
                            {
                                armyplane.changespeed();
                            }
                            catch(EmergencyException er) 
                            {
                                Console.WriteLine(er);
                            }
                            finally
                            {
                                Console.WriteLine("Er: You couln't change speed by words");
                            }
                            break;
                        case 4:
                            try
                            {
                                armyplane.changeamountammo();
                            }
                            catch( EmergencyException Ex)
                            {
                                Console.WriteLine(Ex);
                            }
                            finally
                            {
                                Console.WriteLine("Ex: Massage could be only float ");
                            }
                            break;
                        case 5:
                            d.TakeOffEvent += new AircraftsHandler(armyplane.MakeATakeOff);
                            d.TakeOffCommand();
                            break;
                        case 6:
                            d.LandingEvent += new AircraftsHandler(armyplane.MakeALanding);
                            d.LandingCommand();
                            break;
                        case 7:
                            armyplane.quit();
                            try
                            {
                                int n = 0;
                                int i = 5 / n;
                            }
                            catch (Exception ex)
                            { Console.WriteLine(ex); }
                            finally
                            {
                                Console.WriteLine("All-Catch Exception design is implemented.");
                            }
                    break;
                        default:
                            Console.WriteLine("Type correct number");
                            break;
                    }
                }
                while (ch != 7);
            }
            public class Dispatcher
            {
                public delegate void AircraftsHandler();
                
                public event AircraftsHandler TakeOffEvent;
                public void TakeOffCommand()
                {
                    if (TakeOffEvent != null)
                        TakeOffEvent();
                }
                
                public event AircraftsHandler LandingEvent;
                public void LandingCommand()
                {
                    if (LandingEvent != null)
                        LandingEvent();
                }
            }
        }
    }
}
