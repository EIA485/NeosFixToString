using HarmonyLib;
using NeosModLoader;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrooxEngine;
using FrooxEngine.LogiX;

namespace FixToString
{
    public class FixToString : NeosMod
    {
        public override string Name => "FixToString";
        public override string Author => "eia485";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/EIA485/NeosFixToString/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.eia485.FixToString");
            harmony.PatchAll();

        }
        [HarmonyPatch(typeof(DebugHelper), "ToStringWrap")]
        class FixToStringPatch
        {
            public static bool Prefix(object obj, ref object __result)
            {
                __result = obj;
                return false;
            }
        }
    }
}