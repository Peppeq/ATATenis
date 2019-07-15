using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.Data
{
    public enum PlayingSystem
    {
        complete = 0,
        prince = 1,
        kombi = 2,
        group = 3
    }

    public enum TournamentCategory
    {
        singles = 0,
        doubles = 1
    }

    public enum TournamentType{
        grandslam = 0,
        ata =1,
        challanger =2,
        ataSpecial = 3,
        challangerSpecial = 4
}

    public enum BallsType
    {
        slazenger = 0,
        dunlop = 1
    }

    public enum DrawType
    {
        playoff = 0,
        group = 1
    }
}
