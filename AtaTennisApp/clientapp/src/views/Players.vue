<template>
	<div>
		<h1>List of Players</h1>
		<div v-for="(player, index) in players" :key="player.id">
			<div>
				<label>{{ index }}.</label>
				{{ player.Name }}
			</div>
		</div>
	</div>
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
}
</script>
