<template>
  <d-container fluid class="main-content-container px-4">
    <d-row class="px-4 py-2">
      <h4>Edit Tournament</h4>
    </d-row>
    <d-row class="p-4">
      <d-input-group class="mb-3" seamless>
        <!-- <d-input-group-text slot="prepend">
					<i class="material-icons">search</i>
					<i class="fas fa-search"></i>
                </d-input-group-text>-->

        <div class="input-group-prepend">
          <div class="input-group-text">
            <i class="fas fa-search"></i>
          </div>
        </div>
        <input v-model="searchName" class="navbar-search form-control" type="text" @keyup="searchTournamentByName" />
        <input lass="navbar-search form-control" type="text" :value="test" v-on:change="onChangeTest"/>
      </d-input-group>
      <d-list-group v-if="searchedTournaments != null && searchedTournaments.length > 0">
        <div v-for="searchedTournament in searchedTournaments" :key="searchedTournament.tournamentId" class="list-group-item fake-link" @click="editTournament(searchedTournament.tournamentId)">
          {{ searchedTournament.name + " " + searchedTournament.startTime }}
        </div>
      </d-list-group>
      <d-list-group v-else-if="searchedTournaments == null || searchedTournaments.length == 0">No tournaments founded</d-list-group>
    </d-row>
    <d-card v-if="selectedTour != null" class="px-4 py-2">
      <d-tabs card>
        <d-tab title="Details" active>
          <tournament-details :tournament-prop="selectedTour" :is-create-or-edit="true"></tournament-details>
        </d-tab>
        <d-tab title="Players">
          <tournament-players :tournament-id="selectedTour.id" :assigned-players="assignedPlayers" :remove-tournament-entry="removeTournamentEntry" :add-tournament-entry="addTournamentEntry"></tournament-players>
        </d-tab>
        <d-tab title="Draw">
          <tournament-draw :tournament-id="selectedTour.id" :tournament-draw="draw" :is-editable-page="true" @tournamentDrawDelete="deleteDraw" @createDrawEvent="createDrawHandlerHub" @addQualificationMatch="addQualificationMatch" />
        </d-tab>
      </d-tabs>
    </d-card>
    <d-row class="p-4">
      <d-button @click="addOrEditTournament(null)">Add tournament</d-button>
    </d-row>
    <tournament-modal :show-modal="showTournamentModal" :hide-modal="hideTournamentModal" :tournament="tournament" :modify-tournament="modifySearchedTournament"></tournament-modal>
  </d-container>
</template>

<script lang="ts">
import { BaseComponentClass } from "../../common/BaseComponentClass";
import Component from "vue-class-component";
import TournamentModal from "../tournament/TournamentModal.vue";
import TournamentDetails from "../tournament/TournamentDetails.vue";
import TournamentDraw from "../tournament/TournamentDraw.vue";
import TournamentPlayers from "../tournament/TournamentPlayers.vue";
import {
  TournamentClient,
  SearchedTournamentByNameArgs,
  TournamentPlayersArgs
} from "@/Api/TournamentController";
import {
  TournamentEntryClient,
  GetPlayersArgs,
  DeletePlayerArgs,
  PlayerArgs
} from "@/Api/TournamentEntryController";
import {
  MatchClient,
  MatchesArgs
} from '@/Api/MatchController';
import {
  QualificationMatch,
  QualificationMatchClient
} from '@/Api/QualificationMatchController';
import { NotificationUtils } from '@/common/notification';
import { SearchedTournamentDTO } from "@/Api/dtos/SearchedTournamentDTO";
import { TournamentDTO } from "@/Api/dtos/TournamentDTO";
import { PlayerDrawDTO } from "@/Api/dtos/PlayerDrawDTO";
import { DrawDTO } from "@/Api/dtos/DrawDTO";
import { TournamentEntryDTO } from "@/Api/dtos/TournamentEntryDTO";
import { TournamentGraphDTO } from "@/Api/dtos/TournamentGraphDTO";
import { MatchDTO } from "@/Api/dtos/MatchDTO";
import { RoundMatchDTO } from "@/Api/dtos/RoundMatchDTO";

