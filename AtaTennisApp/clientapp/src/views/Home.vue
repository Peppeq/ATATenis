<template>
	<d-card class="main-card">
		<d-card-header><h2>Welcome to ATA</h2></d-card-header>
		<d-card-body>
			<d-row>
				ATAtennis je okruh tenisových turnajov organizovaných pre amatérskych hráčov. Cieľom okruhu je
				sprostredkovať amatérskym tenistom možnosti porovnania výkonnosti na základe rebríčkov, ktoré zahŕňajú
				výsledky turnajov prihlásených do okruhu ATAtennis a hraných podľa týchto pravidiel.
			</d-row>
			<d-row>
				<h3>Najbližší turnaj</h3>
			</d-row>
		</d-card-body>
		<img alt="Vue logo" src="../assets/logo.png" />
		<HelloWorld msg="Welcome to ATA" />
	</d-card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src

@Component({
	components: {
		HelloWorld
	}
})
export default class Home extends Vue {}
</script>
