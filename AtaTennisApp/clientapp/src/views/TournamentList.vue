<template>
  <div>
    <div>Years</div>
    <d-card v-for="(tournament, index) in tournaments" :key="tournament.id" class="mb-1">
      <d-card-header class="px-3 py-2" role="tab">
        <!-- <d-btn v-d-toggle:[index.toString()] block-level theme="secondary" href="#">{{getMonthName(tournament.StartTime) }}</d-btn> -->
        <d-btn :aria-controls="index.toString()" block-level theme="secondary" href="#">{{getMonthName(tournament.StartTime) }}</d-btn>

      </d-card-header>
      <d-collapse v-bind:id="index.toString()" accordion="my-accordion" role="tabpanel">
        <d-card-body>
          <p
            class="card-text"
          >Nullam augue tortor, viverra id gravida fermentum, posuere a libero. Curabitur at arcu tortor. Donec cursus blandit leo consequat convallis.</p>
        </d-card-body>
      </d-collapse>
    </d-card>
  </div>
</template>

<script lang="ts">
  import Vue from "vue";
  import Component from "vue-class-component";
  import TournamentClient, {
    Tournament,
    TournamentArgs
  } from "../Api/TournamentController";
  import { BaseComponentClass } from "../common/BaseComponentClass";
  import { NotificationUtils } from "../common/notification";

  @Component
  export default class TournamentListClass extends BaseComponentClass {
    year: number = new Date().getFullYear();
    tournaments: Tournament[] = [];

    getMonthName(date: Date): string {
		var dateConverted = new Date(date);
      return dateConverted.toLocaleString("default", { month: "long" });
	}
	
	getAccordionIndex(index: string): string {
		return `v-d-toggle.{index}`;
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
          _this.tournaments = tournaments.sort((a, b) => (a.StartTime > b.StartTime) ? 1 : -1);
        }
      });
    }
  }
</script>