@Component({
  components: {
    TournamentModal,
    TournamentDetails,
    TournamentDraw,
    TournamentPlayers
  }
})
export default class TournamentManagement extends BaseComponentClass {
  showTournamentModal = false;
  searchName: string = null;
  searchedTournaments: SearchedTournamentDTO[] = [];
  // searchedTournament: SearchedTournamentDTO = null;
  tournament: TournamentDTO = null;
  selectedTournament: TournamentDTO = null;
  assignedPlayers: PlayerDrawDTO[] = [];
  draw: DrawDTO = new DrawDTO();
  startingRound: number;
  test:string = "abc";
  onChangeTest(val: InputEvent) {
    var el = val.target as HTMLInputElement;
    this.test = el.value;
  }

  get selectedTour(): TournamentDTO {
    return this.selectedTournament;
  }

  set selectedTour(tournament: TournamentDTO) {
    this.selectedTournament = tournament;
  }

  searchTournamentByName(event: KeyboardEvent): void {
    if (this.searchName != null && this.searchName != "") {
      const ENTER_KEY = 13;
      if (event.keyCode == ENTER_KEY) {
        this.editTournament(this.searchedTournaments[0].tournamentId);
      } else {
        const client = new TournamentClient();
        this.tryGetDataByArgs<SearchedTournamentDTO[], SearchedTournamentByNameArgs>({
          apiMethod: client.getSearchedTournamentsByName,
          showError: true,
          requestArgs: { name: this.searchName }
        }).then((response) => {
          if (response.ok) this.searchedTournaments = response.data;
        });
      }
    } else {
      this.searchName = "";
      this.searchedTournaments = null;
    }
  }

  getAssignedPlayers(): void {
    const client = new TournamentEntryClient();
    this.tryGetDataByArgs<PlayerDrawDTO[], GetPlayersArgs>({
      apiMethod: client.tournamentPlayers,
      showError: true,
      requestArgs: { tournamentId: this.selectedTournament.id }
    }).then((response) => {
      if (response.ok) {
        this.assignedPlayers = response.data;
      }
    });
  }

  async addTournamentEntry(player: PlayerDrawDTO): Promise<boolean> {
    let result = false;
    const client = new TournamentEntryClient();
    await this.tryGetDataByArgs<TournamentEntryDTO, PlayerArgs>({
      apiMethod: client.addTournamentPlayer,
      showError: true,
      requestArgs: {
        tournamentId: this.selectedTournament.id,
        playerId: player.playerId
      }
    }).then((response) => {
      result = response.ok;
      if (response.ok) {
        player.tournamentEntryId = response.data.id;
        this.assignedPlayers.push(player);
      }
    });
    return result;
  }

  async removeTournamentEntry(tournamentId: number): Promise<boolean> {
    const client = new TournamentEntryClient();
    if (tournamentId > 0) {
      await this.tryGetDataByArgs<void, DeletePlayerArgs>({
        apiMethod: client.deleteTournamentPlayer,
        showError: true,
        requestArgs: { tournamentEntryId: tournamentId }
      }).then((response) => {
        if (response.ok) {
          this.assignedPlayers = this.assignedPlayers.filter(p => p.tournamentEntryId != tournamentId);
        }
        return response.ok;
      });
    } else {
      return false;
    }
  }

  hideTournamentModal(): void {
    this.showTournamentModal = false;
  }

  editTournament(tournamentId: number): void {
    const client = new TournamentClient();
    if (tournamentId > 0) {
      this.tryGetDataByArgs<TournamentGraphDTO, TournamentPlayersArgs>({
        apiMethod: client.getTournamentPlayers,
        showError: true,
        requestArgs: { tournamentId: tournamentId }
      }).then((response) => {
        if (response.ok) {
          this.assignedPlayers = response.data.players;
          this.selectedTour = response.data.tournament;
          this.searchedTournaments = null;
          this.draw = response.data.draw;
        }
      });
    }
  }

