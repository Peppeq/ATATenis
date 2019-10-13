<template>
	<d-container fluid class="main-content-container px-4">
		<d-row no-gutters class="page-header py-4">
			<d-col col sm="4" class="text-center text-sm-left mb-4 mb-sm-0">
				<h3 class="page-title">User Profile</h3>
			</d-col>
		</d-row>
		<!-- <div v-if="player != null">
			{{ player.Name }}
		</div> -->

		<!-- Content -->
		<d-row>
			<d-col lg="4">
				<d-card v-if="player != null">
					<!-- Card Header -->
					<d-card-header class="border-bottom text-center">
						<!-- User Avatar -->
						<div class="mb-3 mx-auto">
							<img class="rounded-circle" src="../assets/rog.jpg" :alt="player.Name" width="200" />
						</div>

						<!-- User Name -->
						<h4 class="mb-0">{{ player.Name + " " + player.Surname }}</h4>
					</d-card-header>
					<d-list-group flush>
						<!-- User Performance Report -->
						<d-list-group-item class="px-4">
							<div class="progress-wrapper">
								<strong class="text-muted d-block mb-2">{{ "win/loss" }}</strong>
								<d-progress class="progress-sm">
									<span class="progress-value">{{ "75" }}%</span>
									<d-progress-bar :max="100" :value="60" />
								</d-progress>
							</div>
						</d-list-group-item>
						<d-list-group-item class="px-4">
							<strong class="text-muted d-block mb-2">{{ "current ranking" }}</strong>
							<d-form-input id="ranking" :plaintext="true" :value="5" />
						</d-list-group-item>
						<span class="fake-link">
							<d-list-group-item class="px-4" :class="{ 'bg-light border border-dark': isBio }">
								<div @click="onChangeCardType(0, $event)">
									<strong class="text-muted d-block mb-2 fake-link">{{ $t("bio") }}</strong>
								</div>
							</d-list-group-item>
						</span>
						<span class="fake-link">
							<d-list-group-item class="px-4" :class="{ 'bg-light border border-dark': isTournament }">
								<div @click="onChangeCardType(1, $event)">
									<strong class="text-muted d-block mb-2 fake-link">{{
										$tc("tournament", 2)
									}}</strong>
								</div>
							</d-list-group-item>
						</span>
					</d-list-group>
				</d-card>
			</d-col>
			<d-col v-if="isBio" id="player-details" lg="8">
				<d-card v-if="player != null">
					<d-list-group flush>
						<d-list-group-item>
							<d-form>
								<d-form-row>
									<!-- Age -->
									<d-col md="6" class="form-group">
										<label for="age">{{ $t("age") }}</label>
										<d-form-input
											id="age"
											:readonly="true"
											:value="player.Age"
											class="player-input"
										/>
									</d-col>

									<!-- residence -->
									<d-col md="6" class="form-group">
										<label for="residence">{{ $t("residence") }}</label>
										<!-- <d-form-input id="residence" :readonly="true" :value="player.Residence" /> -->
										<d-form-input
											id="residence"
											:readonly="true"
											:value="player.Residence"
											class="player-input"
										/>
									</d-col>
								</d-form-row>

								<d-form-row>
									<!-- Height -->
									<d-col md="6" class="form-group">
										<label for="height">{{ $t("height") }}</label>
										<d-form-input
											id="height"
											:readonly="true"
											:value="player.Height"
											class="player-input"
										/>
									</d-col>

									<!-- Weight -->
									<d-col md="6" class="form-group">
										<label for="weight">{{ $t("weight") }}</label>
										<d-form-input
											id="weight"
											:readonly="true"
											:value="player.Weight"
											class="player-input"
										/>
									</d-col>
								</d-form-row>

								<d-form-row>
									<!-- Forehand -->
									<d-col md="6" class="form-group">
										<label for="forehand">Forehand</label>
										<d-form-input
											id="forehand"
											:readonly="true"
											:value="player.Forehand"
											class="player-input"
										/>
									</d-col>

									<!-- Backhand -->
									<d-col md="6" class="form-group">
										<label for="Backhand">Backhand</label>
										<d-form-input
											id="Backhand"
											:readonly="true"
											:value="player.Backhand"
											class="player-input"
										/>
									</d-col>
								</d-form-row>

								<d-form-row>
									<!-- Favourite Surface -->
									<d-col md="6" class="form-group">
										<label for="favSurface">{{ $t("favSurface") }}</label>
										<d-form-input
											id="favSurface"
											:readonly="true"
											:value="player.Surface"
											class="player-input"
										/>
									</d-col>

									<!-- Favourite Atp Player -->
									<d-col md="6" class="form-group">
										<label for="favAtpPlayer">{{ $t("favAtpPlayer") }}</label>
										<d-form-input
											id="favAtpPlayer"
											:readonly="true"
											:value="player.FavouritePlayer"
											class="player-input"
										/>
									</d-col>
								</d-form-row>
								<d-form-row>
									<!-- Titels -->
									<d-col md="6" class="form-group">
										<label for="titles">{{ $tc("title", 2) }}</label>
										<d-form-input
											id="titles"
											:readonly="true"
											:value="player.TitlesCount"
											class="player-input"
										/>
									</d-col>

									<!-- Finalist -->
									<d-col md="6" class="form-group">
										<label for="finalist">{{ $t("finalist") }}</label>
										<d-form-input
											id="finalist"
											:readonly="true"
											:value="player.FinalistCount"
											class="player-input"
										/>
									</d-col>
								</d-form-row>
								<d-form-row>
									<!-- tournaments -->
									<d-col md="6" class="form-group">
										<label for="tournaments">{{ $tc("tournament", 2) }}</label>
										<d-form-input
											id="tournaments"
											:readonly="true"
											:value="player.TournamentCount"
											class="player-input"
										/>
									</d-col>

									<!-- racquet -->
									<d-col md="6" class="form-group">
										<label for="racquet">{{ $t("racquet") }}</label>
										<d-form-input
											id="racquet"
											:readonly="true"
											:value="player.Racquet"
											class="player-input"
										/>
									</d-col>
								</d-form-row>
							</d-form>
						</d-list-group-item>
					</d-list-group>
				</d-card>
			</d-col>
			<d-col v-else-if="isTournament" id="player-details" lg="8">
				<d-card v-if="player != null">
					<d-list-group flush>
						<d-list-group-item class="px-4">
							<d-row>
								<d-col sm="3"
									><label for="tournament-history-select">{{ $tc("year", 1) }}</label></d-col
								>
								<d-col sm="9"
									><d-form-select
										v-model="history"
										:options="yearsPlayed"
										class="tournament-history-select"
										@change="onChangeHistory($event)"
									></d-form-select
								></d-col>
							</d-row>
						</d-list-group-item>

						<d-list-group-item class="px-4">
							<table class="table mb-0">
								<thead class="bg-light">
									<tr>
										<th scope="col" class="border-0">{{ "Turnaj name" }}</th>
									</tr>
								</thead>
								<tbody v-if="results != null && results.length > 0">
									<!-- <tr v-for="(player, index) in players" :key="player.id">
						<td>{{ index + 1 }}</td>
						<td>
							<router-link
								:to="{
									name: 'Player',
									params: { id: player.Id, testProp: null }
								}"
								class="text-fiord-blue"
								>{{ getPlayerFullname(player) }}</router-link
							>
						</td>
						<td>{{ player.Points }}</td>
					</tr> -->
									abc
								</tbody>
							</table>
						</d-list-group-item>
					</d-list-group>
				</d-card>
			</d-col>
		</d-row>
	</d-container>
</template>

<script lang="ts">
import { BaseComponentClass } from "../common/BaseComponentClass";
import Component from "vue-class-component";
import PlayerClient, { PlayerDTO, PlayerArgs } from "@/Api/PlayerController";

@Component
export default class PlayerView extends BaseComponentClass {
	player: PlayerDTO = null;
	playerId: number = 0;
	history: number = 2019;
	yearsPlayed: number[] = [2019, 2017];
	isBio: boolean = true;
	isTournament: boolean = false;
	results: [] = [];

	onChangeCardType(type: number, event: Event) {
		if (type == 0) {
			this.isBio = true;
			this.isTournament = false;
		} else if (type == 1) {
			this.isTournament = true;
			this.isBio = false;
		}
	}

	mounted() {
		console.log("mounted");
		this.playerId = parseInt(this.$route.params.id, 10);

		var client = new PlayerClient();
		this.tryGetDataByArgs<PlayerDTO, PlayerArgs>({
			apiMethod: client.getPlayerById,
			showError: true,
			requestArgs: { Id: this.playerId }
		}).then(player => {
			if (player != null) {
				this.player = player;
			}
		});
	}
}
</script>
<style lang="scss" scoped>
@import "@/styles/views/player/player.scss";
</style>
