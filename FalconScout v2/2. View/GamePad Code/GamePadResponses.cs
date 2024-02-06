using System;
using System.Collections.Generic;
using SlimDX.DirectInput;
using System.Diagnostics;
using SharpDX.XInput;
using System.Diagnostics.Eventing.Reader;
using System.Web.Configuration;
using System.Security.Policy;
using System.Threading;
using SlimDX.DirectSound;
using System.Resources;

namespace T250DynoScout_v2023
{
    class Controllers
    {
        public void setScore()
        {
            RobotState.Red_Score = 0;

            RobotState.Blue_Score = 0;
        }

        public static RobotState[] rs;   //Objects for storing Match State

        // #Rumble
        //Controller rumble0 = new Controller((UserIndex)0);
        //Controller rumble1 = new Controller((UserIndex)1);
        //Controller rumble2 = new Controller((UserIndex)2);
        //Controller rumble3 = new Controller((UserIndex)3);
        //Controller rumble4 = new Controller((UserIndex)4);
        //Controller rumble5 = new Controller((UserIndex)5);

        Vibration vibration = new Vibration { LeftMotorSpeed = 65535, RightMotorSpeed = 65535 };
        Vibration vibration2 = new Vibration { LeftMotorSpeed = 0, RightMotorSpeed = 0 };

        Activity activity_record = new Activity();              //This is the activity for one Acquire and Scoring cycle.  We also save when an Event Activity is selected.       
        SeasonContext seasonframework = new SeasonContext();    //This is the context, meaning the entire database structure supporting this application.

        Utilities utilities = new Utilities();
        public Stopwatch stopwatch = new Stopwatch();
        public static Dictionary<int, int> controllerNumberMap = new Dictionary<int, int>
        {
            {0, 0},
            {1, 1},
            {2, 2},
            {3, 3},
            {4, 4},
            {5, 5},
        };
        public static Dictionary<int, RobotState.SCOUTER_NAME> ScouterNameMap = new Dictionary<int, RobotState.SCOUTER_NAME>
        {
            {0, RobotState.SCOUTER_NAME.Select_Name},
            {1, RobotState.SCOUTER_NAME.Select_Name},
            {2, RobotState.SCOUTER_NAME.Select_Name},
            {3, RobotState.SCOUTER_NAME.Select_Name},
            {4, RobotState.SCOUTER_NAME.Select_Name},
            {5, RobotState.SCOUTER_NAME.Select_Name},
        };

        public TimeSpan Zero { get; private set; }

        //getScoreZone to getScoreZone all the joysticks connected to the computer
        public Joystick[] GetSticks(DirectInput Input, SlimDX.DirectInput.Joystick stick, Joystick[] Sticks, Joystick stick1)
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>(); //Creates the list of joysticks connected to the computer via USB.
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                //Creates a joystick for each game device in USB Ports
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    //Gets the joysticks properties and sets the range for them.
                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                    }

