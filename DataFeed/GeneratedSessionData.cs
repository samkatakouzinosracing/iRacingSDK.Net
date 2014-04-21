﻿

// This file is part of iRacingSDK.
//
// Copyright 2014 Dean Netherton
// https://github.com/vipoo/iRacingSDK.Net
//
// iRacingSDK is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// iRacingSDK is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with iRacingSDK.  If not, see <http://www.gnu.org/licenses/>.



using System;
using System.Collections.Generic;
using System.Linq;

namespace iRacingSDK
{
    public partial class SessionData
    {

        public partial class _WeekendInfo
        {
            public string TrackName { get; set; }
            public long TrackID { get; set; }
            public string TrackLength { get; set; }
            public string TrackDisplayName { get; set; }
            public string TrackDisplayShortName { get; set; }
            public string TrackCity { get; set; }
            public string TrackCountry { get; set; }
            public string TrackAltitude { get; set; }
            public string TrackLatitude { get; set; }
            public string TrackLongitude { get; set; }
            public long TrackNumTurns { get; set; }
            public string TrackPitSpeedLimit { get; set; }
            public string TrackType { get; set; }
            public string TrackWeatherType { get; set; }
            public string TrackSkies { get; set; }
            public string TrackSurfaceTemp { get; set; }
            public string TrackAirTemp { get; set; }
            public string TrackAirPressure { get; set; }
            public string TrackWindVel { get; set; }
            public string TrackWindDir { get; set; }
            public string TrackRelativeHumidity { get; set; }
            public string TrackFogLevel { get; set; }
            public long SeriesID { get; set; }
            public long SeasonID { get; set; }
            public long SessionID { get; set; }
            public long SubSessionID { get; set; }
            public long LeagueID { get; set; }
            public long Official { get; set; }
            public long RaceWeek { get; set; }
            public string EventType { get; set; }
            public string Category { get; set; }
            public string SimMode { get; set; }

            public partial class _WeekendOptions
            {
                public long NumStarters { get; set; }
                public string StartingGrid { get; set; }
                public string QualifyScoring { get; set; }
                public string CourseCautions { get; set; }
                public long StandingStart { get; set; }
                public string Restarts { get; set; }
                public string WeatherType { get; set; }
                public string Skies { get; set; }
                public string WindDirection { get; set; }
                public string WindSpeed { get; set; }
                public string WeatherTemp { get; set; }
                public string RelativeHumidity { get; set; }
                public string FogLevel { get; set; }
                public long Unofficial { get; set; }
                public string CommercialMode { get; set; }
                public long NightMode { get; set; }
                public long IsFixedSetup { get; set; }
                public string StrictLapsChecking { get; set; }
                public long HasOpenRegistration { get; set; }
                public long HardcoreLevel { get; set; }
            }

            public _WeekendOptions WeekendOptions { get; set; }
        }

        public _WeekendInfo WeekendInfo { get; set; }

        public partial class _SessionInfo
        {
            public partial class _Sessions
            {
                public long SessionNum { get; set; }
                public string SessionLaps { get; set; }
                public string SessionTime { get; set; }
                public long SessionNumLapsToAvg { get; set; }
                public string SessionType { get; set; }
                public partial class _ResultsPositions
                {
                    public long Position { get; set; }
                    public long ClassPosition { get; set; }
                    public long CarIdx { get; set; }
                    public long Lap { get; set; }
                    public double Time { get; set; }
                    public long FastestLap { get; set; }
                    public double FastestTime { get; set; }
                    public double LastTime { get; set; }
                    public long LapsLed { get; set; }
                    public long LapsComplete { get; set; }
                    public double LapsDriven { get; set; }
                    public long Incidents { get; set; }
                    public long ReasonOutId { get; set; }
                    public string ReasonOutStr { get; set; }
                }

                public _ResultsPositions[] ResultsPositions { get; set; }
                public partial class _ResultsFastestLap
                {
                    public long CarIdx { get; set; }
                    public long FastestLap { get; set; }
                    public double FastestTime { get; set; }
                }

                public _ResultsFastestLap[] ResultsFastestLap { get; set; }
                public double ResultsAverageLapTime { get; set; }
                public long ResultsNumCautionFlags { get; set; }
                public long ResultsNumCautionLaps { get; set; }
                public long ResultsNumLeadChanges { get; set; }
                public long ResultsLapsComplete { get; set; }
                public long ResultsOfficial { get; set; }
            }

            public _Sessions[] Sessions { get; set; }
        }

        public _SessionInfo SessionInfo { get; set; }

        public partial class _CameraInfo
        {
            public partial class _Groups
            {
                public long GroupNum { get; set; }
                public string GroupName { get; set; }
                public partial class _Cameras
                {
                    public long CameraNum { get; set; }
                    public string CameraName { get; set; }
                }

                public _Cameras[] Cameras { get; set; }
            }

            public _Groups[] Groups { get; set; }
        }

        public _CameraInfo CameraInfo { get; set; }

        public partial class _RadioInfo
        {
            public long SelectedRadioNum { get; set; }
            public partial class _Radios
            {
                public long RadioNum { get; set; }
                public long HopCount { get; set; }
                public long NumFrequencies { get; set; }
                public long TunedToFrequencyNum { get; set; }
                public long ScanningIsOn { get; set; }
                public string Frequencies { get; set; }
            }

            public _Radios[] Radios { get; set; }
        }

        public _RadioInfo RadioInfo { get; set; }

        public partial class _DriverInfo
        {
            public long DriverCarIdx { get; set; }
            public double DriverHeadPosX { get; set; }
            public double DriverHeadPosY { get; set; }
            public double DriverHeadPosZ { get; set; }
            public double DriverCarRedLine { get; set; }
            public double DriverCarFuelKgPerLtr { get; set; }
            public double DriverCarSLFirstRPM { get; set; }
            public double DriverCarSLShiftRPM { get; set; }
            public double DriverCarSLLastRPM { get; set; }
            public double DriverCarSLBlinkRPM { get; set; }
            public double DriverPitTrkPct { get; set; }
            public partial class _Drivers
            {
                public long CarIdx { get; set; }
                public string UserName { get; set; }
                public string AbbrevName { get; set; }
                public string Initials { get; set; }
                public long UserID { get; set; }
                public long CarNumber { get; set; }
                public string CarPath { get; set; }
                public long CarClassID { get; set; }
                public long CarID { get; set; }
                public string CarClassShortName { get; set; }
                public long CarClassRelSpeed { get; set; }
                public long CarClassLicenseLevel { get; set; }
                public string CarClassMaxFuel { get; set; }
                public string CarClassWeightPenalty { get; set; }
                public long IRating { get; set; }
                public long LicLevel { get; set; }
                public long LicSubLevel { get; set; }
                public string LicColor { get; set; }
                public long IsSpectator { get; set; }
            }

            public _Drivers[] Drivers { get; set; }
        }

        public _DriverInfo DriverInfo { get; set; }

        public partial class _SplitTimeInfo
        {
            public partial class _Sectors
            {
                public long SectorNum { get; set; }
                public double SectorStartPct { get; set; }
            }

            public _Sectors[] Sectors { get; set; }
        }

        public _SplitTimeInfo SplitTimeInfo { get; set; }
    }
}

