<template>
  <d-container fluid class="main-content-container px-4">
    <d-row class="px-4 py-2">
      <h4>Edit Player</h4>
    </d-row>
    <d-row class="p-4">
      <d-input-group class="mb-3" seamless>
        <!-- <d-input-group-text slot="prepend">
					<i class="material-icons">search</i>
					<i class="fas fa-search"></i>
				</d-input-group-text> -->

        <div class="input-group-prepend">
          <div class="input-group-text"><i class="fas fa-search"></i></div>
        </div>
        <input v-model="searchName" class="navbar-search form-control" type="text" @keyup="searchPlayerByNameSurname" />
      </d-input-group>
      <d-list-group v-if="searchedPlayers != null">
        <div v-for="player in searchedPlayers" :key="player.id" class="list-group-item" @click="addOrEditPlayer(player)">
          {{ player.name + " " + player.surname }}
        </div>
      </d-list-group>
      <d-list-group v-else>
        No players founded
      </d-list-group>
    </d-row>

    <d-row class="p-4">
      <d-button @click="addOrEditPlayer(null)">Add player</d-button>
    </d-row>
    <player-add-modal :show-modal="showAddPlayerModal" :hide-modal="hideAddPlayerModal" :player="player" :modify-player="modifySearchedPlayer"></player-add-modal>
  </d-container>
</template>

<script lang="ts">
import { BaseComponentClass } from "../../common/BaseComponentClass";
import Component from "vue-class-component";
import PlayerAddModal from "../player/player-add-modal.vue";
import {
  PlayerClient,
  PlayerSearchArgs
} from "../../Api/PlayerController";
import { PlayerDTO } from "@/Api/dtos/PlayerDTO";

@Component({
  components: { PlayerAddModal }
})
export default class PlayerManagement extends BaseComponentClass {
  showAddPlayerModal = false;
  searchName: string = null;
  searchedPlayers: PlayerDTO[] = [];
  player: PlayerDTO = null;

  searchPlayerByNameSurname(): void {
    if (this.searchName != null && this.searchName != "") {
      console.log("event triggered " + this.searchName);
      const client = new PlayerClient();
      this.tryGetDataByArgs<PlayerDTO[], PlayerSearchArgs>({
        apiMethod: client.playerBySearch,
        showError: true,
        requestArgs: { searchName: this.searchName }
      }).then((resp) => {
        if (resp.ok) this.searchedPlayers = resp.data;
      });
    } else {
      this.searchName = "";
      this.searchedPlayers = null;
    }
  }

  hideAddPlayerModal(): void {
    this.showAddPlayerModal = false;
  }

  addOrEditPlayer(player: PlayerDTO): void {
    this.player = player;
    this.showAddPlayerModal = true;
  }

  modifySearchedPlayer(player: PlayerDTO): void {
    const index = this.searchedPlayers.findIndex(p => p.id == player.id);
    this.searchedPlayers[index] = player;
  }
}
</script>

<style></style>
