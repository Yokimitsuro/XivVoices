﻿using Dalamud.Game.ClientState.Objects.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace XivVoices.Engine
{
    [System.Serializable]
    public class TTSData
    {
        public TTSData(string type, string speaker, string npcID, string skeletonID, string message, string body, string gender, string race, string tribe, string eyes, string language, Vector3 position, ICharacter character, string user) {
            Type = type;
            Speaker = speaker;
            NpcID = npcID;
            SkeletonID = skeletonID;
            Message = message;
            Body = body;
            Gender = gender;
            Race = race;
            Tribe = tribe;
            Eyes = eyes;
            Language = language;
            Position = position;
            Character = character;
            User = user;
            Region = Plugin.ClientState.TerritoryType;
        }

        public TTSData() {
            Language = "English";
            Position = new Vector3(-99);
            Character = null;
            Region = 0;
        }

        public string Type;
        public string Speaker;
        public string NpcID;
        public string SkeletonID;
        public string Message;
        public string Body;
        public string Gender;
        public string Race;
        public string Tribe;
        public string Eyes;
        public string Language;
        public Vector3 Position;
        public ICharacter Character;
        public string User;
        public ushort Region;
    }


    [System.Serializable]
    public class XivMessage
    {
        public XivMessage() {
            Ignored = false;
            Reported = false;
            isRetainer = false;
            Time = DateTime.Now;
        }
        public XivMessage(TTSData ttsData)
        {
            if (ttsData.Speaker == "")
                ttsData.Speaker = "Narrator";

            ChatType = ttsData.Type;
            Speaker = ttsData.Speaker;
            NpcId = ttsData.NpcID;
            Sentence = ttsData.Message;
            TtsData = ttsData;
            Ignored = false;
            Reported = false;
            AccessRequested = "";
            GetRequested = "";
            isRetainer = false;
            Time = DateTime.Now;
        }

        public string ChatType;
        public string Speaker = "";
        public string NpcId;
        public string Sentence = "";
        public TTSData TtsData;

        public string FilePath = "";
        public string Network = "";
        public string VoiceName;
        public XivNPC? NPC = null;

        public bool Ignored;
        public bool Reported;
        public string AccessRequested;
        public string GetRequested;
        public bool isRetainer;
        public DateTime Time;

        public string FrameworkPath = "";
    }


    [System.Serializable]
    public class XivNPC
    {
        public string Gender;
        public string Race;
        public string Tribe;
        public string Body;
        public string Eyes;
        public string Type;

        public string Data()
        {
            return "Gender: " + Gender + "\n" +
                "Race: " + Race + "\n" +
                "Tribe: " + Tribe + "\n" +
                "Body: " + Body + "\n" +
                "Eyes: " + Eyes + "\n" +
                "Type: " + Type;
        }
    }


    [System.Serializable]
    public class ReportXivMessage
    {
        public ReportXivMessage(XivMessage _message, string _folder, string _comment) { message = _message; folder = _folder; comment = _comment; }

        public XivMessage message;
        public string folder;
        public string comment;
    }


    [System.Serializable]
    public class DownloadInfo
    {
        public DownloadInfo(string _id, string _file, string _status, float _percentage) { id = _id; file = _file; status = _status; percentage = _percentage;}

        public string id;
        public string file;
        public string status;
        public float percentage;

    }


    [System.Serializable]
    public class AudioInfo
    {
        public AudioInfo(string _id, string _state, float _percentage, string _type, XivMessage _data) { id = _id; state = _state; percentage = _percentage; type = _type;  data = _data; }

        public string id;
        public string state;
        public string type;
        public float percentage;
        public XivMessage data;

    }


    [System.Serializable]
    public class VoiceMapping
    {
        public string voiceName;
        public List<string> speakers;
    }


    [System.Serializable]
    public class ReportData
    {
        public string speaker;
        public string sentence;
        public string npcid;
        public string skeletonid;
        public string body;
        public string race;
        public string gender;
        public string tribe;
        public string eyes;
        public string folder;
        public string user;
        public string comment;
    }


    [System.Serializable]
    public class PlayerCharacter
    {
        public string Body { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Tribe { get; set; }
        public string EyeShape { get; set; }
    }

    public class GitHubRelease
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
