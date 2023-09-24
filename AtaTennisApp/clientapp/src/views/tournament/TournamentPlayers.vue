<template>
  <div class="">
    <ol>
      <li v-for="player in assignedPlayers" :key="player.playerId">
        {{ getFullName(player)
			}}<span class="text-danger remove-player" @click="removeTournamentEntry"><i :id="player.tournamentEntryId" class="material-icons">clear</i></span>
      </li>
    </ol>
    <d-input-group class="mb-2">
      <input v-model="player" placeholder="Name Surname" list="searchedPlayers" class="form-control" @keyup="searchPlayers" @input="setSelectedPlayer" />
      <datalist id="searchedPlayers">
        <option v-for="searchedPlayer in searchedPlayers" :key="searchedPlayer.playerId" :value="getFullName(searchedPlayer)" />
        >
      </datalist>
      <d-input-group-addon append>
        <d-btn outline theme="success" :disabled="selectedPlayer == null" @click="addTournamentEntry">Add</d-btn>
      </d-input-group-addon>
    </d-input-group>
  </div>
</template>

<script lang="ts">
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { BaseComponentClass } from "../../common/BaseComponentClass";
import {
  TournamentEntryClient,
  GetSearchedPlayersArgs
} from "../../Api/TournamentEntryController";
import { NotificationUtils } from "../../common/notification";
import { PlayerDrawDTO } from "@/Api/dtos/PlayerDrawDTO";

@Component
export default class TournamentPlayers extends BaseComponentClass {
  @Prop() readonly TournamentId: number;
  @Prop() readonly AssignedPlayers: PlayerDrawDTO[];
  @Prop({
    default: null
  }) readonly RemoveTournamentEntry: (tournamentEntryId: number) => Promise<boolean>;
  @Prop({
    default: null
  }) readonly AddTournamentEntry: (player: PlayerDrawDTO) => Promise<boolean>;

  player: string = null;
  selectedPlayer: PlayerDrawDTO = null;
  assignedPlayers: PlayerDrawDTO[];
  searchedPlayers: PlayerDrawDTO[] = [];

  getFullName(player: PlayerDrawDTO): string {
    return player.name + " " + player.surname;
  }

  searchPlayers(): void {
    this.selectedPlayer = null;
    if (this.player != null && this.player != "") {
      const client = new TournamentEntryClient();
      this.tryGetDataByArgs<PlayerDrawDTO[], GetSearchedPlayersArgs>({
        apiMethod: client.getSearchedPlayers,
        showError: true,
        requestArgs: { nameSurname: this.player }
      }).then((response) => {
        if (response.ok) this.searchedPlayers = response.data;
      });
    } else {
      this.player = null;
    }
  }

  setSelectedPlayer(event: Event): void {
    const targetValue = (event.target as HTMLInputElement).value;
    const filteredValue = this.searchedPlayers.filter(value => this.getFullName(value).toUpperCase() === targetValue.toUpperCase())[0];
    if (filteredValue != null) {
      this.selectedPlayer = filteredValue;
    }
  }

  addTournamentEntry(): void {
    if (this.AddTournamentEntry != null) {
      if (!this.assignedPlayers.some(p => p.tournamentEntryId == this.selectedPlayer.tournamentEntryId)) {
        this.AddTournamentEntry(this.selectedPlayer).then((result) => {
          if (result) {
            this.selectedPlayer = null;
            this.player = null;
          }
        });
      } else {
        NotificationUtils.ShowErrorMessage("Player already added.");
      }
    }
  }

  removeTournamentEntry(event: MouseEvent): void {
    const id = Number((event.target as HTMLElement).id);
    if (id > 0 && this.RemoveTournamentEntry != null) {
      this.RemoveTournamentEntry(id).then((result) => {
        if (result) {
          this.selectedPlayer = null;
          this.player = null;
        }
      });
    }
  }

  onClickPlayer(player: PlayerDrawDTO): void {
    this.selectedPlayer = player;
  }

  created() {
    if (this.AssignedPlayers) {
      this.assignedPlayers = this.AssignedPlayers;
    } else {
      this.assignedPlayers = [];
    }
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-players.scss";
</style>
