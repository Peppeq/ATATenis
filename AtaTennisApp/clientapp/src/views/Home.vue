<template>
	<d-container fluid class="main-content-container px-4">
		<div class="page-header row no-gutters py-4"><h2>Welcome to ATA</h2></div>
		<d-row class="px-4 py-2">
			ATAtennis je okruh tenisových turnajov organizovaných pre amatérskych hráčov. Cieľom okruhu je
			sprostredkovať amatérskym tenistom možnosti porovnania výkonnosti na základe rebríčkov, ktoré zahŕňajú
			výsledky turnajov prihlásených do okruhu ATAtennis a hraných podľa týchto pravidiel.
		</d-row>
		<d-row class="px-4 pt-4 pb-2">
			{{ $t("nearestTournament") }}
		</d-row>

		<d-row v-if="nearestTournament != null" class="px-4 py-2">
			<h3>
				<router-link
					:to="{
						name: 'Tournament',
						params: { id: nearestTournament.Id, tournamentProp: nearestTournament }
					}"
					class="text-fiord-blue"
					>{{ nearestTournament.Name }}</router-link
				>
			</h3>
		</d-row>
		<d-row v-else class="p-4">
			{{ $t("noTournament") }}
		</d-row>

		<img alt="nearestTournament" src="../assets/clay.jpg" style="width: 100%" />
		<!-- <HelloWorld msg="Welcome to ATA" /> -->
	</d-container>
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
	nearestTournament: TournamentDTO = null;
	mounted() {
		const client = new TournamentClient();
		this.tryGetDataByArgs<TournamentDTO, null>({
			apiMethod: client.getWithoutParams,
			showError: true,
			requestArgs: null
		}).then(resp => {
			if (resp.ok) this.nearestTournament = resp.data;
		});
	}
}
</script>
