﻿using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class MatchPlayer
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }

        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
    }
}