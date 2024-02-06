using System;
using System.Diagnostics;
using static T250DynoScout_v2023.RobotState;

namespace T250DynoScout_v2023
{

    public class RobotState
    {
        // These are our own defined types...
        public enum ROBOT_LOCATION { Tarmac, Field, LaunchPad, Terminal };
        public enum TEAM_ENUM { };
        public enum ROBOT_MODE { Auto, Teleop, Showtime };
        public enum CYCLE_DIRECTION { Up, Down }
        public enum DELROW { Select, Bot, Mid, Top }
        public enum DELGRID { Select, Outer, Coop }
        public enum DELFLOOR { Select, Success, Drop }
        public enum PIECE { Select, Cone, Cube }
        public enum ACQ { Select, Chute, Shelf, Opp, Other, Floor_Comm, Floor_Load, Floor_Neut }
        public enum CHARGESTATUS { Select, No_Attempt, Tried_And_Failed, Docked, Engaged, Parked }
        public enum MOB { N, Y }
        public enum ENGAGEFAIL { Select, No_Fail, Alliance, Drove_Off, Hold_Fail, Timed_Out, Lowrider }
        public enum STRATEGY { Select, None, Runner, Placer, Independent, Defense, Mixed }
        public enum SETLOC { Q_, Q1, Q2, Q3, Q4 }
        public enum CSTEAMS { T0, T1, T2, T_ }
        public enum DEFRATE { D0, D1, D2, D3, D_ }
        public enum AVORATE { A0, A1, A2, A3, A_ }
        public enum FLOORLBL { Select, Floor }
        public enum NODELBL { Select, Node }
        public enum MATCHEVENT_NAME { Match_Event, Fumbled, Broke_Down, Got_Stuck, Jammed_Piece, Lost_Parts, No_Show, Partner_Engage, Tipped_Over }
        public enum SCOUTER_NAME_ALT { Select_AltName, Sub1, Sub2, Sub3, }
        public enum SCOUTER_NAME { Select_Name, Scouter1, Scouter2, Scouter3, Scouter4, Scouter5, Scouter6, Scouter7, Scouter8, Scouter9, Scouter10, Scouter11, Scouter12 }

        // 2024 enums
        public enum DEL_DEST { Select, Speaker, Amp, Trap, FloorWing, FloorNeut }
        public enum ROBOT_SET { Select, Amp, Sub, Pod, Opp }
        public enum HP_AMP { Select, Y, N }
        public enum STAGE_STAT { Select, Onstage, Park, Elsewhere }
        public enum STAGE_ATT { Select, Y, N }
        public enum STAGE_LOC { Select, L, C, R }
        public enum LIT { Select, Y, N, }
        public enum APP_STRAT { Select, None, Defense, Mover, Shooter, Hybrid, Celeberity }
        public enum CURRENT_LOC { Select, Left, Right, Neut, SubW, Source }







        public int ctr_number;

        public int APoints;
        public int GPoints;
        public int CPoints;
        public int TotDelOut;
        public int TotDelCoop;
        public int TotDelConeTop;
        public int TotDelConeMid;
        public int TotDelConeHyb;
        public int TotDelCubeTop;
        public int TotDelCubeMid;
        public int TotDelCubeHyb;
        public int TotAutoCone;
        public int TotAutoCube;
        public int ScouterError;

        //2024 PUBLIC INT
        public int Leave;
        public int Acq_Center;
        public int Flag;
        public int Harm;
        public int Def_Rat;
        public int Avo_Rat;
        public int Mic;
        public int Coop;
        public string Acq_Loc = CURRENT_LOC.Select.ToString();

        public static bool Red_Right;
        public bool Alt_Flag;

        // 2024 timers
        public TimeSpan OpptT = TimeSpan.Zero;
        public Stopwatch OpptT_StopWatch;
        public bool OpptT_StopWatch_running;
        public double OpptTDouble;

        public TimeSpan ClimbT = TimeSpan.Zero;
        public Stopwatch ClimbT_StopWatch;
        public bool ClimbT_StopWatch_running;
        public double ClimbTDouble;


