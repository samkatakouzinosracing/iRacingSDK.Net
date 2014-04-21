﻿// This file is part of iRacingSDK.
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
using System.Linq;
using iRacingSDK;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace SpikeIRSDK
{
    //----
    // Remote controll the sim by sending these windows messages
    // camera and replay commands only work when you are out of your car, 
    // pit commands only work when in your car
    enum irsdk_BroadcastMsg
    {
        irsdk_BroadcastCamSwitchPos = 0,      // car position, group, camera
        irsdk_BroadcastCamSwitchNum,	      // driver #, group, camera
        irsdk_BroadcastCamSetState,           // irsdk_CameraState, unused, unused 
        irsdk_BroadcastReplaySetPlaySpeed,    // speed, slowMotion, unused
        irskd_BroadcastReplaySetPlayPosition, // irsdk_RpyPosMode, Frame Number (high, low)
        irsdk_BroadcastReplaySearch,          // irsdk_RpySrchMode, unused, unused
        irsdk_BroadcastReplaySetState,        // irsdk_RpyStateMode, unused, unused
        irsdk_BroadcastReloadTextures,        // irsdk_ReloadTexturesMode, carIdx, unused
        irsdk_BroadcastChatComand,		      // irsdk_ChatCommandMode, subCommand, unused
        irsdk_BroadcastPitCommand,            // irsdk_PitCommandMode, parameter
        irsdk_BroadcastLast                   // unused placeholder
    };

    class MainClass
    {
         [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
         private static extern int RegisterWindowMessage(string lpString);

         [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
         static extern bool SendNotifyMessageA(IntPtr hWnd, int Msg, int wParam, int lParam);

        static IntPtr HWND_BROADCAST = new IntPtr(0xffff);

        public static int FromShorts(short lowPart, short highPart)
        {
            return ((int)highPart << 16) | (ushort)lowPart;
        }

        public static void Main(string[] args)
        {
            //CaptureDriverPositionPerLap();
            GetData_Main(args);
        }

        public static void CaptureDriverPositionPerLap()
        {
            foreach( var data in iRacing.GetDataFeed().TakeWhile(d => !d.IsConnected))
            {
                Console.WriteLine("Waiting to connect ...");
                continue;
            }

            var data2 = iRacing.GetDataFeed().First();

            var yamlData = data2.SessionData.Raw;

            Console.WriteLine(yamlData);

            var input = new StringReader(yamlData);

            // Load the stream
            var yaml = new YamlStream();
            yaml.Load(input);

            // Examine the stream
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            foreach (var entry in mapping)
            {
                Process(1, entry.Key.ToString(), entry.Value);
            }

            return;
            // List all the items
            var items = (YamlSequenceNode)mapping.Children[new YamlScalarNode("items")];
            foreach (YamlMappingNode item in items)
            {
                Console.WriteLine( "{0}\t{1}",
                    item.Children[new YamlScalarNode("part_no")],
                    item.Children[new YamlScalarNode("descrip")]
                );
            }

            //iRacing.Replay.ToStart();
            //while( iRacing.

            /*
            foreach (var data in iRacing.GetDataFeed())
            {
                
                if (!data.IsConnected)
                {
                    Console.WriteLine("Waiting to connect ...");
                    continue;
                }

                Console.Clear();

                iRacing.Replay.ToStart();
                
            }*/
        }

        private static void Process(int a, string key, YamlNode value)
        {
            for (int i = 0; i < a; i++)
                Console.Write(" ");

            Console.Write(key);

            var mappingNode = value as YamlMappingNode;
            var scalarNode = value as YamlScalarNode;
            var sequenceNode = value as YamlSequenceNode;

            if (mappingNode != null)
            {
                Console.WriteLine(":");
                foreach (var x in mappingNode)
                    Process(a+1, x.Key.ToString(), x.Value);
            }
            else if( scalarNode != null )
            {
                
                Console.WriteLine(" = " + scalarNode);

            } else if(sequenceNode != null)
            {
                Console.WriteLine("[");
                foreach (var x in sequenceNode)
                    Process(a+1,"", x);
                Console.WriteLine("]");

            }
            //foreach( var k )
        }

        public static void Spike()
        {
            var IRSDK_BROADCASTMSGNAME = "IRSDK_BROADCASTMSG";

            var msgId = RegisterWindowMessage(IRSDK_BROADCASTMSGNAME);

            var msg = (short)irsdk_BroadcastMsg.irsdk_BroadcastCamSwitchPos;
            short var1 = 1;
            short var2 = 1;
            short var3 = 0;

            var var23 = FromShorts(var2, var3);
            var msgVar1 = FromShorts(msg, var1);

            var r = SendNotifyMessageA(HWND_BROADCAST, msgId, msgVar1, var23);
            Console.WriteLine(r);

            msg = (short)irsdk_BroadcastMsg.irsdk_BroadcastReplaySetPlaySpeed;
            var1 = 16;
            var2 = 1; //true
            var3 = 0;

            var23 = FromShorts(var2, var3);
            msgVar1 = FromShorts(msg, var1);

/*x
1048579
var2
1
*/

            r = SendNotifyMessageA(HWND_BROADCAST, msgId, msgVar1, var23);
            Console.WriteLine(r);

            //irsdk_broadcastMsg(irsdk_BroadcastReplaySetPlaySpeed, 16, true, 0);
        }

        public unsafe static void GetData_Main(string[] args)
        {
			foreach (var data in iRacing.GetDataFeed())
            {
                if (!data.IsConnected)
                {
                    Console.WriteLine("Waiting to connect ...");
                    continue;
                }

                Console.Clear();

                Console.WriteLine("Session Data");
                //Console.WriteLine(data.SessionData.Raw);

                Console.WriteLine("Telemtary");

				foreach(var kv in data.Telemetry)
                {
                    Console.WriteLine("{0} = {1}", kv.Key, kv.Value);
                }

                var session = data.SessionData.SessionInfo.Sessions.First(s => s.SessionNum == data.Telemetry.SessionNum);
                Console.WriteLine("SessionLaps = {0}", session.SessionLaps);
                Console.WriteLine("SessionTime = {0}", session.SessionTime);
                Console.WriteLine("SessionTimeRemaing = {0}", data.Telemetry.SessionTimeRemain);
                Console.WriteLine("SessionLapRemining = {0}", data.Telemetry.SessionLapsRemain);
                
                //return;
                Thread.Sleep(2000);
            }
        }
    }			
}
