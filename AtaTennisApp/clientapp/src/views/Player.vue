<template>
	<d-row>
		{{ player.Name }}
	</d-row>
</template>

<script lang="ts">
import { BaseComponentClass } from "../common/BaseComponentClass";
import Component from "vue-class-component";
import PlayerClient, { PlayerDTO } from "@/Api/PlayerController";

@Component
export default class PlayerView extends BaseComponentClass {
	player: PlayerDTO = null;
	playerId: number = 0;

	mounted() {
		console.log("mounted");
		this.playerId = parseInt(this.$route.params.id, 10);

		var client = new PlayerClient();
		// todo fix parameter on API controller
		// this.tryGetDataByArgs<PlayerDTO, number>({
		// 	apiMethod: client.getPlayerById,
		// 	showError: true,
		// 	requestArgs: { this.playerId}
		// }).then(player => {
		// 	if (player != null) {
		// 		this.player = player;
		// 	}
		// });
	}
}
</script>