        public TimeSpan NeutT = TimeSpan.Zero;
        public Stopwatch NeutT_StopWatch;
        public bool NeutT_StopWatch_running;
        public double NeutTDouble;

        public TimeSpan AllyT = TimeSpan.Zero;
        public Stopwatch AllyT_StopWatch;
        public bool AllyT_StopWatch_running;
        public double AllyTDouble;

        public string[] enneadecimal = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "J" };

        public bool TransactionCheck = false;

        public TimeSpan EngageTime = TimeSpan.Zero;
        public Stopwatch EngageTime_StopWatch;
        public bool EngageTime_StopWatch_running;
        public double EngageTimeDouble;

        public bool AUTO = true;
        public bool Alt;

        // These are the standard types...
        public string YEAR = "2023";

        public ROBOT_MODE Desired_Mode;         //Desired Mode
        public int Current_Match;               //Current Match

        public string color;

        public static double Red_Score;
        public static double Blue_Score;

        public bool NoSho = false;

        public int DrStation;

        //LOCAL VARIABLES SECTION.  All underscored variables indicate local variables for one controller/scouter

        public SCOUTER_NAME _ScouterName;          //ScouterName
        public SCOUTER_NAME_ALT _ScouterNameALT;
        private string _TeamName;                   //TeamName
        private MATCHEVENT_NAME _match_event;       //Match Event
        private ROBOT_MODE _RobotMode;              //Control
        private ACQ _Acq;
        private DELGRID _DelGrid;
        private DELROW _DelRow;
        private PIECE _Piece;
        private DELFLOOR _DelFloor;
        private MOB _Mob;
        private CHARGESTATUS _ChargeStatus;
        private CHARGESTATUS _ChargeStatusAuto;
        private SETLOC _SetLoc;
        private STRATEGY _Strategy;
        private CSTEAMS _CSTeams = CSTEAMS.T_;
        private ENGAGEFAIL _EngageFail;
        private DEFRATE _DefRate = DEFRATE.D_;
        private AVORATE _AvoRate = AVORATE.A_;
        private FLOORLBL _Floorlbl;
        private NODELBL _Nodelbl;
        private DELGRID _DDelGrid;
        private PIECE _DPiece;
        private FLOORLBL _DFloorlbl;
        private NODELBL _DNodelbl;

        // 2024 local variables
        //private ACQ_LOC _Acq_Loc;
        //private DEL_ORIG _Del_Orig;
        private DEL_DEST _Del_Dest;
        private ROBOT_SET _Robot_Set;
        private HP_AMP _HP_Amp;
        private STAGE_STAT _Stage_Stat;
        private STAGE_ATT _Stage_Att;
        private STAGE_LOC _Stage_Loc;
        private LIT _Lit;
        private APP_STRAT _App_Strat;
        private CURRENT_LOC _Current_Loc;
        private string _Drive_Sta;


        //2023 Get Set

