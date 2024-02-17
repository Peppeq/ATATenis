﻿/* eslint-disable */
/* this file is autogenerated by typewriter (used Template.tst file to generate) */


      
      import { TournamentCategory } from "../enums/TournamentCategory";
            
      
      import { PlayingSystem } from "../enums/PlayingSystem";
            
      
      import { BallsType } from "../enums/BallsType";
            
      
      import { TournamentType } from "../enums/TournamentType";
            
      
      import { SurfaceType } from "../enums/SurfaceType";
            

  export class TournamentDTO {
        id: number = null;
        name: string = null;
        startTime: Date = null;
        endTime: Date = null;
        place: string = null;
        category: TournamentCategory = null;
        playingSystem: PlayingSystem = null;
        ballsType: BallsType | null = null;
        tournamentType: TournamentType = null;
        surface: SurfaceType = null;
        description: string = null;
    }