                    //Adds how ever many joysticks are connected to the computer into the sticks list.
                    sticks.Add(stick);
                }
                catch (DirectInputException) { }
            }
            return sticks.ToArray();
        }

        public RobotState getRobotState(int state)
        {
            state = Math.Max(0, state);
            state = Math.Min(5, state);
            return rs[state]; //If you crash here, you do not have a controller connected
        }

        public GamePad[] getGamePads()
        {
            //Connect to DirectInput and setup Joystick Objects
            DirectInput Input = new DirectInput();
            Joystick stick;
            GamePad gamepad;

            //Creates the list of joysticks connected to the computer via USB.
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            List<GamePad> gamepads = new List<GamePad>();
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                //Creates a joystick object for each game device in USB Ports
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    //Gets the joysticks properties and sets the range for them.
                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                    }

                    gamepad = new GamePad(stick);

                    //Adds how ever many joysticks are connected to the computer into the sticks list.
                    sticks.Add(stick);
                    gamepads.Add(gamepad);
                    Console.WriteLine(stick.Information.InstanceName);
                }
                catch (DirectInputException) { }

                //Initiate Match State objects
                rs = new RobotState[6];
                rs[0] = new RobotState();
                rs[1] = new RobotState();
                rs[2] = new RobotState();
                rs[3] = new RobotState();
                rs[4] = new RobotState();
                rs[5] = new RobotState();
                rs[0].color = "Red";
                rs[1].color = "Red";
                rs[2].color = "Red";
                rs[3].color = "Blue";
                rs[4].color = "Blue";
                rs[5].color = "Blue";
            }
            return gamepads.ToArray();  //return sticks.ToArray();
        }
        public void readStick(GamePad[] gpArray, int controllerNumber)
        {
            GamePad gamepad = gpArray[controllerNumber];
            gamepad.Update();

            if (gamepad.RTHRight_Press && !rs[controllerNumberMap[controllerNumber]].NoSho && !gamepad.XButton_Down)
            {
                rs[controllerNumberMap[controllerNumber]].cycleEventName(RobotState.CYCLE_DIRECTION.Up);
            }
            if (gamepad.RTHLeft_Press && !rs[controllerNumberMap[controllerNumber]].NoSho && !gamepad.XButton_Down)
            {
                rs[controllerNumberMap[controllerNumber]].cycleEventName(RobotState.CYCLE_DIRECTION.Down);
            }

            if (gamepad.R3_Press && !gamepad.XButton_Down)
            {
                if (rs[controllerNumberMap[controllerNumber]].match_event != RobotState.MATCHEVENT_NAME.Match_Event &&
                    !rs[controllerNumberMap[controllerNumber]].NoSho &&
                    (rs[controllerNumberMap[controllerNumber]]._ScouterName != RobotState.SCOUTER_NAME.Select_Name || rs[controllerNumberMap[controllerNumber]]._ScouterNameALT != RobotState.SCOUTER_NAME_ALT.Select_AltName))
                {

                    if (rs[controllerNumberMap[controllerNumber]].match_event == RobotState.MATCHEVENT_NAME.No_Show)
                    {
                        activity_record.match_event = (rs[controllerNumberMap[controllerNumber]].match_event.ToString())[0].ToString();
                        rs[controllerNumberMap[controllerNumber]].NoSho = true;
                    }
                    else
                    {
                        activity_record.match_event = (rs[controllerNumberMap[controllerNumber]].match_event.ToString())[0].ToString(); //If you crash here you didn't load matches
                    }
                    activity_record.Team = rs[controllerNumberMap[controllerNumber]].TeamName;
                    activity_record.Match = rs[controllerNumberMap[controllerNumber]].Current_Match;
                    activity_record.Time = DateTime.Now;
                    activity_record.Mode = rs[controllerNumberMap[controllerNumber]].Current_Mode.ToString();
                    activity_record.ScouterName = rs[controllerNumberMap[controllerNumber]].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
                    //activity_record.ScouterNameAlt = rs[controllerNumberMap[controllerNumber]].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
                    activity_record.RecordType = "Match_Event";
                    activity_record.Mobility = 0;
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOther = 0;
                    activity_record.AcqFOpps = 0;
                    activity_record.DelTop = 0;
                    activity_record.DelMid = 0;
                    activity_record.DelBot = 0;
                    activity_record.DelFloor = 0;
                    activity_record.DelOut = 0;
                    activity_record.DelCoop = 0;
                    activity_record.DelDrop = 0;
                    activity_record.Cone = 0;
                    activity_record.Cube = 0;
                    activity_record.Parked = 0;
                    activity_record.Docked = 0;
                    activity_record.Engaged = 0;
                    activity_record.Tried_And_Failed = 0;
                    activity_record.No_Attempt = 0;
                    activity_record.ChargePart = 0;
                    activity_record.EngageT = 0;
                    activity_record.EngageFail = "-";
                    activity_record.Setup = 0;
                    activity_record.AutoPts = 0;
                    activity_record.GridPts = 0;
                    activity_record.ChargePts = 0;
                    activity_record.ScouterError = 0;
                    activity_record.Defense = 0;
                    activity_record.Avoidance = 0;
                    activity_record.Strategy = "-";

                    //Save Record to the database
                    //seasonframework.ActivitySet.Add(activity_record);
                    //seasonframework.SaveChanges(); // If you crash here migration isn't working

                    rs[controllerNumberMap[controllerNumber]].match_event = RobotState.MATCHEVENT_NAME.Match_Event;

                    //Reset Match Event
                    rs[controllerNumberMap[controllerNumber]].match_event = 0;
                }
                else if (rs[controllerNumberMap[controllerNumber]].match_event == RobotState.MATCHEVENT_NAME.Match_Event)
                {
                    rs[controllerNumberMap[controllerNumber]].ScouterError++;
                }
            }

            // #Auto
            // **************************************************************
            // *** Auto MODE ***
            // **************************************************************
            if (rs[controllerNumberMap[controllerNumber]].Current_Mode == RobotState.ROBOT_MODE.Auto && !rs[controllerNumberMap[controllerNumber]].NoSho)
            {
                //2024 Scouter Names
                if (gamepad.XButton_Down)
                {
                    if (gamepad.RTHRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeScouterName(RobotState.CYCLE_DIRECTION.Up);
                        rs[controllerNumberMap[controllerNumber]]._ScouterNameALT = RobotState.SCOUTER_NAME_ALT.Select_AltName;
                    }
                    if (gamepad.RTHLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeScouterName(RobotState.CYCLE_DIRECTION.Down);
                        rs[controllerNumberMap[controllerNumber]]._ScouterNameALT = RobotState.SCOUTER_NAME_ALT.Select_AltName;
                    }
                    if (gamepad.RTHUp_Press && rs[controllerNumberMap[controllerNumber]].Alt_Flag == false)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeScouterNameALT(RobotState.CYCLE_DIRECTION.Up);
                        rs[controllerNumberMap[controllerNumber]].Alt_Flag = true;
                        rs[controllerNumberMap[controllerNumber]]._ScouterName = RobotState.SCOUTER_NAME.Select_Name;
                    }
                    if (!gamepad.RTHUp_Press && rs[controllerNumberMap[controllerNumber]].Alt_Flag == true)
                    {
                        rs[controllerNumberMap[controllerNumber]].Alt_Flag = false;
                    }
                    if (gamepad.RTHDown_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeScouterNameALT(RobotState.CYCLE_DIRECTION.Down);
                        rs[controllerNumberMap[controllerNumber]]._ScouterName = RobotState.SCOUTER_NAME.Select_Name;
                    }
                }

                //2024 Setup Controls
                if (gamepad.XButton_Down)
                {
                    if (gamepad.LTHRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeRobot_Set(RobotState.CYCLE_DIRECTION.Up);
                    }
                    if (gamepad.LTHLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeRobot_Set(RobotState.CYCLE_DIRECTION.Down);
                    }
                }

                //2024 Leave
                if (gamepad.StartButton_Press && rs[controllerNumberMap[controllerNumber]].Leave == 0)
                {
                    rs[controllerNumberMap[controllerNumber]].Leave = 1;
                }
                else if (gamepad.StartButton_Press && rs[controllerNumberMap[controllerNumber]].Leave == 1)
                {
                    rs[controllerNumberMap[controllerNumber]].Leave = 0;
                }

                //2024 HP in Amp
                if (gamepad.XButton_Down)
                {
                    if (gamepad.L3_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeHP_Amp(RobotState.CYCLE_DIRECTION.Up);
                    }
                }

                //2024 Current Location and Red Right logic
                if (gamepad.XButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Left;
                }
                if (gamepad.BButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Right;

                }
                if (gamepad.AButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Neut;
                }
                if (gamepad.YButton_Down && !gamepad.LeftTrigger_Down)
                {
                    if (RobotState.Red_Right == true)
                    {
                        if (rs[controllerNumberMap[controllerNumber]].color == "Red")
                        {
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.SubW;
                            }
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Source;
                            }
                        }
                        else
                        {
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Source;
                            }
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.SubW;
                            }
                        }
                    }
                    else
                    {
                        if (rs[controllerNumberMap[controllerNumber]].color == "Blue")
                        {
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.SubW;
                            }
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Source;
                            }
                        }
                        else
                        {
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Source;
                            }
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.SubW;
                            }
                        }
                    }
                }

                //2024 acquire locations
                if (gamepad.LeftTrigger_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].Acq_Center = 0;
                }
                if (gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Select;
                    if (gamepad.DpadUp_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 1;
                    }
                    else if (gamepad.DpadDown_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 5;
                    }
                    else if (gamepad.DpadRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 4;
                    }
                    else if (gamepad.DpadLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 2;
                    }
                    else if (gamepad.L3_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 3;
                    }
                    else
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Loc = rs[controllerNumberMap[controllerNumber]].Current_Loc.ToString();
                    }
                }

                // 2024 deliver destination
                if (gamepad.RightButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Acq_Loc = "Select";
                }
                if (gamepad.RightButton_Down && gamepad.DpadUp_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Speaker;
                }
                if (gamepad.RightButton_Down && gamepad.DpadLeft_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Amp;
                }
                if (gamepad.RightButton_Down && gamepad.DpadRight_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.FloorWing;
                }
                if (gamepad.RightButton_Down && gamepad.DpadDown_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.FloorNeut;
                }
                if (gamepad.RightButton_Down && gamepad.L3_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Trap;
                }

                // 2024 Flag
                if (gamepad.LeftButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Flag = 1;
                }
                else
                {
                    rs[controllerNumberMap[controllerNumber]].Flag = 0;
                }
            }

            // #Teleop
            // **************************************************************
            // *** Teleop MODE ***
            // **************************************************************
            if (rs[controllerNumberMap[controllerNumber]].Current_Mode == RobotState.ROBOT_MODE.Teleop && !rs[controllerNumberMap[controllerNumber]].NoSho)
            {
                //2024 current loc 
                if (gamepad.XButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Left;
                }
                if (gamepad.BButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Right;

                }
                if (gamepad.AButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Neut;
                }
                if (gamepad.YButton_Down)
                {
                    if (RobotState.Red_Right == true)
                    {
                        if (rs[controllerNumberMap[controllerNumber]].color == "Red")
                        {
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.SubW;
                            }
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Source;
                            }
                        }
                        else
                        {
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Source;
                            }
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.SubW;
                            }
                        }
                    }
                    else
                    {
                        if (rs[controllerNumberMap[controllerNumber]].color == "Blue")
                        {
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.SubW;
                            }
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Source;
                            }
                        }
                        else
                        {
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.Source;
                            }
                            if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                            {
                                rs[controllerNumberMap[controllerNumber]].Current_Loc = RobotState.CURRENT_LOC.SubW;
                            }
                        }
                    }
                }
                //2024 del 
                if (gamepad.RightButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Acq_Loc = "Select";
                }
                if (gamepad.RightButton_Down && gamepad.DpadUp_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Speaker;
                }
                if (gamepad.RightButton_Down && gamepad.DpadLeft_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Amp;
                }
                if (gamepad.RightButton_Down && gamepad.DpadRight_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.FloorWing;
                }
                if (gamepad.RightButton_Down && gamepad.DpadDown_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.FloorNeut;
                }
                if (gamepad.RightButton_Down && gamepad.L3_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Trap;
                }

                //2024 acq loc 
                if (gamepad.LeftTrigger_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].Acq_Center = 0;
                }
                if (gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Select;
                    if (gamepad.DpadUp_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 1;
                    }
                    else if (gamepad.DpadDown_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 5;
                    }
                    else if (gamepad.DpadRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 4;
                    }
                    else if (gamepad.DpadLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 2;
                    }
                    else if (gamepad.L3_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Center = 3;
                    }
                    else
                    {
                        rs[controllerNumberMap[controllerNumber]].Acq_Loc = rs[controllerNumberMap[controllerNumber]].Current_Loc.ToString();
                    }
                }

                // 2024 flag 
                if (gamepad.LeftButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Flag = 1;
                }
                else
                {
                    rs[controllerNumberMap[controllerNumber]].Flag = 0;
                }

                //2024 comp
                if (gamepad.RightTrigger_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Select;
                    rs[controllerNumberMap[controllerNumber]].Acq_Loc = "Select";
                    rs[controllerNumberMap[controllerNumber]].Flag = 0;
                }
                if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Neut)
                {
                    rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Start();
                    rs[controllerNumberMap[controllerNumber]].NeutT = rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Elapsed;
                    rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = true;

                    rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Stop();
                    rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = false;

                    rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Stop();
                    rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = false;
                }
                if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Source ||
                    rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.SubW)
                {
                    rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                    rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;

                    rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Stop();
                    rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = false;

                    rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Stop();
                    rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = false;
                }

                //2024 zone time 
                if (RobotState.Red_Right == true)
                {
                    if (rs[controllerNumberMap[controllerNumber]].color == "Red")
                    {
                        if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                        {
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Start();
                            rs[controllerNumberMap[controllerNumber]].AllyT = rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Elapsed;
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = true;

                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;

                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = false;
                        }
                        if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                        {
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Start();
                            rs[controllerNumberMap[controllerNumber]].OpptT = rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Elapsed;
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = true;

                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = false;

                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;
                        }
                    }
                    else
                    {
                        if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                        {
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Start();
                            rs[controllerNumberMap[controllerNumber]].OpptT = rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Elapsed;
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = true;

                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = false;

                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;
                        }
                        if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                        {
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Start();
                            rs[controllerNumberMap[controllerNumber]].AllyT = rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Elapsed;
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = true;

                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;

                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = false;
                        }
                    }

                }
                else
                {
                    if (rs[controllerNumberMap[controllerNumber]].color == "Blue")
                    {
                        if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                        {
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Start();
                            rs[controllerNumberMap[controllerNumber]].AllyT = rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Elapsed;
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = true;

                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;

                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = false;
                        }
                        if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                        {
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Start();
                            rs[controllerNumberMap[controllerNumber]].OpptT = rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Elapsed;
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = true;

                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = false;

                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;
                        }
                    }
                    else
                    {
                        if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Right)
                        {
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Start();
                            rs[controllerNumberMap[controllerNumber]].OpptT = rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Elapsed;
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = true;

                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = false;

                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;
                        }
                        if (rs[controllerNumberMap[controllerNumber]].Current_Loc == RobotState.CURRENT_LOC.Left)
                        {
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Start();
                            rs[controllerNumberMap[controllerNumber]].AllyT = rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch.Elapsed;
                            rs[controllerNumberMap[controllerNumber]].AllyT_StopWatch_running = true;

                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].NeutT_StopWatch_running = false;

                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch.Stop();
                            rs[controllerNumberMap[controllerNumber]].OpptT_StopWatch_running = false;
                        }
                    }
                }
                if (gamepad.StartButton_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch.Stop();
                    rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch_running = false;
                    if (gamepad.LeftTrigger_Down && gamepad.StartButton_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch.Reset();
                        rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch_running = true;
                    }
                }
            }

            // #Showtime 
            // **************************************************************
            // *** SHOWTIME MODE ***
            // **************************************************************
            //2024 climb time
            if (rs[controllerNumberMap[controllerNumber]].Current_Mode == RobotState.ROBOT_MODE.Showtime && !rs[controllerNumberMap[controllerNumber]].NoSho)
            {
                if (gamepad.StartButton_Press)
                {
                    if (rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch_running)
                    {
                        rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch.Stop();
                        rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch_running = false;
                    }
                    else if (!rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch_running)
                    {
                        rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch.Start();
                        rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch_running = true;
                    }
                }
                if (gamepad.LeftTrigger_Down && gamepad.StartButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch.Reset();
                    rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch_running = false;
                }

                // 2024 del
                if (gamepad.L3_Press && gamepad.RightButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Trap;
                }

                //2024 flag 
                if (gamepad.LeftButton_Down)
                {
                    rs[controllerNumberMap[controllerNumber]].Flag = 1;
                }
                else
                {
                    rs[controllerNumberMap[controllerNumber]].Flag = 0;
                }
                if (gamepad.RightTrigger_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Select;
                    rs[controllerNumberMap[controllerNumber]].Flag = 0;
                }

                //2024 stat
                if (gamepad.XButton_Down)
                {
                    if (gamepad.LTHRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeStage_Stat(RobotState.CYCLE_DIRECTION.Up);
                    }
                    else if (gamepad.LTHLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeStage_Stat(RobotState.CYCLE_DIRECTION.Down);
                    }
                }

                //2024 stage Att
                if (gamepad.YButton_Down && rs[controllerNumberMap[controllerNumber]].Stage_Stat == RobotState.STAGE_STAT.Onstage)
                {
                    if (gamepad.LTHRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Stage_Att = RobotState.STAGE_ATT.Select;
                        rs[controllerNumberMap[controllerNumber]].changeStage_Loc(RobotState.CYCLE_DIRECTION.Up);
                    }
                    else if (gamepad.LTHLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Stage_Att = RobotState.STAGE_ATT.Select;
                        rs[controllerNumberMap[controllerNumber]].changeStage_Loc(RobotState.CYCLE_DIRECTION.Down);
                    }
                }

                //2024 stage loc
                if (gamepad.YButton_Down && (rs[controllerNumberMap[controllerNumber]].Stage_Stat == RobotState.STAGE_STAT.Elsewhere || rs[controllerNumberMap[controllerNumber]].Stage_Stat == RobotState.STAGE_STAT.Park))
                {
                    if (gamepad.LTHRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeStage_Att(RobotState.CYCLE_DIRECTION.Up);
                        rs[controllerNumberMap[controllerNumber]].Stage_Loc = RobotState.STAGE_LOC.Select;
                    }
                    else if (gamepad.LTHLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeStage_Att(RobotState.CYCLE_DIRECTION.Down);
                        rs[controllerNumberMap[controllerNumber]].Stage_Loc = RobotState.STAGE_LOC.Select;

                    }
                }

                // 2024 strat
                if (gamepad.BButton_Down)
                {
                    if (gamepad.LTHRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeApp_Strat(RobotState.CYCLE_DIRECTION.Up);
                    }
                    else if (gamepad.LTHLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].changeApp_Strat(RobotState.CYCLE_DIRECTION.Down);
                    }
                }

                //2024 harm 
                if (gamepad.AButton_Down)
                {
                    if (gamepad.LTHLeft_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Harm++;
                    }
                    if (gamepad.LTHRight_Press)
                    {
                        rs[controllerNumberMap[controllerNumber]].Harm--;
                    }
                }

                //2024 Mic
                if (gamepad.DpadUp_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].Mic++;
                    if (rs[controllerNumberMap[controllerNumber]].Mic == 4)
                    {
                        rs[controllerNumberMap[controllerNumber]].Mic = 0;
                    }
                }

                //2024 Spotlit 
                if (gamepad.DpadDown_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].changeLit(RobotState.CYCLE_DIRECTION.Up);
                }

                // 2024 Def / avo
                if (gamepad.DpadRight_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].Def_Rat++;
                    if (rs[controllerNumberMap[controllerNumber]].Def_Rat == 4)
                    {
                        rs[controllerNumberMap[controllerNumber]].Def_Rat = 0;
                    }
                }
                if (gamepad.DpadLeft_Press)
                {
                    rs[controllerNumberMap[controllerNumber]].Avo_Rat++;
                    if (rs[controllerNumberMap[controllerNumber]].Avo_Rat == 4)
                    {
                        rs[controllerNumberMap[controllerNumber]].Avo_Rat = 0;
                    }
                }
            }


            // #Transact
            // **************************************************************
            // ***  TRANSACT TO DATABASE  ***
            // **************************************************************
            if (rs[controllerNumberMap[controllerNumber]]._ScouterName != RobotState.SCOUTER_NAME.Select_Name || rs[controllerNumberMap[controllerNumber]]._ScouterNameALT != RobotState.SCOUTER_NAME_ALT.Select_AltName)
            {
                rs[controllerNumberMap[controllerNumber]].TransactionCheck = true;
            }
            else
            {
                rs[controllerNumberMap[controllerNumber]].TransactionCheck = false;
            }

            //2023 EndAuto End of Autonomous transaction
            if (rs[controllerNumberMap[controllerNumber]].AUTO && gamepad.BackButton_Press && !rs[controllerNumberMap[controllerNumber]].NoSho &&
                (rs[controllerNumberMap[controllerNumber]]._ScouterName != RobotState.SCOUTER_NAME.Select_Name
                || rs[controllerNumberMap[controllerNumber]]._ScouterName != RobotState.SCOUTER_NAME.Select_Name))
            {
                activity_record.Team = rs[controllerNumberMap[controllerNumber]].TeamName;
                activity_record.Match = rs[controllerNumberMap[controllerNumber]].Current_Match;
                activity_record.Time = DateTime.Now;
                activity_record.Mode = rs[controllerNumberMap[controllerNumber]].Current_Mode.ToString();
                activity_record.ScouterName = rs[controllerNumberMap[controllerNumber]].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
                //activity_record.ScouterNameAlt = rs[controllerNumberMap[controllerNumber]].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
                activity_record.RecordType = "EndAuto";

                activity_record.match_event = "-";

                activity_record.Defense = 0;
                activity_record.Avoidance = 0;

                activity_record.ScouterError = rs[controllerNumberMap[controllerNumber]].ScouterError;

                activity_record.AcqSub1 = 0;
                activity_record.AcqSub2 = 0;
                activity_record.AcqFComm = 0;
                activity_record.AcqFLoad = 0;
                activity_record.AcqFOther = 0;
                activity_record.AcqFOpps = 0;
                activity_record.DelTop = 0;
                activity_record.DelMid = 0;
                activity_record.DelBot = 0;
                activity_record.DelOut = 0;
                activity_record.DelCoop = 0;
                activity_record.DelDrop = 0;
                activity_record.Cone = 0;
                activity_record.Cube = 0;
                activity_record.Parked = 0;
                activity_record.ChargePart = 0;
                activity_record.EngageT = 0;
                activity_record.EngageFail = "-";
                activity_record.GridPts = 0;
                activity_record.ChargePts = 0;
                activity_record.Strategy = "-";

                rs[controllerNumberMap[controllerNumber]].AUTO = false;

                //Save Record to the database
                //seasonframework.ActivitySet.Add(activity_record);
                //seasonframework.SaveChanges();

                //Reset Values
                rs[controllerNumberMap[controllerNumber]].Mob = RobotState.MOB.N;
                rs[controllerNumberMap[controllerNumber]].ChargeStatus = RobotState.CHARGESTATUS.Select;
            }
            else if (gamepad.RightTrigger_Press && !rs[controllerNumberMap[controllerNumber]].NoSho && rs[controllerNumberMap[controllerNumber]].TransactionCheck == true)
            {
                activity_record.Team = rs[controllerNumberMap[controllerNumber]].TeamName;
                activity_record.Match = rs[controllerNumberMap[controllerNumber]].Current_Match;
                activity_record.Time = DateTime.Now;
                activity_record.Mode = rs[controllerNumberMap[controllerNumber]].Current_Mode.ToString();
                activity_record.ScouterName = rs[controllerNumberMap[controllerNumber]].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
                //activity_record.ScouterNameAlt = rs[controllerNumberMap[controllerNumber]].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
                activity_record.RecordType = "Activities";

                activity_record.match_event = "-";

                activity_record.Mobility = 0;
                activity_record.Parked = 0;
                activity_record.Docked = 0;
                activity_record.Engaged = 0;
                activity_record.Tried_And_Failed = 0;
                activity_record.No_Attempt = 0;
                activity_record.ChargePart = 0;
                activity_record.EngageT = 0;
                activity_record.EngageFail = "-";
                activity_record.Setup = 0;
                activity_record.AutoPts = 0;
                activity_record.ChargePts = 0;
                activity_record.Strategy = "-";

                activity_record.Defense = 0;
                activity_record.Avoidance = 0;

                activity_record.ScouterError = 0;

                //Save Record to the database
                //seasonframework.ActivitySet.Add(activity_record);
                //seasonframework.SaveChanges();

                //Reset Values
                rs[controllerNumberMap[controllerNumber]].Del_Dest = RobotState.DEL_DEST.Select;
                rs[controllerNumberMap[controllerNumber]].Acq_Loc = "Select";
                rs[controllerNumberMap[controllerNumber]].Acq_Center = 0;
                rs[controllerNumberMap[controllerNumber]].Flag = 0;
                rs[controllerNumberMap[controllerNumber]].TransactionCheck = false;
            }
            else if (gamepad.RightTrigger_Press && !rs[controllerNumberMap[controllerNumber]].NoSho && rs[controllerNumberMap[controllerNumber]].TransactionCheck == false)
            {
                rs[controllerNumberMap[controllerNumber]].ScouterError = rs[controllerNumberMap[controllerNumber]].ScouterError + 100;
            }

            // 2023 Changing modes
            if (gamepad.BackButton_Press && rs[controllerNumberMap[controllerNumber]].Current_Mode == RobotState.ROBOT_MODE.Auto && !rs[controllerNumberMap[controllerNumber]].AUTO && !rs[controllerNumberMap[controllerNumber]].NoSho)
            {
                rs[controllerNumberMap[controllerNumber]].Desired_Mode = RobotState.ROBOT_MODE.Showtime;
                rs[controllerNumberMap[controllerNumber]].Current_Mode = RobotState.ROBOT_MODE.Teleop;
            }
            else if (gamepad.BackButton_Press && rs[controllerNumberMap[controllerNumber]].Current_Mode == RobotState.ROBOT_MODE.Teleop && !rs[controllerNumberMap[controllerNumber]].NoSho)

            {
                rs[controllerNumberMap[controllerNumber]].Desired_Mode = RobotState.ROBOT_MODE.Teleop;
                rs[controllerNumberMap[controllerNumber]].Current_Mode = RobotState.ROBOT_MODE.Showtime;
                rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch.Start();
                rs[controllerNumberMap[controllerNumber]].ClimbT = rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch.Elapsed;
                rs[controllerNumberMap[controllerNumber]].ClimbT_StopWatch_running = true;
            }
            else if (gamepad.BackButton_Press && rs[controllerNumberMap[controllerNumber]].Current_Mode == RobotState.ROBOT_MODE.Showtime && !rs[controllerNumberMap[controllerNumber]].NoSho)
            {
                rs[controllerNumberMap[controllerNumber]].Desired_Mode = RobotState.ROBOT_MODE.Showtime;
                rs[controllerNumberMap[controllerNumber]].Current_Mode = RobotState.ROBOT_MODE.Teleop;
            }
        }
    }
}