        public static int[,] teamScores = new int[6, 3];
        public ACQ Acq
        {
            get { return _Acq; }
            set { _Acq = value; }
        }
        public DELGRID DelGrid
        {
            get { return _DelGrid; }
            set { _DelGrid = value; }
        }
        public DELROW DelRow
        {
            get { return _DelRow; }
            set { _DelRow = value; }
        }
        public PIECE Piece
        {
            get { return _Piece; }
            set { _Piece = value; }
        }
        public DELFLOOR DelFloor
        {
            get { return _DelFloor; }
            set { _DelFloor = value; }
        }
        public MOB Mob
        {
            get { return _Mob; }
            set { _Mob = value; }
        }
        public CHARGESTATUS ChargeStatus
        {
            get { return _ChargeStatus; }
            set { _ChargeStatus = value; }
        }
        public CHARGESTATUS ChargeStatusAuto
        {
            get { return _ChargeStatusAuto; }
            set { _ChargeStatusAuto = value; }
        }
        public SETLOC SetLoc
        {
            get { return _SetLoc; }
            set { _SetLoc = value; }
        }
        public STRATEGY Strategy
        {
            get { return _Strategy; }
            set { _Strategy = value; }
        }
        public CSTEAMS CSTeams
        {
            get { return _CSTeams; }
            set { _CSTeams = value; }
        }
        public ENGAGEFAIL EngageFail
        {
            get { return _EngageFail; }
            set { _EngageFail = value; }
        }
        public DEFRATE DefRate
        {
            get { return _DefRate; }
            set { _DefRate = value; }
        }
        public AVORATE AvoRate
        {
            get { return _AvoRate; }
            set { _AvoRate = value; }
        }
        public PIECE DPiece
        {
            get { return _DPiece; }
            set { _DPiece = value; }
        }
        public DELGRID DDelGrid
        {
            get { return _DDelGrid; }
            set { _DDelGrid = value; }
        }
        public FLOORLBL Floorlbl
        {
            get { return _Floorlbl; }
            set { _Floorlbl = value; }
        }
        public NODELBL Nodelbl
        {
            get { return _Nodelbl; }
            set { _Nodelbl = value; }
        }
        public FLOORLBL DFloorlbl
        {
            get { return _DFloorlbl; }
            set { _DFloorlbl = value; }
        }
        public NODELBL DNodelbl
        {
            get { return _DNodelbl; }
            set { _DNodelbl = value; }
        }

        public ROBOT_MODE Current_Mode
        {
            get { return _RobotMode; }
            set { _RobotMode = value; }
        }

        public String TeamName
        {
            get { return _TeamName; }
            set { _TeamName = value; }
        }
        public MATCHEVENT_NAME match_event
        {
            get { return _match_event; }
            set { _match_event = value; }
        }

        // 2024 get sets
        //public ACQ_LOC Acq_Loc
        //{
        //    get { return _Acq_Loc; }
        //    set { _Acq_Loc = value; }
        //}

        //public DEL_ORIG Del_Orig
        //{
        //    get { return _Del_Orig; }
        //    set { _Del_Orig = value; }
        //}

        public DEL_DEST Del_Dest
        {
            get { return _Del_Dest; }
            set { _Del_Dest = value; }
        }

        public ROBOT_SET Robot_Set
        {
            get { return _Robot_Set; }
            set { _Robot_Set = value; }
        }
        public HP_AMP HP_Amp
        {
            get { return _HP_Amp; }
            set { _HP_Amp = value; }
        }
        public STAGE_STAT Stage_Stat
        {
            get { return _Stage_Stat; }
            set { _Stage_Stat = value; }
        }
        public STAGE_ATT Stage_Att
        {
            get { return _Stage_Att; }
            set { _Stage_Att = value; }
        }
        public STAGE_LOC Stage_Loc
        {
            get { return _Stage_Loc; }
            set { _Stage_Loc = value; }
        }
        public LIT Lit
        {
            get { return _Lit; }
            set { _Lit = value; }
        }
        public APP_STRAT App_Strat
        {
            get { return _App_Strat; }
            set { _App_Strat = value; }
        }
        public CURRENT_LOC Current_Loc
        {
            get { return _Current_Loc; }
            set { _Current_Loc = value; }
        }
        public String Drive_Sta
        {
            get { return _Drive_Sta; }
            set { _Drive_Sta = value; }
        }

        public static object ACQ_LOC { get; internal set; }


        ///Scouter Name
        public SCOUTER_NAME getScouterName(SCOUTER_NAME ScouterName)
        { return ScouterName = _ScouterName; }

        //Scouter Alternative
        public SCOUTER_NAME_ALT getScouterNameALT(SCOUTER_NAME_ALT ScouterName)
        { return ScouterName = _ScouterNameALT; }

        ///<summary>
        ///Resets all values to the default
        ///</summary>
        ///

