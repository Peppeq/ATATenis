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

    public enum SurfaceType
    {
        clay = 0,
        grass = 1,
        hard = 2
    }

    public enum Forehand
    {
        rightHanded = 0,
        leftHanded = 1
    }

    public enum Backhand
    {
        oneHanded = 0,
        twoHanded = 1
    }

    public enum DrawSize
    {
        draw8 = 8,
        draw16 = 16,
        draw32 = 32,
        draw64 = 64
    }

    public enum TournamentRound
    {
        round1 = 1,
        round2 = 2,
        round3 = 3,
        round4 = 4,
        round5 = 5,
        round6 = 6
    }
}
