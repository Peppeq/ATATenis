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
				<tbody v-for="(player, index) in players" :key="player.id">
					<tr>
						<td>{{ index + 1 }}</td>
						<td>{{ getPlayerFullname(player) }}</td>
						<td>{{ player.Points }}</td>
					</tr>
				</tbody>
			</table>
		</d-card-body>
	</d-card>
</template>

<script lang="ts">
import PlayerClient, { Player, PlayerResponse, PlayerArgs } from "../Api/PlayerController";
import { Component } from "vue-property-decorator";
import { BaseComponentClass } from "../common/BaseComponentClass";

@Component
export default class PlayersView extends BaseComponentClass {
	players: Player[] = [];
	async mounted() {
		var client = new PlayerClient();
		console.log(client);

		this.tryGetDataByArgs<PlayerResponse, PlayerArgs>({
			apiMethod: client.get,
			showError: true,
			requestArgs: { Id: null, Count: 10, Ranking: true }
		}).then(result => {
			if (result != null) {
				this.players = result.Players;
			}
		});
	}
	getPlayerFullname(player: Player): string {
		return player.Name + " " + player.Surname;
	}
}
</script>
