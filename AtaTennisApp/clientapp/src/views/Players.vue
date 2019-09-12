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
import PlayerClient, { Player, PlayerResponse } from "../Api/PlayerController";
import { Component } from "vue-property-decorator";
import { BaseComponentClass } from "../common/BaseComponentClass";

@Component
export default class PlayersView extends BaseComponentClass {
	players: Player[] = [];
	async mounted() {
		var client = new PlayerClient();
		console.log(client);

		this.tryGetDataByArgs<PlayerResponse, void>({
			apiMethod: client.getWithoutParams,
			showError: true,
			requestArgs: null
		}).then(result => {
			if (result != null) {
				this.players = result.Players;
			}
		});
	}
}
</script>