        //Scouter Name
        public void changeScouterName(CYCLE_DIRECTION CycleDirection)
        {
            Alt = false;
            _ScouterNameALT = 0;
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _ScouterName = (SCOUTER_NAME)GetNextEnum<SCOUTER_NAME>(_ScouterName);
            else
            {
                _ScouterName = (SCOUTER_NAME)GetPreviousEnum<SCOUTER_NAME>(_ScouterName);
            }
        }

        public void changeScouterNameALT(CYCLE_DIRECTION CycleDirection)
        {
            Alt = true;
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _ScouterNameALT = (SCOUTER_NAME_ALT)GetNextEnum<SCOUTER_NAME_ALT>(_ScouterNameALT);
            else
            {
                _ScouterNameALT = (SCOUTER_NAME_ALT)GetPreviousEnum<SCOUTER_NAME_ALT>(_ScouterNameALT);
            }
        }


        //2023 Cycles 
        public void changeMob(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Mob =
                (MOB)GetNextEnum<MOB>(_Mob);
            else
            {
                _Mob =
                (MOB)GetPreviousEnum<MOB>(_Mob);
            }
        }
        public void changeChargeStatus(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _ChargeStatus =
                (CHARGESTATUS)GetNextEnum<CHARGESTATUS>(_ChargeStatus);
            else
            {
                _ChargeStatus =
                (CHARGESTATUS)GetPreviousEnum<CHARGESTATUS>(_ChargeStatus);
            }
        }
        public void changeChargeStatusAuto(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _ChargeStatusAuto =
                (CHARGESTATUS)GetNextEnum<CHARGESTATUS>(_ChargeStatusAuto);
            else
            {
                _ChargeStatusAuto =
                (CHARGESTATUS)GetPreviousEnum<CHARGESTATUS>(_ChargeStatusAuto);
            }
        }
        public void changeSetLoc(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _SetLoc =
                (SETLOC)GetNextEnum<SETLOC>(_SetLoc);
            else
            {
                _SetLoc =
                (SETLOC)GetPreviousEnum<SETLOC>(_SetLoc);
            }
        }
        public void changeStrategy(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Strategy =
                (STRATEGY)GetNextEnum<STRATEGY>(_Strategy);
            else
            {
                _Strategy =
                (STRATEGY)GetPreviousEnum<STRATEGY>(_Strategy);
            }
        }
        public void changeCSTeams(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _CSTeams =
                (CSTEAMS)GetNextEnum<CSTEAMS>(_CSTeams);
            else
            {
                _CSTeams =
                (CSTEAMS)GetPreviousEnum<CSTEAMS>(_CSTeams);
            }
        }
        public void changeFailReason(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _EngageFail =
                (ENGAGEFAIL)GetNextEnum<ENGAGEFAIL>(_EngageFail);
            else
            {
                _EngageFail =
                (ENGAGEFAIL)GetPreviousEnum<ENGAGEFAIL>(_EngageFail);
            }
        }


        public void changeDefRate(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _DefRate = (DEFRATE)GetNextEnum<DEFRATE>(_DefRate);
            else
            {
                _DefRate = (DEFRATE)GetPreviousEnum<DEFRATE>(_DefRate);
            }
        }
        public void changeAvoRate(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _AvoRate = (AVORATE)GetNextEnum<AVORATE>(_AvoRate);
            else
            {
                _AvoRate = (AVORATE)GetPreviousEnum<AVORATE>(_AvoRate);
            }
        }

        //2024 cycles
        //public void changeAcq_Loc(CYCLE_DIRECTION CycleDirection)
        //{
        //    if (CycleDirection == CYCLE_DIRECTION.Up)
        //        _Acq_Loc = (ACQ_LOC)GetNextEnum<ACQ_LOC>(_Acq_Loc);
        //    else
        //    {
        //        _Acq_Loc = (ACQ_LOC)GetPreviousEnum<ACQ_LOC>(_Acq_Loc);
        //    }
        //}

