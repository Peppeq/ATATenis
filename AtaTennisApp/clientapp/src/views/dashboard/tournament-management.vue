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
				</d-input-group-text> -->

				<div class="input-group-prepend">
					<div class="input-group-text"><i class="fas fa-search"></i></div>
				</div>
				<input
					v-model="searchName"
					class="navbar-search form-control"
					type="text"
					@keyup="searchTournamentByName"
				/>
			</d-input-group>
			<d-list-group v-if="searchedTournaments != null">
				<div
					v-for="tournament in searchedTournaments"
					:key="tournament.id"
					class="list-group-item"
					@click="addOrEditTournament(tournament)"
				>
					{{ tournament.Name + " " + tournament.StartTime }}
				</div>
			</d-list-group>
			<d-list-group v-else>
				No tournaments founded
			</d-list-group>
		</d-row>

		<d-row class="p-4">
			<d-button @click="addOrEditTournament(null)">Add tournament</d-button>
		</d-row>
		<tournament-modal
			:show-modal="showTournamentModal"
			:hide-modal="hideTournamentModal"
			:tournament="tournament"
			:modify-tournament="modifySearchedTournament"
		></tournament-modal>
	</d-container>
</template>

<script lang="ts">
import { BaseComponentClass } from "../../common/BaseComponentClass";
import Component from "vue-class-component";
import TournamentModal from "../tournament/TournamentModal.vue";
import TournamentClient, { TournamentDTO, TournamentByNameArgs } from "@/Api/TournamentController";

@Component({
	components: { TournamentModal }
})
export default class TournamentManagement extends BaseComponentClass {
	showTournamentModal: boolean = false;
	searchName: string = null;
	searchedTournaments: TournamentDTO[] = [];
	tournament: TournamentDTO = null;

	searchTournamentByName() {
		if (this.searchName != null) {
			console.log("event triggered " + this.searchName);
			var client = new TournamentClient();
			this.tryGetDataByArgs<TournamentDTO[], TournamentByNameArgs>({
				apiMethod: client.getTournamentByName,
				showError: true,
				requestArgs: { Name: this.searchName }
			}).then(response => {
				if (response.ok) this.searchedTournaments = response.data;
			});
		} else {
			this.searchName = "";
			this.searchedTournaments = null;
		}
	}

	hideTournamentModal() {
		this.showTournamentModal = false;
	}

	addOrEditTournament(tournament: TournamentDTO) {
		console.log("add or edit player called");
		this.tournament = tournament;
		this.showTournamentModal = true;
	}

	modifySearchedTournament(tournament: TournamentDTO): void {
		var index = this.searchedTournaments.findIndex(p => p.Id == tournament.Id);
		this.searchedTournaments[index] = tournament;
	}
}
</script>

<style></style>
