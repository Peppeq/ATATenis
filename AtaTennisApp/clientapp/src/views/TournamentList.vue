<template>
	<div>
		<div>Years</div>
		<d-card v-for="(tournament, index) in tournaments" :key="tournament.id" class="mb-1">
			<d-card-header class="px-3 py-2" role="tab">
				<d-btn v-d-toggle="index.toString()" block-level theme="secondary" href="#">{{
					getMonthName(tournament.StartTime)
				}}</d-btn>
				<!-- <d-btn :aria-controls="index.toString()" block-level theme="secondary" href="#">{{getMonthName(tournament.StartTime) }}</d-btn> -->
			</d-card-header>
			<d-collapse :id="index.toString()" accordion="my-accordion" role="tabpanel">
				<d-card-body>
					<p class="card-text">
						<a href="/tournament/" + tournament.Id>
							{{ getDate(tournament.StartTime) }}
							{{ tournament.Name }}
							{{ tournament.Place }}
							{{ tournament.Category }}
							{{ tournament.TournamentType }}
							{{ tournament.Surface }}
						</a>
					</p>
				</d-card-body>
			</d-collapse>
		</d-card>
	</div>
</template>

<script lang="ts">
import Component from "vue-class-component";
import TournamentClient, { Tournament, TournamentArgs } from "../Api/TournamentController";
import { BaseComponentClass } from "../common/BaseComponentClass";

@Component
export default class TournamentListClass extends BaseComponentClass {
	year: number = new Date().getFullYear();
	tournaments: Tournament[] = [];

	getDate(date: Date): string {
		var dateConverted = new Date(date);
		var options = { weekday: "long", year: "numeric", month: "long", day: "numeric" };
		return dateConverted.toLocaleString("sk-SK", options);
	}

	getMonthName(date: Date): string {
		var dateConverted = new Date(date);
		return dateConverted.toLocaleString("default", { month: "long" });
	}

	async mounted() {
		var _this = this;
		var tournamentClient = new TournamentClient();

		this.tryGetDataByArgs<Tournament[], TournamentArgs>({
			apiMethod: tournamentClient.get,
			showError: true,
			requestArgs: {
				Id: null,
				Year: this.year
			}
		}).then((tournaments: Tournament[]) => {
			if (tournaments != null && tournaments.length > 0) {
				_this.tournaments = tournaments.sort((a, b) => (a.StartTime > b.StartTime ? 1 : -1));
			}
		});
	}
}
</script>
