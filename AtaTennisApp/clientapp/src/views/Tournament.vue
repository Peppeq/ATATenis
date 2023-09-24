<template>
	<d-container v-if="tournament != null" fluid class="main-content-container px-4">
		<d-card class="mt-4">
			<d-row>
				<d-col class="tournament-details no-padding-right" lg="4">
					<!-- <d-card><d-list-group flush>
						<d-list-group-item>
							blaa
						</d-list-group-item>
					</d-list-group> </d-card> -->
					<div class="tournament-header m-auto">
						<div class="text-center text-nowrap">
							<h4>{{ getStarttimeText(tournament.startTime) }}</h4>
							<h2>{{ tournament.name }}</h2>
							<h4>{{ tournament.place }}</h4>
						</div>
					</div>
					<div class="tournament-options">
						<d-list-group flush>
							<span class="fake-link">
								<d-list-group-item class="px-4 border border-dark" :class="{ 'bg-light ': isDetails }">
									<div @click="onChangeCardType(0, $event)">
										<strong class="text-muted d-block mb-2 fake-link">{{
											$tc("detail", 2)
										}}</strong>
									</div>
								</d-list-group-item>
							</span>
							<span class="fake-link">
								<d-list-group-item class="px-4 border border-dark" :class="{ 'bg-light': isDraw }">
									<div @click="onChangeCardType(1, $event)">
										<strong class="text-muted d-block mb-2 fake-link">{{ $t("draw") }}</strong>
									</div>
								</d-list-group-item>
							</span>
						</d-list-group>
					</div>
				</d-col>

				<d-col lg-8 class="no-padding-left">
					<div class="tournament-image"></div>
				</d-col>
			</d-row>
		</d-card>
		<d-card class="mt-4">
			<d-list-group flush>
				<d-list-group-item>
					<tournament-details v-if="isDetails" :tournament-prop="tournament" />
					<tournament-draw v-if="isDraw" />
				</d-list-group-item>
			</d-list-group>
		</d-card>
	</d-container>
</template>

<script lang="ts">
import Component from "vue-class-component";
import {
	TournamentClient
} from "@/Api/TournamentController";
import { BaseComponentClass } from "../common/BaseComponentClass";
import { Watch, Prop } from "vue-property-decorator";
import { router } from "@/router";
import { DateHelper } from "@/common/DateHelper";
import TournamentDetails from "./tournament/TournamentDetails.vue";
import TournamentDraw from "./tournament/TournamentDraw.vue";
import { TournamentDTO } from "@/Api/dtos/TournamentDTO";
import { TournamentFilterDTO } from "@/Api/dtos/TournamentFilterDTO";

@Component({
  components: { TournamentDetails, TournamentDraw }
})
export default class TournamentClass extends BaseComponentClass {
	tournament?: TournamentDTO = null;
	tournamentId = 0;
	isDetails = true;
	isDraw = false;

	@Prop() tournamentProp?: TournamentDTO;

	getStarttimeText(date: Date): string {
	  return date != null ? DateHelper.getDateByLocale(date, this.$i18n.locale) : "";
	}

	onChangeCardType(type: number, event: Event): void {
	  if (type == 0) {
	    this.isDetails = true;
	    this.isDraw = false;
	  } else if (type == 1) {
	    this.isDraw = true;
	    this.isDetails = false;
	  }
	}

	mounted(): void {
	  // const _this = this;
	  console.log("tour was mounted");
	  const tournamentClient = new TournamentClient();
	  // natiahnut data z bekendu ...

	  if (this.tournamentProp == null) {
	    this.tournamentId = parseInt(this.$route.params.id, 10);
	    this.tryGetDataByArgs<TournamentDTO[], TournamentFilterDTO>({
	      apiMethod: tournamentClient.get,
	      showError: true,
	      requestArgs: {
	        id: this.tournamentId,
	        year: 0,
	        type: null
	      }
	    }).then((response) => {
	      if (response.ok) this.tournament = response.data[0];
	    });
	  } else {
	    console.log("yeah");
	    this.tournament = this.tournamentProp;
	  }
	}

	@Watch("$route")
	onUrlChange(to: string): void {
	  router.push(to);
	}
}
</script>
<style lang="scss" scoped>
.tournament-image {
	width: 100%;
	height: 400px;
	background-image: url("http://images.sportspromedia.com/images/made/images/uploads/news/tennis_grass_court_generic_630_354_80_s_c1.jpg");
	background-size: cover;
	border: 1px solid black;
}
.tournament-details {
	display: flex;
	flex-direction: column;
}
.tournament-header {
}
.tournament-options {
	align-self: flex-end;
	width: 100%;
}
@media (min-width: 992px) {
	.no-padding-left {
		padding-left: 0px;
	}
	.no-padding-right {
		padding-right: 0px;
	}
}
</style>
