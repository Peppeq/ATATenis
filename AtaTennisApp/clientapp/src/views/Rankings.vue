<template>
	<d-card class="main-card">
		<d-card-header
			><h2>{{ $t("rankings") }}</h2></d-card-header
		>
		<d-card-body>
			<table class="table mb-0">
				<thead class="bg-light">
					<tr>
						<th scope="col" class="border-0">{{ $t("rank") }}</th>
						<th scope="col" class="border-0">{{ $tc("player", 1) }}</th>
						<th scope="col" class="border-0">{{ $tc("point", 0) }}</th>
					</tr>
				</thead>
				<tbody v-if="players != null && players.length > 0">
					<tr v-for="(player, index) in players" :key="player.id">
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
					</tr>
				</tbody>
			</table>
		</d-card-body>
	</d-card>
</template>

<script lang="ts">
import PlayerClient, { PlayerDTO } from "../Api/PlayerController";
import { Component } from "vue-property-decorator";
import { BaseComponentClass } from "../common/BaseComponentClass";

@Component
export default class RankingsView extends BaseComponentClass {
	players: PlayerDTO[] = [];
	mounted() {
		var client = new PlayerClient();
		console.log(client);

		this.tryGetDataByArgs<PlayerDTO[], null>({
			apiMethod: client.getWithoutParams,
			showError: true,
			requestArgs: null
		}).then(resp => {
			if (resp.ok) {
				this.players = resp.data;
			}
		});
	}
	getPlayerFullname(player: PlayerDTO): string {
		return player.Name + " " + player.Surname;
	}
}
</script>
