<template>
	<d-card class="main-card">
		<d-card-body>
			<d-row class="row justify-content-start">
				<d-col cols="12" sm="4" lg="2">
					<label>{{ $t("year") }}</label>
					<d-form-select v-model="year" :options="years" class="year-select" @change="onChangeYear($event)" />
				</d-col>
				<d-col cols="12" sm="6" lg="4">
					<label>{{ $t("type") }}</label>
					<d-form-select
						v-model="selectedTournamentType"
						:options="tournamentTypes"
						class="tournament-type-select"
						@change="onChangeTournamentType($event)"
					/>
				</d-col>
			</d-row>
		</d-card-body>
		<d-card-body>
			<div>{{ $t("calendar") }}</div>
			<div v-if="tournaments != null && tournaments.length > 0">
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
								<a :href="'/tournament/' + tournament.Id">
									{{ getDate(tournament.StartTime) }}
									{{ tournament.Name }}
									{{ tournament.Place }}
									{{ helpers.GetTournamentCategoryName(tournament.Category) }}
									{{ helpers.GetTournamentTypeName(tournament.TournamentType) }}
									{{ helpers.GetTournamentSurfaceName(tournament.Surface) }}
								</a>
							</p>
						</d-card-body>
					</d-collapse>
				</d-card>
			</div>
			<div v-else>
				No tournaments.
			</div>
		</d-card-body>
	</d-card>
</template>

<script lang="ts">
import Component from "vue-class-component";
import TournamentClient, { Tournament, TournamentArgs, TournamentType } from "@/Api/TournamentController";
import { BaseComponentClass } from "../common/BaseComponentClass";
import {
	GetTournamentTypeName,
	GetTournamentCategoryName,
	GetTournamentSurfaceName,
	TournamentHelperClass
} from "../views/tournament/tournamentHelper";
import { i18n } from "../plugins/i18n";
import { Watch } from "vue-property-decorator";

interface TournamentTypeObjExtended {
	value: number;
	text: string;
}

@Component
export default class TournamentListClass extends BaseComponentClass {
	year: number = new Date().getFullYear();
	years: number[] = [];
	tournamentTypes: TournamentTypeObjExtended[] = [];
	selectedTournamentType: TournamentType = null;

	tournaments: Tournament[] = [];

	helpers = {
		GetTournamentTypeName,
		GetTournamentCategoryName,
		GetTournamentSurfaceName
	};

	getDate(date: Date): string {
		var dateConverted = new Date(date);
		var options = { weekday: "long", year: "numeric", month: "long", day: "numeric" };
		return dateConverted.toLocaleString("sk-SK", options);
	}

	getMonthName(date: Date): string {
		var dateConverted = new Date(date);
		return dateConverted.toLocaleString(i18n.locale.toString(), { month: "long" });
	}

	getYears(): void {
		for (let index = this.year; index >= 2017; index--) {
			this.years.push(index);
		}
	}

	onChangeYear(year: number) {
		this.year = year;
		this.getTournaments();
	}

	onChangeTournamentType(tournamentType: TournamentType) {
		this.selectedTournamentType = tournamentType;
		this.getTournaments();
	}

	setTournamentTypeOptions() {
		this.tournamentTypes = TournamentHelperClass.GetTournamentTypes();
		this.tournamentTypes.push({
			value: null,
			text: i18n.t("all").toString()
		});
	}

	getTournaments() {
		var _this = this;
		var tournamentClient = new TournamentClient();

		this.tryGetDataByArgs<Tournament[], TournamentArgs>({
			apiMethod: tournamentClient.get,
			showError: true,
			requestArgs: {
				Id: null,
				Year: this.year,
				Type: this.selectedTournamentType
			}
		}).then((tournaments: Tournament[]) => {
			_this.tournaments = tournaments;
			if (this.tournaments != null && this.tournaments.length > 0) {
				_this.tournaments = tournaments.sort((a, b) => (a.StartTime > b.StartTime ? 1 : -1));
			}
		});
	}

	// better way to translate computed values
	@Watch("$i18n.locale")
	onLocaleChanged() {
		this.setTournamentTypeOptions();
	}

	mounted() {
		this.getYears();
		this.setTournamentTypeOptions();
		this.selectedTournamentType = this.tournamentTypes[5].value;
		this.getTournaments();
	}
}
</script>
<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-list.scss";
</style>
