﻿    /* eslint-disable 
   this file is autogenerated by typewriter (used Template.tst file to generate) */

import { TournamentDTO } from "./dtos/TournamentDTO";
import { TournamentFilterDTO } from "./dtos/TournamentFilterDTO";
import { SearchedTournamentDTO } from "./dtos/SearchedTournamentDTO";
import { TournamentGraphDTO } from "./dtos/TournamentGraphDTO";
import { AjaxProvider } from "../scripts/ajax";

    
export class SearchedTournamentByNameArgs {
    name: string = null;
}
    
export class TournamentPlayersArgs {
    tournamentId: number = null;
}

export class TournamentClient {get<TArgs extends TournamentFilterDTO, TResult extends TournamentDTO[]>(data: TArgs): Promise<TResult> {
        return AjaxProvider.apiGet("api/Tournament?id=${args.id}&year=${args.year}&type=${args.type}", data);
    }
    
    
    getSearchedTournamentsByName<TArgs extends SearchedTournamentByNameArgs, TResult extends SearchedTournamentDTO[]>(data: TArgs): Promise<TResult> {
        return AjaxProvider.apiGet("api/Tournament/GetSearchedTournamentsByName?name=${args.name}", data);
    }
    
    
    getTournamentPlayers<TArgs extends TournamentPlayersArgs, TResult extends TournamentGraphDTO>(data: TArgs): Promise<TResult> {
        return AjaxProvider.apiGet("api/Tournament/GetTournamentGraph?tournamentId=${args.tournamentId}", data);
    }
    
    
    getNearestTournament<TResult extends TournamentDTO>(): Promise<TResult> {
        return AjaxProvider.apiGet("api/Tournament/nearestTournament", null);
    }
    addOrEditTournament<TArgs extends TournamentDTO, TResult extends TournamentDTO>(data: TArgs): Promise<TResult> {
        return AjaxProvider.apiPost("api/Tournament/AddOrEditTournament", data);
    }
    
     
}