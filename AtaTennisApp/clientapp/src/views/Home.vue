<template>
	<div class="main-content-container container-fluid">
		<d-card-header class="main-header"><h2>Welcome to ATA</h2></d-card-header>
		<d-card-body class="main-body">
			<d-row>
				ATAtennis je okruh tenisových turnajov organizovaných pre amatérskych hráčov. Cieľom okruhu je
				sprostredkovať amatérskym tenistom možnosti porovnania výkonnosti na základe rebríčkov, ktoré zahŕňajú
				výsledky turnajov prihlásených do okruhu ATAtennis a hraných podľa týchto pravidiel.
			</d-row>
			<d-row>
				<h3>Najbližší turnaj</h3>
				<div>
					{{ nearestTounrament != null ? nearestTounrament.Name : "" }}
				</div>
			</d-row>
		</d-card-body>
		<div>asdf</div>
		<img alt="Vue logo" src="../assets/logo.png" />
		<HelloWorld msg="Welcome to ATA" />
	</div>
</template>

<script lang="ts">
import { Component } from "vue-property-decorator";
import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src
import TournamentClient, { TournamentDTO } from "../Api/TournamentController";
import { BaseComponentClass } from "../common/BaseComponentClass";

@Component({
	components: {
		HelloWorld
	}
})
export default class Home extends BaseComponentClass {
	nearestTounrament: TournamentDTO = null;
	mounted() {
		var client = new TournamentClient();
		this.tryGetDataByArgs<TournamentDTO, null>({
			apiMethod: client.getWithoutParams,
			showError: true,
			requestArgs: null
		}).then((tournament: TournamentDTO) => {
			this.nearestTounrament = tournament;
		});
	}
}
</script>
