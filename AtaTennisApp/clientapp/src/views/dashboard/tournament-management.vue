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
					v-for="searchedTournament in searchedTournaments"
					:key="searchedTournament.TournamentId"
					class="list-group-item fake-link"
					@click="editTournament(searchedTournament.TournamentId)"
				>
					{{ searchedTournament.Name + " " + searchedTournament.StartTime }}
				</div>
			</d-list-group>
			<d-list-group v-else-if="searchedTournaments != null && searchedTournaments.length > 0">
				No tournaments founded
			</d-list-group>
		</d-row>
		<d-card v-if="selectedTour != null" class="px-4 py-2">
			<d-tabs card>
				<d-tab title="Details" active>
					<tournament-details :tournament-prop="selectedTour" :is-create-or-edit="true"></tournament-details>
				</d-tab>
				<d-tab title="Players">
					<tournament-players
						:tournament-id="selectedTour.Id"
						:assigned-players="assignedPlayers"
						:remove-tournament-entry="removeTournamentEntry"
						:add-tournament-entry="addTournamentEntry"
					></tournament-players>
				</d-tab>
				<d-tab title="Draw">
					<tournament-draw />
				</d-tab>
			</d-tabs>
		</d-card>
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
import TournamentDetails from "../tournament/TournamentDetails.vue";
import TournamentDraw from "../tournament/TournamentDraw.vue";
import TournamentPlayers from "../tournament/TournamentPlayers.vue";
import TournamentClient, {
	TournamentDTO,
	SearchedTournamentByNameArgs,
	SearchedTournamentDTO,
	TournamentPlayersDTO,
	TournamentPlayersArgs
} from "@/Api/TournamentController";
import TournamentEntryClient, {
	PlayerDrawDTO,
	GetPlayersArgs,
	DeletePlayerArgs,
	TournamentEntry,
	PlayerArgs
} from "@/Api/TournamentEntryController";

@Component({
	components: { TournamentModal, TournamentDetails, TournamentDraw, TournamentPlayers }
})
export default class TournamentManagement extends BaseComponentClass {
	showTournamentModal = false;
	searchName: string = null;
	searchedTournaments: SearchedTournamentDTO[] = [];
	// searchedTournament: SearchedTournamentDTO = null;
	tournament: TournamentDTO = null;
	selectedTournament: TournamentDTO = null;
	assignedPlayers: PlayerDrawDTO[] = [];

	get selectedTour(): TournamentDTO {
		return this.selectedTournament;
	}

	set selectedTour(tournament: TournamentDTO) {
		this.selectedTournament = tournament;
	}

	searchTournamentByName(): void {
		if (this.searchName != null && this.searchName != "") {
			console.log("event triggered " + this.searchName);
			const client = new TournamentClient();
			this.tryGetDataByArgs<SearchedTournamentDTO[], SearchedTournamentByNameArgs>({
				apiMethod: client.getSearchedTournamentsByName,
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

	getAssignedPlayers(): void {
		const client = new TournamentEntryClient();
		this.tryGetDataByArgs<PlayerDrawDTO[], GetPlayersArgs>({
			apiMethod: client.tournamentPlayers,
			showError: true,
			requestArgs: { TournamentId: this.selectedTournament.Id }
		}).then(response => {
			if (response.ok) {
				this.assignedPlayers = response.data;
			}
		});
	}

	async addTournamentEntry(player: PlayerDrawDTO): Promise<boolean> {
		let result = false;
		const client = new TournamentEntryClient();
		await this.tryGetDataByArgs<TournamentEntry, PlayerArgs>({
			apiMethod: client.addTournamentPlayer,
			showError: true,
			requestArgs: { TournamentId: this.selectedTournament.Id, PlayerId: player.PlayerId }
		}).then(response => {
			result = response.ok;
			if (response.ok) {
				player.TournamentEntryId = response.data.Id;
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
				requestArgs: { TournamentEntryId: tournamentId }
			}).then(response => {
				if (response.ok) {
					this.assignedPlayers = this.assignedPlayers.filter(p => p.TournamentEntryId != tournamentId);
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
			this.tryGetDataByArgs<TournamentPlayersDTO, TournamentPlayersArgs>({
				apiMethod: client.getTournamentPlayers,
				showError: true,
				requestArgs: { TournamentId: tournamentId }
			}).then(response => {
				if (response.ok) {
					this.assignedPlayers = response.data.Players;
					this.selectedTour = response.data.Tournament;
					this.searchedTournaments = null;
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
		const index = this.searchedTournaments.findIndex(p => p.TournamentId == tournament.Id);
		this.searchedTournaments[index] = {
			TournamentId: tournament.Id,
			Name: tournament.Name,
			StartTime: tournament.StartTime
		};
	}
}
</script>

<style></style>