        //public void changeDel_Orig(CYCLE_DIRECTION CycleDirection)
        //{
        //    if (CycleDirection == CYCLE_DIRECTION.Up)
        //        _Del_Orig = (DEL_ORIG)GetNextEnum<DEL_ORIG>(_Del_Orig);
        //    else
        //    {
        //        _Del_Orig = (DEL_ORIG)GetPreviousEnum<DEL_ORIG>(_Del_Orig);
        //    }
        //}
        public void changeDel_Dest(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Del_Dest = (DEL_DEST)GetNextEnum<DEL_DEST>(_Del_Dest);
            else
            {
                _Del_Dest = (DEL_DEST)GetPreviousEnum<DEL_DEST>(_Del_Dest);
            }
        }

        public void changeRobot_Set(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Robot_Set = (ROBOT_SET)GetNextEnum<ROBOT_SET>(_Robot_Set);
            else
            {
                _Robot_Set = (ROBOT_SET)GetPreviousEnum<ROBOT_SET>(_Robot_Set);
            }
        }

        public void changeHP_Amp(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _HP_Amp = (HP_AMP)GetNextEnum<HP_AMP>(_HP_Amp);
            else
            {
                _HP_Amp = (HP_AMP)GetPreviousEnum<HP_AMP>(_HP_Amp);
            }
        }
        public void changeStage_Stat(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Stage_Stat = (STAGE_STAT)GetNextEnum<STAGE_STAT>(_Stage_Stat);
            else
            {
                _Stage_Stat = (STAGE_STAT)GetPreviousEnum<STAGE_STAT>(_Stage_Stat);
            }
        }
        public void changeStage_Att(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Stage_Att = (STAGE_ATT)GetNextEnum<STAGE_ATT>(_Stage_Att);
            else
            {
                _Stage_Att = (STAGE_ATT)GetPreviousEnum<STAGE_ATT>(_Stage_Att);
            }
        }
        public void changeStage_Loc(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Stage_Loc = (STAGE_LOC)GetNextEnum<STAGE_LOC>(_Stage_Loc);
            else
            {
                _Stage_Loc = (STAGE_LOC)GetPreviousEnum<STAGE_LOC>(_Stage_Loc);
            }
        }
        public void changeLit(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Lit = (LIT)GetNextEnum<LIT>(_Lit);
            else
            {
                _Lit = (LIT)GetPreviousEnum<LIT>(_Lit);
            }
        }
        public void changeApp_Strat(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _App_Strat = (APP_STRAT)GetNextEnum<APP_STRAT>(_App_Strat);
            else
            {
                _App_Strat = (APP_STRAT)GetPreviousEnum<APP_STRAT>(_App_Strat);
            }
        }
        public void changeCurrent_Loc(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Current_Loc = (CURRENT_LOC)GetNextEnum<CURRENT_LOC>(_Current_Loc);
            else
            {
                _Current_Loc = (CURRENT_LOC)GetPreviousEnum<CURRENT_LOC>(_Current_Loc);
            }
        }


        //Cycle Event Name
        public void cycleEventName(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
            {
                _match_event = (MATCHEVENT_NAME)GetNextEnum<MATCHEVENT_NAME>(_match_event);
            }
            else
            {
                _match_event = (MATCHEVENT_NAME)GetPreviousEnum<MATCHEVENT_NAME>(_match_event);
            }
        }

        private Enum GetNextEnum<t>(object currentlySelectedEnum)
        {
            Type enumList = typeof(t);
            if (!enumList.IsEnum)
                throw new InvalidOperationException("Object is not an Enum.");

            Array enums = Enum.GetValues(enumList);
            int index = Array.IndexOf(enums, currentlySelectedEnum);
            index = (index + 1) % enums.Length;
            return (Enum)enums.GetValue(index);
        }

        private Enum GetPreviousEnum<t>(object currentlySelectedEnum)
        {
            Type enumList = typeof(t);
            if (!enumList.IsEnum)
                throw new InvalidOperationException("Object is not an Enum.");

            Array enums = Enum.GetValues(enumList);
            int index = Array.IndexOf(enums, currentlySelectedEnum);
            index = (((index == 0) ? enums.Length : index) - 1);
            return (Enum)enums.GetValue(index);
        }
    }
}
