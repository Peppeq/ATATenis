<template>
	<d-card class="main-card">
		<d-row>
			<d-col>
				<d-card>
					<!--<img src="http://localhost/wwwclientapp/src/assets/images/300x200.gif">-->
					<d-card-img
						src="http://images.sportspromedia.com/images/made/images/uploads/news/tennis_grass_court_generic_630_354_80_s_c1.jpg"
					/>
				</d-card>
			</d-col>
			<d-col v-if="tournament != null">
				<d-card-header>{{ tournament.Name }}</d-card-header>
				<d-card-body>
					<p>blaaa</p>
					<p>asf</p>
				</d-card-body>
				<d-card-footer>Card footer</d-card-footer>
			</d-col>
		</d-row>
	</d-card>
</template>

<script lang="ts">
import Component from "vue-class-component";
import TournamentClient, { TournamentDTO, TournamentFilter } from "../Api/TournamentController";
import { BaseComponentClass } from "../common/BaseComponentClass";
import { Watch, Prop } from "vue-property-decorator";
import { router } from "@/router";

@Component
export default class TournamentClass extends BaseComponentClass {
	tournament?: TournamentDTO = null;
	tournamentId: number = 0;

	@Prop() tournamentProp?: TournamentDTO;

	async mounted() {
		var _this = this;
		console.log("tour was mounted");
		var tournamentClient = new TournamentClient();
		//natiahnut data z bekendu ...

		if (this.tournamentProp == null) {
			this.tournamentId = parseInt(this.$route.params.id, 10);
			this.tryGetDataByArgs<TournamentDTO[], TournamentFilter>({
				apiMethod: tournamentClient.get,
				showError: true,
				requestArgs: {
					Id: this.tournamentId,
					Year: 0,
					Type: null
				}
			}).then((tournament: TournamentDTO[]) => {
				if (tournament != null && tournament.length > 0) {
					_this.tournament = tournament[0];
				}
			});
		} else {
			console.log("yeah");
			this.tournament = this.tournamentProp;
		}
	}

	@Watch("$route")
	onUrlChange(to: string) {
		router.push(to);
	}
}
</script>