  addOrEditTournament(tournament: TournamentDTO): void {
    console.log("add or edit player called");
    this.tournament = tournament;
    this.showTournamentModal = true;
  }

  modifySearchedTournament(tournament: TournamentDTO): void {
    const index = this.searchedTournaments.findIndex(p => p.tournamentId == tournament.id);
    this.searchedTournaments[index] = {
      tournamentId: tournament.id,
      name: tournament.name,
      startTime: tournament.startTime
    };
  }

  deleteDraw(tournamentId: number): void {
    console.log('delete draw handler execute')

    const matchClient = new MatchClient();
    this.tryGetDataByArgs<void, MatchesArgs>({
      apiMethod: matchClient.deleteTournamentDrawGraph,
      showError: true,
      requestArgs: { tournamentId: tournamentId }
    }).then((resp) => {
      if (resp.ok) {
        NotificationUtils.ShowSuccess({
          message: "Tournament draw deleted",
          title: "Tournament Draw Delete"
        });
        this.draw = null;
      }
    });
  }

  addQualificationMatch(entryId: number) {
    const qualificationMatchClient = new QualificationMatchClient();

    var response = this.tryGetDataByArgs<MatchDTO, QualificationMatch>({
      apiMethod: qualificationMatchClient.createQualificationMatch,
      showError: true,
      requestArgs: { entryId: entryId }
    }).then((resp) => {
      if (resp.ok) {
        var roundMatch = this.draw.roundMatches.filter(roundMatch => roundMatch.round == resp.data.round);

        var roundMatchesIndex = this.draw.roundMatches.findIndex(roundMatch => roundMatch.round == resp.data.round);
        let newRoundMatch: RoundMatchDTO = null;

        if (roundMatch) {
          console.log('roundMatch')
          console.log(roundMatch)
          if (roundMatch[0].matches && roundMatch[0].matches.length > 0) {
            roundMatch[0].matches.push(resp.data);

            newRoundMatch = roundMatch[0];
          } else {
            roundMatch[0].matches = [resp.data];
            newRoundMatch = roundMatch[0];
          }
        } else {
          roundMatch.push({ round: resp.data.round, matches: [resp.data] });
          newRoundMatch = { round: resp.data.round, matches: [resp.data] };
        }
        console.log('reactivity test')
        let rounds = this.draw.roundMatches.map(m => m);
        let testDraw: DrawDTO = new DrawDTO();

        testDraw = { ...this.draw }
        // rounds.push(newRoundMatch);
        testDraw.roundMatches = rounds;
        this.draw = testDraw;

        console.log('nefunguje reactivita na objekte')
        // toto funguje
        // let draww = new Draw();
        // draww.InitialRound = 5;
        // draww.MatchesCount = 22;
        // draww.RoundMatches = [];
        // this.draw = draww;

        // let draww = this.draw;
        // draww.InitialRound = 5;
        // draww.MatchesCount = 22;
        // draww.RoundMatches = [];
        // this.draw = draww;

        // this.$set(this.draw, "MatchesCount", 100);
        // Vue.set(this.draw, "MatchesCount", 100)
        // this.$set(this.draw, "RoundMatches", rounds);
      }
    })
  }

  // createDrawHandlerHub(roundMatches: RoundMatchDTO[]): void {
  //   this.draw.RoundMatches = roundMatches;
  // }

  createDrawHandlerHub(draw: DrawDTO): void {
    this.draw = draw;
  }

  created() {
    this.$eventHub.$on('createDrawEventOnHub', this.createDrawHandlerHub);
    this.$eventHub.$on('addQualificationMatch', this.addQualificationMatch);
  }

  beforeDestroy() {
    this.$eventHub.$off('createDrawEventOnHub');
    this.$eventHub.$off('addQualificationMatch');
  }
}
</script>

<style></style>
