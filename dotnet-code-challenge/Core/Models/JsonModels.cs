﻿using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Core.JsonModels
{
    #region Root
    public class Root
    {
        public string FixtureId { get; set; }
        public DateTime Timestamp { get; set; }
        public RawData RawData { get; set; }
    }
    #endregion

    #region RawData

    public class RawData
    {
        public string FixtureName { get; set; }
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Sequence { get; set; }
        public RootTags Tags { get; set; }
        public List<Market> Markets { get; set; }
        public List<Participant> Participants { get; set; }
    }
    
    #endregion

    #region RootTags
    public class RootTags
    {
        public string CourseType { get; set; }
        public string Distance { get; set; }
        public string Going { get; set; }
        public string Runners { get; set; }
        public string MeetingCode { get; set; }
        public string TrackCode { get; set; }
        public string Sport { get; set; }
    }
    #endregion

    #region Markets
    public class Market
    {
        public string Id { get; set; }
        public List<Selection> Selections { get; set; }
        public MarketTags Tags { get; set; }
    }

    public class Selection
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public SelectionTags Tags { get; set; }
    }

    public class SelectionTags
    {
        public string participant { get; set; }
        public string name { get; set; }
    }

    public class MarketTags
    {
        public string Places { get; set; }
        public string type { get; set; }
    }
    #endregion

    #region Participants
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ParticipantTags Tags { get; set; }
    }

    public class ParticipantTags
    {
        public string Weight { get; set; }
        public string Drawn { get; set; }
        public string Jockey { get; set; }
        public string Number { get; set; }
        public string Trainer { get; set; }
    }
    #endregion

}
