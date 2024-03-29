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
						:options="tournamentHelper.GetTournamentTypesWithAll()"
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
							getMonthName(tournament.startTime)
						}}</d-btn>
						<!-- <d-btn :aria-controls="index.toString()" block-level theme="secondary" href="#">{{getMonthName(tournament.StartTime) }}</d-btn> -->
					</d-card-header>
					<d-collapse :id="index.toString()" accordion="my-accordion" role="tabpanel">
						<d-card-body>
							<p class="card-text">
								<a :href="'/tournament/' + tournament.id">
									{{ getDate(tournament.startTime) }}
									{{ tournament.name }}
									{{ tournament.place }}
									{{ tournamentHelper.GetTournamentCategoryName(tournament.category) }}
									{{ tournamentHelper.GetTournamentTypeName(tournament.tournamentType) }}
									{{ tournamentHelper.GetTournamentSurfaceName(tournament.surface) }}
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
import {
  TournamentClient
} from "@/Api/TournamentController";
import { BaseComponentClass } from "../common/BaseComponentClass";
import { TournamentHelper } from "../views/tournament/tournamentHelper";
import { i18n } from "../plugins/i18n";
import { TournamentType } from "@/Api/enums/TournamentType";
import { TournamentDTO } from "@/Api/dtos/TournamentDTO";
import { TournamentFilterDTO } from "@/Api/dtos/TournamentFilterDTO";

@Component
export default class TournamentListClass extends BaseComponentClass {
	year: number = new Date().getFullYear();
	years: number[] = [];
	selectedTournamentType: TournamentType = null;
	tournaments: TournamentDTO[] = [];
	tournamentHelper = TournamentHelper;

	getDate(date: Date): string {
	  const dateConverted = new Date(date);
	  const options = {
	    weekday: "long",
	    year: "numeric",
	    month: "long",
	    day: "numeric"
	  };
	  return dateConverted.toLocaleString("sk-SK", options);
	}

	getMonthName(date: Date): string {
	  const dateConverted = new Date(date);
	  return dateConverted.toLocaleString(i18n.locale.toString(), {
	    month: "long"
	  });
	}

	getYears(): void {
	  for (let index = this.year; index >= 2017; index--) {
	    this.years.push(index);
	  }
	}

	onChangeYear(year: number): void {
	  this.year = year;
	  this.getTournaments();
	}

	onChangeTournamentType(tournamentType: TournamentType): void {
	  this.selectedTournamentType = tournamentType;
	  this.getTournaments();
	}

	getTournaments(): void {
	  const tournamentClient = new TournamentClient();

	  this.tryGetDataByArgs<TournamentDTO[], TournamentFilterDTO>({
	    apiMethod: tournamentClient.get,
	    showError: true,
	    requestArgs: {
	      id: null,
	      year: this.year,
	      type: this.selectedTournamentType
	    }
	  }).then((resp) => {
	    if (resp.ok) {
	      this.tournaments = resp.data;
	      // if (this.tournaments != null && this.tournaments.length > 0) {
	      // 	_this.tournaments = tournaments.sort((a, b) => (a.StartTime > b.StartTime ? 1 : -1));
	      // }
	    }
	  });
	}

	mounted(): void {
	  this.getYears();
	  this.selectedTournamentType = TournamentHelper.GetTournamentTypesWithAll()[5].value;
	  this.getTournaments();
	}
}
</script>
<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-list.scss";
</style>
