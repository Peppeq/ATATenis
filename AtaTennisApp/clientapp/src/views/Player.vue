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
			<d-col v-if="isBio && player != null" id="player-details" lg="8">
				<d-card
					><d-list-group flush>
						<d-list-group-item>
							<player-bio :player-prop="player"></player-bio>
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
import PlayerBio from "./player/player-bio.vue";

@Component({
	components: { PlayerBio }
})
export default class PlayerView extends BaseComponentClass {
	player: PlayerDTO = null;
	playerId = 0;
	history = 2019;
	yearsPlayed: number[] = [2019, 2017];
	isBio = true;
	isTournament = false;
	results: [] = [];

	onChangeCardType(type: number) {
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

		const client = new PlayerClient();
		this.tryGetDataByArgs<PlayerDTO, PlayerArgs>({
			apiMethod: client.getPlayerById,
			showError: true,
			requestArgs: { Id: this.playerId }
		}).then(response => {
			if (response.ok != null) {
				this.player = response.data;
			}
		});
	}
}
</script>
<style lang="scss" scoped>
@import "@/styles/views/player/player.scss";
</style>
